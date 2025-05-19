using BookCatalogManagementApp.Dtos;
using BookCatalogManagementApp.Models;
using BookCatalogManagementApp.Repositories;
using BookCatalogManagementApp.Extensions;
using BookCatalogManagementApp.Responses;
using BookCatalogManagementApp.Validators;
using BookCatalogManagementApp.Messages;
using Serilog;
using Humanizer;

namespace BookCatalogManagementApp.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IBookValidator _bookValidator;

        public BookService(IBookRepository repository, IBookValidator bookValidator)
        {
            _repository = repository;
            _bookValidator = bookValidator;
        }

        public async Task<ServiceResponse<List<BookDto>>> GetAllAsync()
        {
            try
            {
                var books = await _repository.GetAllAsync();
                var dtoList = books.Select(b => b.ToDto()).ToList();

                Log.Information(BookMessages.ListSuccess(dtoList.Count));

                return new ServiceResponse<List<BookDto>>
                {
                    Success = true,
                    Data = dtoList
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, BookMessages.ListError);

                return new ServiceResponse<List<BookDto>>
                {
                    Success = false,
                    Message = BookMessages.ListError,
                    ErrorCode = "ListFailed"
                };
            }
        }

        public async Task<ServiceResponse<BookDto>> GetByIdAsync(int id)
        {
            try
            {
                var book = await _repository.GetByIdAsync(id);
                if (book == null)
                {
                    Log.Warning(BookMessages.NotFound(id));

                    return new ServiceResponse<BookDto>
                    {
                        Success = false,
                        Message = BookMessages.NotFound(id),
                        ErrorCode = "NotFound"
                    };
                }

                Log.Information(BookMessages.DetailsSuccess(id));

                return new ServiceResponse<BookDto>
                {
                    Success = true,
                    Data = book.ToDto(),
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, BookMessages.ListError);

                return new ServiceResponse<BookDto>
                {
                    Success = false,
                    Message = BookMessages.ListError,
                    ErrorCode = "GetFailed"
                };
            }
        }

        public async Task<ServiceResponse<string>> AddAsync(CreateBookDto dto)
        {
            if (!_bookValidator.Validate(dto, out var validationErrorMessage))
            {
                Log.Warning("{Message}: {ValidationError}", BookMessages.ValidationError, validationErrorMessage);
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = validationErrorMessage,
                    ErrorCode = "ValidationError"
                };
            }

            try
            {
                var book = dto.ToEntity();
                await _repository.AddAsync(book);

                Log.Information(BookMessages.CreateSuccess + " {@Book}", dto);

                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = BookMessages.CreateSuccess
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, BookMessages.CreateError);

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = BookMessages.CreateError,
                    ErrorCode = "CreateFailed"
                };
            }
        }

        public async Task<ServiceResponse<string>> UpdateAsync(UpdateBookDto dto)
        {
            if (!_bookValidator.Validate(dto, out var validationErrorMessage))
            {
                Log.Warning("{Message}: {ValidationError}", BookMessages.ValidationError, validationErrorMessage);
                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = validationErrorMessage,
                    ErrorCode = "ValidationError"
                };
            }

            try
            {
                var existing = await _repository.GetByIdAsync(dto.Id);
                if (existing == null)
                {
                    Log.Warning(BookMessages.UpdateNotFound(dto.Id));

                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = BookMessages.UpdateNotFound(dto.Id),
                        ErrorCode = "NotFound"
                    };
                }

                existing.UpdateEntity(dto);
                await _repository.UpdateAsync(existing);

                Log.Information(BookMessages.UpdateSuccess + " {@Book}", dto);

                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = BookMessages.UpdateSuccess
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, BookMessages.UpdateError);

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = BookMessages.UpdateError,
                    ErrorCode = "UpdateFailed"
                };
            }
        }

        public async Task<ServiceResponse<string>> DeleteAsync(int id)
        {
            try
            {
                var existing = await _repository.GetByIdAsync(id);
                if (existing == null)
                {
                    Log.Information(BookMessages.DeleteNotFound(id));

                    return new ServiceResponse<string>
                    {
                        Success = false,
                        Message = BookMessages.DeleteNotFound(id),
                        ErrorCode = "NoContent"
                    };
                }

                await _repository.DeleteAsync(id);

                Log.Information(BookMessages.DeleteSuccess + "{@Book}", existing);

                return new ServiceResponse<string>
                {
                    Success = true,
                    Message = BookMessages.DeleteSuccess
                };
            }
            catch (Exception ex)
            {
                Log.Error(ex, BookMessages.DeleteError);

                return new ServiceResponse<string>
                {
                    Success = false,
                    Message = BookMessages.DeleteError,
                    ErrorCode = "DeleteFailed"
                };
            }
        }
    }
}
