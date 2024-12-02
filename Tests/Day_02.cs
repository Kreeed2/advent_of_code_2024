using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_02;

namespace TestDay_02
{
    [TestFixture]
    public class TestDay_02
    {
        #pragma warning disable CS8618
        string[] input;
        #pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            this.input = new string[]
            {
                "7 6 4 2 1",
                "1 2 7 8 9",
                "9 7 6 2 1",
                "1 3 2 4 5",
                "8 6 4 4 1",
                "1 3 6 7 9"
            };
        }

        [Test]
        public void Part_1_Result()
        {
            var result = new Part_01().Solve(input);

            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Part_2_Result()
        {
            var result = new Part_02().Solve(input);

            Assert.That(result, Is.EqualTo(4));
        }
    }
}
