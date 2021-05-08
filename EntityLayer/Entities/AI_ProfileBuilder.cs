using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{

    public class AI_Profile : BaseEntity {
        [Key]
        public int Key { get; set; }
        public string Use_key { get; set; }
        public int ProfileType { get; set; }
        public virtual ICollection<AI_Profile_AboutUs> ProductFeature { get; set; }
        public virtual ICollection<AI_Profile_Whoweare>  Whoweare { get; set; }
        public virtual ICollection<AI_Profile_WhyUs>  WhyUs { get; set; }
        public virtual ICollection<AI_Profile_Process> Process { get; set; }
        public virtual ICollection<AI_Profile_Settings> Settings { get; set; }
        public virtual ICollection<AI_Profile_Title_Subpage> Title_Subpage { get; set; }
        public virtual ICollection<AI_Profile_Our_Services> AI_Profile_Our_Services { get; set; }
        public virtual ICollection<AI_Pricing> Pricing { get; set; }
        public virtual ICollection<AI_OurBolg> OurBolg { get; set; } 
        public virtual ICollection<AI_SearchFeature> SearchFeature { get; set; } 
        public virtual ICollection<AI_LatestNews> LatestNews { get; set; } 
        public virtual ICollection<AI_BlogsandNew> AI_BlogsandNew { get; set; } 
    }
    public class AI_Profile_AboutUs : BaseEntity {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        public string ImageUrl { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(6000)")]
        public string Description { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

    }
    public class AI_Profile_Whoweare : BaseEntity {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(6000)")]
        public string Description { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

    }
    public class AI_Profile_WhyUs : BaseEntity
    {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string Url { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(2000)")]
        public string Profile_Title_Subpage { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_Profile_Process : BaseEntity {
        [Key]
        public int Key { get; set; }

        [Column(TypeName = "nvarchar(1000)")]
        public string icon { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(6000)")]
        public string Description { get; set; }

        public int Profile_Key { get; set; } 
        public string SequanceNo { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_Profile_Settings : BaseEntity {
        [Key]
        public int Key { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string Blogo { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Flogo { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Hlogo { get; set; }
        public int Templete { get; set; }
        public int IconeType { get; set; }
        public int buttonStyle { get; set; }
        public string FooterColorCode { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_Profile_Title_Subpage : BaseEntity {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

        public virtual ICollection<AI_Profile_Title_Subpage_SliderImages> SliderImages { get; set; }
        
    }
    public class AI_Profile_Video : BaseEntity
    {
        [Key]
        public int Key { get; set; }
        [Column(TypeName = "nvarchar(300)")]
        public string Url { get; set; }
        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(6000)")]
        public int Profile_Title_Subpage { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_Profile_Title_Subpage_SliderImages : BaseEntity {

        public int Key { get; set; }
        public int Profile_Title_Subpage_Key { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(6000)")]
        public string Description { get; set; }

        [ForeignKey("Profile_Title_Subpage_Key")]
        public virtual AI_Profile_Title_Subpage Title_Subpage { get; set; }
    }
    public class AI_Profile_Galary : BaseEntity
    {

        public int Key { get; set; }
        public int Profile_Key { get; set; }

        [Column(TypeName = "nvarchar(300)")]
        public string ImageUrl { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Title { get; set; }

        [Column(TypeName = "nvarchar(6000)")]
        public string Description { get; set; }

        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

    }
    public class AI_Profile_ClientTestimonials : BaseEntity {
        public int Key { get; set; }
        public int Profile_Key { get; set; } 
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
        public string Client_Key { get; set; }
        [Column(TypeName = "nvarchar(6000)")]
        public string client_message { get; set; }
    }
    public class Ai_Profile_Map_Locations : BaseEntity
    {

        public int Key { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }

    public class AI_Profile_Our_Services : BaseEntity {
        [Key]
        public int Key { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_Pricing : BaseEntity {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

        public virtual ICollection<AI_Pricing_Features> Features { get; set; }
    }
    public class AI_Pricing_Features : BaseEntity
    {
        [Key]
        public int Key { get; set; }
        public int Pricing_Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        [ForeignKey("Pricing_Key")]
        public virtual AI_Pricing Price { get; set; }
    }
    public class AI_OurBolg : BaseEntity {
        [Key]
        public int Key { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_SearchFeature : BaseEntity {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_LatestNews : BaseEntity {
        [Key]
        public int Key { get; set; }
        public string Url { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }
    }
    public class AI_BlogsandNew : BaseEntity
    {
        [Key]
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        [ForeignKey("Profile_Key")]
        public virtual AI_Profile Profile { get; set; }

    }


}
