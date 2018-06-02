using System.Security.Cryptography;
using System.IO;

namespace EncryptionTest.DotNet.Symmetrical
{
    class DotNetTripleDES
    {
        private static TripleDESCryptoServiceProvider TDESCrypto = null;
        private static byte[] Key = null;
        private static byte[] IV = null;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            byte[] output = null;

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, TDESCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

            byte[] buffer = input.ToByteArray();
            cStream.Write(buffer, 0, buffer.Length);
            cStream.FlushFinalBlock();

            output = mStream.ToArray();

            cStream.Close();
            mStream.Close();

            return output;
        }

        public static string Decrypt(byte[] input)
        {
            InitializeEncryption();
            string output = "";

            MemoryStream mStream = new MemoryStream();
            CryptoStream dStream = new CryptoStream(mStream, TDESCrypto.CreateDecryptor(Key, IV), CryptoStreamMode.Write);

            dStream.Write(input, 0, input.Length);
            dStream.FlushFinalBlock();

            output = mStream.ToArray().ToStringUTF();

            dStream.Close();
            mStream.Close();

            return output;
        }

        private static void InitializeEncryption()
        {
            if (TDESCrypto == null)
                TDESCrypto = new TripleDESCryptoServiceProvider();
            if (Key == null)
            {
                TDESCrypto.GenerateKey();
                Key = TDESCrypto.Key;
            }
            if (IV == null)
            {
                TDESCrypto.GenerateIV();
                IV = TDESCrypto.IV;
            }
        }
    }
}
