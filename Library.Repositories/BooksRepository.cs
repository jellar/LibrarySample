using System;
using System.Collections.Generic;
using System.IO;
using Library.Core.Models;

namespace Library.Repositories
{
    public class BooksRepository
    {
        private readonly List<Book> _books = new List<Book>();
        public BooksRepository(string dir)
        {
            var files = Directory.GetFiles(dir, "*.txt");
            for (int i = 0; i < files.Length; i++)
            {
                _books.Add(new Book
                {
                    Id = i + 1,
                    Title = Path.GetFileNameWithoutExtension(files[i]),
                    Content = File.ReadAllText(Path.Combine(dir, Path.GetFileName(files[i]) ?? throw new InvalidOperationException()))
                });
            }
        }

        public List<Book> GetBooks()
        {
            return _books;
        }

        public Book GetBook(int id)
        {
            return _books.Find(b => b.Id == id);
        }
    }
}