using EntityLayer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class RC_Profile_BusinessInfor : BaseEntity 
    {
        public long ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string BusinessName { get; set; }
        public long Category { get; set; }
        public long SubCategory { get; set; }
        public string Website { get; set; }
        public string LoyaltyMembership { get; set; }
        public string GSTNo { get; set; }
        public string Logo { get; set; }
        [Column(TypeName = "nvarchar(5000)")]
        public string Description { get; set; }
        public string BusinessRegCertificateImg { get; set; }
        public string BusinessEmail { get; set; }
        public string BusinessRegNumber { get; set; }
        public string AccountManagId { get; set; }

        public string UserID { get; set; } 
        [ForeignKey("UserID")]
        public virtual ExtendedUser User { get; set; }
        [ForeignKey("SubCategory")]
        public virtual SubCategory subcategory { get; set; }

    }
    public class RC_Profile_BankingDetails : BaseEntity
    {
        public long ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string BnakName { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string AccountHolderName { get; set; }

        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ExtendedUser User { get; set; }

    }
    public class RC_Profile_CardDetails : BaseEntity
    {
        public long ID { get; set; } 
        public long Type { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string CardHoldername { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVVCode { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string BillingAddress { get; set; }
        public string Email { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ExtendedUser User { get; set; }

    }
    public class RC_Profile_Legal : BaseEntity
    {
        public long ID { get; set; }
        public string PhotoId { get; set; }
        public int Country { get; set; }
        public string PhotIDNumber { get; set; }
        public string ImageURL { get; set; } 
        public int SecurityQuestion1 { get; set; } 
        public int SecurityQuestion2 { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Answer1 { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Answer2 { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        //public string UserID { get; set; }
        //[ForeignKey("UserID")]
        public virtual ExtendedUser User { get; set; }
        public long CountryPhotoIdIssuer { get; set; }
        [ForeignKey("CountryPhotoIdIssuer")]
        public virtual LookUp_Country CountryPhotoIssuer { get; set; }
    }

    [Table("rc_profile_loyalityMembership")]
    public class RC_Profile_LoyalityMembership : BaseEntity
    {
        public long Id { get; set; }
        [Column(TypeName = "nvarchar(500)")]
        public string MembershipName { get; set; }
    }
    [Table("rc_profile_category")]
    public class Category  : BaseEntity
    {
        public long ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        public int OrderBy { get; set; }

    }
    [Table("rc_profile_subcategory")]
    public class SubCategory : BaseEntity
    {
        public long ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Name { get; set; }
        public int OrderBy { get; set; }
        public long ParentID { get; set; }
        [ForeignKey("ParentID")]
        public virtual Category Category{ get; set; }
    }



}