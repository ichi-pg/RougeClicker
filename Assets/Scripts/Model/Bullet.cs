using System.Collections.Generic;
using UniRx;

public sealed class Bullet
{
    public int ATK { get; private set; }
    public int CritRate { get; private set; }
    public int CritDMG { get; private set; }
    public int BaseDMG { get; private set; }

    Subject<int> onHit = new Subject<int>();
    public Subject<int> OnHit { get; } = new Subject<int>();

    public Bullet(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            ATK += item.ATK;
            CritRate += item.CritRate;
            CritDMG += item.CritDMG;
            BaseDMG += item.BaseDMG;
        }
    }

    public void Hit(Unit unit)
    {
        int damage = (ATK - unit.DEF) * BaseDMG;

        if (UnityEngine.Random.Range(0, 100) < CritRate)
            damage = damage * CritDMG / 10000;
        else
            damage /= 100;

        //TODO 元素反応
        //TODO 状態異常

        if (damage < 0)
            damage = 0;

        onHit.OnNext(damage);
        unit.Damaged(damage);
    }
}
