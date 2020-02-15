using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace KTCommon
{
    public class Security
    {
        //加密動作
        string strKey = "toyo1234";
        string strIV = "lovecode";

        // Create the file streams to handle the input and output files.
        DES des = new DESCryptoServiceProvider();

        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public string Encrypt(string input)
        {
            byte[] encrypted;

            // 記憶體串流
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                // Create the streams used for encryption.
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, des.CreateEncryptor(Encoding.UTF8.GetBytes(strKey), Encoding.UTF8.GetBytes(strIV)), CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(input, 0, input.Length);
                        //swEncrypt.Close();
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// 解密
        /// </summary>
        /// <param name="cipherText"></param>
        /// <returns></returns>
        public string Decrypt(string cipherText)
        {
            string plaintext = null;

            // 記憶體串流
            using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                // Create the streams used for decryption.
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, des.CreateDecryptor(Encoding.UTF8.GetBytes(strKey), Encoding.UTF8.GetBytes(strIV)), CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    }
}
