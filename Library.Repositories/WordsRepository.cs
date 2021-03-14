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
            var words = GetBookContentWords();

            var mostCommonWords = words.GroupBy(w => w)
                .Where(w => w.Key.Length > 4)
                .Select(w => new Word()
                {
                    WordText = w.Key.StringCapitalize(),
                    Count = w.Count()
                })
                .OrderByDescending(w => w.Count)
                .Take(10);

            return mostCommonWords.ToList();
        }
        public List<Word> GetWordsBySearch(string searchWord)
        {
            var words = GetBookContentWords();
            
            var searchWords = words.GroupBy(w => w)
                .Where(w => searchWord.Length > 2 && w.Key.StartsWith(searchWord.ToLower()))
                .Select(w => new Word()
                {
                    WordText = w.Key.StringCapitalize(),
                    Count = w.Count()
                });
            return searchWords.ToList();
        }
        
        private string[] GetBookContentWords()
        {
            return _bookContent.ToLower().RemovePunctuations().SplitWords();
        }

    }
}