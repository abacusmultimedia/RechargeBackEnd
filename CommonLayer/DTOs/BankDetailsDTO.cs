using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class BankDetailsDTO
    {
        public int Id { get; set; }
        public long ? BankID { get; set; }
        public string BranchCode { get; set; }
        public string AccountNo { get; set; }
        public string AccountHolderName { get; set; }

    }
}
