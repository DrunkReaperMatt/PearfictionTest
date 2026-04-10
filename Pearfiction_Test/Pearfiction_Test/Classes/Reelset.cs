namespace Pearfiction_Test.Classes;

public class Reelset : IReelset
{
    public List<IBands> Bands { get; set; } = [];
    public List<int> Indexes { get; set; } = [];

    private readonly List<ISymbol> _screenDisplay;
    private List<(ISymbol, string)> _winnings;
    private List<ISymbol> _centerRow;
    private List<ISymbol> _upperRow;
    private List<ISymbol> _lowerRow;
    
    public Reelset(params IBands[] bands)
    {
        Bands.AddRange(bands);
        _screenDisplay = [];
    }

    public void ShuffleBands()
    {
        var rand = new Random();

        foreach (var band in Bands)
        {
            int index = rand.Next(band.Symbols.Count);
            Indexes.Add(index);
        }
    }

    public void CalculateResults()
    {
        _centerRow = [];
        _upperRow = [];
        _lowerRow = [];
        
        _screenDisplay.Clear();
        
        for (int i = 0; i < Indexes.Count; i++)
        {
            var one = Bands[i].GetSymbolByIndex(Indexes[i]);
            var two = Bands[i].GetSymbolByIndex(Indexes[i ]+ 1);
            var three = Bands[i].GetSymbolByIndex(Indexes[i] + 2);

            _upperRow.Add(one);
            _centerRow.Add(two);
            _lowerRow.Add(three);
            
            Bands[i].AddResults([Indexes[i], Indexes[i] + 1, Indexes[i] + 2], [one, two, three]);
        }
        
        _screenDisplay.AddRange(_upperRow);
        _screenDisplay.AddRange(_centerRow);
        _screenDisplay.AddRange(_lowerRow);

        _winnings = CalculateReel();
    }

    public void DisplayScreen()
    {
        Console.WriteLine($"Stop Positions: {string.Join(", ", Indexes)}");
        Console.WriteLine("Screen:");
        
        Console.WriteLine(string.Join(" ", _upperRow.Select(x => x.Name)));
        Console.WriteLine(string.Join(" ", _centerRow.Select(x => x.Name)));
        Console.WriteLine(string.Join(" ", _lowerRow.Select(x => x.Name)));
    }
    
    public void PrintWinnings()
    {
        int totalWinnings = 0;
        List<string> winningLineMessages = [];
        
        foreach (var winner in _winnings)
        {
            switch (winner.Item2.Split('-').Length)
            {
                case 3:
                    totalWinnings += winner.Item1.PayTable.ThreeKind;
                    winningLineMessages.Add($"- Ways win {winner.Item2}, {winner.Item1.Name} x3, {winner.Item1.PayTable.ThreeKind}");
                    break;
                case 4:
                    totalWinnings += winner.Item1.PayTable.FourKind;
                    winningLineMessages.Add($"- Ways win {winner.Item2}, {winner.Item1.Name} x4, {winner.Item1.PayTable.FourKind}");
                    break;
                case 5 :
                    totalWinnings += winner.Item1.PayTable.FiveKind;
                    winningLineMessages.Add($"- Ways win {winner.Item2}, {winner.Item1.Name} x5, {winner.Item1.PayTable.FiveKind}");
                    break;
            }
        }

        Console.WriteLine($"Total wins: {totalWinnings}");
        
        // LinQ method to print the entire array.
        winningLineMessages.ForEach(Console.WriteLine);
    }

    public void ResetReel()
    {
        foreach (var band in Bands)
        {
            band.Results.Clear();
        }
        
        Indexes.Clear();
    }
    
    private List<(ISymbol, string)> CalculateReel()
    {
        List<(ISymbol, string)> matches = [];
        for (int i = 0; i < _screenDisplay.Count; i = i + 5)
        {
            string line;
            for (int j = 1; j < _screenDisplay.Count; j = j + 5)
            {
                if (_screenDisplay[i] != _screenDisplay[j])
                {
                    continue;
                }

                for (int k = 2; k < _screenDisplay.Count; k = k + 5)
                {
                    if (_screenDisplay[k] != _screenDisplay[i])
                    {
                        continue;
                    }

                    line = $"{i}-{j}-{k}";
                    for (int l = 3; l < _screenDisplay.Count; l = l + 5)
                    {
                        if (_screenDisplay[l] != _screenDisplay[i])
                        {
                            continue;
                        }
                        
                        line += $"-{l}";
                        for (int m = 4; m < _screenDisplay.Count; m = m + 5)
                        {
                            if (_screenDisplay[m] != _screenDisplay[i])
                            {
                                continue;
                            }

                            line += $"-{m}";
                        }
                    }
                    
                    matches.Add((_screenDisplay[i], line));
                }
            }
        }
        
        return matches;
    }
}