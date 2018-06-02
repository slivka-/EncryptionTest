
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Security;
using System;

namespace EncryptionTest.BouncyCastle.Signature
{
    class BCECDsa
    {
        private static AsymmetricCipherKeyPair key = null;

        public static Tuple<byte[], byte[]> SignMessage(string input)
        {
            byte[] data = input.ToByteArray();
            ECKeyPairGenerator g = new ECKeyPairGenerator("ECDSA");
            var param = new KeyGenerationParameters(new SecureRandom(), 256);
            g.Init(param);
            key = g.GenerateKeyPair();
            ISigner signer = SignerUtilities.GetSigner("SHA256withECDSA");
            signer.Init(true, key.Private);
            signer.BlockUpdate(data, 0, data.Length);
            return Tuple.Create(data, signer.GenerateSignature());
        }

        public static bool CheckMessage(Tuple<byte[], byte[]> msg)
        {
            ISigner signer = SignerUtilities.GetSigner("SHA256withECDSA");
            signer.Init(false, key.Public);
            signer.BlockUpdate(msg.Item1, 0, msg.Item1.Length);
            if (signer.VerifySignature(msg.Item2))
                return true;
            else
                return false;
        }
    }
}
