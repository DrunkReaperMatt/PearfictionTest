namespace Pearfiction_Test;

public interface IBands
{
    List<ISymbol>  Symbols { get; }
    
    Dictionary<int, ISymbol> Results { get; }

    ISymbol GetSymbolByIndex(int index);
    
    void AddResults(int[] indexes, ISymbol[] symbols);
}