namespace HelperLibrary
{
    public class FileReader
    {
        public static string[] ReadFile(string pFileName)
        {
            var cPath = Directory.GetCurrentDirectory();

            while (cPath is not null 
                && new DirectoryInfo(cPath).Name != "advent_of_code_2024")
            {
                if (File.Exists(Path.Join(cPath, pFileName)))
                {
                    break;
                }
                else
                {
                    cPath = Directory.GetParent(cPath)?.FullName;
                }
            }

            return File.ReadAllLines(Path.Join(cPath, pFileName));
        }

        public static (int, int) SplitLineIntoNumbers(string pLine)
        {
            var splits = pLine.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);
            return (Convert.ToInt32(splits[0]), Convert.ToInt32(splits[1]));
        }
    }
}
