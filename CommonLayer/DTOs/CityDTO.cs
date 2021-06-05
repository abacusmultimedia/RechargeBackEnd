using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace CommonLayer.DTOs
{
   public class CityDTO
    {
        public long CityID { get; set; }
        public String CityName { get; set; }
        public long StateID { get; set; }
    }
}
