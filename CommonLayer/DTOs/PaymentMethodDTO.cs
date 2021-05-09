using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    class PaymentMethodDTO
    {
        public string paymentMethod { get; set; }
        public string cardHolderName { get; set; }
        public string expiryDate { get; set; }
        public string Cvv { get; set; }
        public string postalAddress { get; set; }
    }
}
