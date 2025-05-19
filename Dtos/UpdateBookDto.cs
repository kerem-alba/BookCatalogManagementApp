using System.ComponentModel.DataAnnotations;

namespace BookCatalogManagementApp.Dtos
{
    public class UpdateBookDto
    {
        public int Id { get; set; }
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "Başlık alanı boş bırakılamaz.")]
        public string Title { get; set; } = null!;

        [Display(Name = "Yazar")]
        [Required(ErrorMessage = "Yazar alanı boş bırakılamaz.")]
        public string Author { get; set; } = null!;

        [Display(Name = "Tür")]
        [Required(ErrorMessage = "Tür alanı boş bırakılamaz.")]
        public string Genre { get; set; } = null!;

        [Display(Name = "Sayfa Sayısı")]
        [Required(ErrorMessage = "Sayfa sayısı boş bırakılamaz.")]
        [Range(1, int.MaxValue, ErrorMessage = "Sayfa sayısı 0'dan büyük olmalıdır.")]
        public int PageCount { get; set; }
    }
}
