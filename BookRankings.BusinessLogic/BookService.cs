using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace BookRankings.BusinessLogic
{
    public class BookService : Service<Book>
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository) : base(bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public void AddBookPhoto(IFormFile formFile , string ISBN)
        {
            
            string filePath = @"C:\Users\menta\source\repos\BookRankings\BookRankings\wwwroot\BookPhotos";
            filePath = Path.Combine(filePath, ISBN + ".jpg");
            using (FileStream fs = System.IO.File.Create(filePath))
            {
                formFile.CopyTo(fs);
                fs.Flush();
            }
        }

        public Book Get(string author, string name)
        {
            return bookRepository.Get(author, name);
        }

        public void RemoveBook(string id)
        {
            bookRepository.Remove(id);
        }
    }
}
