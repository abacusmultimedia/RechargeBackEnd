using EntityLayer.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Entities
{
    public class User : BaseEntity, ITenant
    {
        public int Id { get; set; }
        public string Name { get; set; }
       public string TenantId { get; set; }
    }
}
