using System.Text.RegularExpressions;
using HelperLibrary;

namespace Day_03 {
    public class Part_01 : IDay {
        public int Solve(string[] pInput) {
            var regex = new Regex(@"mul\(\d{1,3},\d{1,3}\)", RegexOptions.Multiline | RegexOptions.Compiled);

            var tmp = pInput.Select(
                line => regex.Matches(line)
                    .Select(match => ParseMathOperation(match.Value))
                    .Sum())
                .Sum();

            return tmp;
        }

        public static int ParseMathOperation(string pOperation) {
            // mul(3, 4) -> 3 * 4

            var splits = pOperation.Split(',');
            return int.Parse(splits[0][4..]) * int.Parse(splits[1][..^1]);
        }
    }
}