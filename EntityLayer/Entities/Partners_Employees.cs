using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using static EntityLayer.Entities.Payroll;

namespace EntityLayer.Entities
{
    public class RC_Partners_Employees:BaseEntity
    {
        public long ID { get; set; }
        public string F_Name { get; set; }
        public string L_Name { get; set; }
        public string ImageUrl { get; set; }

        public int JobTitle { get; set; }
        [ForeignKey("JobTitle")]
        public virtual Lookup_Job_Title Job_Title { get; set; }
       
        public string EmployerId { get; set; }
        [ForeignKey("EmployerId")]
        public virtual ExtendedUser Employeer { get; set; }

        public virtual ICollection<EmployeeServices> EmployeeServices { get; set; }

    }
}
