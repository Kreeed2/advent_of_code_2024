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

        public int Solve(string[] pInput)
        {
            var count = 0;
            foreach (var line in pInput)
            {

                var splits = FileReader.SplitLineIntoNumbers<int>(line)?.ToArray() ?? Array.Empty<int>();

                if (IsSafe(splits))
                    count++;
            }
            return count;
        }

        private static bool IsSafe(IEnumerable<int> pInput)
        {
            var enumerator = pInput.GetEnumerator();

            bool? isDecreasing = null;
            
            enumerator.MoveNext();
            int previous = enumerator.Current;
            while (enumerator.MoveNext())
            {
                // Any two adjacent levels differ by at least one and at most three.
                // The levels are either all increasing or all decreasing.
                if (!isDecreasing.HasValue)
                {
                    isDecreasing = previous > enumerator.Current;
                }

                var validMove = (isDecreasing.Value 
                    ? (previous - enumerator.Current) 
                    : (enumerator.Current - previous))
                switch
                {
                    >= MIN_DIFFERENCE and <= MAX_DIFFERENCE => true,
                    _ => false,
                };

                previous = enumerator.Current;

                if (!validMove)
                    return false;
            }
            return true;
        }
    }
}
