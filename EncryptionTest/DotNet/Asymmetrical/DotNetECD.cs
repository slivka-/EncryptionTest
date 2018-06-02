using System.IO;
using System.Security.Cryptography;

namespace EncryptionTest.DotNet.Asymmetrical
{
    class DotNetECD
    {
        private static ECDiffieHellmanCng ENC_ECDCrypto = null;
        private static byte[] ENCpublicKey = null;
        private static byte[] ENCprivateKey = null;
        private static ECDiffieHellmanCng DEC_ECDCrypto = null;
        private static byte[] DECpublicKey = null;
        private static byte[] DECprivateKey = null;

        private static byte[] IV = null;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            byte[] output = null;
            byte[] data = input.ToByteArray();
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = ENCprivateKey;
                IV = aes.IV;
                using (MemoryStream mStream = new MemoryStream())
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cStream.Write(data, 0, data.Length);
                    cStream.Close();
                    output = mStream.ToArray();
                }
            }
            return output;
        }

        public static string Decrypt(byte[] input)
        {
            InitializeEncryption();
            string output = null;
            using (Aes aes = new AesCryptoServiceProvider())
            {
                aes.Key = DECprivateKey;
                aes.IV = IV;
                using (MemoryStream mStream = new MemoryStream())
                using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    cStream.Write(input, 0, input.Length);
                    cStream.Close();
                    output = mStream.ToArray().ToStringUTF();
                }
            }
            return output;
        }

        private static void InitializeEncryption()
        {
            if (ENC_ECDCrypto == null || DEC_ECDCrypto == null)
            {
                ENC_ECDCrypto = new ECDiffieHellmanCng
                {
                    KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                    HashAlgorithm = CngAlgorithm.Sha256
                };
                ENCpublicKey = ENC_ECDCrypto.PublicKey.ToByteArray();

                DEC_ECDCrypto = new ECDiffieHellmanCng
                {
                    KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash,
                    HashAlgorithm = CngAlgorithm.Sha256
                };
                DECpublicKey = DEC_ECDCrypto.PublicKey.ToByteArray();

                ENCprivateKey = ENC_ECDCrypto.DeriveKeyMaterial(CngKey.Import(DECpublicKey, CngKeyBlobFormat.EccPublicBlob));
                DECprivateKey = DEC_ECDCrypto.DeriveKeyMaterial(CngKey.Import(ENCpublicKey, CngKeyBlobFormat.EccPublicBlob));
            }
        }
    }
}
