namespace Pearfiction_Test.Classes;

public class Symbol(string name, IPayTable payTable) : ISymbol
{
    public string Name { get; set; } = name;
    public IPayTable PayTable { get; set; } = payTable;
    
    public int CheckMatches(ISymbol nextSymbol)
    {
        return nextSymbol.Name == Name ? 1 : 0;
    }

    /*
    public int CheckMatches()
    {
        if (Neighbours.Count < 1)
        {
            return 0;
        }
        
        int wins = 0;
        if (name == Neighbours[0].Name)
        {
            wins += Neighbours[0].CheckMatches();
        }

        if (name == Neighbours[1].Name)
        {
            wins +=  Neighbours[1].CheckMatches();
        }

        if (name == Neighbours[2].Name)
        {
            wins += Neighbours[2].CheckMatches();
        }

        return wins;
    }
    */
}