using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.DTOs
{
        public class CardDTO
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public string CardHoldername { get; set; }
        public string CardNumber { get; set; }
        public string ExpirationDate { get; set; }
        public string CVVCode { get; set; }
        public string BillingAddress { get; set; }
        public string Email { get; set; }
    }
}
