namespace Pearfiction_Test.Classes;

public class PayTable : IPayTable
{
    public int ThreeKind { get; set; }
    public int FourKind { get; set; }
    public int FiveKind { get; set; }

    public PayTable(int threeKind, int fourKind, int fiveKind)
    {
        ThreeKind = threeKind;
        FourKind = fourKind;
        FiveKind = fiveKind;
    }
}