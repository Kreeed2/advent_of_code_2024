using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
    public class Part_01 : IDay
    {
        public int Solve(string[] pInput)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            foreach (var line in pInput)
            {
                var splits = FileReader.SplitLineIntoNumbers(line);
                list1.Add(splits.Item1);
                list2.Add(splits.Item2);
            }

            list1.Sort();
            list2.Sort();

            var distance = list1.Zip(list2, (x, y) => Math.Abs(x - y));
            return distance.Sum();
        }


    }
}
