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

        for (int i = diskMap.Length - 1; i >= 0; i--)
        {
            // Skip the empty spaces
            if (diskMap[i] == ".")
                continue;

            var index = FillDiskMap(diskMap, i);
            if (index == -1)
            {
                Console.WriteLine($"Solve - The disk map is full at index {i}");
                break;
            }           
        }

        return Part_01.CalulateChecksum(diskMap);
    }

    public static int FillDiskMap(string[] pDiskMap, int pLast) {
        
        // Find the first index of a .
        // If the index is past the last character, return -1
        int freeSpace = Array.IndexOf(pDiskMap, ".");
        if (freeSpace == -1 || freeSpace >= pLast) {
            return -1;
        }

        // Get size of the free space on the disk
        int freeSpaceSize = GetSizeOfFreeSpace(pDiskMap, ".", freeSpace);

        int fileSize = 0;
        // Find a file that is the same size or smaller as the free space
        for (int i = pLast; i >= 0; i--) {
            // Skip the empty spaces
            if (pDiskMap[i] == ".")
                continue;

            fileSize = GetSizeOfFile(pDiskMap, pDiskMap[i], i);
            if (fileSize <= freeSpaceSize) {
                pLast = i;
                break;
            }
            i -= fileSize;
        }

        // Move the file to the free space
        for (int i = 0; i < fileSize; i++) {
            pDiskMap[freeSpace + i] = pDiskMap[pLast - i];
            pDiskMap[pLast - i] = ".";
        }

        return freeSpace;
    }

    public static int GetSizeOfFreeSpace(string[] pDiskMap, string pId, int pStartIndex) {
        int size = 0;
        for (int i = pStartIndex; i < pDiskMap.Length; i++) {
            if (pDiskMap[i] == pId) {
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