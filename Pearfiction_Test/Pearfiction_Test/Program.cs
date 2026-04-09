// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using Pearfiction_Test;
using Pearfiction_Test.Classes;

Symbol sym1 = new("sym1", new PayTable(1, 2, 3));
Symbol sym2 = new("sym2", new PayTable(1, 2, 3));
Symbol sym3 = new("sym3", new PayTable(1, 2, 5));
Symbol sym4 = new("sym4", new PayTable(2, 5, 10));
Symbol sym5 = new("sym5", new PayTable(5, 10, 15));
Symbol sym6 = new("sym6", new PayTable(5, 10, 15));
Symbol sym7 = new("sym7", new PayTable(5, 10, 20));
Symbol sym8 = new("sym8", new PayTable(10, 20, 50));

Band band1 = new(sym2, sym7, sym7, sym1, sym1, sym5, sym1, sym4, sym5, sym3, sym2, sym3, sym8, sym4, sym5, sym2, sym8, sym5, sym7, sym2);
Band band2 = new(sym1, sym6, sym7, sym6, sym5, sym5, sym8, sym5, sym5, sym4, sym7, sym2, sym5, sym7, sym1, sym5, sym6,
    sym8, sym7, sym6, sym3, sym3, sym6, sym7, sym3);
Band band3 = new(sym5, sym2, sym7, sym8, sym3, sym2, sym6, sym2, sym2, sym5, sym3, sym5, sym1, sym6, sym3, sym2, sym4,
    sym1, sym6, sym8, sym6, sym3, sym4, sym4, sym8, sym1, sym7, sym6, sym1, sym6);
Band band4 = new(sym2, sym6, sym3, sym6, sym8, sym8, sym3, sym6, sym8, sym1, sym5, sym1, sym6, sym3, sym6, sym7, sym2,
    sym5, sym3, sym6, sym8, sym4, sym1, sym5, sym7);
Band band5 = new(sym7, sym8, sym2, sym3, sym4, sym1, sym3, sym2, sym2, sym4, sym4, sym2, sym6, sym4, sym1, sym6,
    sym1, sym6, sym4, sym8);

Reelset reelset = new(band1, band2, band3, band4, band5);

while (true)
{
    reelset.RollReels();

    Console.WriteLine("Press 1 to exit");
    var exit = Console.ReadLine();

    if (exit != null && int.TryParse(exit, out int output) && output  == 1)
    {
        break;
    }
}

