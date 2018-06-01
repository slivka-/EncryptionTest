using System.Text;

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

        public static string ToHexString(this byte[] array)
        {
            StringBuilder s = new StringBuilder();
            foreach (byte b in array)
                s.AppendFormat("{0:x2}", b);
            return s.ToString();
        }
    }
}
