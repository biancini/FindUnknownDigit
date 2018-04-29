using NUnit.Framework;
using FindUnknownDigit;

namespace UnitTests
{
    [TestFixture]
    public class RunesTest
    {
        [TestCase("1+1=?", 2)]
        [TestCase("123*45?=5?088", 6)]
        [TestCase("-5?*-1=5?", 0)]
        [TestCase("19--45=5?", -1)]
        [TestCase("??*??=302?", 5)]
        [TestCase("?*11=??", 2)]
        [TestCase("??*1=??", 2)]
        public void TestSample(string expression, int missingDigit)
        {
            int result = Runes.SolveExpression(expression);
            Assert.AreEqual(missingDigit, result);
        }
    }

}
