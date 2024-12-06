using System.Diagnostics;
using System.Text;
using HelperLibrary;

namespace Day_06;

public class Part_01 : IDay
{
    public int Solve(string[] pInput)
    {
        var map = new Map(pInput);

        if (map.guard is null)
        {
            throw new ArgumentException("No guard found in the map");
        }

        while (map.guard.Move(map))
        {
            Debug.WriteLine(map.ToString());
        }

        return map.GetVisitedCount();
    }
}

public class Guard
{
    public Position startingPosition;
    public Direction startingDirection;
    public Position position;
    public Direction facingDirection;

    public Guard(Position pPos, Direction pFacingDirection)
    {
        position = pPos;
        startingPosition = new Position(pPos.x, pPos.y);
        startingDirection = pFacingDirection;
        facingDirection = pFacingDirection;
    }

    public bool Move(Map pMap)
    {
        var coords = position.Move(facingDirection);

        if (!IsInBounds(pMap, coords.Item1, coords.Item2))
        {
            return false;
        }

        var newPosition = pMap.map[coords.Item1, coords.Item2];

        if (!HasObstacle(pMap, newPosition))
        {
            newPosition.isVisited = true;
            position = newPosition;
        }
        else
        {
            facingDirection = facingDirection.TurnRight();
        }
        return true;
    }

    private static bool IsInBounds(Map pMap, int pX, int pY)
    {
        return pX >= 0 && pX < pMap.map.GetLength(0) && pY >= 0 && pY < pMap.map.GetLength(1);
    }

    private static bool HasObstacle(Map pMap, Position pPos)
    {
        return pMap.map[pPos.x, pPos.y].type == '#' || pMap.map[pPos.x, pPos.y].type == 'O';
    }
}

public class Position(int pX, int pY) : IEquatable<Position>
{
    public int x = pX, y = pY;
    public bool isVisited;
    public char type = '.';

    public bool Equals(Position? other)
    {
        return x == other?.x && y == other?.y;
    }

    public (int, int) Move(Direction pDirection)
    {
        var newPosition = pDirection switch
        {
            Direction.North => (x - 1, y),
            Direction.East => (x, y + 1),
            Direction.South => (x + 1, y),
            Direction.West => (x, y - 1),
            _ => throw new ArgumentException("Invalid direction"),
        };

        return newPosition;
    }

    public override string ToString()
    {
        return isVisited ? "X" : type.ToString();
    }
}

    public class Map
    {
        static readonly char[] mGuardCharacters = ['<', '>', '^', 'v'];

        /// <summary>
        /// The guard that moves around the map.
        /// </summary>
        public Guard? guard;

        /// <summary>
        /// Contains the map of the area.
        /// </summary>
        public Position[,] map;

        public Map(string[] pInput)
        {
            map = ParseMap(pInput);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    sb.Append(map[i, j]);
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

        public int GetVisitedCount()
        {
            int count = 0;
            foreach (var pos in map)
            {
                if (pos.isVisited)
                {
                    count++;
                }
            }
            return count;
        }

        private Position[,] ParseMap(string[] pInput)
        {
            var map = new Position[pInput.Length, pInput[0].Length];

            for (int i = 0; i < pInput.Length; i++)
            {
                for (int j = 0; j < pInput[i].Length; j++)
                {
                    var pos = new Position(i, j);
                    if (mGuardCharacters.Contains(pInput[i][j]))
                    {
                        guard = new Guard(pos, DirectionExtensions.FromChar(pInput[i][j]));
                        pos.isVisited = true;
                    }
                    pos.type = pInput[i][j];
                    map[i, j] = pos;
                }
            }
            return map;
        }
    }