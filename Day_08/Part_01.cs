using System.Diagnostics.CodeAnalysis;
using System.Text;
using HelperLibrary;

namespace Day_08;

public class Part_01 : IDay
{
    public long Solve(string[] pInput)
    {
        var map = new Map(pInput);
        map.FindAntiNodes();
        Console.WriteLine(map);
        return map.CountAntinodes();
    }
}

struct Postion {
    public int x;
    public int y;

    public override readonly string ToString() {
        return $"({x}, {y})";
    }
}

class Node(char pFrequency, Postion pPosition)
{
    public char frequency = pFrequency;
    public Postion position = pPosition;
    public bool hasAntennas;

    public int DistanceTo(Node pOther) {
        return Math.Abs(position.x - pOther.position.x) + Math.Abs(position.y - pOther.position.y);
    }

    public override bool Equals(object? other)
    {
        if (other is Node node)
        {
            return frequency == node.frequency && position.Equals(node.position);
        } else {
            return false;
        }
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(frequency, position);
    }

    public double GetGradient(Node pOther) {
        if ((position.x - pOther.position.x) == 0)
            return 0;
        return Math.Abs(Convert.ToDouble(position.y - pOther.position.y) / Convert.ToDouble(position.x - pOther.position.x));
    }

    public override string ToString() {
        return $"N: {frequency} at {position}";
    }
}

class Map {
    protected readonly List<Node> antiNodes = [];
    protected readonly List<Node> nodes = [];
    protected (int, int) mapSize;

    public Map(string[] pInput) {
        mapSize = (pInput.Length, pInput[0].Length);
        for (int i = 0; i < pInput.Length; i++) {
            for (int j = 0; j < pInput[i].Length; j++) {
                if (pInput[i][j] == '.') {
                    antiNodes.Add(new Node(pInput[i][j], new Postion { x = i, y = j }));
                } else {
                    nodes.Add(new Node(pInput[i][j], new Postion { x = i, y = j }));
                    // Nodes can also be anti-nodes
                    antiNodes.Add(new Node(pInput[i][j], new Postion { x = i, y = j }));
                }
            }
        }
    }

    public int CountAntinodes() {
        return antiNodes.Where(n => n.hasAntennas).Count();
    }

    public virtual void FindAntiNodes() {
        var nodeTuples = from n in nodes
                from n2 in nodes
                where n.frequency == n2.frequency
                && !n.Equals(n2)
                select (n, n2);

        // Console.WriteLine("Original Tuples (including reversed):");
        // foreach (var (n, n2) in nodeTuples)
        // {
        //     Console.WriteLine($"({n.position}, {n2.position})");
        // }

        // Filter out reversed tuples
        var filteredTuples = nodeTuples.Where(tuple => nodes.IndexOf(tuple.n) < nodes.IndexOf(tuple.n2));


        // Console.WriteLine("\nFiltered Tuples (no reversed):");
        // foreach (var (n, n2) in filteredTuples)
        // {
        //     Console.WriteLine($"({n.position}, {n2.position})");
        // }

        // Get all postions of nodes that lie on a straight line
        foreach (var (n1, n2) in nodeTuples) {
            var gradient = n1.GetGradient(n2);

            var antiNodesOnLine = from n in antiNodes
                            where n.GetGradient(n1) == gradient
                            && n.GetGradient(n2) == gradient
                            && n.DistanceTo(n1) == n.DistanceTo(n2) * 2
                            select n;

            foreach (var node in antiNodesOnLine) {
                node.hasAntennas = true;
            }
        }
    }

    public override string ToString()
    {
        // Create array of map
        var map = new char[mapSize.Item1, mapSize.Item2];

        foreach (var node in antiNodes.Where(n => n.hasAntennas)) {
            map[node.position.x, node.position.y] = '#';
        }

        foreach (var node in nodes) {
            map[node.position.x, node.position.y] = node.frequency;
        }

        // Convert array to string
        var sb = new StringBuilder();
        for (int i = 0; i < mapSize.Item1; i++) {
            for (int j = 0; j < mapSize.Item2; j++) {
                if (map[i, j] == default) {
                    sb.Append('.');
                }
                sb.Append(map[i, j]);
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}