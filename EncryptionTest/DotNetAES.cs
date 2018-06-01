using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace EncryptionTest
{
    class DotNetAES
    {
        private static RijndaelManaged RMCrypto = null;
        private static byte[] Key = null;
        private static byte[] IV = null;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            byte[] output = null;

            MemoryStream mStream = new MemoryStream();
            CryptoStream cStream = new CryptoStream(mStream, RMCrypto.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

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
            CryptoStream dStream = new CryptoStream(mStream, RMCrypto.CreateDecryptor(Key, IV), CryptoStreamMode.Write);

            dStream.Write(input, 0, input.Length);
            dStream.FlushFinalBlock();

            output = mStream.ToArray().ToStringUTF();

            dStream.Close();
            mStream.Close();

            return output;
        }

        private static void InitializeEncryption()
        {
            if (RMCrypto == null)
                RMCrypto = new RijndaelManaged();
            if (Key == null)
            {
                RMCrypto.GenerateKey();
                Key = RMCrypto.Key;
            }
            if (IV == null)
            {
                RMCrypto.GenerateIV();
                IV = RMCrypto.IV;
            }
        }

    }
}
