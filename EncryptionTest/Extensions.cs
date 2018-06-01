using System.Text;
using System.Security.Cryptography;

namespace EncryptionTest
{
    static class Extensions
    {
        public static byte[] ToByteArray(this string msg)
        {
            return Encoding.UTF8.GetBytes(msg);
        }

        public static string ToStringUTF(this byte[] arr)
        {
            return Encoding.UTF8.GetString(arr);
        }
    }
}
