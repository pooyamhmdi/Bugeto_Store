using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace Bugeto_Store.Common
{
    public class PasswordHasher
    {
        private readonly KeyDerivationPrf _prf = KeyDerivationPrf.HMACSHA256;
        private readonly int _iterCount = 10000;
        private readonly int _saltLength = 16; // 128-bit
        private readonly int _subkeyLength = 32; // 256-bit

        public string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));

            byte[] salt = new byte[_saltLength];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(salt);

            byte[] subkey = KeyDerivation.Pbkdf2(password, salt, _prf, _iterCount, _subkeyLength);

            byte[] outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // IdentityV3 marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)_prf);
            WriteNetworkByteOrder(outputBytes, 5, (uint)_iterCount);
            WriteNetworkByteOrder(outputBytes, 9, (uint)_saltLength);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + salt.Length, subkey.Length);

            return Convert.ToBase64String(outputBytes);
        }

        public bool VerifyPassword(string hashedPassword, string enteredPassword)
        {
            if (string.IsNullOrEmpty(hashedPassword) || string.IsNullOrEmpty(enteredPassword)) return false;

            byte[] decoded;
            try { decoded = Convert.FromBase64String(hashedPassword); }
            catch { return false; }

            if (decoded.Length < 13) return false;
            if (decoded[0] != 0x01) return false;

            var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decoded, 1);
            var iterCount = (int)ReadNetworkByteOrder(decoded, 5);
            var saltLength = (int)ReadNetworkByteOrder(decoded, 9);

            if (decoded.Length < 13 + saltLength) return false;

            byte[] salt = new byte[saltLength];
            Buffer.BlockCopy(decoded, 13, salt, 0, saltLength);

            int subkeyLength = decoded.Length - 13 - saltLength;
            byte[] expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decoded, 13 + saltLength, expectedSubkey, 0, subkeyLength);

            byte[] actualSubkey = KeyDerivation.Pbkdf2(enteredPassword, salt, prf, iterCount, subkeyLength);

            return ByteArraysEqual(actualSubkey, expectedSubkey);
        }

        private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value);
        }

        private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)buffer[offset] << 24)
                 | ((uint)buffer[offset + 1] << 16)
                 | ((uint)buffer[offset + 2] << 8)
                 | ((uint)buffer[offset + 3]);
        }

        [MethodImpl(MethodImplOptions.NoInlining | MethodImplOptions.NoOptimization)]
        private static bool ByteArraysEqual(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            bool areSame = true;
            for (int i = 0; i < a.Length; i++) areSame &= (a[i] == b[i]);
            return areSame;
        }
    }
}