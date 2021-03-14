﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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
            var words = _bookContent.ToLower().RemovePunctuations().SplitWords();
            
            var searchWords = words.GroupBy(w => w)
                .Where(w => searchWord.Length > 2 && w.Key.StartsWith(searchWord))
                .Select(w => new Word()
                {
                    WordText = w.Key.StringCapitalize(),
                    Count = w.Count()
                });
            return searchWords.ToList();
        }

        public int GetCount(string word)
        {
            var words = _bookContent.ToLower().RemovePunctuations().SplitWords();
            return words.Count(w => w==word);
        }
    }
}