namespace Pearfiction_Test.Classes;

public class PayTable : IPayTable
{
    public int ThreeKind { get; set; }
    public int FourKind { get; set; }
    public int FiveKind { get; set; }

    public PayTable(int ThreeKind, int FourKind, int FiveKind)
    {
        this.ThreeKind = ThreeKind;
        this.FourKind = FourKind;
        this.FiveKind = FiveKind;
    }
}