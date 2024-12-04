
using System.Diagnostics;
using HelperLibrary;

namespace Day_04
{
    public class Part_02 : IDay
    {
        private int mLineLength;
        public int[] mDirectionStepLength = new int[8];

        public int Solve(string[] pInput)
        {
            Initialize(pInput);

            var flatMatrix = SplitByChar(pInput).ToArray();
            var matches = 0;

            // The relevant directions to check for the 'XMAS' word are only the diagonals
            var validDirections = new Direction[] { Direction.NorthEast, Direction.SouthEast, Direction.SouthWest, Direction.NorthWest };

            for (int i = 0; i < flatMatrix.Length; i++)
            {
                // If I find an 'A' character, I will check the directions around it
                if (flatMatrix[i] == 'A')
                {
                    foreach (Direction direction in validDirections)
                    {
                        if (NextCharacterIsM(flatMatrix, i, direction))
                        {
                            if (!NextCharacterIsS(flatMatrix, i, GetOpposite(direction)))
                            {
                                break;
                            }
                            if (NextCharacterIsM(flatMatrix, i, GetMirroredHorizontal(direction))
                                && NextCharacterIsS(flatMatrix, i, GetMirroredHorizontal(GetOpposite(direction)))) {
                                Debug.WriteLine($"Found XMAS at x:{(i % mLineLength) + 1}, y:{(i / mLineLength) + 1} in direction {Enum.GetName(typeof(Direction), direction)}");
                                matches++;
                                break;
                            }
                            else if (NextCharacterIsM(flatMatrix, i, GetMirroredVertrical(direction))
                                && NextCharacterIsS(flatMatrix, i, GetMirroredVertrical(GetOpposite(direction)))) {
                                Debug.WriteLine($"Found XMAS at x:{(i % mLineLength) + 1}, y:{(i / mLineLength) + 1} in direction {Enum.GetName(typeof(Direction), direction)}");
                                matches++;
                                break;
                            }
                        }
                    }
                }
            }

            return matches;
        }

        private static Direction GetOpposite(Direction pDirection) => pDirection switch {
            Direction.North => Direction.South,
            Direction.South => Direction.North,
            Direction.East => Direction.West,
            Direction.West => Direction.East,
            Direction.NorthEast => Direction.SouthWest,
            Direction.SouthWest => Direction.NorthEast,
            Direction.NorthWest => Direction.SouthEast,
            Direction.SouthEast => Direction.NorthWest,
            _ => throw new ArgumentOutOfRangeException(nameof(pDirection), $"Not expected direction value: {pDirection}")
        };

        private static Direction GetMirroredVertrical(Direction pDirection) => pDirection switch {
            Direction.NorthEast => Direction.NorthWest,
            Direction.NorthWest => Direction.NorthEast,
            Direction.SouthWest => Direction.SouthEast,
            Direction.SouthEast => Direction.SouthWest,
            _ => throw new ArgumentOutOfRangeException(nameof(pDirection), $"Not expected direction value: {pDirection}")
        };

        private static Direction GetMirroredHorizontal(Direction pDirection) => pDirection switch {
            Direction.NorthEast => Direction.SouthEast,
            Direction.NorthWest => Direction.SouthWest,
            Direction.SouthWest => Direction.NorthWest,
            Direction.SouthEast => Direction.NorthEast,
            _ => throw new ArgumentOutOfRangeException(nameof(pDirection), $"Not expected direction value: {pDirection}")
        };


        public void Initialize(string[] pInput)
        {
            var lineLength = pInput[0].Length;
            var north = -lineLength;
            var east = 1;
            var south = lineLength;
            var west = -1;
            var northEast = north + east;
            var northWest = north + west;
            var southEast = south + east;
            var southWest = south + west;

            mDirectionStepLength =
            [
                north,
                northEast,
                east,
                southEast,
                south,
                southWest,
                west,
                northWest,
            ];

            mLineLength = lineLength;
        }

        public static IEnumerable<char> SplitByChar(string[] pInput)
        {
            return pInput.SelectMany(line => line.ToCharArray());
        }

        private Func<char[], int, Direction, bool> NextCharacterIs(char pCharacterToMatch)
        {
            return new Func<char[], int, Direction, bool>((pFlatMaxtrix, pIndex, pDirection) =>
            {
                var steps = mDirectionStepLength[(int)pDirection];
                return IsInBounds(pFlatMaxtrix, pIndex, pDirection)
                    && IsInLine(pIndex, pDirection)
                    && pFlatMaxtrix[pIndex + steps] == pCharacterToMatch;
            });
        }

        public bool NextCharacterIsM(char[] pFlatMaxtrix, int pIndex, Direction pDirection) 
            => NextCharacterIs('M')(pFlatMaxtrix, pIndex, pDirection);

        public bool NextCharacterIsA(char[] pFlatMaxtrix, int pIndex, Direction pDirection)
            => NextCharacterIs('A')(pFlatMaxtrix, pIndex, pDirection);

        public bool NextCharacterIsS(char[] pFlatMaxtrix, int pIndex, Direction pDirection)
            => NextCharacterIs('S')(pFlatMaxtrix, pIndex, pDirection);

        public bool IsInBounds(char[] pFlatMatrix, int pIndex, Direction pDirection)
        {
            return pIndex + mDirectionStepLength[(int)pDirection] >= 0 
                && pIndex + mDirectionStepLength[(int)pDirection] < pFlatMatrix.Length;
        }

        /// <summary>
        /// Determines if the given index crosses a line based on the specified direction.
        /// </summary>
        /// <param name="pIndex">The current index.</param>
        /// <param name="pDirection">The steps in a specific direction of movement.</param>
        /// <returns>
        /// <c>true</c> if the direction is North or South, or if the movement crosses a line;
        /// otherwise, <c>false</c>.
        /// </returns>
        public bool IsInLine(int pIndex, Direction pDirection)
        {
            var currentRow = pIndex / mLineLength;
            var movedRow = (pIndex + mDirectionStepLength[(int)pDirection]) / mLineLength;

            int requiredRowDifference = pDirection switch  {
                Direction.North => -1,
                Direction.South => 1,
                Direction.East or Direction.West => 0,
                Direction.NorthEast => -1,
                Direction.SouthEast => 1,
                Direction.SouthWest => 1,
                Direction.NorthWest => -1,
                _ => throw new ArgumentOutOfRangeException(nameof(pDirection), $"Not expected direction value: {pDirection}") 
            };

            return currentRow + requiredRowDifference == movedRow;
        }
    }
}