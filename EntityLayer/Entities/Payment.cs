using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
    public class Payment
    {
        public class RC_Payment : BaseEntity
        {
            public long Id { get; set; }
            public DateTime NextPaymentDate { get; set; }
            public long PayoutOptions { get; set; }
            public long TransferEntireBalance { get; set; }
            public long TransferAmount { get; set; }
            public long FrequencyId { get; set; }

            [ForeignKey("FrequencyId")]
            public virtual LookUp_Frequency Frequency { get; set; }
        }
        public class LookUp_Frequency : BaseEntity
        {
            public long Id { get; set; }
            public string Name { get; set; }
        }
    }
}
