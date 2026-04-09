namespace Pearfiction_Test.Classes;

public class Band : IBands
{
    public List<ISymbol> Symbols { get; set; }
    public List<ISymbol> Results { get; set; } = [];

    public Band(params ISymbol[] symbols)
    {
        Symbols?.AddRange(symbols);
    }
    
    public ISymbol GetSymbolByIndex(int index)
    {
        return Symbols[GetWrappedIndex(index)];
    }

    public int CompareBands(ISymbol result)
    {
        return Results.Count(currentSymbol => currentSymbol.Name == result.Name);
    }

    public void AddResults(params ISymbol[] symbols)
    {
        Results.AddRange(symbols);
    }
    
    private int GetWrappedIndex(int index)
    {
        return ((index % Symbols.Count) + Symbols.Count) % Symbols.Count;
    }
}