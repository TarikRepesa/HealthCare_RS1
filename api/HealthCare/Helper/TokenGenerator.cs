using System.Security.Cryptography;
using System.Text;

namespace HealthCare.Helper
{

    public class TokenGenerator
    {

        /// <summary>
        /// Generisi alfanumericki string sa brojem znakova odredjen parametrom {size}
        /// </summary>
        /// <param name="size">Broj znakova</param>
        /// <returns>Alfanumericki string (token)</returns>
        public static string GenerisiAlfanumerickiToken(int size)
        {
            // Characters except I, l, O, 1, and 0 to decrease confusion when hand typing tokens
            var charSet = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var chars = charSet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }

        /// <summary>
        /// Generisi numericki string sa brojem znakova odredjen parametrom {size}
        /// </summary>
        /// <param name="size">Broj znakova</param>
        /// <returns>Numericki string (token)</returns>
        public static string GenerisiNumerickiToken(int size)
        {
            var charSet = "0123456789".ToLower();
            var chars = charSet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result = new StringBuilder(size);
            foreach (var b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
    }
}