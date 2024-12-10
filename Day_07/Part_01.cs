using System.Diagnostics;
using HelperLibrary;

namespace Day_07
{
    public class Part_01 : IDay
    {
        public long Solve(string[] pInput)
        {
            long sum = 0;
            foreach (string line in pInput) {
                var tmp = FileReader.SplitByColon<string>(line).ToArray();
                var targetValue = Convert.ToInt64(tmp[0]);
                var arguments = FileReader.SplitBySpace<long>(tmp[1]);

                var argumentPermutations = GetPermutation(arguments.Reverse().ToList());

                foreach (var testResult in argumentPermutations)
                {
                    if (testResult == targetValue)
                    {
                        Debug.WriteLine(string.Join(',',argumentPermutations));
                        sum += targetValue;
                        break;
                    }
                }
            }

            return sum;
        }

        private static List<long> GetPermutation(List<long> pArguments)
        {
            if (pArguments.Count == 2){
                return [pArguments[0] + pArguments[1], pArguments[0] * pArguments[1]];
            }
            else
            {
                var ele = pArguments[0];
                var rest = pArguments.Skip(1).ToList();

                var perm = GetPermutation(rest);

                var res = new List<long>();
                foreach (var p in perm)
                {
                    res.Add(ele + p);
                    res.Add(ele * p);
                }
                return res;
            }
        }
    }
}