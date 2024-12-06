using System.Diagnostics;
using System.Text;
using HelperLibrary;

namespace Day_06;

public class Part_02 : IDay
{
    public int Solve(string[] pInput)
    {
        var map = new Map(pInput);

        if (map.guard is null)
        {
            throw new ArgumentException("No guard found in the map");
        }

        var cycles = 0;
        for (int i = 0; i < map.map.Length; i++)
        {
            var firstRun = true;
            var steps = 0;
            map.CreateMapVariation(i);
            while (map.guard.Move(map))
            {
                if (!firstRun
                    && map.guard.startingDirection == map.guard.facingDirection 
                    && map.guard.startingPosition.Equals(map.guard.position)
                    || steps > map.map.Length)
                {
                    Debug.WriteLine($"Found a cycle at {i}");
                    cycles++;
                    break;
                }
                firstRun = false;
                steps++;
                Debug.WriteLine(map.ToString());
            }
            map.ResetMap();
        }

        return cycles;
    }
}

public static class MapExtension
{
    public static bool CreateMapVariation(this Map map, int pIndex)
    {
        if (pIndex > map.map.Length)
        {
            return false;
        }

        // Modify the postion at the given index
        int y = pIndex % map.map.GetLength(0);
        int x =  pIndex / map.map.GetLength(0);

        if (map.map[x, y].type == '.') {
            map.map[x, y].type = 'O';
            Debug.WriteLine($"Modified map at {x},{y}");
        }
                
        return true;
    }

    public static void ResetMap(this Map map)
    {
        if (map.guard is null)
        {
            throw new ArgumentException("No guard found in the map");
        }

        map.guard.position = new Position(map.guard.startingPosition.x, map.guard.startingPosition.y);
        map.guard.facingDirection = map.guard.startingDirection;

        foreach (var cell in map.map)
        {
            cell.isVisited = false;
            if (cell.type == 'O')
            {
                cell.type = '.';
            }
        }
    }
}
