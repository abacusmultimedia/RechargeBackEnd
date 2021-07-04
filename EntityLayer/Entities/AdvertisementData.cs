using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityLayer.Entities
{
   public class AdvertisementData : BaseEntity
    {
        public long Id { get; set; }
        public long OptionID { get; set; }
        public long UserID { get; set; }
        public string Value { get; set; }
        public long PartnerID { get; set; }
        public long FieldID { get; set; }
    }
    public class Form : BaseEntity
    {
        public long Id { get; set; }
        public int Order { get; set; }
        public string Title { get; set; }
        public virtual ICollection<Fields> Fields { get; set; }
    }
    public class Fields : BaseEntity
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
        public virtual ICollection<Options> Options { get; set; }
        [ForeignKey("FormID")]
        public virtual Form Form { get; set; }

    }
    public class Options : BaseEntity
    {
        public long Id { get; set; }
        public long FieldID { get; set; }
        public string Title { get; set; }
        public int Order { get; set; }
        public bool isDisabled { get; set; }

        [ForeignKey("FieldID")]
        public virtual Fields Field { get; set; }

    }
}
