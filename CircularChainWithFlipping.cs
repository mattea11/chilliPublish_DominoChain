using System;
using System.Collections.Generic;
using System.Linq;
using DominoChain;

namespace DominoChain {
    public class CircularChainWithFlip
    {
        public List<(int, int)>? FindCircularChainByFlipping(List<(int, int)> dominoes)
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

                if (!graph.ContainsKey(b))
                    graph[b] = new List<(int, int)>();

                //by assuming we can flip the domino we expand the possible edges 
                // in the graph hence in this case we must add 'both' edges  
                graph[a].Add((a, b));
                graph[b].Add((b, a));
            }

            return graph;
        }
    }
}