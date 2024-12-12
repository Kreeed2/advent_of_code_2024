using Day_07;

namespace TestDay_07;

public class TestDay_07 {

    #pragma warning disable CS8618
    string[] input;
    #pragma warning restore CS8618

    [SetUp]
    public void SetUp() {
        input = [
            "190: 10 19",
            "3267: 81 40 27",
            "83: 17 5",
            "156: 15 6",
            "7290: 6 8 6 15",
            "161011: 16 10 13",
            "192: 17 8 14",
            "21037: 9 7 18 13",
            "292: 11 6 16 20",
        ];
    }

    [Test]
    public void Part_1_Result() {
        var result = new Part_01().Solve(input);

        Assert.That(result, Is.EqualTo(3749));
    }
    
    [Test]
    public void Part_2_Result() {
        var result = new Part_02().Solve(input);

        Assert.That(result, Is.EqualTo(11387));
    }
}