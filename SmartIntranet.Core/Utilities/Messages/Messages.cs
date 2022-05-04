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
            public static string Updated = "Məlumat uğurla yeniləndi";
            public static string NotUpdated = "Məlumat yenilənmədi";
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
        }
    }
}
