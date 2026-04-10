namespace Pearfiction_Test.Classes;

public class Reelset : IReelset
{
    public List<IBands> Bands { get; set; } = [];

    private List<ISymbol> _output = [];
    
    public Reelset(params IBands[] bands)
    {
        Bands.AddRange(bands);
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

        indexes = [15, 7, 9, 10, 17];

        DisplayResults(indexes.ToArray());
        
        //CalculateReel(indexes);

        List<(ISymbol, string)> results = calc();
        PrintResults(results);
        
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
            
            Bands[i].AddResults([indexes[i], indexes[i] + 1, indexes[i] + 2], [one, two, three]);
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
        int payout = 0;
        for (int i = 0; i < _output.Count; i = i + 5)
        {
            List<int> matchingSymbols = [];
            if (Bands[1].CompareBands(_output[i], out var band2) <= 0) continue;
            
            Console.WriteLine(band2[1]);

            if (Bands[2].CompareBands(_output[i], out var band3) <= 0) continue;

            if (Bands[3].CompareBands(_output[i], out var band4) <= 0)
            {
                 Console.WriteLine($"{_output[i].Name} | 3 Matches: {_output[i].PayTable.ThreeKind}");
            }
            
            if (Bands[4].CompareBands(_output[i], out var band5) <= 0)
            {
                Console.WriteLine($"{_output[i].Name} | 4 Matches: {_output[i].PayTable.FourKind}");
            }
            else
            {
                Console.WriteLine($"{_output[i].Name} | 5 Matches: {_output[i].PayTable.FiveKind}");
            }
        }
    }

    private List<(ISymbol, string)> calc()
    {
        List<(ISymbol, string)> matches = [];
        for (int i = 0; i < _output.Count; i = i + 5)
        {
            string line;
            for (int j = 1; j < _output.Count; j = j + 5)
            {
                if (_output[i] != _output[j])
                {
                    continue;
                }

                for (int k = 2; k < _output.Count; k = k + 5)
                {
                    if (_output[k] != _output[i])
                    {
                        continue;
                    }

                    line = $"{i}-{j}-{k}";
                    for (int l = 3; l < _output.Count; l = l + 5)
                    {
                        if (_output[l] != _output[i])
                        {
                            continue;
                        }
                        
                        line += $"-{l}";
                        for (int m = 4; m < _output.Count; m = m + 5)
                        {
                            if (_output[m] != _output[i])
                            {
                                continue;
                            }

                            line += $"-{m}";
                        }
                    }
                    
                    matches.Add((_output[i], line));
                }
            }
        }
        
        return matches;
    }

    void PrintResults(List<(ISymbol, string)> winnings)
    {
        int totalWinnings = 0;
        List<string> winningLineMessages = [];
        
        foreach (var winner in winnings)
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

    private void ClearScreen()
    {
        foreach (var band in Bands)
        {
            band.Results.Clear();
        }
    }
}