using System;
using System.Security.Cryptography;
using System.Text;

namespace KTCommon.Security
{
    public static class CryptographyHelper
    {
        public static Tuple<byte[], byte[]> CreateAesKeyAndIV()
        {
            using (var aes = Aes.Create())
            {
                aes.GenerateKey();
                aes.GenerateIV();
                return new Tuple<byte[], byte[]>(aes.Key, aes.IV);
            }
        }

        private static Aes CreateAes(byte[] key, byte[] iv)
        {
            var aes = Aes.Create();
            aes.Key = key;
            aes.IV = iv;
            return aes;
        }

        public static string EncryptAes(string source, byte[] key, byte[] iv)
        {
            byte[] sourceBytes = Encoding.UTF8.GetBytes(source);
            using (var aes = CreateAes(key, iv))
            using (ICryptoTransform transform = aes.CreateEncryptor())
            {
                return Convert.ToBase64String(transform.TransformFinalBlock(sourceBytes, 0, sourceBytes.Length));
            }
        }
        public static string DecryptAes(string encryptData, byte[] key, byte[] iv)
        {
            var encryptBytes = Convert.FromBase64String(encryptData);
            var aes = CreateAes(key, iv);

            ICryptoTransform transform = aes.CreateDecryptor();

            return Encoding.UTF8.GetString(transform.TransformFinalBlock(encryptBytes, 0, encryptBytes.Length));
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
