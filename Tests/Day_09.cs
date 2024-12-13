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

    #region Tests for the checksum calculation

    [Test]
    public void CalulateChecksum_WithDot_ReturnsChecksumUpToDot()
    {
        // Arrange
        string[] diskMap = ["1", "2", ".", "4", "5"];

        // Act
        long result = Part_01.CalulateChecksum(diskMap);

        // Assert
        Assert.That(result, Is.EqualTo(2)); // 1*0 + 2*1 = 0 + 2 = 2
    }

    [Test]
    public void CalulateChecksum_EmptyArray_ReturnsZero()
    {
        // Arrange
        string[] diskMap = [];

        // Act
        long result = Part_01.CalulateChecksum(diskMap);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void CalulateChecksum_AllDots_ReturnsZero()
    {
        // Arrange
        string[] diskMap = [".", ".", ".", ".", "."];

        // Act
        long result = Part_01.CalulateChecksum(diskMap);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void CalulateChecksum_MixedCharacters_ReturnsCorrectChecksum()
    {
        // Arrange
        string[] diskMap = ["1", "2", "3", ".", "5"];

        // Act
        long result = Part_01.CalulateChecksum(diskMap);

        // Assert
        Assert.That(result, Is.EqualTo(8)); // 1*0 + 2*1 + 3*2 = 0 + 2 + 6 = 8
    }

    #endregion

    #region Tests for the disk map filling

    [Test]
    public void FillDiskMap_ShouldFillFirstFreeSpace()
    {
        // Arrange
        string[] diskMap = ["1", "2", ".", "4", "5"];
        int last = 4;

        // Act
        int result = Part_01.FillDiskMap(diskMap, last);

        // Assert
        string[] target = ["1", "2", "5", "4", "."];
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(2)); // The retuned index of the first free space
            Assert.That(diskMap, Is.EquivalentTo(target));
        });
    }

    [Test]
    public void FillDiskMap_ShouldReturnMinusOne_WhenNoFreeSpace()
    {
        // Arrange
        string[] diskMap = ["1", "2", "3", "4", "5"];
        int last = 4;

        // Act
        int result = Part_01.FillDiskMap(diskMap, last);

        // Assert
        string[] target = ["1", "2", "3", "4", "5"];
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(-1)); // The retuned index of the first free space
            Assert.That(diskMap, Is.EquivalentTo(target));
        });
    }

    [Test]
    public void FillDiskMap_ShouldReturnMinusOne_WhenFreeSpaceIsPastLast()
    {
        // Arrange
        string[] diskMap = ["1", "2", "3", "4", "."];
        int last = 3;

        // Act
        int result = Part_01.FillDiskMap(diskMap, last);

        // Assert
        string[] target = ["1", "2", "3", "4", "."];
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(-1)); // The retuned index of the first free space
            Assert.That(diskMap, Is.EquivalentTo(target));
        });
    }

    [Test]
    public void FillDiskMap_ShouldHandleMultipleFreeSpaces()
    {
        // Arrange
        string[] diskMap = ["1", ".", "3", ".", "5"];
        int last = 4;

        // Act
        int result = Part_01.FillDiskMap(diskMap, last);

        // Assert
        string[] target = ["1", "5", "3", ".", "."];
        Assert.Multiple(() =>
        {
            Assert.That(result, Is.EqualTo(1)); // The retuned index of the first free space
            Assert.That(diskMap, Is.EquivalentTo(target));
        });
    }

    #endregion

    #region Tests for the disk map creation

    [Test]
    public void CreateDiskMap_Input1234_ReturnsExpectedDiskMap()
    {
        // Arrange
        var input = "1234".ToCharArray().Select(c => c.ToString()).ToArray();
        var expected = "0..111....".ToCharArray().Select(c => c.ToString()).ToArray();

        // Act
        var result = Part_01.CreateDiskMap(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CreateDiskMap_Input11111_ReturnsExpectedDiskMap()
    {
        // Arrange
        var input = "11111".ToCharArray().Select(c => c.ToString()).ToArray();
        var expected = "0.1.2".ToCharArray().Select(c => c.ToString()).ToArray();

        // Act
        var result = Part_01.CreateDiskMap(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CreateDiskMap_Input22222_ReturnsExpectedDiskMap()
    {
        // Arrange
        var input = "22222".ToCharArray().Select(c => c.ToString()).ToArray();
        var expected = "00..11..22".ToCharArray().Select(c => c.ToString()).ToArray();

        // Act
        var result = Part_01.CreateDiskMap(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    [Test]
    public void CreateDiskMap_InputEmpty_ReturnsEmptyString()
    {
        // Arrange
        var input = "".ToCharArray().Select(c => c.ToString()).ToArray();
        var expected = "".ToCharArray().Select(c => c.ToString()).ToArray();

        // Act
        var result = Part_01.CreateDiskMap(input);

        // Assert
        Assert.That(result, Is.EqualTo(expected));
    }

    #endregion
}