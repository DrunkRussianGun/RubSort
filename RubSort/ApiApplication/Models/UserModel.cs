using System;
using RubSort.Core.Results;
using RubSort.IdentitySystem;

namespace RubSort.ApiApplication.Models
{
    public class UserModel
    {
        public string Email { get; set; }
        
        public string Password { get; set; }

        public ValidationResult Validate()
        {
            throw new NotImplementedException();
        }

        public User ToDomainModel()
        {
            throw new NotImplementedException();
        }
    }
}