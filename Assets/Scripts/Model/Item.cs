public sealed class Item
{
    public int ATK { get; private set; }
    public int CritRate { get; private set; }
    public int CritDMG { get; private set; }
    public int BaseDMG { get; private set; }

    public Item(int atk, int critRate, int critDMG, int baseDMB)
    {
        ATK = atk;
        CritRate = critRate;
        CritDMG = critDMG;
        BaseDMG = baseDMB;
    }
}
