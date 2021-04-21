using BookRankings.DataAcess.Abstractions;
using BookRankings.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookRankings.DataAccess
{
    public class EFBookRepository : EFRepository<Book>, IBookRepository
    {
        private readonly BooksDbContext context;

        public EFBookRepository(BooksDbContext context) : base(context)
        {
            this.context = context;
        }

        public Book Get(string author, string name)
        {
            return context.Books.Where(book => book.Author == author && book.Name == name).FirstOrDefault();
        }

        public void Remove(string id)
        {
            context.Books.Remove(context.Books.Find(id));
            context.SaveChanges();
        }
    }
}
