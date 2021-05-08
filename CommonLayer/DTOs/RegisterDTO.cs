using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer.DTOs
{
    public class RegisterDTO : BaseDTO
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        ///public string Name { get; set; }
        public int UserType { get; set; }
        public string Contact { get; set; }
        public string CompanyName { get; set; }
        public string CompanyURL { get; set; }
        public string Logo { get; set; } 
        public bool IsEmailVerified { get; set; }
        public bool IsSignupCompleted { get; set; }
        public string role { get; set; }
    }
}