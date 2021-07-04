using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class EmployeeServices
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long ServiceProviderId { get; set; }
        public int PaymentOptionId { get; set; }
        public string EmployeeConsumerNo { get; set; }
        public long ServiceAmmount { get; set; }
        public string ExpirationDate{get;set;}
    }
}
