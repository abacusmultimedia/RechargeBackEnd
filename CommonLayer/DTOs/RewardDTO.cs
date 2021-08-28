using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
   public class RewardDTO
    {
        public long Id { get; set; }
        public string Membership { get; set; }
        public string MembershipNumber { get; set; }
        public int RewardCheckBoxValue { get; set; }
        public long EmployeeId { get; set; }
        public long RewardId { get; set; }
    }
}
