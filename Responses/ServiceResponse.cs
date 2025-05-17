namespace BookCatalogManagementApp.Responses
{
    public class ServiceResponse<T>
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public T? Data { get; set; }
        public string? ErrorCode { get; set; }
    }
}
