﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Http;
using Library.Core.Models;
using Library.Repositories;

namespace Library.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        /*
		The following GET methods are expected on the api/books controller:

			1. GET api/books
				Returns a list of Ids & Titles for all the books in the Resources folder
				Titles should be the name of the filename, minus the extension.
				The Id should be unique.

			2. GET api/books/{Id}
				Returns a list of the most common 10 words (min 5 letters) and how many times they occur in the specified book.
				When parsing, whitespace, linefeeds and punctiation should be ignored, and words matched case-insensitively (e.g. "the" and "The" and "THE" will be returned as "The"=3)
				Words should be returned in capital case (e.g. Word), and the list should be sorted in decreasing incidence.

			3. GET api/books/{Id}?query={query}
				Returns a list of all words which start with the specified string (min 3 letters) and the number of times they occur within the specified book.
				Case matching should be insensitive.

		The logic for these calls should largely be encapsulated in other classes. This should make it easier to Unit Test those classes
		to validate the expected behaviour.
		*/

        public IHttpActionResult Get()
        {
	        var repository = new BooksRepository(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources"));
	        var books = repository.GetBooks();
	        return Ok(books.Select(b => new { b.Id, b.Title }).ToList());
        }


        public IHttpActionResult Get(int id, string query = "")
        {
	        var repository = new BooksRepository(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Resources"));

	        var book = repository.GetBook(id);
	        if (book == null) return NotFound();

	        var wordsRepository = new WordsRepository(book.Content);
	        var mostCommandWords = new List<Word>();
	        if (string.IsNullOrEmpty(query))
	        {
		        mostCommandWords = wordsRepository.GetMostCommandWords();
	        }
	        else if (query.Length > 2)
	        {
		        mostCommandWords = wordsRepository.GetWordsBySearch(query);
	        }

	        return Ok(mostCommandWords);
        }
    }
}
