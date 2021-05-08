using EntityLayer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class ExtendedUser : IdentityUser//, ISoftDelete
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string TenantId { get; set; }
        public bool IsSignUpCompleted { get; set; }
        public string SecondaryPhoneNumber { get; set; }
        public string Address { get; set; }
        public bool MemberStatus { get; set; }
        public string TimeZone { get; set; }
        public string ImageName { get; set; }
        public string BlobURI { get; set; }
        public int? JobTitleId { get; set; }
        public int? CompensationTypeId { get; set; }
        public int? CurrencyTypeId { get; set; }
        public int? CompensationAmountId { get; set; }
        public int? CityId { get; set; }
        public int? ContactId { get; set; }
        public bool IsDeleted { get; set; }
        public bool RecieveProductEmails { get; set; }
        public bool RecieveNotifications { get; set; }
        public bool IsPersonalSettingsCompleted { get; set; }
        public int ProfileCompletion { get; set; }
        public string StripeCustomerId { get; set; }
        public string PeronalGreeting { get; set; }
        public DateTime DateOfBirth { get; set; } = DateTime.UtcNow;
        public int CountryId { get; set; }
        public string Address2 { get; set; }
        public int StateProvinceID { get; set; }
        public string ZiPcode { get; set; }
        public string PhysicalAddress { get; set; }
    }
}