using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class Reward : BaseEntity
    {
        public long Id { get; set; }
        public string Membership { get; set; }
        public string MembershipNumber { get; set; }
        public long EmployeeId { get; set; }
        public int RewardCheckBoxValue { get; set; }
        [ForeignKey("EmployeeId")]
        public virtual RC_Partners_Employees Employee { get; set; }
        
    }
}
