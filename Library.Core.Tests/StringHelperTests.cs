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
    }
}
