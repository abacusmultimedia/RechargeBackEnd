using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class EmployeeServicesDTO
    {
        public long Id { get; set; }
        public long ServiceId { get; set; }
        public long ServiceProviderId { get; set; }
        public long PaymentOptionId { get; set; }
        public string EmployeeConsumerNo { get; set; }
        public long ServiceAmmount { get; set; }
        public DateTime ExpirationDate{get;set;}
    }
}
