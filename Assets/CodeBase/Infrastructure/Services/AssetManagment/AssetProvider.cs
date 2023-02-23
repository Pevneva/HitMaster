using UnityEngine;

namespace CodeBase.Infrastructure.Services.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path) => 
            Object.Instantiate( original: GetPrefab(path: path));

        public GameObject Instantiate(string path, Vector3 at) => 
            Object.Instantiate(original: GetPrefab(path: path), position: at, rotation: Quaternion.identity);
        public GameObject Instantiate(string path, Vector3 at, Transform parent) => 
            Object.Instantiate(original: GetPrefab(path: path), position: at, rotation: Quaternion.identity, parent);
        
        public GameObject Instantiate(string path, Transform parent) => 
            Object.Instantiate(original: GetPrefab(path: path), parent: parent);

        private GameObject GetPrefab(string path) => 
            Resources.Load<GameObject>(path: path);
    }
}