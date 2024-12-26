using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using static JSONPractice.Interface.Crypto;

namespace JSONPractice.Helper
{
    public class CryptoConverting: ICrypto
    {
        public string Encrypt(string input, string key)
        {
            using var aesAlgoritm = Aes.Create();
            aesAlgoritm.Key = Encoding.UTF8.GetBytes(key.PadRight(32));
            aesAlgoritm.IV = new byte[16];

            using var encryptor = aesAlgoritm.CreateEncryptor(aesAlgoritm.Key, aesAlgoritm.IV);
            var bytesInput = Encoding.UTF8.GetBytes(input);
            var bytesEncrypted = encryptor.TransformFinalBlock(bytesInput, 0, bytesInput.Length);

            return Convert.ToBase64String(bytesEncrypted);
        }
    }
}
