﻿namespace SmartIntranet.Core.Extensions
{
  public  static class UpperCase
    {
      public  static string UppercaseFirst(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return string.Empty;
            }
            // Return char and concat substring.
            return char.ToUpper(s[0]) + s.Substring(1);
        }
    }
}
