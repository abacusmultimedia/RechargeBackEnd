using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class EmployeewithServices
    {
        public PartnersEmployeesDTO employee { get; set; } = new PartnersEmployeesDTO();
        public List<EmployeeServices> Services { get; set; } = new List<EmployeeServices>();
        public RewardDTO reward { get; set; }=  new RewardDTO();
    }
}
