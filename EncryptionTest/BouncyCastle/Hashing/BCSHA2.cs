using Org.BouncyCastle.Crypto.Digests;

namespace EncryptionTest.BouncyCastle.Hashing
{
    class BCSHA2
    {
        public static string GetHash(string input)
        {
            byte[] data = input.ToByteArray();
            Sha256Digest h = new Sha256Digest();
            h.BlockUpdate(data, 0, data.Length);
            byte[] outputArr = new byte[h.GetDigestSize()];
            h.DoFinal(outputArr, 0);
            return outputArr.ToHexString();
        }
    }
}
