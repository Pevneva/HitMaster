using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public interface IBulletFactory
    {
        void InitializePool(Transform parent);
        GameObject CreateArrow(Transform parent);
    }
}