using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Paper_Profreader
    {
        public int Id { get; set; }
        public int PaperId { get; set; }
        public Paper Paper { get; set; }
        public int ProfreaderId { get; set; }
        public Profreader Profreader { get; set; }

        public string Status { get; set; }
        public string RejectNote { get; set; }

        public string NoteToAuthor { get; set; }
        public string NoteToAdmin { get; set; }
    }
}