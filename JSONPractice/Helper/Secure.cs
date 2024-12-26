using JSONPractice.Interface;
using JSONPractice.Model;
using Newtonsoft.Json;

namespace JSONPractice.Helper
{
    public class Secure
    {
        private readonly Crypto.ICrypto _encrypt;
        private readonly Hasher.IHasher _hasher;
        private readonly string _keyEncryption;
        private readonly string _salt;

        public Secure(Crypto.ICrypto encrypt, Hasher.IHasher hasher, string keyEncryption, string salt)
        {
            _encrypt       = encrypt;
            _hasher        = hasher;
            _keyEncryption = keyEncryption;
            _salt          = salt;
        }

        public void SecureCardInfo(string fileName)
        {
            var data = File.ReadAllText(fileName);
            var cardList = JsonConvert.DeserializeObject<CardList>(data);

            foreach (var card in cardList.Cards) 
            {
                card.Name   = _encrypt.Encrypt(card.Name, _keyEncryption);
                card.Family = _encrypt.Encrypt(card.Family, _keyEncryption);
                card.Month  =_encrypt.Encrypt(card.Month, _keyEncryption);
                card.Year   = _encrypt.Encrypt(card.Year, _keyEncryption);

                card.CVC    = _hasher.ToSHA256(card.CVC, _salt);
                card.Number = _hasher.ToSHA256(card.Number, _salt);
            }

            var securedCardInfo = JsonConvert.SerializeObject(cardList, Formatting.Indented);
            File.WriteAllText(fileName.Replace(".json", "_no_no_no_mr_fish.json"), securedCardInfo);
        }
    }
}
