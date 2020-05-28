using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using RubSort.DataStorageSystem;
using RubSort.DataStorageSystem.Dbo;

namespace RubSort.IdentitySystem
{
    public class AuthenticationManager
    {
        private readonly IEntityRepository<UserDbo> userRepository;
        
        public AuthenticationManager(IEntityRepository<UserDbo> userRepository)
        {
            this.userRepository = userRepository;
        }

        public bool IsRegisteredUser(string userEmail)
        {
            return userRepository.Get().FirstOrDefault(u => u.Email == userEmail) != default(UserDbo);
        }

        public void ChangePassword(string userEmail, string password)
        {
            userRepository.Update(new UserDbo()
            {
                Email = userEmail, 
                Password = Encryption.EncryptPasswordMD5(password, userEmail)
            });
        }

        public ClaimsIdentity Register(string userEmail, string password)
        {
            if (IsRegisteredUser(userEmail))
                return null;
            
            userRepository.Add(new UserDbo()
            {
                Email = userEmail, 
                Password = Encryption.EncryptPasswordMD5(password, userEmail)
            });
            return Login(userEmail);
        }

        public ClaimsIdentity Login(string userEmail)
        {
            if(!IsRegisteredUser(userEmail))
                return null;
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userEmail)
            };
            return new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
    }
}