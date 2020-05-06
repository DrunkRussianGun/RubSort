using System;
using System.ComponentModel.DataAnnotations;
using RubSort.IdentitySystem;

namespace RubSort.ApiApplication.Models
{
    public class UserDto
    {
        public string Email;
        public string Password;

        public UserDto(string email, string password)
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