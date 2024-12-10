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
        public long Solve(string[] pInput)
        {
            var list1 = new List<int>();
            var list2 = new List<int>();

            foreach (var line in pInput)
            {
                var splits = FileReader.SplitBySpace<int>(line)?.ToArray() ?? Array.Empty<int>();
                list1.Add(splits[0]);
                list2.Add(splits[1]);
            }

            return list1
                .Select(num => 
                    num * list2.Where(row => row == num).Count()
                    )
                .Sum();
        }
    }
}
