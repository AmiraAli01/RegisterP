using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Paper
    {

        public int Id { get; set; }
        public string Titel { get; set; }
        public KeywordSearch KeywordSearch { get; set; }
        public string Abstract { get; set; }
        public string Filepath { get; set; }

        public string FileName { get; set; }
        public string Status { get; set; }
        public RegisterP RegisterP { get; set; }

        public int VolumeId { get; set; }
        public Volume  Volume { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}