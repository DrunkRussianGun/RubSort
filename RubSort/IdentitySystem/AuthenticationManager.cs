using System;
using DataStorageSystem;

namespace IdentitySystem
{
    public class AuthenticationManager
    {
        IEntityRepository<UserDbo> _userRepository;

        public bool isRegistrredUser(string userEmail)
        {
            //todo
            throw new NotImplementedException();
        }

        public void ChangePassword(string userEmail, string password)
        {
            //todo
        }

        public void Register()//что метод принимает?
        {
            //todo
        }
    }
}