using CodeBase.Bullet;
using CodeBase.Infrastructure.Services.Factory.CodeBase.Infrastructure.Services.Factory;
using CodeBase.Infrastructure.Services.StaticData;
using CodeBase.StaticData;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private const int Capacity = 30;

        private readonly ObjectPool _pool = new ObjectPool();
        private readonly BulletStaticData _bulletData;

        public BulletFactory(IStaticDataService staticData) =>
            _bulletData = staticData.BulletStaticData();

        public void InitializePool(Transform parent) =>
            _pool.Initialize(_bulletData.Prefab, parent, Capacity);

        public GameObject CreateBullet(Transform parent)
        {
            if (_pool.TryGetObject(out GameObject bullet))
            {
                bullet.GetComponent<Bullet.Bullet>().Construct(parent);

                BulletAttack bulletAttack = bullet.GetComponent<BulletAttack>();
                bulletAttack.Damage = _bulletData.Damage;
                bulletAttack.Construct(parent);

                bullet.GetComponent<BulletMover>().Speed = _bulletData.Speed;

                bullet.transform.parent.position = parent.position;
                bullet.transform.parent = null;
                bullet.transform.rotation = Quaternion.Euler(Vector3.zero);
                return bullet;
            }

            return Object.Instantiate(_bulletData.Prefab, parent.position, Quaternion.identity);
        }

        public void Clear() => _pool.Clear();
    }
}