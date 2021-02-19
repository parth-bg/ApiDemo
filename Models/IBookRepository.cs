using System.Collections.Generic;

namespace ApiDemo.Models {
    public interface IBookRepository
    {
        Book GetBook(int BookId);

        IEnumerable<Book> GetAllBooks();

        Book Add(Book book);

        Book Update(Book BookChanges);

        Book Delete(int BookId);
    }
}