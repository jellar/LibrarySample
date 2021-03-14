using System.Collections.Generic;
using System.Linq;
using Library.Core.Helpers;
using Library.Core.Models;

namespace Library.Repositories
{
    public class WordsRepository
    {
        private readonly string bookContent;

        public WordsRepository(string bookContent)
        {
            this.bookContent = bookContent;
        }

        public List<Word> GetMostCommandWords()
        {
            var delimiters = new char[] { ' ', '\r', '\n'};
            var words = bookContent.RemovePunctuations().SplitWords();

            var groups = words.GroupBy(x => x).Where(x => x.Key.Length > 5);
            var largest = groups.OrderByDescending(x => x.Count()).Take(10)
                .Select(g => new Word {  WordText= g.Key.StringCapitalize(), Count = g.Count() });
            return largest.ToList();
            
            /*
            var list = new List<string>(words);
            var freqs = GetFrequencies(list);

            var sorted = from pair in freqs
                orderby pair.Value descending
                select new Word { WordText = pair.Key, Count = pair.Value };
            return sorted.ToList();
            //return words.GroupBy(w => w).OrderByDescending(g => g.Count()).Select(g => g.Key).FirstOrDefault();
            */
        }
        
        public List<Word> GetWordsBySearch(string searchWord)
        {
            var delimiters = new char[] { ' ', '\r', '\n' };

            var words = bookContent.RemovePunctuations().SplitWords();

            var groups = words.GroupBy(x => x).Where(x=>x.Key.StartsWith(searchWord));
            var largest = groups.OrderByDescending(x => x.Count())
                .Select(g => new Word { WordText = g.Key, Count = g.Count() });
            return largest.ToList();
        }
        
        static Dictionary<string, int> GetFrequencies(List<string> values)
        {
            var result = new Dictionary<string, int>();
            foreach (string value in values)
            {
                if (result.TryGetValue(value, out int count))
                {
                    // Increase existing value.
                    result[value] = count + 1;
                }
                else
                {
                    // New value, set to 1.
                    result.Add(value, 1);
                }
            }
            // Return the dictionary.
            return result;
        }
    }
}