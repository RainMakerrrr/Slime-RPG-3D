using UnityEngine;

namespace Infrastructure.Services.Assets
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : Object;
        T[] LoadAll<T>(string path) where T : Object;
    }
}