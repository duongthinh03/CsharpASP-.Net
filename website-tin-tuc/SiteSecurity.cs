using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace website_tin_tuc
{
    public static class SiteSecurity
    {
        private const string HashPrefix = "S:";

        public static bool IsLoggedIn()
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return false;
            }

            object value = HttpContext.Current.Session["isLoggedIn"];
            return value != null && (bool)value;
        }

        public static bool IsAdmin()
        {
            if (HttpContext.Current == null || HttpContext.Current.Session == null)
            {
                return false;
            }

            object value = HttpContext.Current.Session["admin"];
            return value != null && (bool)value;
        }

        public static string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hash = sha256.ComputeHash(bytes);
                return HashPrefix + Convert.ToBase64String(hash);
            }
        }

        public static bool VerifyPassword(string savedPassword, string inputPassword)
        {
            if (string.IsNullOrEmpty(savedPassword))
            {
                return false;
            }

            if (savedPassword.StartsWith(HashPrefix, StringComparison.Ordinal))
            {
                return string.Equals(savedPassword, HashPassword(inputPassword), StringComparison.Ordinal);
            }

            return string.Equals(savedPassword, inputPassword, StringComparison.Ordinal);
        }

        public static bool NeedsPasswordUpgrade(string savedPassword)
        {
            return !string.IsNullOrEmpty(savedPassword)
                && !savedPassword.StartsWith(HashPrefix, StringComparison.Ordinal);
        }
    }
}
