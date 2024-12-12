using System.Diagnostics;
using System.Text;
using HelperLibrary;

namespace Day_09;

public class Part_01 : IDay
{
    public long Solve(string[] pInput)
    {
        // The input is just a single line of numbers
        var input = pInput[0].ToCharArray();

        var diskMap = CreateDiskMap(input).ToCharArray();

        Debug.WriteLine(diskMap);
        for (int i = diskMap.Length - 1; i >= 0; i--)
        {
            var index = FillDiskMap(diskMap, i);
            Debug.WriteLine(diskMap);
            if (index == -1)
            {
                break;
            }           
        }

        Console.WriteLine(diskMap);

        return CalulateChecksum(diskMap);
    }

    private static long CalulateChecksum(char[] pDiskMap)
    {
        long checksum = 0;
        for (int i = 0; i < pDiskMap.Length; i++)
        {
            if (pDiskMap[i] == '.')
            {
                break;
            }

            checksum += int.Parse(pDiskMap[i].ToString()) * i;
        }

        return checksum;
    }

    private static int FillDiskMap(char[] pDiskMap, int pLast) {
        
        // Find the first index of a .
        // If the index is past the last character, return -1
        int freeSpace = Array.IndexOf(pDiskMap, '.');
        if (freeSpace == -1 || freeSpace > pLast) {
            return -1;
        }

        // Fill the free space with the number at the end of the disk map
        pDiskMap[freeSpace] = pDiskMap[pLast];
        pDiskMap[pLast] = '.';

        return freeSpace;
    }

    private static string CreateDiskMap(char[] input)
    {
        var diskMap = new StringBuilder();

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

            diskMap.Append(string.Concat(Enumerable.Repeat(c, int.Parse(input[pos].ToString()))));
        }

        return diskMap.ToString();
    }
}