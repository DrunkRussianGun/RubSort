using System;

namespace RubSort.IdentitySystem
{
    public class User
    {
        public string Email { get; set; }

        public User(string email)
        {
            Email = email;
        }

        public bool ComparePassword(string comparePassw)
        {
            //todo
            throw new NotImplementedException();
        }
    }
}