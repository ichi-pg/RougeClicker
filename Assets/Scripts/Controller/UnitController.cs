using System.Collections.Generic;
using UniRx;
using UnityEngine;

public sealed class UnitController : MonoBehaviour
{
    [SerializeField] UnitView unitView;

    public Unit Unit { get; } = new Unit();
    public List<Item> Items { get; } = new List<Item>();

    void Awake()
    {
        unitView.Initialize(Unit);
    }

    async void Start()
    {
        var resourceManager = FindObjectOfType<ResourceManager>();
        var damagePrefab = await resourceManager.GetPrefab(AssetAddress.Damage);
        var deadPrefab = await resourceManager.GetPrefab(AssetAddress.Dead);

        Unit.OnDamaged.Subscribe(damage =>
            Instantiate(damagePrefab, transform.position, transform.rotation, transform.parent)
                .GetComponent<DamageView>().Initialize(damage)
        ).AddTo(this);

        Unit.OnDead.Subscribe(_ =>
            Instantiate(deadPrefab, transform.position, transform.rotation, transform.parent)
        ).AddTo(this);
    }
}
