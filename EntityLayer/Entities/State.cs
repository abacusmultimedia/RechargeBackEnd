using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class State : BaseEntity
    {
        public long StateID { get; set; }
        public String StateName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }

    public class City : BaseEntity
    {
        public long CityID { get; set; }
        public String CityName { get; set; }
        [ForeignKey("State")]
        public long StateID { get; set; }

    }
    public class Country : BaseEntity
    {
        public long CountryID { get; set; }
        public string CountryName { get; set; }
        public virtual ICollection<State> States { get; set; }

    }
}