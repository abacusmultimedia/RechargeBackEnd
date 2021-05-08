using System;
using System.Collections.Generic;
using System.Text;

namespace EntityLayer.Entities
{
    public class BaseEntity
    { 
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string ModifiedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
