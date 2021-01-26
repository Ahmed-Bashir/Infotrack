using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Models
{
    public class SearchTerm
    {
        public int Id { get; set; }

        [Required]
        public string Keywords { get; set; }

        [Required]
        public string Url { get; set; }

        public SearchEngine SearchEngine { get; set; }

        [Display(Name ="Search Engine")]
        [Required]
        public int SearchEngineId { get; set; }

        public ICollection<Scrape> Scrapes { get; set; }

        public SearchTerm()
        {
            Scrapes = new List<Scrape>();
        }
    }
}
