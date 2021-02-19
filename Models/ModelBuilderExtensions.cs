using Microsoft.EntityFrameworkCore;

namespace ApiDemo.Models {

    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book 
                {
                    BookId = 1,
                    Title = "FIOS",
                    Price = 500,
                    AuthorId = 1
                }
            );

            modelBuilder.Entity<Author>().HasData(
                new Author
                {
                    AuthorId = 1,
                    AuthorName = "John Green"
                }
            );
        }
    }
}