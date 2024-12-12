using HelperLibrary;

namespace Day_08;

public class Part_02 : IDay
{
    public long Solve(string[] pInput)
    {
        var map = new FixedMap(pInput);
        map.FindAntiNodes();
        Console.WriteLine(map);
        return map.CountAntinodes();
    }
}

class FixedMap(string[] pInput) : Map(pInput)
{
    public override void FindAntiNodes() {
        var nodeTuples = from n in nodes
                from n2 in nodes
                where n.frequency == n2.frequency
                && !n.Equals(n2)
                select (n, n2);

        // Filter out reversed tuples
        var filteredTuples = nodeTuples.Where(tuple => nodes.IndexOf(tuple.n) < nodes.IndexOf(tuple.n2));

        // Get all postions of nodes that lie on a straight line
        foreach (var (n1, n2) in nodeTuples) {
            var gradient = n1.GetGradient(n2);

            var antiNodesOnLine = from n in antiNodes
                            where (n.GetGradient(n1) == gradient
                            && n.GetGradient(n2) == gradient)
                            || n.Equals(n1) 
                            || n.Equals(n2)
                            select n;

            foreach (var node in antiNodesOnLine) {
                node.hasAntennas = true;
            }
        }
    }
}