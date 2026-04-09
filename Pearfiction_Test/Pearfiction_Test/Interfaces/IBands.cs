namespace Pearfiction_Test;

public interface IBands
{
    List<ISymbol>  Symbols { get; set; }
    
    List<ISymbol> Results { get; set; }

    ISymbol GetSymbolByIndex(int index);
    
    int CompareBands(ISymbol result);
    
    void AddResults(params ISymbol[] symbols);
}