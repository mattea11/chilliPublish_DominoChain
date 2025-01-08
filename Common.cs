
namespace DominoChain {
    public class Common
    {
        public static bool DFS((int, int) current, int totalDominoes, Dictionary<int, List<(int, int)>> graph,
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