using UnityEngine;

namespace CodeBase.Infrastructure.Services.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) => 
            Object.Instantiate( GetPrefab(path));

        public GameObject Instantiate(string path, Vector3 at) => 
            Object.Instantiate(GetPrefab(path), at, Quaternion.identity);
        
        public GameObject Instantiate(string path, Transform parent) => 
            Object.Instantiate(GetPrefab(path), parent);

        private GameObject GetPrefab(string path) => 
            Resources.Load<GameObject>(path);
    }
}