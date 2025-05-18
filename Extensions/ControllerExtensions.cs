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
            object? errorView = null)
        {
            if (response.Success)
            {
                controller.TempData["SuccessMessage"] = response.Message;
                return onSuccess(response.Data);
            }

            if (!string.IsNullOrEmpty(response.Message))
            {
                controller.TempData["ErrorMessage"] = response.Message;
                if (response.ErrorCode == "ValidationError")
                    controller.ModelState.AddModelError(string.Empty, response.Message);
            }

            return response.ErrorCode switch
            {
                "NotFound" => controller.NotFound(response.Message),
                "ValidationError" => errorView != null ? controller.View(errorView) : controller.BadRequest(response.Message),
                "Unauthorized" => controller.Unauthorized(),
                "NoContent" => controller.NoContent(),
                _ => controller.StatusCode(500, response.Message ?? "Bilinmeyen hata")
            };
        }
    }

}
