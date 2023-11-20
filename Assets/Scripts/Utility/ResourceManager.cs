using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public sealed class ResourceManager : MonoBehaviour
{
    Dictionary<string, AsyncOperationHandle<GameObject>> prefabs = new Dictionary<string, AsyncOperationHandle<GameObject>>();

    void OnDestroy()
    {
        foreach (var (name, prefab) in prefabs)
            Addressables.Release(prefab);
    }

    public async UniTask<GameObject> GetPrefab(string name)
    {
        if (prefabs.ContainsKey(name))
            return prefabs[name].Result;

        var prefab = Addressables.LoadAssetAsync<GameObject>(name);
        await prefab.Task;

        if (prefabs.ContainsKey(name))
        {
            Addressables.Release(prefab);
            return prefabs[name].Result;
        }

        prefabs.Add(name, prefab);
        return prefab.Result;
    }
}
