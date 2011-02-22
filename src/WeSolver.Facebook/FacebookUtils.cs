using System;
using System.Security.Cryptography;

namespace WeSolver.Facebook
{
    public static class FacebookUtils
    {

        public static byte[] HashHmac(byte[] data, byte[] key)
        {
            using (var crypto = new HMACSHA256(key))
            {
                return crypto.ComputeHash(data);
            }
        }



        public static byte[] Base64UrlDecode(string base64)
        {
            base64 = base64.PadRight(base64.Length + (4 - base64.Length % 4) % 4, '=');
            base64 = base64.Replace('-', '+').Replace('_', '/');

            return Convert.FromBase64String(base64);
        }



        public static DateTime Epoch
        {
            get { return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); }
        }



        public static DateTime ParseUnixTime(long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }
    }
}
