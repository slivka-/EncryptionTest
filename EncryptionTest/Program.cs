using System;

namespace EncryptionTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input message:");
            string inputString = Console.ReadLine();

            #region SYMMETRICAL
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
            Console.WriteLine("------------------------------------------------------------------------------------------");

            byte[] BCAESEncrypted = BouncyCastle.Symmetrical.BCAES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by Bouncy Castle AES:\n{0}", BCAESEncrypted.ToStringUTF()));

            string BCAESDEcrypted = BouncyCastle.Symmetrical.BCAES.Decrypt(BCAESEncrypted);
            Console.WriteLine(string.Format("Decrypted by Bouncy Castle AES:\n{0}", BCAESDEcrypted));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            byte[] BCDESEncrypted = BouncyCastle.Symmetrical.BCDES.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by Bouncy Castle DES:\n{0}", BCDESEncrypted.ToStringUTF()));

            string BCDESDEcrypted = BouncyCastle.Symmetrical.BCDES.Decrypt(BCDESEncrypted);
            Console.WriteLine(string.Format("Decrypted by Bouncy Castle DES:\n{0}", BCDESDEcrypted));
            
            Console.WriteLine();
            #endregion

            #region ASYMMETRICAL
            Console.WriteLine("=============================ASYMMETRICAL=================================================");
            byte[] DotNetRSAEncrypted = DotNet.Asymmetrical.DotNetRSA.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net RSA:\n{0}", DotNetRSAEncrypted.ToStringUTF()));

            string DotNetRSADecrypted = DotNet.Asymmetrical.DotNetRSA.Decrypt(DotNetRSAEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net RSA:\n{0}", DotNetRSADecrypted));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            byte[] DotNetECDEncrypted = DotNet.Asymmetrical.DotNetECD.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by .Net ECD:\n{0}", DotNetECDEncrypted.ToStringUTF()));

            string DotNetECDDecrypted = DotNet.Asymmetrical.DotNetECD.Decrypt(DotNetECDEncrypted);
            Console.WriteLine(string.Format("Decrypted by .Net ECD:\n{0}", DotNetECDDecrypted));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            byte[] BCRSAEncrypted = BouncyCastle.Asymmetrical.BCRSA.Encrypt(inputString);
            Console.WriteLine(string.Format("Encrypted by Bouncy Castle RSA:\n{0}", BCRSAEncrypted.ToStringUTF()));

            string BCRSADecrypted = BouncyCastle.Asymmetrical.BCRSA.Decrypt(BCRSAEncrypted);
            Console.WriteLine(string.Format("Decrypted by Bouncy Castle RSA:\n{0}", BCRSADecrypted));
            Console.WriteLine();



            #endregion

            #region HASHING
            Console.WriteLine("=============================HASHING======================================================");
            Console.WriteLine(string.Format("SHA265 by .Net:\n{0}", DotNet.Hashing.DotNetSHA2.GetHash(inputString)));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            Console.WriteLine(string.Format("MD5 by .Net:\n{0}", DotNet.Hashing.DotNetMD5.GetHash(inputString)));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            Console.WriteLine(string.Format("SHA265 by Bouncy Castle:\n{0}", BouncyCastle.Hashing.BCSHA2.GetHash(inputString)));
            Console.WriteLine("------------------------------------------------------------------------------------------");

            Console.WriteLine(string.Format("MD5 by Bouncy Castle:\n{0}", BouncyCastle.Hashing.BCMD5.GetHash(inputString)));
            Console.WriteLine();
            #endregion

            #region DIGITAL SIGNATURE
            Console.WriteLine("=============================DIGITAL SIGNATURE============================================");
            var DotNetSignature = DotNet.Signature.DotNetECDsa.SignMessage(inputString);
            Console.WriteLine(string.Format("Digital Signature check by .Net:\n{0}", DotNet.Signature.DotNetECDsa.CheckMessage(DotNetSignature)));
            Console.WriteLine("------------------------------------------------------------------------------------------");
            var BCSignature = BouncyCastle.Signature.BCECDsa.SignMessage(inputString);
            Console.WriteLine(string.Format("Digital Signature check by Bouncy Castle:\n{0}", BouncyCastle.Signature.BCECDsa.CheckMessage(BCSignature)));
            #endregion

            Console.ReadLine();
        }
    }
}
