namespace HelperLibrary;

public enum Direction
{
    North,
    NorthEast,
    East,
    SouthEast,
    South,
    SouthWest,
    West,
    NorthWest,
}

public static class DirectionExtensions {
    public static Direction FromChar(char pChar) => pChar switch
    {
        '^' => Direction.North,
        '>' => Direction.East,
        'v' => Direction.South,
        '<' => Direction.West,
        _ => throw new ArgumentException("Invalid character"),
    };

    public static Direction TurnRight(this Direction pDirection) => (Direction)(((int)pDirection + 2) % 8);
}