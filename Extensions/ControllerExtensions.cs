using Microsoft.AspNetCore.Mvc;
using BookCatalogManagementApp.Responses;

namespace BookCatalogManagementApp.Extensions
{
    public static class ControllerExtensions
    {
        public static IActionResult HandleResponse<T>(
            this Controller controller,
            ServiceResponse<T> response,
            Func<T, IActionResult> onSuccess,
            object? errorViewModel = null)
        {
            if (!string.IsNullOrWhiteSpace(response.Message))
            {
                var key = response.Success ? "SuccessMessage" : "ErrorMessage";
                controller.TempData[key] = response.Message;
            }

            if (response.Success)
            {
                return onSuccess(response.Data!);
            }

            return response.ErrorCode switch
            {
                "NotFound" => controller.NotFound(response.Message),
                "ValidationError" => errorViewModel != null
                    ? controller.View(errorViewModel)
                    : controller.BadRequest(response.Message),
                "Unauthorized" => controller.Unauthorized(),
                "NoContent" => controller.NoContent(),
                _ => controller.StatusCode(500, response.Message ?? "Bilinmeyen hata")
            };
        }
    }
}
