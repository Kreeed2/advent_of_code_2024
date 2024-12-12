using Day_08;
using HelperLibrary;

var input = FileReader.ReadFile(@"Input.txt");

var solution = new Part_01().Solve(input);

Console.WriteLine($"The solution for part 1 is {solution} !");

solution = new Part_02().Solve(input);

Console.WriteLine($"The solution for part 2 is {solution} !");