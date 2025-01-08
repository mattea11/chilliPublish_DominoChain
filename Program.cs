using System;
using System.Collections.Generic;
using System.Linq;
using DominoChain;

class DominoChainMain
{
    public static void Main(string[] args)
    {
        
        var dominoChainFinderWithFlipping = new CircularChainWithFlip();
        var dominoChainFinderNoFlipping = new CircularChainNoFlip();

        var tests = new List<List<(int, int)>>()
        {
            CreateDominoesList(new Random(), 6, 3),
            CreateDominoesList(new Random(), 6, 4),
            //since the above test cases are bieng randomly generated, its is unlikely 
            //that a test case will be generated that would be able to create a domnino 
            // circular chain ehnce I will hard code a few test cases
            new List<(int, int)> { (5, 6), (6, 1), (1, 5) },
            new List<(int, int)> { (1, 2), (3, 4), (5, 6) },
            new List<(int, int)> { (2, 4), (4, 5), (5, 6) },
            new List<(int, int)> { (2, 1), (2, 3), (1, 3) },
            new List<(int, int)> { (3, 4), (1, 3), (4, 1) }
        };

        string chainWithFlip = "Domino Chain with flip";
        string chainNoFlip = "Domino Chain with no flip";

        foreach (var test in tests)
            RunTest(test, dominoChainFinderWithFlipping, dominoChainFinderNoFlipping, chainWithFlip, chainNoFlip);

    }
    
    private static List<(int, int)> CreateDominoesList(Random random, int maxSide, int count)
    {
        List<(int, int)> dominoes = new List<(int, int)>();

        for (int i = 0; i < count; i++)
        {
            int side1 = random.Next(1, maxSide + 1);
            int side2 = random.Next(1, maxSide + 1);
            dominoes.Add((side1, side2));
        }
        return dominoes;
    }

    private static void RunTest(List<(int, int)> test, CircularChainWithFlip chainWithFlipFinder,
                    CircularChainNoFlip chainNoFlipFinder, string chainWithFlip, string chainNoFlip)
    {
        printDominoesList(test);
        checkPrintChainResult(chainWithFlipFinder.FindCircularChainByFlipping(test), chainWithFlip);
        checkPrintChainResult(chainNoFlipFinder.FindCircularChainNoFlipping(test), chainNoFlip);
    }

    private static void printDominoesList(List<(int, int)> dominoes)
    {
        Console.Write("\n\nGenerated domino lists:\t");
        
        foreach (var domino in dominoes)
            Console.Write($"[{domino.Item1}|{domino.Item2}] ");
    }

    private static void checkPrintChainResult(List<(int, int)>? result, string chainType)
    {
        if (result == null)
            Console.Write("\nNo valid circular chain exists.");
        else
        {
            Console.Write($"\n{chainType}: ");
            foreach (var domino in result)
                Console.Write($"[{domino.Item1}|{domino.Item2}]");
        }
    }
}    