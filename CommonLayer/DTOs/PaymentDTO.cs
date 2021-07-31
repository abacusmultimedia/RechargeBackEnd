﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class PaymentDTO
    {
        public long Id { get; set; }
        public string Frequency { get; set; }
        public DateTime NextPaymentDate { get; set; }
        public long PayoutOptions { get; set; }
        public long TransferEntireBalance { get; set; }
        public long TransferAmount { get; set; }
    }
}
