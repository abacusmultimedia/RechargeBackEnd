using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class BankDetails
    {
        public int Id { get; set; }
        public string bank { get; set; }
        public string branchCode { get; set; }
      
        public string accountNo { get; set; }

        public string accountHolderName { get; set; }
      	
    }
}
