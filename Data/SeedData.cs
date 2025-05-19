using BookCatalogManagementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BookCatalogManagementApp.Data
{
    public class SeedData : ISeedData
    {
        private readonly ApplicationDbContext _context;

        public SeedData(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task InitializeAsync()
        {

            if (_context.Books.Any())
            {
                return;
            }

            _context.Books.AddRange(
                new Book { Title = "Tutunamayanlar", Author = "Oğuz Atay", Genre = "Roman", PageCount = 455 },
                new Book { Title = "Nutuk", Author = "M.K. Atatürk", Genre = "Söylev", PageCount = 600 },
                new Book { Title = "Sırça Köşk", Author = "Sabahattin Ali", Genre = "Hikaye", PageCount = 333 }
            );
            await _context.SaveChangesAsync();
        }
    }
}

