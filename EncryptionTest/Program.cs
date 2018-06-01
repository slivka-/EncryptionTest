using System;

namespace EncryptionTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input message:");
            string inputString = Console.ReadLine();

            Console.WriteLine();
            byte[] DotNetEncrypted = DotNet.Symmetrical.DotNetAES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net AES:\n{0}", DotNetEncrypted.ToStringUTF()));

            Console.WriteLine();
            string DotNetDecrypted = DotNet.Symmetrical.DotNetAES.Decrypt(DotNetEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net AES:\n{0}", DotNetDecrypted));
            Console.WriteLine("==========================================================================================");

            Console.WriteLine();
            Console.WriteLine(string.Format("SHA265 by .Net:\n{0}", DotNet.Hashing.DotNetSHA2.GetHash(inputString)));
            Console.WriteLine("==========================================================================================");

            Console.WriteLine();
            Console.WriteLine(string.Format("MD5 by .Net:\n{0}", DotNet.Hashing.DotNetMD5.GetHash(inputString)));
            Console.WriteLine("==========================================================================================");

            Console.ReadLine();
        }
    }
}
