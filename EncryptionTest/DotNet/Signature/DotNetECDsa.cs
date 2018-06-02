using System;
using System.Security.Cryptography;

namespace EncryptionTest.DotNet.Signature
{
    class DotNetECDsa
    {
        private static byte[] key = null;

        public static Tuple<byte[],byte[]> SignMessage(string input)
        {
            byte[] data = input.ToByteArray();
            byte[] signature;
            using (ECDsaCng dsa = new ECDsaCng())
            {
                dsa.HashAlgorithm = CngAlgorithm.Sha256;
                key = dsa.Key.Export(CngKeyBlobFormat.EccPublicBlob);
                signature = dsa.SignData(data);
            }
            return Tuple.Create(data, signature);
        }

        public static bool CheckMessage(Tuple<byte[], byte[]> msg)
        {
            using (ECDsaCng dsa = new ECDsaCng(CngKey.Import(key, CngKeyBlobFormat.EccPublicBlob)))
            {
                if (dsa.VerifyData(msg.Item1, msg.Item2))
                    return true;
                else
                    return false;
            }
        }

    }
}
