using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class Reward
    {
        public string Membership { get; set; }
        public string MembershipNumber { get; set; }
        public int RewardCheckBoxValue { get; set; }
        public string UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual ExtendedUser User { get; set; }
    }
}
