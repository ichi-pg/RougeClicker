using TMPro;
using UnityEngine;

public sealed class ItemView : MonoBehaviour
{
    Item item;
    [SerializeField] TextMeshPro atk;
    [SerializeField] TextMeshPro critRate;
    [SerializeField] TextMeshPro critDMG;
    [SerializeField] TextMeshPro baseDMG;

    public void Initialize(Item item)
    {
        this.item = item;
    }

    void Start()
    {
        atk.SetText("{0}", item.ATK);
        critRate.SetText("{0}", item.CritRate);
        critDMG.SetText("{0}", item.CritDMG);
        baseDMG.SetText("{0}", item.BaseDMG);
    }
}
