using System.Linq;
using NUnit.Framework;

namespace Library.Repositories.Tests
{
    [TestFixture]
    public class WordsRepositoryTests
    {
        private const string SAMPLE_TEXT =
            @"Lorem ipsum Dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. 
                Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate 
                velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        private readonly WordsRepository _repository;

        public WordsRepositoryTests()
        {
            _repository = new WordsRepository(SAMPLE_TEXT);
        }

        [Test]
        public void MostCommonWordsTest()
        {
            var commonWords = _repository.GetMostCommandWords();
            Assert.AreEqual("Dolor", commonWords[0].WordText);
        }

        [Test]
        public void MostCommonWordsCountTest()
        {
            var commonWords = _repository.GetMostCommandWords();
            Assert.AreEqual(10, commonWords.Count);
        }

        [Test]
        public void SearchWordNotExistsTest()
        {
            var words = _repository.GetWordsBySearch("testtest");
            Assert.IsTrue(!words.Any());
        }

        [Test]
        public void GetCountTest()
        {
            var count = _repository.GetCount("dolor");
            Assert.AreEqual(2, count);
        }

        [Test]
        public void SearchWordCountTest()
        {
            var words = _repository.GetWordsBySearch("labor");
            Assert.AreEqual(3, words.Count);
        }

        [Test]
        public void SearchWordWithTwoCharactersTest()
        {
            var words = _repository.GetWordsBySearch("do");
            Assert.AreEqual(0, words.Count);
        }
    }
}