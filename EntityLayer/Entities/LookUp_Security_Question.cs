using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class LookUp_Security_Question : BaseEntity
    {
        [Key]
        public int Question_ID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public String Question_Title { get; set; }
    }
} 
