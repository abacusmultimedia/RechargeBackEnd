using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class LookUp_Type_Of_Govt_ID : BaseEntity
    {
        [Key]
        public long Type_Govt_ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public String Govt_Id_Type { get; set; }
    }
}
