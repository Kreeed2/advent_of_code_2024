using HelperLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_01
{
    public class Part_02 : IDay
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

            return list1
                .Select(num => 
                    num * list2.Where(row => row == num).Count()
                    )
                .Sum();
        }
    }
}
