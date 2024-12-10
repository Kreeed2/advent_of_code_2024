
using System.Diagnostics;
using HelperLibrary;

namespace Day_04
{
    public class Part_01 : IDay
    {
        private int mLineLength;
        public int[] mDirectionStepLength = new int[8];

        public long Solve(string[] pInput)
        {
            Initialize(pInput);

            var flatMatrix = SplitByChar(pInput).ToArray();
            var matches = 0;

            for (int i = 0; i < flatMatrix.Length; i++)
            {
                // If I find an 'X' character, I will check the 8 directions around it
                if (flatMatrix[i] == 'X')
                {
                    foreach (Direction direction in Enum.GetValues(typeof(Direction)))
                    {
                        if (NextCharacterIsM(flatMatrix, i, direction))
                        {
                            if (NextCharacterIsA(flatMatrix, i + mDirectionStepLength[(int)direction], direction))
                            {
                                if (NextCharacterIsS(flatMatrix, i + mDirectionStepLength[(int)direction] * 2, direction))
                                {
                                    Debug.WriteLine($"Found XMAS at x:{(i % mLineLength) + 1}, y:{(i / mLineLength) + 1} in direction {Enum.GetName(typeof(Direction), direction)}");
                                    matches++;
                                }
                            }
                        }
                    }
                }
            }

            return matches;
        }

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