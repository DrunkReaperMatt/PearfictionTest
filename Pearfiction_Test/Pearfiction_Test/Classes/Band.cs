namespace Pearfiction_Test.Classes;

public class Band(params ISymbol[] symbols) : IBands
{
    public List<ISymbol> Symbols { get; set; } = new (symbols);
    public List<ISymbol> Results { get; set; } = [];

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