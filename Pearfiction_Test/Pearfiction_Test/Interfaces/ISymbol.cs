namespace Pearfiction_Test;

public interface ISymbol
{
    public string Name { get; set; }

    public IPayTable PayTable { get; set; }
    
    public int CheckMatches(ISymbol nextSymbol);
}