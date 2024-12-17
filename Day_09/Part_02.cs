using HelperLibrary;

namespace Day_09;

public class Part_02 : IDay
{
    public long Solve(string[] pInput)
    {
        // The input is just a single line of numbers
        var input = pInput[0].SplitIntoCharacters();

        Console.WriteLine($"The input is {input.Length} characters long.");

        var diskMap = Part_01.CreateDiskMap(input);

        for (int i = diskMap.Length - 1; i >= 0;)
        {
            // Skip the empty spaces
            if (diskMap[i] == ".")
            {
                i--;
                continue;
            }

            var index = FillDiskMap(diskMap, i);
            i -= index;
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
                continue;
            }

            checksum += int.Parse(pDiskMap[i].ToString()) * i;
        }

        return checksum;
    }

    public static int FillDiskMap(string[] pDiskMap, int pLast) {

        // Get the size of the last file
        int fileSize = GetSizeOfFile(pDiskMap, pDiskMap[pLast], pLast);

        // Go through the disk map and try to find a free space for that file
        for (int i = 0; i < pLast; i++)
        {
            if (pDiskMap[i] == ".")
            {
                var freeSpace = GetSizeOfFreeSpace(pDiskMap, i);
                // Check if the file fits in the free space
                if (fileSize <= freeSpace)
                {
                    // Move the file to the free space
                    for (int j = 0; j < fileSize; j++)
                    {
                        pDiskMap[i + j] = pDiskMap[pLast - j];
                        pDiskMap[pLast - j] = ".";
                    }
                    break;
                }
                i += freeSpace;
            }
        }
        return fileSize;
    }

    public static int GetSizeOfFreeSpace(string[] pDiskMap, int pStartIndex)
    {
        int size = 0;
        for (int i = pStartIndex; i < pDiskMap.Length; i++) {
            if (pDiskMap[i] == ".") {
                size++;
            } else {
                break;
            }
        }

        return size;
    }

        public static int GetSizeOfFile(string[] pDiskMap, string pId, int pStartIndex) {
        int size = 0;
        for (int i = pStartIndex; i >= 0; i--) {
            if (pDiskMap[i] == pId) {
                size++;
            } else {
                break;
            }
        }

        return size;
    }
}