using System;
using UniRx;

public sealed class Unit
{
    public int MaxHP { get; private set; }
    public int HP { get; private set; }
    public int DEF { get; private set; }

    public bool IsAlive { get => HP > 0; }
    public bool IsDead { get => HP <= 0; }

    Subject<int> onDead = new Subject<int>();
    Subject<int> onDamaged = new Subject<int>();
    Subject<int> onHealed = new Subject<int>();

    public IObservable<int> OnDead { get => onDead; }
    public IObservable<int> OnDamaged { get => onDamaged; }
    public IObservable<int> OnHealed { get => onHealed; }

    public void Initialize(int hp, int def)
    {
        MaxHP = hp;
        HP = hp;
        DEF = def;
    }

    public void Damaged(int damage)
    {
        HP -= damage;
        if (HP < 0)
            HP = 0;

        onDamaged.OnNext(damage);

        if (IsAlive)
            return;

        onDead.OnNext(0);
    }

    public void Healed(int rate)
    {
        int heal = MaxHP * rate / 100;

        HP += heal;
        if (HP > MaxHP)
            HP = MaxHP;

        onHealed.OnNext(heal);
    }
}
