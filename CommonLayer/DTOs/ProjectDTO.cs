using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
     public class ProjectDTO
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public int GroupId { get; set; }
        public string Owner { get; set; }
        //public List<ProjectFileDTO> ProjectFiles { get; set; }
        public  List<int> Features { get; set; }
        public List<string> Tags { get; set; }
        public int Type { get; set; }
        public int VisibilityType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<string> invitationEmails { get; set; }
        public int whoCanInvite { get; set; }

    }
}
