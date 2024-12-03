using System.Text.RegularExpressions;
using HelperLibrary;

namespace Day_03 {
    public class Part_02 : IDay {
        public int Solve(string[] pInput) {
            var pattern = @"(mul\(\d{1,3},\d{1,3}\))|(don't|do)";

            var matches = pInput.SelectMany(line => Regex.Matches(line, pattern, RegexOptions.Multiline).Select(match => match.Value ));

            // At the beginning of the program, mul instructions are enabled.
            bool enabled = true;
            int sum = 0;
            foreach (var match in matches) {
                if (match == "do" || match == "don't") {
                    enabled = match == "do";
                } else if (enabled) {
                    sum += Part_01.ParseMathOperation(match);
                }
            }
            return sum;
        }
    }
}