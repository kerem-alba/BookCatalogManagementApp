using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Models;
using BookCatalogManagementApp.Repositories;
using BookCatalogManagementApp.Extensions;
using BookCatalogManagementApp.Responses;
using Serilog;


namespace BookCatalogManagementApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task<ServiceResponse<List<BookDto>>> GetAllAsync()
        {
            var books = await _repository.GetAllAsync();
            var dtoList = books.Select(b => b.ToDto()).ToList();

            Log.Information("Toplam, {x} kitap listelendi.", dtoList.Count);

            return new ServiceResponse<List<BookDto>>
            {
                Success = true,
                Data = dtoList
            };
        }

        public async Task<ServiceResponse<BookDto>> GetByIdAsync(int id)
        {
            var book = await _repository.GetByIdAsync(id);
            if (book == null)
            {
                Log.Warning("{Id} id'sine sahip bir kitap bulunamadı.", id);

                return new ServiceResponse<BookDto>
                {
                    Success = false,
                    Message = "Kitap bulunamadı",
                    ErrorCode = "NotFound"
                };
            }
            Log.Information("Kitap detayları getirildi. Id = {Id}", id);

            return new ServiceResponse<BookDto>
            {
                Success = true,
                Data = book.ToDto()
            };
        }

        public async Task<ServiceResponse<string>> AddAsync(CreateBookDto dto)
        {
            var book = dto.ToEntity();
            await _repository.AddAsync(book);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Kitap başarıyla eklendi"
            };
        }

        public async Task<ServiceResponse<string>> UpdateAsync(UpdateBookDto dto)
        {
            var existing = await _repository.GetByIdAsync(dto.Id);
            if (existing == null)
            {
                Log.Warning("Güncellenecek kitap bulunamadı. Id = {Id}", dto.Id);

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Güncellenecek kitap bulunamadı"
                };
            }

            existing.UpdateEntity(dto);

            await _repository.UpdateAsync(existing);

            Log.Information("Kitap güncellendi: {@Book}", dto);


            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Kitap başarıyla güncellendi"
            };
        }

        public async Task<ServiceResponse<string>> DeleteAsync(int id)
        {
            var existing = await _repository.GetByIdAsync(id);
            if (existing == null)
            {
                Log.Information("Silinecek kitap zaten yoktu. Id = {Id}", id);

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = "Silinecek kitap bulunamadı",
                    ErrorCode = "NoContent"
                };
            }

            await _repository.DeleteAsync(id);

            Log.Information("Kitap silindi. Id = {Id}", id);

            return new ServiceResponse<string>
            {
                Success = true,
                Message = "Kitap başarıyla silindi"
            };
        }
    }
}
