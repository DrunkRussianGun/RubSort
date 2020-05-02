using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DataStorageSystem;

namespace IdentitySystem
{
    public class AuthenticationManager : IAuthenticationManager<ClaimsIdentity>
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
            _userRepository.Update(new UserDbo()
            {
                Email = userEmail, 
                Password = Encryption.EncryptPasswordMD5(password, userEmail)
            });
        }

        public ClaimsIdentity Register(string userEmail, string password)
        {
            if(IsRegisteredUser(userEmail))
                return null;
            _userRepository.Add(new UserDbo()
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