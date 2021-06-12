using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class BusinessDetailsDTO
    {
        public int Id { get; set; }
        public string BusinessName { get; set; }

        public string CategoryName { get; set; }
        public int CategoryID { get; set; }
        public string SubCategory { get; set; }
        public int SubCategoryID { get; set; }
        public string Website { get; set; }

        public string ContactNo { get; set; }
        public string LoyaltyMembership { get; set; }
        public string Gst { get; set; }
        public string Logo { get; set; }
        public string Description { get; set; }
        public string PhysicalAddress { get; set; }
        public string Country { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
       public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
}
}
