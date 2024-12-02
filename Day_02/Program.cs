using Day_02;
using HelperLibrary;

//var prompt = FileReader.ReadFile(@".\Description.md");
//foreach (var line in prompt)
//    Console.WriteLine(line);

var input = FileReader.ReadFile(@".\input.txt");

var solution = new Part_01().Solve(input);

Console.WriteLine($"The solution for part 1 is {solution} !");

solution = new Part_02().Solve(input);

Console.WriteLine($"The solution for part 2 is {solution} !");