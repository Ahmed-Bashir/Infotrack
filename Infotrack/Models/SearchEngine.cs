using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Models
{
    public class SearchEngine
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<SearchTerm> SearchTerms { get; set; }

        public SearchEngine()
        {
            SearchTerms = new List<SearchTerm>();
        }
    }
}
