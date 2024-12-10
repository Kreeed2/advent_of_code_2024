using System.Diagnostics;
using HelperLibrary;

namespace Day_05
{
    public class Part_01 : IDay
    {
        public long Solve(string[] pInput)
        {
            // Speperate the page ordering rules
            var pageOrderingRules = ParseRules(pInput);
            for (int i = 0; i < pageOrderingRules.Length; i++)
            {
                if (pageOrderingRules[i] is null)
                    continue;
                Debug.WriteLine($"Index {i}: {string.Join(",", pageOrderingRules[i])}");
            }

            // Take the update pages from the input
            var updatedPages = ParseUpdatePages(pInput);
            
            var pageSum = 0;
            foreach (var updatedPage in updatedPages)
            {
                var correctOrder = IsCorrectOrder(pageOrderingRules, updatedPage);

                Debug.WriteLine($"Updated page: {string.Join(",", updatedPage)}");
                Debug.WriteLine(correctOrder);

                if (correctOrder)
                    pageSum += updatedPage[updatedPage.Length / 2];
            }

            return pageSum;
        }

        public static bool IsCorrectOrder(int[][] pPageOrderingRules, int[] pUpdatedPage)
        {
            // Each updated page must located before any of the page defined in the rules
            for (int i = 0; i < pUpdatedPage.Length; i++)
            {
                var pageRules = pPageOrderingRules[pUpdatedPage[i]];
                // If the page has no rules, then it is in the correct order
                if (pageRules is null)
                    continue;

                // Checking each updated page before against the rules
                for (int j = i; j >= 0; j--)
                {
                    if (pageRules.Contains(pUpdatedPage[j]))
                        return false;
                }
            }
            return true;
        }

        public static int[][] ParseUpdatePages(string[] pInput)
            => pInput
                .SkipWhile(line => line.Trim() != string.Empty)
                .Skip(1)
                .SelectMany(input => input.Split(['\r', '\n']))
                .Select(line => line.Split(',')
                    .Select(int.Parse)
                    .ToArray())
                .ToArray();

        public static int[][] ParseRules(string[] pInput)
        {
            var rules = pInput
                .TakeWhile(line => line.Trim() != string.Empty)
                .SelectMany(input => input.Split(['\r', '\n']))
                .SplitByPipe<int>();

            var output = new List<int>[100];
            foreach (var rule in rules)
            {                
                var key = rule.First();
                var value = rule.Last();

                if (output[key] is null)
                {
                    output[key] = [ value ];
                }
                else
                {
                    output[key].Add(value);
                }
            }

            return output.Select(ele => ele?.ToArray() ?? []).ToArray();
        }
    }
}