using System;

namespace WinFormsApp2.Extensions
{
    public static class StringExtensions
    {
        public static bool IsMobileNumber(this string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return false;

            if (mobile.Length != 11)
                return false;

            if (!mobile.StartsWith("09"))
                return false;

            foreach (char c in mobile)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
    }
}