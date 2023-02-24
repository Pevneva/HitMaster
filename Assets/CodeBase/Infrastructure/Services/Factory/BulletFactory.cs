using CodeBase.Bullet;
using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Factory.CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private const int Capacity = 30;
        
        private readonly ObjectPool _pool = new ObjectPool();
        private readonly IAssetProvider _assetProvider;
        private readonly IStaticDataService _staticData;

        public BulletFactory(IAssetProvider assetProvider, IStaticDataService staticData)
        {
            _assetProvider = assetProvider;
            _staticData = staticData;
        }

        public void InitializePool(Transform parent) => 
            _pool.Initialize(_assetProvider, AssetPath.BulletPath, parent, Capacity);
        
        public GameObject CreateBullet(Transform parent)
        {
            if (_pool.TryGetObject(out GameObject bullet))
            {
                bullet.GetComponent<Bullet.Bullet>().Construct(parent);
                
                BulletAttack bulletAttack = bullet.GetComponent<BulletAttack>();
                bulletAttack.Damage = _staticData.BulletStaticData().Damage;
                bulletAttack.Construct(parent);

                bullet.GetComponent<BulletMover>().Speed = _staticData.BulletStaticData().Speed;
                
                bullet.transform.parent.position = parent.position;
                bullet.transform.parent = null;
                bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
                return bullet;
            }

            return _assetProvider.Instantiate(AssetPath.BulletPath, parent.position);
        }
        
        public void Clear() => _pool.Clear();
    }
}