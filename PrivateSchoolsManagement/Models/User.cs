﻿using System.ComponentModel.DataAnnotations;

namespace PrivateSchoolsManagement.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Role { get; set; }
        public  DateTime Created { get; set; }
    }
}