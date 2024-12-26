using JSONPractice.Helper;

string fileName       = "Card.json";
string keyEnscryption = "NoNoNoMrFishYouDontGoToUrFamily";
string salt           = "YouGoToGrebanyTazik";

var encrypt = new CryptoConverting();
var hasher  = new Hashing();
var secure  = new Secure(encrypt, hasher, keyEnscryption, salt);

secure.SecureCardInfo(fileName);
Console.WriteLine("Secured data was added in new file.\nCheck the file in the Debug folder.");


