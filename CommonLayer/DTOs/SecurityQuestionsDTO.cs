using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class SecurityQuestionsDTO
    {
        public string Email { get; set; }
        public int SecurityQuestion1 { get; set; }
        public int SecurityQuestion2 { get; set; }
        public string Answer1 { get; set; }
        public string Answer2 { get; set; }
    }
}
