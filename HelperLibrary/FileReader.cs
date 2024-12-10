using System.Collections;
using System.Linq;

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

        public static IEnumerable<T> SplitBySpace<T>(string pLine) => SplitBy<T>(' ')(pLine);

        public static IEnumerable<T> SplitByComma<T>(string pLine) => SplitBy<T>(',')(pLine);

        public static IEnumerable<T> SplitByColon<T>(string pLine) => SplitBy<T>(':')(pLine);

        public static IEnumerable<T> SplitByPipe<T>(string pLine) => SplitBy<T>('|')(pLine);

        private static Func<string, IEnumerable<T>> SplitBy<T>(char pSeperator) => 
        pLine => {
            var splits = pLine.Split(pSeperator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.RemoveEmptyEntries);
            return Type.GetTypeCode(typeof(T)) switch
            {
                TypeCode.String => (IEnumerable<T>)splits.AsEnumerable(),
                TypeCode.Int32 => (IEnumerable<T>)splits.Select(item => Convert.ToInt32(item)),
                TypeCode.Int64 => (IEnumerable<T>)splits.Select(item => Convert.ToInt64(item)),
                _ => throw new NotImplementedException(),
            };
        };


    }

    public static class FileReaderExtenstions {
        public static IEnumerable<IEnumerable<T>> SplitByPipe<T>(this IEnumerable<string> pLines) => pLines.Select(FileReader.SplitByPipe<T>);
    }
}
