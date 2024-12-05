
using System.Diagnostics;
using HelperLibrary;

namespace Day_05
{
    public class Part_02 : IDay
    {
        public int Solve(string[] pInput)
        {
            var pageOrderingRules = Part_01.ParseRules(pInput);
            var updatedPages = Part_01.ParseUpdatePages(pInput);

            var invalidUpdatePages = updatedPages.Where(page => !Part_01.IsCorrectOrder(pageOrderingRules, page));
            
            var pageSum = 0;
            foreach (var invalidPage in invalidUpdatePages)
            {
                Debug.WriteLine($"Invalid page: {string.Join(",", invalidPage)}");
                var correctedPage = invalidPage;
                while(!Part_01.IsCorrectOrder(pageOrderingRules, correctedPage))
                    correctedPage = CorrectInvalidPages(pageOrderingRules, correctedPage);

                Debug.WriteLine($"Corrected page: {string.Join(",", correctedPage)}");

                pageSum += invalidPage[invalidPage.Length / 2];
            }
            return pageSum;
        }

        private static int[] CorrectInvalidPages(int[][] pPageOrderingRules, int[] pInvalidUpdatedPages)
        {
            // Each updated page must located before any of the page defined in the rules
            for (int i = 0; i < pInvalidUpdatedPages.Length; i++)
            {
                var pageRules = pPageOrderingRules[pInvalidUpdatedPages[i]];

                // Checking each updated page before against the rules
                for (int j = i; j >= 0; j--)
                {
                    // If a incorrect page is found, then swap their positions
                    if (pageRules.Contains(pInvalidUpdatedPages[j])) {
                        (pInvalidUpdatedPages[i], pInvalidUpdatedPages[j]) = (pInvalidUpdatedPages[j], pInvalidUpdatedPages[i]);
                    }
                }
            }
            return pInvalidUpdatedPages;
        }
    }
}