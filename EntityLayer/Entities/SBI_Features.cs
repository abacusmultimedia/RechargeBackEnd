using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
    public class SBI_Features : BaseEntity
    {
        [Key]
        public int SBI_Features_Key { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string SBI_Features_Title { get; set; }
        public string SBI_Features_Descriptions { get; set; }



    }
}
