namespace Constant.Instructions;

public static class CryptionHelper
{
    // Hash Data
    public static string ComputeHashMD5(string data)
    {
        var dataBytes = System.Text.Encoding.ASCII.GetBytes(data);

        using (var md5 = MD5.Create())
        {
            var hashBytes = md5.ComputeHash(buffer: dataBytes);

            var result =
                Convert.ToHexString(inArray: hashBytes);

            return result;
        }
    }

    // Encryption
    public static string Encrypt(string key, string plainText)
    {
        var iv = new byte[16];

        byte[] array;

        using (var aes = Aes.Create())
        {
            aes.Key = System.Text.Encoding.UTF8.GetBytes(key);

            aes.IV = iv;

            var encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

            using (var memoryStream = new MemoryStream())
            {
                using (var cryptoStream =
                    new CryptoStream((Stream)memoryStream, encryptor, CryptoStreamMode.Write))
                {
                    using (var streamWriter = new StreamWriter(stream: (Stream)cryptoStream))
                    {
                        streamWriter.Write(plainText);
                    }
                }

                array = memoryStream.ToArray();
            }
        }

        var result =
            Convert.ToBase64String(inArray: array);

        return result;
    }

    // Decryption
    public static string DecryptString(string key, string cipherText)
    {
        var iv = new byte[16];

        var buffer = Convert.FromBase64String(cipherText);

        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);

            aes.IV = iv;

            var decryptor =
                aes.CreateDecryptor(aes.Key, aes.IV);

            using (MemoryStream memoryStream = new MemoryStream(buffer))
            {
                using (CryptoStream cryptoStream = new
                    CryptoStream((Stream)memoryStream, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader =
                        new StreamReader((Stream)cryptoStream))
                    {
                        return streamReader.ReadToEnd();
                    }
                }
            }
        }
    }
}
