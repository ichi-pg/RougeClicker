using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class EnemyController : MonoBehaviour
{
    [SerializeField] UnitController unitController;

    Unit unit;
    List<Item> items;

    void Awake()
    {
        unit = unitController.Unit;
        items = unitController.Items;

        unit.Initialize(200, 0);
        items.Add(new Item(88, 50, 212, 151));
    }

    void Start()
    {
        var playerController = FindObjectOfType<PlayerController>();
        if (playerController == null)
            return;

        var playerUnitController = playerController.UnitController;
        var playerUnit = playerUnitController.Unit;
        var playerItems = playerUnitController.Items;

        var input = FindObjectOfType<PlayerInput>();
        var confirm = input.actions["Confirm"];

        confirm.AsObservable().Subscribe(async _ =>
        {
            if (playerUnit.IsDead)
                return;
            if (unit.IsDead)
                return;

            new Bullet(playerItems).Hit(unit);

            if (playerUnit.IsDead)
                return;
            if (unit.IsDead)
                return;

            await UniTask.WaitForSeconds(0.2f);

            new Bullet(items).Hit(playerUnit);

        }).AddTo(this);
    }
}
