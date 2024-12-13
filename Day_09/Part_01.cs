using System.Diagnostics;
using System.Text;
using HelperLibrary;

namespace Day_09;

public class Part_01 : IDay
{
    public long Solve(string[] pInput)
    {
        // The input is just a single line of numbers
        var input = pInput[0].SplitIntoCharacters();

        Console.WriteLine($"The input is {input.Length} characters long.");

        var diskMap = CreateDiskMap(input);

        for (int i = diskMap.Length - 1; i >= 0; i--)
        {
            var index = FillDiskMap(diskMap, i);
            if (index == -1)
            {
                Console.WriteLine($"Solve - The disk map is full at index {i}");
                break;
            }           
        }

        return CalulateChecksum(diskMap);
    }

    public static long CalulateChecksum(string[] pDiskMap)
    {
        long checksum = 0;
        for (int i = 0; i < pDiskMap.Length; i++)
        {
            if (pDiskMap[i] == ".")
            {
                Console.WriteLine($"CalulateChecksum - The disk map is full at index {i}");
                break;
            }

            checksum += int.Parse(pDiskMap[i].ToString()) * i;
        }

        return checksum;
    }

    public static int FillDiskMap(string[] pDiskMap, int pLast) {
        
        // Find the first index of a .
        // If the index is past the last character, return -1
        int freeSpace = Array.IndexOf(pDiskMap, ".");
        if (freeSpace == -1 || freeSpace >= pLast) {
            return -1;
        }

        // Fill the free space with the number at the end of the disk map
        pDiskMap[freeSpace] = pDiskMap[pLast];
        pDiskMap[pLast] = ".";

        return freeSpace;
    }

    public static string[] CreateDiskMap(string[] input)
    {
        var diskMap = new List<string>();

        long index = 0;
        // Expand the disk map from the input
        for (int pos = 0; pos < input.Length; pos++)
        {
            string c;
            if (pos % 2 == 0)
            {
                c = index.ToString();
                index++;
            }
            else
            {
                c = ".";
            }

            diskMap.AddRange(Enumerable.Repeat(c, int.Parse(input[pos].ToString())));
        }

        return diskMap.ToArray();
    }
}