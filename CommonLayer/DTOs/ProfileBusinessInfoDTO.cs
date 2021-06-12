using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
   public class ProfileBusinessInfoDTO
    {
        public long Id { get; set; }
        public string BusinessName { get; set; }
        public string BusinessEmail { get; set; }
        public string ContactNo { get; set; }
        public string AlternativeNumber { get; set; }
        public string BusinessLogo { get; set; }
        public string BusinessDescription { get; set; }
        public string CategoryName { get; set; }
        public long CategoryID { get; set; }
        public string subCategory { get; set; }
        public long subCategoryID { get; set; }
        public string BusinessRegisterationNumber { get; set; }
        public string BusinessGst { get; set; }
        public string FamilyName { get; set; }
        public string FirstName { get; set; }
        public string PersonalGreetingAll { get; set; }
        public int? JobTitle { get; set; }
    }
}
