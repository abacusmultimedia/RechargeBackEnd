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
        public string URLIf { get; set; }
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
        public string FamilyName { get; set; }
        public string Firstname { get; set; }
        public string PersonalGreeting { get; set; }
        public string ContactNumber { get; set; }
        public string Landline { get; set; }
        public DateTime Dob { get; set; }
        public int JobTitleId { get; set; }
        public string BusinessName { get; set; }
        public string BusinessRegNumber { get; set; }


    }
}
    public class SignUPStage5PartnerDTO
    {
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public string SecurityAnswer1 { get; set; }
        public string SecurityAnswer2 { get; set; }
        public string BusinessGSTNo { get; set; }
        public string GvtIssuedPhotoID { get; set; } // ImgUrl
        public string UploadBusinessRegistrationNo { get; set; } // ImgUrl
    }

    public class Partner_BusinessInfo
    {
        public string BusinessGSTNo { get; set; }
        public string GvtIssuedPhotoID { get; set; } // ImgUrl
        public string UploadBusinessRegistrationNo { get; set; } // ImgUrl

    }


public class SignUPStage5PersonalDTO
{
    public string GovtissuedID { get; set; }
    public int countryIssueId { get; set; }
    public string GovtPhotoIDNo { get; set; }
    public string IdScannedCopy { get; set; }
    public int SecurityQuestion1 { get; set; }
    public int SecurityQuestion2 { get; set; }

    public string SecurityAnswer1 { get; set; }
    public string SecurityAnswer2 { get; set; }

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


