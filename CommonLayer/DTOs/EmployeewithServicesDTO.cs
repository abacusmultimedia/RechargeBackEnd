using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class EmployeewithServicesDTO
    {
        public PartnersEmployeesDTO Employee { get; set; } = new PartnersEmployeesDTO();
        public List<EmployeeServicesDTO> Services { get; set; } = new List<EmployeeServicesDTO>();
        public RewardDTO Reward { get; set; }=  new RewardDTO();
    }
}
