using UnityEngine;

public sealed class PlayerController : MonoBehaviour
{
    [SerializeField] UnitController unitController;
    public UnitController UnitController { get => unitController; }

    void Awake()
    {
        unitController.Unit.Initialize(2000, 0);
        unitController.Items.Add(new Item(88, 50, 212, 151));
    }
}
