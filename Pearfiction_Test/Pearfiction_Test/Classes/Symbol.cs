namespace Pearfiction_Test.Classes;

public class Symbol: ISymbol
{
    public string Name { get; set; }
    public IPayTable PayTable { get; set; } 

    public Symbol(string name, IPayTable payTable)
    {
        Name = name;
        PayTable = payTable;
    }
}