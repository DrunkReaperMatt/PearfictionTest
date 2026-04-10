namespace Pearfiction_Test;

public interface IReelset
{
    List<IBands> Bands { get; set; }
    
    List<int> Indexes { get; set; }

    void ShuffleBands();

    void CalculateResults();

    void ResetReel();

    void DisplayScreen();

    void PrintWinnings();
    
}