﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EncryptionTest.DotNet;

namespace EncryptionTest
{
    class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Input message:");
            string inputString = Console.ReadLine();

            Console.WriteLine();
            byte[] DotNetEncrypted = DotNetAES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net AES:\n{0}", DotNetEncrypted.ToStringUTF()));

            Console.WriteLine();
            string DotNetDecrypted = DotNetAES.Decrypt(DotNetEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net AES:\n{0}", DotNetDecrypted));
            Console.WriteLine("==========================================================================================");

            Console.WriteLine();
            Console.WriteLine(string.Format("SHA265 by .Net:\n{0}", DotNetSHA2.GetHash(inputString)));
            Console.WriteLine("==========================================================================================");


            Console.ReadLine();
        }
    }
}
