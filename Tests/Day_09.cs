using Day_09;

namespace TestDay_09;

public class TestDay_09
{

    #pragma warning disable CS8618
    string[] input;
    #pragma warning restore CS8618

    [SetUp]
    public void SetUp()
    {
        input = [
            "2333133121414131402"
        ];
    }

    [Test]
    public void Part_1_Result()
    {
        var result = new Part_01().Solve(input);

        Assert.That(result, Is.EqualTo(1928));
    }

}