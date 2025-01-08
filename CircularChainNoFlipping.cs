using System;
using System.Collections.Generic;
using System.Linq;
using DominoChain;

namespace DominoChain {
    public class CircularChainNoFlip
    {
        public List<(int, int)>? FindCircularChainNoFlipping(List<(int, int)> dominoes)
        {
            var graph = CreateGraph(dominoes);
            List<(int, int)> chain = new List<(int, int)>();

            foreach (var start in dominoes)
            {
                HashSet<(int, int)> visited = new HashSet<(int, int)>();
                if (Common.DFS(start, dominoes.Count, graph, chain, visited))
                    return chain;
            }

            return null;
        }

        private Dictionary<int, List<(int, int)>> CreateGraph(List<(int, int)> dominoes)
        {
            Dictionary<int, List<(int, int)>> graph = new Dictionary<int, List<(int, int)>>();

            foreach (var (a, b) in dominoes)
            {
                if (!graph.ContainsKey(a))
                    graph[a] = new List<(int, int)>();

                //unlike the case where flipping is allowed a case suhc as (a,b) and (b,a)
                //would be 2 different edges hence we only use a domino as it is presented 
                graph[a].Add((a, b));
            }

            return graph;
        }
    }
}