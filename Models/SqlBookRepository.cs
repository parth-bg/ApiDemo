using System.Collections.Generic;

namespace ApiDemo.Models {
    public class SqlBookRepository : IBookRepository
    {
        private readonly AppDbContext context;

        public SqlBookRepository(AppDbContext context)
        {
            this.context = context;
        }

        public Book Add(Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return book;
        }

        public Book Delete(int BookId)
        {
            Book book = context.Books.Find(BookId);
            if (book != null)
            {
                context.Books.Remove(book);
                context.SaveChanges();
            }
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return context.Books;
        }

        public Book GetBook(int BookId)
        {
            return context.Books.Find(BookId);
        }

        public Book Update(Book BookChanges)
        {
            var book = context.Books.Attach(BookChanges);
            book.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return BookChanges;
        }
    }
}