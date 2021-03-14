using Library.Core.Helpers;
using NUnit.Framework;

namespace Library.Core.Tests
{
    [TestFixture]
    public class StringHelperTests
    {
        [Test]
        public void StringCapitalizeTest() 
        {
            string str = "whale";
            var capitalisedString = str.StringCapitalize();
            Assert.AreEqual("Whale", capitalisedString);
        }
        [Test]
        public void StringCapitalizeWithSingleCharacterTest() 
        {
            var str = "w";

            var capitalisedString = str.StringCapitalize();

            Assert.AreEqual("W", capitalisedString);
        }

        [Test]
        public void RemovePunctuationsTest()
        {
            var str = @"string!-_@";
            
            Assert.AreEqual("string", str.RemovePunctuations());
        }

        [Test]
        public void SplitWordsTest()
        {
            var str = "This is a split words test";
            var splitStr = str.SplitWords();
            Assert.AreEqual(6, splitStr.Length);
        }
    }
}
