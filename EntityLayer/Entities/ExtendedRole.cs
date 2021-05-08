using EntityLayer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;

namespace EntityLayer.Entities
{
    public class ExtendedRole : IdentityRole//, ISoftDelete
    {
        public string Description { get; set; }
        public string TenantId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
