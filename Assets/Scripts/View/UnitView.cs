using TMPro;
using UnityEngine;
using UniRx;

public sealed class UnitView : MonoBehaviour
{
    [SerializeField] TextMeshPro hpText;

    Unit unit;

    public void Initialize(Unit unit)
    {
        this.unit = unit;
    }

    void Start()
    {
        hpText.SetText("{0}", unit.HP);

        unit.OnDamaged.Subscribe(_ =>
            hpText.SetText("{0}", unit.HP)
        ).AddTo(this);

        unit.OnDead.Subscribe(_ =>
            Destroy(gameObject)
        ).AddTo(this);
    }
}
