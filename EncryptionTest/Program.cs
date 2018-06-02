﻿using System;

namespace EncryptionTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input message:");
            string inputString = Console.ReadLine();

            Console.WriteLine("=============================SYMMETRICAL==================================================");
            byte[] DotNetAESEncrypted = DotNet.Symmetrical.DotNetAES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net AES:\n{0}", DotNetAESEncrypted.ToStringUTF()));

            string DotNetAESDecrypted = DotNet.Symmetrical.DotNetAES.Decrypt(DotNetAESEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net AES:\n{0}", DotNetAESDecrypted));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            byte[] DotNetDESEncrypted = DotNet.Symmetrical.DotNetTripleDES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net DES:\n{0}", DotNetDESEncrypted.ToStringUTF()));

            string DotNetDESDecrypted = DotNet.Symmetrical.DotNetTripleDES.Decrypt(DotNetDESEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net DES:\n{0}", DotNetDESDecrypted));
            Console.WriteLine();



            Console.WriteLine("=============================HASHING======================================================");
            Console.WriteLine(string.Format("SHA265 by .Net:\n{0}", DotNet.Hashing.DotNetSHA2.GetHash(inputString)));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            Console.WriteLine(string.Format("MD5 by .Net:\n{0}", DotNet.Hashing.DotNetMD5.GetHash(inputString)));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}
