using System;
using System.Collections.Generic;
using System.Linq;

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
                if (DFS(start, dominoes.Count, graph, chain, visited))
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

        private bool DFS((int, int) current, int totalDominoes, Dictionary<int, List<(int, int)>> graph,
                                List<(int, int)> chain, HashSet<(int, int)> visited)
        {
            chain.Add(current);
            visited.Add(current);

            if (chain.Count == totalDominoes && current.Item2 == chain[0].Item1)
                return true;

            // check for paths in the other half of the domino
            if (graph.ContainsKey(current.Item2))
            {
                foreach (var neighbor in graph[current.Item2])
                {
                    if (!visited.Contains(neighbor))
                    {
                        if (DFS(neighbor, totalDominoes, graph, chain, visited))
                            return true;
                    }
                }
            }

            //back track in case the path fails and mark the node as not visited
            chain.RemoveAt(chain.Count - 1);
            visited.Remove(current);
            return false;
        }
    }
}