using System.Security.Cryptography;

namespace EncryptionTest.DotNet.Asymmetrical
{
    class DotNetRSA
    {
        private static RSACryptoServiceProvider RSA = null;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            return RSA.Encrypt(input.ToByteArray(), true);
        }

        public static string Decrypt(byte[] input)
        {
            InitializeEncryption();
            return RSA.Decrypt(input, true).ToStringUTF(); ;
        }

        private static void InitializeEncryption()
        {
            if (RSA == null)
                RSA = new RSACryptoServiceProvider();
        }
    }
}
