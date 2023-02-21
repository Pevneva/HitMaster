using CodeBase.Infrastructure.Services.AssetManagment;
using CodeBase.Infrastructure.Services.Factory.CodeBase.Infrastructure.Services.Factory;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Factory
{
    public class BulletFactory : IBulletFactory
    {
        private const int Capacity = 30;
        
        private readonly ObjectPool _pool = new ObjectPool();
        private readonly IAssetProvider _assetProvider;

        public BulletFactory(IAssetProvider assetProvider) => 
            _assetProvider = assetProvider;

        public void InitializePool(Transform parent) => 
            _pool.Initialize(_assetProvider, AssetsPath.BulletPath, parent, Capacity);
        
        public GameObject CreateArrow(Transform parent)
        {
            if (_pool.TryGetObject(out GameObject arrow))
            {
                arrow.transform.parent.position = parent.position;
                return arrow;
            }

            return _assetProvider.Instantiate(AssetsPath.BulletPath, parent.position);
        }
    }
}