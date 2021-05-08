using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{

    public class ProfileAboutUsDTO :BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; } 
        public string ImageUrl { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 

    }
    public class Profile_Whoweare : BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; } 
        public string Description { get; set; } 

    }
    public class Profile_WhyUs : BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; } 
        public string Url { get; set; } 
        public string Title { get; set; } 
        public string Profile_Title_Subpage { get; set; } 
    }
    public class Profile_Process : BaseDTO
    { 
        public int Key { get; set; } 
        public string icon { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; }

        public int Profile_Key { get; set; }
        public string SequanceNo { get; set; } 
    }
    public class Profile_Settings : BaseDTO
    { 
        public int Key { get; set; }          
        public string Blogo { get; set; }        
        public string Flogo { get; set; }        
        public string Hlogo { get; set; }
        public int Templete { get; set; }
        public int IconeType { get; set; }
        public int buttonStyle { get; set; }
        public string FooterColorCode { get; set; }
        public int Profile_Key { get; set; }  
    }
    public class Profile_Title_Subpage : BaseDTO
    {
        public int Key { get; set; }
        public int Profile_Key { get; set; }

    }
    public class Profile_Video : BaseDTO
    {
        public int Key { get; set; }
        
        public string Url { get; set; }
        public string Title { get; set; }
        public int Profile_Title_Subpage { get; set; }
        public int Profile_Key { get; set; }
    }
    public class Profile_Title_Subpage_SliderImages : BaseDTO
    {

        public int Key { get; set; }
        public int Profile_Title_Subpage_Key { get; set; }

        
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class Profile_Galary : BaseDTO
    {

        public int Key { get; set; }
        public int Profile_Key { get; set; }

        
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

    }
    public class Profile_ClientTestimonials : BaseDTO
    {
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        public string Client_Key { get; set; }
        public string client_message { get; set; }
    }
    public class Profile_Map_Locations : BaseDTO
    {

        public int Key { get; set; }
        public int Profile_Key { get; set; }
    }
    public class Profile_Our_Services : BaseDTO
    { 
        public int Key { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Profile_Key { get; set; } 
    }
    public class Pricing : BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
    }
    public class Pricing_Features : BaseDTO
    { 
        public int Key { get; set; }
        public int Pricing_Key { get; set; }
        public string Title { get; set; }
        public string Value { get; set; } 
    }
    public class OurBolg : BaseDTO
    { 
        public int Key { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public int Profile_Key { get; set; } 
    }
    public class SearchFeature : BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; } 
    }
    public class LatestNews : BaseDTO
    {
        public int Key { get; set; }
        public string Url { get; set; }
        public int Profile_Key { get; set; }
    }
    public class BlogsandNew : BaseDTO
    { 
        public int Key { get; set; }
        public int Profile_Key { get; set; } 

    }

}
