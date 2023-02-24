using CodeBase.Infrastructure.Services.AssetManagment;

namespace CodeBase.Infrastructure.Services.Factory
{
    using System.Collections.Generic;
    using System.Linq;
    using UnityEngine;

    namespace CodeBase.Infrastructure.Services.Factory
    {
        public class ObjectPool
        {
            private readonly List<GameObject> _pool = new List<GameObject>();
        
            private Transform _parent;

            public void Initialize(IAssetProvider assetProvider, string prefab, Transform container, int capacity)
            {
                _parent = container;
                for (int i = 0; i < capacity; i++)
                {
                    GameObject poolObject = assetProvider.Instantiate(path: prefab, parent: container);
                    poolObject.SetActive(value: false);

                    _pool.Add(item: poolObject);
                }
            }

            public bool TryGetObject(out GameObject result)
            {
                result = _pool.FirstOrDefault(predicate: t => t.activeSelf == false);
            
                if (result != null) 
                    result.transform.position = _parent.position;
            
                return result != null;
            }

            public void Clear() => _pool.Clear();
        }
    }
}