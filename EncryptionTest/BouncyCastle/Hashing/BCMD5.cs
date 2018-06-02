using Org.BouncyCastle.Crypto.Digests;

namespace EncryptionTest.BouncyCastle.Hashing
{
    class BCMD5
    {
        public static string GetHash(string input)
        {
            byte[] data = input.ToByteArray();
            MD5Digest h = new MD5Digest();
            h.BlockUpdate(data, 0, data.Length);
            byte[] outputArr = new byte[h.GetDigestSize()];
            h.DoFinal(outputArr, 0);
            return outputArr.ToHexString();
        }
    }
}
