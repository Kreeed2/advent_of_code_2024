using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_02
{
    public class Part_01 : IDay
    {
        const int MIN_DIFFERENCE = 1;
        const int MAX_DIFFERENCE = 3;

        public long Solve(string[] pInput)
        {
            var count = 0;
            foreach (var line in pInput)
            {
                var splits = FileReader.SplitBySpace<int>(line)?.ToArray() ?? [];

                if (IsSafe(splits) == -1)
                    count++;
            }
            return count;
        }

        /// <summary>
        /// Determines if the sequence of levels in the input array is safe.
        /// </summary>
        /// <param name="pInput">An array of integers representing the levels.</param>
        /// <returns>
        /// The index of the first level that violates the safety rules, or -1 if all levels are safe.
        /// </returns>
        /// <remarks>
        /// The safety rules are:
        /// 1. Any two adjacent levels differ by at least one and at most three.
        /// 2. The levels are either all increasing or all decreasing.
        /// </remarks>
        public static int IsSafe(int[] pInput)
        {
            bool? isIncreasing = null;
            for (int i = 1; i < pInput.Length; i++)
            {
                if (!isIncreasing.HasValue)
                    isIncreasing = pInput[i] > pInput[i - 1];
                else {
                    if (isIncreasing.Value && pInput[i] < pInput[i - 1] 
                        || !isIncreasing.Value && pInput[i] > pInput[i - 1])
                        return i-1;
                }
                
                var difference = Math.Abs(pInput[i] - pInput[i - 1]);
                if (!(difference >= MIN_DIFFERENCE && difference <= MAX_DIFFERENCE))
                    return i-1;
            }
            return -1;
        }
    }
}
