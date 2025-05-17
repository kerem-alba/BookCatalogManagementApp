using BookCatalogManagementApp.Dtos;

namespace BookCatalogManagementApp.Validators
{
    public class BookValidator : IBookValidator
    {
        public bool Validate(CreateBookDto dto, out string? errorMessage)
        {
            if (string.IsNullOrWhiteSpace(dto.Title))
            {
                errorMessage = "Başlık boş olamaz.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(dto.Author))
            {
                errorMessage = "Yazar adı boş olamaz.";
                return false;
            }

            if (dto.PageCount <= 0)
            {
                errorMessage = "Sayfa sayısı 0'dan büyük olmalıdır.";
                return false;
            }

            errorMessage = null;
            return true;
        }

        public bool Validate(UpdateBookDto dto, out string? errorMessage)
        {
            if (dto.Id <= 0)
            {
                errorMessage = "Geçersiz kitap ID.";
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
