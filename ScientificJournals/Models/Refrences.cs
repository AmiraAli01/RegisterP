using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Refrences
    {
        public int Id { get; set; }
        public string NameOfRefrences { get; set; }
        public Paper Paper { get; set; }
    }
}