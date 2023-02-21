using UnityEngine;

namespace CodeBase.Infrastructure.Services.AssetManagment
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject Instantiate(string path, Vector3 at);
        GameObject Instantiate(string path, Transform parent);
    }
}