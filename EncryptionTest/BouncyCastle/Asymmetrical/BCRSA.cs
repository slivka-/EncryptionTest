using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.Crypto.Engines;

namespace EncryptionTest.BouncyCastle.Asymmetrical
{
    class BCRSA
    {
        private static AsymmetricCipherKeyPair keys;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            byte[] data = input.ToByteArray();
            var encryptEngine = new RsaEngine();
            encryptEngine.Init(true, keys.Private);
            return encryptEngine.ProcessBlock(data, 0, data.Length);
        }

        public static string Decrypt(byte[] input)
        {
            InitializeEncryption();
            var decryptEngine = new RsaEngine();
            decryptEngine.Init(false, keys.Public);
            return decryptEngine.ProcessBlock(input, 0, input.Length).ToStringUTF();
        }

        private static void InitializeEncryption()
        {
            if (keys == null)
            {
                RsaKeyPairGenerator g = new RsaKeyPairGenerator();
                g.Init(new KeyGenerationParameters(new SecureRandom(), 1024));
                keys = g.GenerateKeyPair();
            }
        }
        
    }
}
