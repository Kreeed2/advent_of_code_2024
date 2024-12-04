using System.Collections;

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

        public static IEnumerable<T> SplitBySpace<T>(string pLine)
        {
            var splits = pLine.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);
            return Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.String => (IEnumerable<T>)splits.AsEnumerable(),
                TypeCode.Int32 => (IEnumerable<T>)splits.Select(item => Convert.ToInt32(item)),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
