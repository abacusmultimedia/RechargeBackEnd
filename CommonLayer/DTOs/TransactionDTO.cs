using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
   public class TransactionDTO
    {
        public int Account_Transaction_ID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public string Description { get; set; }
        public string GUIDID { get; set; }
        public int Account_ChildTransaction_ID { get; set; }
        public string Child_Type { get; set; }
        public string Rate { get; set; }
        public string Qty { get; set; }
        public string Child_Description { get; set; }
        public string BillID { get; set; }
        public string ProviderRefNo { get; set; }
        public long ParentTransacatoinID { get; set; }
    }
}
