using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PatientManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        // بررسی کد ملی
        public static bool IsValidNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                return false;

            nationalCode = nationalCode.Trim();

            if (nationalCode.Length != 10)
                return false;

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
                return false;

            // الگوریتم ساده کد ملی
            int sum = 0;
            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
            }

            int checkDigit = int.Parse(nationalCode[9].ToString());
            int remainder = sum % 11;

            return (remainder < 2 && checkDigit == remainder) ||
                   (remainder >= 2 && checkDigit == 11 - remainder);
        }

        // بررسی شماره تلفن
        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim().Replace(" ", "").Replace("-", "");
            return Regex.IsMatch(phone, @"^09\d{9}$");
        }

        // نمایش پیام خطا
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // نمایش پیام موفقیت
        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "موفقیت", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}