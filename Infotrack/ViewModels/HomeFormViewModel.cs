using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Infotrack.ViewModels
{
    public class HomeFormViewModel
    {

        public SearchTerm SearchTerm { get; set; }

        public IEnumerable<SearchEngine> SearchEngines { get; set; }

    }
}
