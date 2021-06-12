using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class ProfilePhysicalAddressDTO
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public int ?City { get; set; } 
        public string ZipCode { get; set; }
        public int Country { get; set; }
    }
}
