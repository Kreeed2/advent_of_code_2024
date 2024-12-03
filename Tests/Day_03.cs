using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Day_03;

namespace TestDay_03
{
    [TestFixture]
    public class TestDay_03
    {
        #pragma warning disable CS8618
        string[] input;
        #pragma warning restore CS8618

        [SetUp]
        public void SetUp()
        {
            input =
            [
                "xmul(2,4)&mul[3,7]!^don't()_mul(5,5)+mul(32,64](mul(11,8)undo()?mul(8,5))",
            ];
        }

        [Test]
        public void Part_1_Result()
        {
            var result = new Part_01().Solve(input);

            Assert.That(result, Is.EqualTo(161));
        }

        [Test]
        public void Part_2_Result()
        {
            var result = new Part_02().Solve(input);

            Assert.That(result, Is.EqualTo(48));
        }
    }
}
