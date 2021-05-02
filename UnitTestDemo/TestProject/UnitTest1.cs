using MainApp;
using NUnit.Framework;

namespace TestProject
{
    public class Tests
    {
        private Berekeningen berekeningen;
        [SetUp]
        public void Setup()
        {
            this.berekeningen = new Berekeningen();
        }

        [TestCase(1.5f, 2.5f, 4.0f)]
        [TestCase(1,2,3)]
        public void TestFloats(float a, float b , float expectedResult) {
            Assert.AreEqual(expectedResult, berekeningen.AddTwoNumbers(a,b));
        }
        
        [TestCase(1, 2, 3)]
        [TestCase(-1, 1, 0)]
        public void TestIntegers(int a, int b , int expectedResult) {
            Assert.AreEqual(expectedResult, berekeningen.AddTwoNumbers(a,b));
        }    
        
        [TestCase(1, 2, 3)]
        [TestCase(-999, 1000, 1)]
        public void TestDoubles(double a, double b , double expectedResult) {
            Assert.AreEqual(expectedResult, berekeningen.AddTwoNumbers(a,b));
        }
    }
}