using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class LegalDTO
    {
        public int Id { get; set; }
        public string PhotoId { get; set; }
        public int Country { get; set; }
        public string PhotIDNumber { get; set; }
        public string ImageURL { get; set; }
        public int  SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
    }
}
