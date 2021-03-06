﻿using System.Security.Cryptography;

namespace EncryptionTest.DotNet.Hashing
{
    class DotNetSHA2
    {
        public static string GetHash(string input)
        {
            return SHA256.Create().ComputeHash(input.ToByteArray()).ToHexString();
        }
    }
}
