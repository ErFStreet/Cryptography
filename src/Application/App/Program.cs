using Constant.Instructions;

namespace App
{
    public class Program
    {
        public static readonly string key = "AoKeY901LJNMErFCodepOwer";

        public static readonly string data = "ErF - Code";

        static void Main(string[] args)
        {
            // Hash Data

            HashData(data: data);

            // Encryption & Decryption  

            var cipherText = EncryptData(data: data);

            DecryptionData(cipherText: cipherText);
        }

        // Methods
        public static void HashData(string data)
        {
            var hashData =
                CryptionHelper.ComputeHashMD5(data: data);

            Console.WriteLine(value: $"Hash Data : {hashData} \n");
        }

        public static string EncryptData(string data)
        {
            var encryptData =
               CryptionHelper.Encrypt(key: key, plainText: data);

            Console.WriteLine(value: $"Encrypt Data : {encryptData} \n");

            return encryptData;
        }

        public static void DecryptionData(string cipherText)
        {
            var decrypData =
               CryptionHelper.DecryptString(key: key, cipherText: cipherText);

            Console.WriteLine(value: $"Decrypt Data : {decrypData}");
        }
    }
}
