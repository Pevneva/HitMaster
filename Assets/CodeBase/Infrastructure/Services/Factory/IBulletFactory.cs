using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IBulletFactory : IService
    {
        void InitializePool(Transform parent);
        GameObject CreateBullet(Transform parent);
    }
}