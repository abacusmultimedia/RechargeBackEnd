using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class SignUPStage2BusinessDTO
    {
        public string businessName { get; set; }
        public int category { get; set; }
        public int subCategory { get; set; }
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
        public string loyaltyMembership { get; set; }
    }
    public class SignUPStage2PartnerDTO
    {
    }
    public class SignUPStage5PartnerDTO
    {
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public int SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
        public string businessGSTNo { get; set; }
        public string uploadBusinessRegistrationNo { get; set; } // ImgUrl
        public string accountManagerID { get; set; } // ImgUrl
        public string authorizedPerson { get; set; }
        public string termsAndConditions { get; set; }

    }

    public class Partner_BusinessInfo
    {
        public string businessGSTNo { get; set; }
        public string uploadBusinessRegistrationNo { get; set; } // ImgUrl
        public string accountManagerID { get; set; } // ImgUrl
        public string authorizedPerson { get; set; }

    }


    public class SignUPStage5PersonalDTO
    {
        public string GovtissuedID { get; set; }
        public int countryIssueId { get; set; }
        public string GovtPhotoIDNo { get; set; }
        public string IdScannedCopy { get; set; }
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public int SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
        public string URLIf { get; set; }

    }

    public class QsAndAsDTO
    {
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public int SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
    }

    public class SignUPStage5BusinessDTO
    {
        public string familyName { get; set; }
        public string firstName { get; set; }
        public string personalGreeting { get; set; }
        public string mobileNumber { get; set; }

        public string typeOfGovtID { get; set; }
        public int countryIssuingPhotoID { get; set; }
        public string govtPhotoIDNo { get; set; }
        public string uploadScannedCopyID { get; set; }
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public int SecurityQuestion3 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string SecurityAnswer3 { get; set; }
        public string termsAndConditions { get; set; }
        public string authorizedPerson { get; set; }
    }

}
