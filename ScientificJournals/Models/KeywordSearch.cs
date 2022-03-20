using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScientificJournals.Models
{
    public class KeywordSearch
    {
        public int Id { get; set; }
        public string NameOfKeywordSearch { get; set; }
        public RegisterP IdPaper { get; set; }
    }
}