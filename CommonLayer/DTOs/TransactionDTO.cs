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
        public double Rate { get; set; }
        public double Qty { get; set; }
        public string Child_Description { get; set; }
        public string BillID { get; set; }
        public string ProviderRefNo { get; set; }
        public long ParentTransacatoinID { get; set; }
        public long DrLedger { get; set; }
        public long CrLedger { get; set; }
    }

    public class ParentTransactionDTO
    {
        public long ID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public string Description { get; set; }
        public string GUIDID { get; set; }
    }
    public class TransactionWithChildren
    {
        public ParentTransactionDTO Transaction { get; set; } = new ParentTransactionDTO();
        public List<TransactionDTO> childTransactions { get; set; } = new List<TransactionDTO>();

    }

}
