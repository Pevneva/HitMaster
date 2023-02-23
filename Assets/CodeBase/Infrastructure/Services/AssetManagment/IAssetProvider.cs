using UnityEngine;

namespace CodeBase.Infrastructure.Services.AssetManagment
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Transform parent);
        GameObject Instantiate(string path, Vector3 at, Transform parent);
    }
}