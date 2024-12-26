using System.Security.Cryptography;
using System.Text;
using static JSONPractice.Interface.Hasher;

namespace JSONPractice.Helper
{
    public class Hashing: IHasher
    {
        public string ToSHA256(string input, string salt)
        {
            using var sha256 = SHA256.Create();
            return Convert.ToBase64String(sha256.ComputeHash(Encoding.UTF8.GetBytes(input + salt)));
        }
    }
}
