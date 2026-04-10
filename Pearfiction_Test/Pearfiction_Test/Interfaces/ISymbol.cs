namespace Pearfiction_Test;

public interface ISymbol
{
    public string Name { get; }

    public IPayTable PayTable { get; }
}