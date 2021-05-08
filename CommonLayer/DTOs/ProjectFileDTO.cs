using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer.DTOs
{
    public class ProjectFileDTO
    {
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public string FileGUID { get; set; }
        public string BlobURI { get; set; }
    }
}
