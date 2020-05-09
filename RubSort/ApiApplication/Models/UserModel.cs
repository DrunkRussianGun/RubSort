using System;
using System.ComponentModel.DataAnnotations;
using RubSort.IdentitySystem;

namespace RubSort.ApiApplication.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public UserModel(string email, string password)
        {
            Email = email;
            Password = password;
        }

        public ValidationResult Validate()
        {
            //todo
            throw new NotImplementedException();
        }

        public User ToModel()//error ValidationResult<User>
        {
            //todo
            throw new NotImplementedException();
        }
    }
}