using Day_08;

namespace TestDay_08;

public class TestDay_08 {
    
        #pragma warning disable CS8618
        string[] input;
        #pragma warning restore CS8618
    
        [SetUp]
        public void SetUp() {
            input = [
                "............",
                "........0...",
                ".....0......",
                ".......0....",
                "....0.......",
                "......A.....",
                "............",
                "............",
                "........A...",
                ".........A..",
                "............",
                "............",
            ];
        }
    
        [Test]
        public void Part_1_Result() {
            var result = new Part_01().Solve(input);
    
            Assert.That(result, Is.EqualTo(14));
        }
        
        [Test]
        public void Part_2_Result() {
            var result = new Part_02().Solve(input);
    
            Assert.That(result, Is.EqualTo(34));
        }
}