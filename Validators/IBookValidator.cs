using BookCatalogManagementApp.Dtos;

namespace BookCatalogManagementApp.Validators
{
    public interface IBookValidator
    {
        bool Validate(CreateBookDto dto, out string? errorMessage);
        bool Validate(UpdateBookDto dto, out string? errorMessage);
    }
}
