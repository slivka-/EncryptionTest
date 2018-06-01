using System.Security.Cryptography;

namespace EncryptionTest.DotNet.Hashing
{
    class DotNetMD5
    {
        public static string GetHash(string input)
        {
            return MD5.Create().ComputeHash(input.ToByteArray()).ToHexString();
        }
    }
}
