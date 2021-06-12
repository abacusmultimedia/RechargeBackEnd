using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class ProfileSecurityInfoDTO
    {
        public string GovtIssuedPhotoId { get; set; }// Legal DTO
        public long CountryIssuePhotoId { get; set; }
        public string GovtPhotoIdNumber { get; set; }
        public string AttachPhotoId { get; set; }
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
        public string Password { get; set; }
        public bool Authentication { get; set; }
        public string GovtIssuedBusinessRegId { get; set; }
        public string AccountMangId { get; set; }
        public string AttachBusinessRegId {get; set;}
    }
    
}

