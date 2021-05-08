using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
    public class SBI_Project : BaseEntity
    {
        [Key]
        public int SBI_Project_Key { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string SBI_Project_ProjectName { get; set; }
        [Column(TypeName = "nvarchar(5000)")]
        public string SBI_Project_Description { get; set; }

        public string SBI_Project_owner { get; set; }

        //public int SBI_Project_Type { get; set; }
        //[ForeignKey("SBI_Project_Type")]
        //public virtual SBI_Project_Types SBI_Project_Types { get; set; }

        //public int SBI_Project_VisibilityType { get; set; }
        //[ForeignKey("SBI_Project_VisibilityType")]
        //public virtual SBI_Project_VisibilityTypes SBI_Project_VisibilityTypes { get; set; }

        [ForeignKey("SBI_Project_owner")]
        public virtual ExtendedUser Project_Owner { get; set; }

        public int SBI_Group_Key { get; set; }

        //[ForeignKey("SBI_Group_Key")]
        //public virtual SBI_Project_Groups SBI_Project_Groups { get; set; }
        public int SBI_Project_CanInviteMoreId { get; set; }
        //public virtual ICollection<SBI_Project_Features> ProductFeature { get; set; }

        //public virtual ICollection<SBI_Project_Media> SBI_Project_Media { get; set; }
        public DateTime SBI_Project_StarDate { get; set; }
        public DateTime SBI_Project_EndDate { get; set; }
        //public SBI_Project()
        //{
        //    SBI_Project_Media = new Collection<SBI_Project_Media>();
        //}
    }
}
