using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Models;

namespace BookCatalogManagementApp.Extensions
{
    public static class MappingExtensions
    {
        public static BookDto ToDto(this Book book)
        {
            return new BookDto
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                Genre = book.Genre,
                PageCount = book.PageCount
            };
        }

        public static Book ToEntity(this CreateBookDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                PageCount = dto.PageCount
            };
        }

        public static void UpdateEntity(this Book book, UpdateBookDto dto)
        {
            book.Title = dto.Title;
            book.Author = dto.Author;
            book.Genre = dto.Genre;
            book.PageCount = dto.PageCount;
        }

        public static UpdateBookDto ToUpdateDto(this BookDto dto)
        {
            return new UpdateBookDto
            {
                Id = dto.Id,
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                PageCount = dto.PageCount
            };
        }

    }
}
