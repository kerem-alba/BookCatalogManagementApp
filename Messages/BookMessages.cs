namespace BookCatalogManagementApp.Messages
{
    public static class BookMessages
    {
        public static string ListSuccess(int count) => $"Toplam {count} kitap listelendi.";
        public static string ListError => "Kitap listesi alınırken bir hata oluştu.";

        public static string NotFound(int id) => $"{id} id'sine sahip bir kitap bulunamadı.";
        public static string DetailsSuccess(int id) => $"{id} id'sine sahip kitap detayları getirildi.";

        public static string CreateSuccess => "Kitap başarıyla eklendi.";
        public static string CreateError => "Kitap eklenirken bir hata oluştu.";

        public static string UpdateSuccess => "Kitap başarıyla güncellendi.";
        public static string UpdateError => "Kitap güncellenirken bir hata oluştu.";
        public static string UpdateNotFound(int id) => $"Güncellenecek kitap bulunamadı. Id = {id}";

        public static string DeleteSuccess(int id) => $"Kitap başarıyla silindi. Id = {id}";
        public static string DeleteError => "Kitap silinirken bir hata oluştu.";
        public static string DeleteNotFound(int id) => $"Silinecek kitap bulunamadı. Id = {id}";
    }
}
