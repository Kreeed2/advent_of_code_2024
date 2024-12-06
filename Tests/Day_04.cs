using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_04;
using HelperLibrary;

namespace TestDay_04
{
    [TestFixture]
    public class TestDay_04
    {
        #pragma warning disable CS8618
        string[] input;
        #pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            input =
            [
                "MMMSXXMASM",
                "MSAMXMSMSA",
                "AMXSXMAAMM",
                "MSAMASMSMX",
                "XMASAMXAMM",
                "XXAMMXXAMA",
                "SMSMSASXSS",
                "SAXAMASAAA",
                "MAMMMXMMMM",
                "MXMXAXMASX"
            ];
        }

        [Test]
        public void Part_1_Result()
        {
            var result = new Part_01().Solve(input);

            Assert.That(result, Is.EqualTo(18));
        }

        [Test]
        public void Part_2_Result()
        {
            var result = new Part_02().Solve(input);

            Assert.That(result, Is.EqualTo(9));
        }

        [Test]
        public void IsAcrossLine_NorthDirection_ReturnsTrue()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["0123", "4567", "89AB", "XXXX"]);
            var index = 5;
            var direction = Direction.North;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAcrossLine_SouthDirection_ReturnsTrue()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["XXXX", "XXXX", "XXXX", "XXXX"]);
            int index = 5;
            var direction = Direction.South;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAcrossLine_EastDirectionCrossesLine_ReturnsFalse()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["0123", "4567", "89AB", "XXXX"]);
            int index = 3;
            var direction = Direction.East;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsAcrossLine_EastDirectionDoesNotCrossLine_ReturnsTrue()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["1234", "4567", "89AB", "CDEF"]);
            int index = 2;
            var direction = Direction.East;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.True);
        }

        [Test]
        public void IsAcrossLine_WestDirectionCrossesLine_ReturnsFalse()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["0123", "4567", "XXXX", "XXXX"]);
            int index = 4;
            var direction = Direction.West;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.False);
        }

        [Test]
        public void IsAcrossLine_WestDirectionDoesNotCrossLine_ReturnsTrue()
        {
            // Arrange
            var part01 = new Part_01();
            part01.Initialize(["1234", "4567", "89AB", "CDEF"]);
            int index = 5;
            var direction = Direction.West;

            // Act
            bool result = part01.IsInLine(index, direction);

            // Assert
            Assert.That(result, Is.True);
        }
    }
}
