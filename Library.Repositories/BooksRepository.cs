using System.Collections.Generic;
using System.IO;
using Library.Core.Models;

namespace Library.Repositories
{
    public class BooksRepository
    {
        private readonly string dir;
        //private Dictionary<int, string> _dictionary;
        private readonly List<Book> books = new List<Book>();
        public BooksRepository(string dir)
        {
            this.dir = dir;
            var files = Directory.GetFiles(dir, "*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                books.Add(new Book
                {
                    Id = i + 1,
                    Title = Path.GetFileNameWithoutExtension(files[i]),
                    Content = File.ReadAllText(Path.Combine(dir, Path.GetFileName(files[i])))
                });
            }
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            return books.Find(b => b.Id == id);
        }
    }
}