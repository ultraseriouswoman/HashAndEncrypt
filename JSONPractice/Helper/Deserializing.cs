using JSONPractice.Model;
using Newtonsoft.Json;

namespace JSONPractice.Helper
{
    public class Deserializing
    {
        public static CardList DeserializeJSON(string file)
        {
            var cardList = JsonConvert.DeserializeObject<CardList>(file)!;
            return cardList;
        }
    }
}
