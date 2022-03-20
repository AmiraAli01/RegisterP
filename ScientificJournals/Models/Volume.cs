using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class Volume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime date { get; set; }
        public IList<Paper>  Papers { get; set; }
    }
}