﻿using System;
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
            //todo
            throw new NotImplementedException();
        }

        public ValidationResult<User> ToDomainModel()
        {
            var validationResult = Validate();
            
            throw new NotImplementedException();
        }
    }
}