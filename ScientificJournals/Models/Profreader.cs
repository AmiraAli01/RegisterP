using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Profreader
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }

        public int MajorId { get; set; }
        public Major Major { get; set; }
    }
}