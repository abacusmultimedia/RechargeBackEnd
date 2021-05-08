using EntityLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Entities
{
    public class Login : BaseEntity, ITenant
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
        public string UserId { get; set; }
        public string TenantId { get; set; }
    }
}
