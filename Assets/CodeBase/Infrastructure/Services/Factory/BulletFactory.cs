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
            if (_pool.TryGetObject(out GameObject bulletObject))
            {
                Bullet.Bullet bullet = bulletObject.GetComponent<Bullet.Bullet>();
                bullet.Construct(parent);
                bullet.LifeTime = _bulletData.LifeTime;

                BulletAttack bulletAttack = bulletObject.GetComponent<BulletAttack>();
                bulletAttack.Damage = _bulletData.Damage;
                bulletAttack.Construct(parent);

                bulletObject.GetComponent<BulletMover>().Speed = _bulletData.Speed;

                bulletObject.transform.parent.position = parent.position;
                bulletObject.transform.parent = null;
                bulletObject.transform.rotation = Quaternion.Euler(Vector3.zero);
                return bulletObject;
            }

            return Object.Instantiate(_bulletData.Prefab, parent.position, Quaternion.identity);
        }

        public void Clear() => _pool.Clear();
    }
}