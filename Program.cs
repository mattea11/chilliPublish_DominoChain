using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

class DominoChain
{
    public static void Main(string[] args)
    {
        var test1 = CreateDominoesList(new Random(), 6, 3);
        var test2 = CreateDominoesList(new Random(), 6, 4);
        
        Console.WriteLine("Generated dominoes:");
        foreach (var domino in test1)
        {
            Console.Write($"[{domino.Item1}|{domino.Item2}] ");
        }
        Console.WriteLine();

        foreach (var domino in test2)
        {
            Console.Write($"[{domino.Item1}|{domino.Item2}] ");
        }
        Console.WriteLine();

        //since the above test cases are bieng randomly generated, its is unlikely 
        //that a test case will be generated that would be able to create a domnino 
        // circular chain ehnce I will hard code a few test cases

        var test3 = new List<(int, int)> { (5, 6), (6, 1), (1, 5) };
        var test4 = new List<(int, int)> { (1, 2), (3, 4), (5, 6) };
        var test5 = new List<(int, int)> { (2, 4), (4, 5), (5, 6), };
        var test6 = new List<(int, int)> { (2, 1), (2, 3), (1, 3) }; 
        var test7 = new List<(int, int)> { (3, 4), (1, 3), (4, 1) };
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
}
