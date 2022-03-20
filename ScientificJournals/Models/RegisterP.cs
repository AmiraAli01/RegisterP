using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class RegisterP
    {
        public int Id { get; set; }
        public int ISSN { get; set; }
        public int MajorId { get; set; }
        public Major Major { get; set; }
        public string Origination { get; set; }
        public bool IsEditor { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser  ApplicationUser { get; set; }
    }
    
        
}