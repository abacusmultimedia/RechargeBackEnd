using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
   public class LedgerDTO
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public DateTime StartDate { get; set; } = DateTime.UtcNow;
        public double openingBalance { get; set; }

        public string Title { get; set; }
        public long ParentLedgerGroupID { get; set; }
    }
}
