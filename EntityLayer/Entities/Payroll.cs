using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
    public class Payroll
    {
        public class EmployeeServices : BaseEntity
        {
            public long EmployeeServiceId { get; set; }
            public long EmployeeId { get; set; }
            public long ServiveId { get; set; }
            public long ServiveProviderId { get; set; }

            [ForeignKey("EmployeeId")]
            public virtual RC_Partners_Employees Employee { get; set; }
            [ForeignKey("ServiveProviderId")]
            public virtual RC_Payroll_ServiceProvider ServiceProvider { get; set; }
            [ForeignKey("ServiveId")]
            public virtual RC_Payroll_Service Service { get; set; }

            public long PaymentOption { get; set; }
            public double ServiceAmount { get; set; }
            public DateTime PaymentDate { get; set; }

        }
        public class RC_Payroll_Service : BaseEntity
        {
            public long Id { get; set; }
            [Column(TypeName = "nvarchar(200)")]
            public string Title { get; set; }
            public long Type { get; set; }
        }
        public class RC_Payroll_ServiceProvider : BaseEntity
        {
            public long Id { get; set; }
            public long Type { get; set; }
            [Column(TypeName = "nvarchar(200)")]
            public string Title { get; set; }
            [Column(TypeName = "nvarchar(200)")]
            public string Discription { get; set; }
        }

    }
}
