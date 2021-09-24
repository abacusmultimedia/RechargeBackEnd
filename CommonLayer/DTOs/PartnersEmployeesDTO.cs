using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class PartnersEmployeesDTO
    {
        public long ID { get; set; }
        public string FullName { get; set; }
        public string ImageUrl { get; set; }
        public int JobTitle { get; set; }
        public string JobTitleName { get; set; }

    }
}
