﻿using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Security;

namespace EncryptionTest.BouncyCastle.Symmetrical
{
    class BCDES
    {
        private static PaddedBufferedBlockCipher cipher;
        private static ParametersWithIV keyParamWithIV;

        public static byte[] Encrypt(string input)
        {
            InitializeEncryption();
            byte[] inputBytes = input.ToByteArray();

            cipher.Init(true, keyParamWithIV);
            byte[] outputBytes = new byte[cipher.GetOutputSize(inputBytes.Length)];
            int length = cipher.ProcessBytes(inputBytes, outputBytes, 0);
            cipher.DoFinal(outputBytes, length);

            return outputBytes;
        }

        public static string Decrypt(byte[] input)
        {
            InitializeEncryption();
            cipher.Init(false, keyParamWithIV);
            byte[] comparisonBytes = new byte[cipher.GetOutputSize(input.Length)];
            int length = cipher.ProcessBytes(input, comparisonBytes, 0);
            cipher.DoFinal(comparisonBytes, length);

            return comparisonBytes.ToStringUTF();
        }

        private static void InitializeEncryption()
        {
            if (cipher == null || keyParamWithIV == null)
            {
                DesEngine engine = new DesEngine();
                CbcBlockCipher blockCipher = new CbcBlockCipher(engine);
                cipher = new PaddedBufferedBlockCipher(blockCipher);
                KeyParameter keyParam = new KeyParameter(GenerateArray(21));
                keyParamWithIV = new ParametersWithIV(keyParam, GenerateArray(8), 0, 8);
            }
        }

        private static byte[] GenerateArray(int length)
        {
            SecureRandom rnd = new SecureRandom();
            byte[] output = new byte[length];
            for (int i = 0; i < length; i++)
                output[i] = (byte)(rnd.Next() % 256);
            return output;
        }
    }
}
