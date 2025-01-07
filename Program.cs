using System;
using System.Collections.Generic;
using System.Linq;
using DominoChain;

class DominoChainMain
{
    public static void Main(string[] args)
    {
        
        var dominoChainFinderWithFlipping = new CircularChainWithFlip();

        var test1 = CreateDominoesList(new Random(), 6, 3);
        printDominoesList(test1);
        var test2 = CreateDominoesList(new Random(), 6, 4);
        printDominoesList(test2);

        //since the above test cases are bieng randomly generated, its is unlikely 
        //that a test case will be generated that would be able to create a domnino 
        // circular chain ehnce I will hard code a few test cases
        var test3 = new List<(int, int)> { (5, 6), (6, 1), (1, 5) };
        printDominoesList(test3);
        var test4 = new List<(int, int)> { (1, 2), (3, 4), (5, 6) };
        printDominoesList(test4);
        var test5 = new List<(int, int)> { (2, 4), (4, 5), (5, 6), };
        printDominoesList(test5);
        var test6 = new List<(int, int)> { (2, 1), (2, 3), (1, 3) };
        printDominoesList(test6);
        var test7 = new List<(int, int)> { (3, 4), (1, 3), (4, 1) };
        printDominoesList(test7);

        Console.WriteLine("");
        Console.WriteLine("----------------------");
        Console.WriteLine("");


        var result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test1);
        checkPrintChainResult(result);

        result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test2);
        checkPrintChainResult(result);

        result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test3);
        checkPrintChainResult(result);

                result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test4);
        checkPrintChainResult(result);

                result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test5);
        checkPrintChainResult(result);

                result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test6);
        checkPrintChainResult(result);

                result = dominoChainFinderWithFlipping.FindCircularChainByFlipping(test7);
        checkPrintChainResult(result);

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

    private static void printDominoesList(List<(int, int)> dominoes)
    {
        Console.WriteLine("Generated domino lists:");
        
        foreach (var domino in dominoes)
            Console.Write($"[{domino.Item1}|{domino.Item2}] ");
        
        Console.WriteLine("\n");
    }

    private static void checkPrintChainResult(List<(int, int)>? result)
    {
        if (result == null)
        {
            Console.WriteLine("No valid circular chain exists.");
        }
        else
        {
            Console.Write("Circular Chain: ");
            foreach (var domino in result)
            {
                Console.Write($"[{domino.Item1}|{domino.Item2}] ");
            }
            Console.WriteLine("\n");
        }
    }
}    