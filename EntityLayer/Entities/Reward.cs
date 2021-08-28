using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
    public class Rewards
    {
        public class Reward : BaseEntity
        {
            public long Id { get; set; }
            public string Membership { get; set; }
            public string MembershipNumber { get; set; }
            public long EmployeeId { get; set; }
            public long RewardId { get; set; }
            public int RewardCheckBoxValue { get; set; }
            [ForeignKey("EmployeeId")]
            public virtual RC_Partners_Employees Employee { get; set; }
            [ForeignKey("RewardId")]
            public virtual Lookup_Reward Rewards { get; set; }
            
        }
        public class Lookup_Reward : BaseEntity
        {
            [Key]
            public long RewardId { get; set; }
            public string RewardName { get; set; }
        }
    }
}
