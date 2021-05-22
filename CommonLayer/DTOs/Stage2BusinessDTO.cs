using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class SignUPStage2BusinessDTO
    {
        public string businessName { get; set; }
        public string category { get; set; }
        public string subCategory { get; set; }
        public string website { get; set; }
        public string contactnumber { get; set; }
        public string loyaltyMembership { get; set; }
        public string businessRegistrationNo { get; set; }
        public string businessDescription { get; set; }
    }
    public class SignUPStage2PersonalDTO
    {
        public string familyName { get; set; }
        public string firstname { get; set; }
        public string personalGreeting { get; set; }
        public string contactNumber { get; set; }
        public string loyaltyMembership{get; set;}
    }
    public class SignUPStage2PartnerDTO
    {
    }
    public class SignUPStage5PartnerDTO
    {
        public string businessGSTNo { get; set; }
       public bool uploadBusinessRegistrationNo{get; set;}
       public string accountManagerID { get; set; }
        public string securityQuestion1 { get; set; }
        public string securityQuestion2 { get; set; }
        public string termsAndConditions { get; set; }
        public string authorizedPerson{get; set;}

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
       public string familyName{get; set;}
       public string firstName{get; set;}
       public string personalGreeting{get; set;}
       public string mobileNumber{get; set;}
       public string typeOfGovtID{ get; set; }
       public string countryIssuingPhotoID{ get; set; }
       public string govtPhotoIDNo{ get; set; }
       public bool uploadScannedCopyID { get; set; }
        public string securityQuestion1{ get; set; }
       public string securityQuestion2{ get; set; }
       public string termsAndConditions{ get; set; }
       public string authorizedPerson{ get; set; }
    }

}
