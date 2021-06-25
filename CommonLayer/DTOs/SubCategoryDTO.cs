using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
   public class SubCategoryDTO
    {
        public long Id { get; set; }
        public string SubCategoryName { get; set; }
        public int ParentId { get; set; }
        public int SubOrderBy { get; set; }
    }
}
