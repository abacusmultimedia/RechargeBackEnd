using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class AdvertisementDTO
    {
        public long Id { get; set; }
        public string ImageUrl { get; set; }
        public string Title { get; set; }
    }
    public class AdvertisementDataDTO
    {
        public long Id { get; set; }
        public long OptionID { get; set; }
        public long UserID { get; set; }
        public string Value { get; set; }
        public long PartnerID { get; set; }
        public long FieldID { get; set; }

    }
        public class FormDTO
        {
            public long Id { get; set; }
            public int Order { get; set; }
            public string Title { get; set; }
        public List<FieldsDTO> Fields { get; set; } = new List<FieldsDTO>();
        }
        public class FieldsDTO
        {
            public long Id { get; set; }
            public string FieldsName { get; set; }
            public string PlaceHolder { get; set; }
            public int Order { get; set; }
            public bool isDisabled { get; set; }
            public int ColSpan { get; set; }
            public bool isRequired { get; set; }
            public int TypeID { get; set; }
            public long FormID { get; set; }
        public List<OptionsDTO> Options { get; set; } = new List<OptionsDTO>();
    }
        public class OptionsDTO
        {
        public long Id { get; set; }
        public long FieldID { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public bool isDisabled { get; set; }
    }


    }
