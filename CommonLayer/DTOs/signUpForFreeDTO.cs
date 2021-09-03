using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class signUpForFreeDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public string photoIDType { get; set; }
        public string countryId { get; set; }
        public string countryName { get; set; }
        public string gPhotoIdNo { get; set; }
        public string photoIDUrl { get; set; }
        public string secQuestion1 { get; set; }
        public string secQuestion2 { get; set; }
        public string secAnswer1 { get; set; }
        public string secAnswer2 { get; set; }
        public string lastName { get; set; }
        public string firstName { get; set; }
        public string greeting { get; set; }
        public string contactNo { get; set; }
        public string loyaltyMembership { get; set; }
        public string businessName { get; set; }
        public string govtbusRegNo { get; set; }
        public DateTime DOB { get; set; }
        public string jobTitle { get; set; }
        public string mobileNo { get; set; }
        public string landline { get; set; }
    }
}
