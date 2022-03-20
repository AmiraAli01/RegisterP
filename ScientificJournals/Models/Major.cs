using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Major
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<RegisterP>  RegisterPs { get; set; }
        public IList<Paper> Papers { get; set; }
    }
}