using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace PatientManagementSystem.Helpers
{
    public static class ValidationHelper
    {
        public static bool IsValidNationalCode(string nationalCode)
        {
            if (string.IsNullOrWhiteSpace(nationalCode))
                return false;

            nationalCode = nationalCode.Trim();

            if (nationalCode.Length != 10)
                return false;

            if (!Regex.IsMatch(nationalCode, @"^\d{10}$"))
                return false;

            var checkDigit = int.Parse(nationalCode[9].ToString());
            var sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(nationalCode[i].ToString()) * (10 - i);
            }

            var remainder = sum % 11;

            return (remainder < 2 && checkDigit == remainder) ||
                   (remainder >= 2 && checkDigit == 11 - remainder);
        }

        public static bool IsValidPhone(string phone)
        {
            if (string.IsNullOrWhiteSpace(phone))
                return false;

            phone = phone.Trim().Replace(" ", "").Replace("-", "");

            return Regex.IsMatch(phone, @"^0[1-9]\d{9}$");
        }

        public static bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Now && date > new DateTime(1900, 1, 1);
        }

        public static bool IsValidName(string name)
        {
            return !string.IsNullOrWhiteSpace(name) &&
                   Regex.IsMatch(name, @"^[\u0600-\u06FF\s]+$");
        }

        public static void ShowValidationError(string message)
        {
            MessageBox.Show(message, "خطای اعتبارسنجی",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public static void ShowSuccess(string message)
        {
            MessageBox.Show(message, "موفقیت",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static void ShowWarning(string message)
        {
            MessageBox.Show(message, "توجه",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}