using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityLayer.Entities
{
    public class Configuration : BaseEntity
    {
        [Key]
        public long Key { get; set; }
        public string Value { get; set; }
    }
}
