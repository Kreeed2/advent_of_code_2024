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

        public long Solve(string[] pInput)
        {
            var count = 0;
            foreach (var line in pInput)
            {
                var splits = FileReader.SplitBySpace<int>(line)?.ToArray() ?? [];

                var result = Part_01.IsSafe(splits);
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

            return Part_01.IsSafe([.. tmp]);
        }
    }
}
