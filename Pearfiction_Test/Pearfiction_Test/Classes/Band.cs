namespace Pearfiction_Test.Classes;

public class Band : IBands
{
    public List<ISymbol> Symbols { get; set; } = [];
    
    public Dictionary<int, ISymbol> Results { get; set; } = new();

    public Band(params ISymbol[] symbols)
    {
        Symbols?.AddRange(symbols);
    }
    
    public ISymbol GetSymbolByIndex(int index)
    {
        return Symbols[GetWrappedIndex(index)];
    }

    public void AddResults(int[] indexes, ISymbol[] symbols)
    {
        for (int i = 0; i < indexes.Length; i++)
        {
            int index = indexes[i] % Symbols.Count;
            Results.Add(index, symbols[i]);
        }
    }
    
    private int GetWrappedIndex(int index)
    {
        return ((index % Symbols.Count) + Symbols.Count) % Symbols.Count;
    }
}