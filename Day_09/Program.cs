
using Day_09;
using HelperLibrary;

var input = FileReader.ReadFile(@"Input.txt");

var solution = new Part_01().Solve(input);

Console.WriteLine($"The solution for part 1 is {solution} !");