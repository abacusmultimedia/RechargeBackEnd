using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class signUpstage4DTO
    {
        public long ? BankID { get; set; }
        public string BranchCode { get; set; }
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public string PaymentMethods { get; set; }
        public string CardholdersName { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string SecurityCode{get; set;}
        public bool SamePostalAddress { get; set; }
    }
}
