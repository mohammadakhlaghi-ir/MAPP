
using System.Security.Cryptography;
using System.Text;
using MAPP.Application.Interfaces;

namespace MAPP.Application.Security
{
    public class AesEncryptionService : IEncryptionService
    {
        private readonly byte[] _key;
        public AesEncryptionService(string key)
        {
            if (string.IsNullOrEmpty(key)) throw new ArgumentException("Key cannot be null");
            if (key.Length != 16 && key.Length != 24 && key.Length != 32)
                throw new ArgumentException("Key must be 16, 24, or 32 characters long");

            _key = Encoding.UTF8.GetBytes(key);
        }
        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV();

            using var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
            using var ms = new MemoryStream();
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            using (var sw = new StreamWriter(cs))
            {
                sw.Write(plainText);
            }

            var iv = aes.IV;
            var encryptedContent = ms.ToArray();

            var result = new byte[iv.Length + encryptedContent.Length];
            Buffer.BlockCopy(iv, 0, result, 0, iv.Length);
            Buffer.BlockCopy(encryptedContent, 0, result, iv.Length, encryptedContent.Length);

            return Convert.ToBase64String(result);
        }

        public string Decrypt(string cipherText)
        {
            var fullCipher = Convert.FromBase64String(cipherText);
            using var aes = Aes.Create();
            aes.Key = _key;

            var iv = new byte[aes.BlockSize / 8];
            var cipher = new byte[fullCipher.Length - iv.Length];

            Buffer.BlockCopy(fullCipher, 0, iv, 0, iv.Length);
            Buffer.BlockCopy(fullCipher, iv.Length, cipher, 0, cipher.Length);

            using var decryptor = aes.CreateDecryptor(aes.Key, iv);
            using var ms = new MemoryStream(cipher);
            using var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read);
            using var sr = new StreamReader(cs);

            return sr.ReadToEnd();
        }
    }
}