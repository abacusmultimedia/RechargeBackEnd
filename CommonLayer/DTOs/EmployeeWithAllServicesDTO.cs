using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class EmployeeWithAllServicesDTO
    {
        public string FullName { get; set; }
        public string JobTitle { get; set; }
        public List<ServicesDTO> Services { get; set; } = new List<ServicesDTO>();
    }
}
