using System.Collections.Generic;
using System.Linq;
using Library.Core.Helpers;
using Library.Core.Models;

namespace Library.Repositories
{
    public class WordsRepository
    {
        private readonly string _bookContent;

        public WordsRepository(string bookContent)
        {
            this._bookContent = bookContent;
        }

        public List<Word> GetMostCommandWords()
        {
            var words = _bookContent.ToLower().RemovePunctuations().SplitWords();

            var mostCommonWords = words.GroupBy(x => x).Where(x => x.Key.Length > 4)
                .Select(x => new Word()
                {
                    WordText = x.Key.StringCapitalize(),
                    Count = x.Count()
                })
                .OrderByDescending(x => x.Count)
                .Take(10);

            return mostCommonWords.ToList();
        }

        public List<Word> GetWordsBySearch(string searchWord)
        {
            var words = _bookContent.ToLower().RemovePunctuations().SplitWords();

            var searchWords = words
                .Where(w => searchWord.Length > 2 && w.StartsWith(searchWord.ToLower()))
                .Select(w => new Word()
                {
                    WordText = w.StringCapitalize(),
                    Count = w.Count()
                });

            return searchWords.ToList();
        }
    }
}