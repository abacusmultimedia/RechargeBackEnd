using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class LookUp_State : BaseEntity
    {
        [Key]
        public long StateID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public String StateName { get; set; }
        public long  CountryID { get; set; }
        public virtual ICollection<LookUp_City> Cities { get; set; }
        [ForeignKey("CountryID")]
        public virtual LookUp_Country  Country { get; set; }

    }

    public class LookUp_City : BaseEntity
    {
        [Key]
        public long CityID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string CityName { get; set; }
        public long StateID { get; set; }
        [ForeignKey("StateID")]
        public virtual LookUp_State States { get; set; }
        
    }
    public class LookUp_Country : BaseEntity
    {
        [Key]
        public long CountryID { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string CountryName { get; set; }
        public virtual ICollection<LookUp_State> States { get; set; }
 
    }
}