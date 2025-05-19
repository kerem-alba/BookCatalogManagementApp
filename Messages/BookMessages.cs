namespace BookCatalogManagementApp.Messages
{
    public static class BookMessages
    {
        public static string ListSuccess(int count) => $"Toplam {count} kitap listelendi.";
        public static string ListError => "Kitap listesi alınırken bir hata oluştu.";
        public static string ValidationError => "Kitap doğrulama hatası.";
        public static string NotFound(int id) => $"{id} id'sine sahip bir kitap bulunamadı.";
        public static string DetailsSuccess(int id) => $"{id} id'sine sahip kitap detayları getirildi.";

        public static string CreateSuccess => "Kitap başarıyla eklendi.";
        public static string CreateError => "Kitap eklenirken bir hata oluştu.";

        public static string UpdateSuccess => "Kitap başarıyla güncellendi.";
        public static string UpdateError => "Kitap güncellenirken bir hata oluştu.";
        public static string UpdateNotFound(int id) => $"Güncellenecek kitap bulunamadı. Id = {id}";

        public static string DeleteSuccess => "Kitap başarıyla silindi.";
        public static string DeleteError => "Kitap silinirken bir hata oluştu.";
        public static string DeleteNotFound(int id) => $"Silinecek kitap bulunamadı. Id = {id}";


        // Validator mesajları
        public const string TitleEmpty = "Başlık boş olamaz.";
        public const string AuthorEmpty = "Yazar adı boş olamaz.";
        public const string GenreEmpty = "Tür boş olamaz.";
        public const string InvalidPageCount = "Sayfa sayısı 0'dan büyük olmalıdır.";
        public const string InvalidId = "Geçersiz kitap ID.";
    }
}
