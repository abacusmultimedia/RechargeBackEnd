using EntityLayer.Infrastructure;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Entities
{
    public class Accounts_Transacation  : BaseEntity
    {
        public long ID { get; set; }
        public DateTime Date { get; set; } = DateTime.UtcNow;
        public string Type { get; set; }
        public string Description { get; set; }
        public string GUIDID { get; set; }
        public ICollection<Accounts_childTransaction> childTransactions { get; set; }

    }
    public class Accounts_childTransaction : BaseEntity
    {
        public int ID { get; set; }
        public string Type { get; set; }
        public double Rate { get; set; }
        public double Qty { get; set; }
        public string Description { get; set; }
        public string BillID { get; set; }
        public string ProviderRefNo { get; set; }
        public long ParentTransacatoinID { get; set; }
        [ForeignKey("ParentTransacatoinID")]
        public virtual Accounts_Transacation Transacation { get; set; }

        [ForeignKey("LedgerDr")]
        public long DrLedgerID { get; set; }
        public Accounts_Ledger LedgerDr { get; set; }

        [ForeignKey("LedgerCr")]
        public long CrLedgerID { get; set; }
        public Accounts_Ledger LedgerCr { get; set; }



    }
    public class Accounts_Ledger : BaseEntity
    {
        public long ID { get; set; }
        public string UserID { get; set; }
        public string ChildTransacationID { get; set; }

        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public double openingBalance { get; set; } 

        public string Title { get; set; }
        public long ParentLedgerGroupID { get; set; }
        [ForeignKey("ParentLedgerGroupID")]
        public virtual Accounts_LedgerGroup LedgerGroup { get; set; }

        [InverseProperty("LedgerDr")]
        public ICollection<Accounts_childTransaction> childTransactionDr { get; set; }
        [InverseProperty("LedgerCr")]
        public ICollection<Accounts_childTransaction> childTransactionCr { get; set; }


    }
    public class Accounts_LedgerGroup : BaseEntity
    {
        public long ID { get; set; }
        public string UnderGroup { get; set; }
        public ICollection<Accounts_Ledger> Ledgers { get; set; }
    }

}