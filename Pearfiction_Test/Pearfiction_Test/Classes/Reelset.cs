namespace Pearfiction_Test.Classes;

public class Reelset : IReelset
{
    public List<IBands> Bands { get; set; }

    private List<ISymbol> _output = [];
    
    public Reelset(params IBands[] bands)
    {
        Bands?.AddRange(bands);
    }
    
    public void ShuffleBands()
    {
        var rand = new Random();

        List<int> indexes = [];
        foreach (var band in Bands)
        {
            int index = rand.Next(band.Symbols.Count);
            indexes.Add(index);
        }
        
        DisplayResults(indexes.ToArray());
        
        CalculateReel(indexes);
        ClearScreen();
    }

    private void DisplayResults(int[] indexes)
    {
        List<ISymbol> centers = [];
        List<ISymbol> uppers = [];
        List<ISymbol> lowers = [];
        
        for (int i = 0; i < indexes.Length; i++)
        {
            var one = Bands[i].GetSymbolByIndex(indexes[i]);
            var two = Bands[i].GetSymbolByIndex(indexes[i ]+ 1);
            var three = Bands[i].GetSymbolByIndex(indexes[i] + 2);

            uppers.Add(one);
            centers.Add(two);
            lowers.Add(three);
            
            Bands[i].AddResults(one, two, three);
        }
        
        _output.Clear();
        _output.AddRange(uppers);
        _output.AddRange(centers);
        _output.AddRange(lowers);

        Console.WriteLine($"Stop Positions: {string.Join(", ", indexes)}");
        
        Console.WriteLine(string.Join(" || ", uppers.Select(x => x.Name)));
        Console.WriteLine(string.Join(" || ", centers.Select(x => x.Name)));
        Console.WriteLine(string.Join(" || ", lowers.Select(x => x.Name)));
    }

    private void CalculateReel(List<int> indexes)
    {
        for (int i = 0; i < _output.Count; i = i + 5)
        {
            if (Bands[1].CompareBands(_output[i]) <= 0) continue;

            if (Bands[2].CompareBands(_output[i]) <= 0) continue;

            if (Bands[3].CompareBands(_output[i]) > 0)
            {
                Console.WriteLine(Bands[4].CompareBands(_output[i]) > 0 ? $"{_output[i].Name} | 5 Matches: {_output[i].PayTable.FiveKind}" : $"{_output[i].Name} | 4 Matches: {_output[i].PayTable.FourKind}");
            }
            else
            {
                Console.WriteLine($"{_output[i].Name} | 3 Matches: {_output[i].PayTable.ThreeKind}");
            }
        }
    }

    private void ClearScreen()
    {
        foreach (var band in Bands)
        {
            band.Results.Clear();
        }
    }
}