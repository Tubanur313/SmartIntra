using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.Core.Utilities.Messages
{
    public static class Messages
    {
        public static class Add
        {
        public static string Added = "Məlumat uğurla əlavə edildi";
        public static string notAdded = "Məlumat əlavə olunmadı";

        }
        public static class Update
        {
            public static string updated = "Məlumat uğurla yeniləndi";
            public static string notUpdated = "Məlumat yenilənmədi";
            public static object confirmed = "Təsdiqləyənlər siyahısı yeniləndi";
            public static object watched = "Nəzarətçilər siyahısı yeniləndi";
            public static object redirect = "Ticket Yönləndirildi";
        }
        public static class Delete
        {
            public static string Deleted = "Məlumat silindi";
        }
        public static class Error
        {
            public static string notFound = " Məlumat tapılmadı";
            public static string notComplete = "Daxil edilən məlumatlar tam deyil";
            public static string wrongFormat = " Daxil edilən fayllar image, jpeg, png və ya gif formatında olmalıdır !";
            public static string sameName = " Bu Adla olan məlumat artıq mövcuddur, Zəhmət olmazsa yeni dəyər daxil edin";
        }
    }
}
