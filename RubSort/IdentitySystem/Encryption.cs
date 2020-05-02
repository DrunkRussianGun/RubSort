using System;
using System.Security.Cryptography;
using System.Text;

namespace IdentitySystem
{
    public static class Encryption
    {
        public static string EncryptPasswordMD5(string password, string userEmail)
        {
            var pass = Encoding.UTF8.GetBytes(password);
            var entropy = GetEntropy(password + userEmail);
            var protectedPass = ProtectedData.Protect(pass, entropy, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(protectedPass);
        }
        
        private static byte[] GetEntropy(string entropyString)
        {
            var md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(entropyString));
        }
    }
}