using Day_06;

namespace TestDay_06;

public class TestDay_06 {

    #pragma warning disable CS8618
    string[] input;
    #pragma warning restore CS8618

    [SetUp]
    public void SetUp() {
        input = [
            "....#.....",
            ".........#",
            "..........",
            "..#.......",
            ".......#..",
            "..........",
            ".#..^.....",
            "........#.",
            "#.........",
            "......#...",
        ];
    }

    [Test]
    public void Part_1_Result() {
        var result = new Part_01().Solve(input);

        Assert.That(result, Is.EqualTo(41));
    }
    
    [Test]
    public void Part_2_Result() {
        var result = new Part_02().Solve(input);

        Assert.That(result, Is.EqualTo(6));
    }
}