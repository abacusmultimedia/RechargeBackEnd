using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class SignUPStage2BusinessDTO
    {
        public string businessRegistrationNo { get; set; }
        public string businessDescription { get; set; }
        public string businessName { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string website { get; set; }
        public string contactnumber { get; set; }
        public string loyaltyMembership { get; set; }
    }
    public class SignUPStage2PersonalDTO
    {
    }
    public class SignUPStage2PartnerDTO
    {
    }
    public class SignUPStage5PartnerDTO
    {

    }
    public class SignUPStage5PersonalDTO
    {
        public string govtissuedID { get; set; }
        public string countryIssueId { get; set; }
        public string govtPhotoIDNo { get; set; }
        public string idScannedCopy { get; set; }
        public string securityQuestion1 { get; set; }
        public string securityQuestion2 { get; set; }
        public string securityQuestion3{get; set;}
    }
    public class SignUPStage5BusinessDTO
    {

    }

}
