using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Messages;

namespace BookCatalogManagementApp.Validators
{
    public class BookValidator : IBookValidator
    {
        public bool Validate(CreateBookDto dto, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                errorMessage = BookMessages.TitleEmpty;
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Author))
            {
                errorMessage = BookMessages.AuthorEmpty;
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Genre))
            {
                errorMessage = BookMessages.GenreEmpty;
                return false;
            }

            if (dto.PageCount <= 5)
            {
                errorMessage = BookMessages.InvalidPageCount;
                return false;
            }

            errorMessage = null;
            return true;
        }

        public bool Validate(UpdateBookDto dto, out string? errorMessage)
        {
            if (dto.Id <= 0)
            {
                errorMessage = BookMessages.InvalidId;
                return false;
            }

            return Validate(new CreateBookDto
            {
                Title = dto.Title,
                Author = dto.Author,
                Genre = dto.Genre,
                PageCount = dto.PageCount
            }, out errorMessage);
        }
    }
}
