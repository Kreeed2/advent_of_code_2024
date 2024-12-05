using Day_05;

namespace TestDay_05;

public class TestDay_05 {

    #pragma warning disable CS8618
    string[] input;
    #pragma warning restore CS8618

    [SetUp]
    public void SetUp() {
        input = [
            "47|53",
            "97|13",
            "97|61",
            "97|47",
            "75|29",
            "61|13",
            "75|53",
            "29|13",
            "97|29",
            "53|29",
            "61|53",
            "97|53",
            "61|29",
            "47|13",
            "75|47",
            "97|75",
            "47|61",
            "75|61",
            "47|29",
            "75|13",
            "53|13",
            "\n",
            "75,47,61,53,29",
            "97,61,53,29,13",
            "75,29,13",
            "75,97,47,61,53",
            "61,13,29",
            "97,13,75,29,47",
        ];
    }

    [Test]
    public void Part_1_Result() {
        var result = new Part_01().Solve(input);

        Assert.That(result, Is.EqualTo(143));
    }
    
    [Test]
    public void Part_2_Result() {
        var result = new Part_02().Solve(input);

        Assert.That(result, Is.EqualTo(123));
    }
}