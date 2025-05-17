namespace BookCatalogManagementApp.Dtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; } // Güncelleme için gerekli
        public string Title { get; set; } = null!;
        public string Author { get; set; } = null!;
        public string Genre { get; set; } = null!;
        public int PageCount { get; set; }
    }
}
