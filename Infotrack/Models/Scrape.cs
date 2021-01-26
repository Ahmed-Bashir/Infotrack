using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Models
{
    public class Scrape
    {
        public int Id { get; set; }

        public string Link { get; set; }

        public int Rank { get; set; }

        public int SearchTermId { get; set; }

        public SearchTerm SearchTerm { get; set; }
    }
}
