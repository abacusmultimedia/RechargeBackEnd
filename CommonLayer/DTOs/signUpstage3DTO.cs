using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class signUpstage3DTO
    {
        public string PhysicalAddress { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode{get; set;}
        public int CityId { get; set; }
    }
}
