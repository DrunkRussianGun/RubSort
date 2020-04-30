using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DataStorageSystem;

namespace IdentitySystem
{
    public class AuthenticationManager
    {
        private readonly IEntityRepository<UserDbo> _userRepository;

        public AuthenticationManager(IEntityRepository<UserDbo> userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsRegisteredUser(string userEmail)
        {
            return _userRepository.Get().FirstOrDefault(u => u.Email == userEmail) != default(UserDbo);
        }

        public void ChangePassword(string userEmail, string password)
        {
            _userRepository.Update(new UserDbo() { Email = userEmail, Password = EncryptPassword(password, userEmail) });
        }

        public Task<ClaimsIdentity> Register(string userEmail, string password)//что метод принимает?
        {
            if(!IsRegisteredUser(userEmail))
                return new Task<ClaimsIdentity>(null);
            _userRepository.Add(new UserDbo() {Email = userEmail, Password = EncryptPassword(password, userEmail)});
            return Login(userEmail);
        }

        private string EncryptPassword(string password, string userEmail)
        {
            var pass = Encoding.UTF8.GetBytes(password);
            var entropy = GetEntropy(password + userEmail);
            var protectedPass = ProtectedData.Protect(pass, entropy, DataProtectionScope.LocalMachine);
            return Convert.ToBase64String(protectedPass);
        }
        
        private byte[] GetEntropy(string entropyString)
        {
            var md5 = MD5.Create();
            return md5.ComputeHash(Encoding.UTF8.GetBytes(entropyString));
        }
        
        public async Task<ClaimsIdentity> Login(string userName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}