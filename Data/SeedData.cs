using BookCatalogManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogManagementApp.Data
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Books.Any())
                {
                    return;
                }

                context.Books.AddRange(
                    new Book { Title = "The Great Gatsby", Author = "F. Scott Fitzgerald", Genre = "Novel", PageCount = 180 },
                    new Book { Title = "To Kill a Mockingbird", Author = "Harper Lee", Genre = "Classic", PageCount = 281 },
                    new Book { Title = "1984", Author = "George Orwell", Genre = "Dystopian", PageCount = 328 }
                );
                context.SaveChanges();
            }
        }
    }
}
