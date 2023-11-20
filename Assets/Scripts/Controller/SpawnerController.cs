using UniRx;
using UnityEngine;

public sealed class SpawnerController : MonoBehaviour
{
    GameObject prefab;

    async void Start()
    {
        var resourceManager = FindObjectOfType<ResourceManager>();
        prefab = await resourceManager.GetPrefab(AssetAddress.Enemy);
        Spawn();
    }

    void Spawn()
    {
        var enemy = Instantiate(prefab, transform);
        var unitController = enemy.GetComponent<UnitController>();

        unitController.Unit.OnDead.Subscribe(_ =>
        {
            if (Random.Range(0, 100) < 10)
                DropItems();
            Spawn();
        }).AddTo(this);
    }

    void DropItems()
    {
        //TODO アイテムドロップ
    }
}
