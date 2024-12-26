namespace JSONPractice.Interface
{
    public class Hasher
    {
        public interface IHasher
        {
            string ToSHA256(string input, string salt);
        }
    }
}
