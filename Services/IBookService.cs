using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Responses;

namespace BookCatalogManagementApp.Services
{
    public interface IBookService
    {
        Task<ServiceResponse<List<BookDto>>> GetAllAsync();
        Task<ServiceResponse<BookDto>> GetByIdAsync(int id);
        Task<ServiceResponse<string>> AddAsync(CreateBookDto dto);
        Task<ServiceResponse<string>> UpdateAsync(UpdateBookDto dto);
        Task<ServiceResponse<string>> DeleteAsync(int id);
    }
}
