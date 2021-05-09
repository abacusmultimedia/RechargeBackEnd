using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class BusinessDetailsDTO
    {
        public int Id { get; set; }
        public string businessName { get; set; }

        public string categoryName { get; set; }
        public string categoryID { get; set; }
        public string subCategory { get; set; }
        public string subCategoryID { get; set; }
        public string website { get; set; }

        public string contactNo { get; set; }
        public string loyaltyMembership { get; set; }
        public string gst { get; set; }
        public string logo { get; set; }
        public string description { get; set; }
        public string physicalAddress { get; set; }
        public string country { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
       public string city { get; set; }
        public string state { get; set; }
        public string zip { get; set; }
}
}
