using System.Text.RegularExpressions;

namespace SmartIntranet.Core.Extensions
{
    public static class CreateUsername
    {
        public static string FixUsername(string username)
        {
            if (string.IsNullOrEmpty(username)) return "";
            username = username.ToLower();
            username = username.Trim();
            if (username.Length > 100)
            {
                username = username.Substring(0, 100);
            }
            username = username.Replace("İ", "I");
            username = username.Replace("ı", "i");
            username = username.Replace("ğ", "g");
            username = username.Replace("Ğ", "G");
            username = username.Replace("ç", "c");
            username = username.Replace("Ç", "C");
            username = username.Replace("ö", "o");
            username = username.Replace("Ö", "O");
            username = username.Replace("ş", "s");
            username = username.Replace("Ş", "S");
            username = username.Replace("ü", "u");
            username = username.Replace("Ü", "U");
            username = username.Replace("ə", "e");
            username = username.Replace("Ə", "E");
            username = username.Replace("'", "");
            username = username.Replace("\"", "");
            username = username.Replace(" ", "");
            char[] replacerList = @"$%#@!*?;:~`+=()[]{}|\'<>,/^""&".ToCharArray();
            for (int i = 0; i < replacerList.Length; i++)
            {
                string strChr = replacerList[i].ToString();
                if (username.Contains(strChr))
                {
                    username = username.Replace(strChr, string.Empty);
                }
            }
            Regex r = new Regex("[^a-zA-Z0-9_-]");
            username = r.Replace(username, ".");
            //while (username.IndexOf("--") > -1)
            //    username = username.Replace("--", "-");
            return username;
        }
    }
}
