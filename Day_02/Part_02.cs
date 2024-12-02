using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_02
{
    public class Part_02 : IDay
    {
        const int MIN_DIFFERENCE = 1;
        const int MAX_DIFFERENCE = 3;

        public int Solve(string[] pInput)
        {
            var count = 0;
            foreach (var line in pInput)
            {
                var splits = FileReader.SplitLineIntoNumbers<int>(line)?.ToArray() ?? Array.Empty<int>();

                var result = IsSafe(splits);
                if (result == -1)
                    count++;
                else
                {
                    for (int i = 0; i < splits.Length; i++)
                    {
                        result = ReconcileReport(splits, i);
                        // We have found the solution
                        if (result == -1)
                        {
                            count++;
                            break;
                        }
                    }
                }
            }
            return count;
        }

        private static int ReconcileReport(int[] pInput, int pIndex)
        {
            var tmp = new List<int>(pInput);
            tmp.RemoveAt(pIndex);

            return IsSafe(tmp.ToArray());
        }

        private static int IsSafe(int[] pInput)
        {
            bool? isDecreasing = null;

            for (int i = 1; i < pInput.Length; i++)
            {
                // Any two adjacent levels differ by at least one and at most three.
                // The levels are either all increasing or all decreasing.
                if (!isDecreasing.HasValue)
                {
                    isDecreasing = pInput[i-1] > pInput[i];
                }

                var validMove = (isDecreasing.Value
                    ? (pInput[i-1] - pInput[i])
                    : (pInput[i] - pInput[i-1]))
                switch
                {
                    >= MIN_DIFFERENCE and <= MAX_DIFFERENCE => true,
                    _ => false,
                };

                // The report is not safe and we stop here
                if (!validMove)
                    return i-1;
            }
            return -1;
        }
    }
}
