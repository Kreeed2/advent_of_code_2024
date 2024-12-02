using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_01;

namespace TestDay_01
{
    [TestFixture]
    public class TestDay_01
    {
        #pragma warning disable CS8618
        string[] input;
        #pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            this.input = new string[]
            {
                "3   4",
                "4   3",
                "2   5",
                "1   3",
                "3   9",
                "3   3"
            };
        }

        [Test]
        public void Part_1_Result()
        {
            var result = new Part_01().Solve(input);

            Assert.That(result, Is.EqualTo(11));
        }

        [Test]
        public void Part_2_Result()
        {
            var result = new Part_02().Solve(input);

            Assert.That(result, Is.EqualTo(31));
        }
    }
}
