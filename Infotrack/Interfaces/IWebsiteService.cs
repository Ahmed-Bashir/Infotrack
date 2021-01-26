using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Interfaces
{
    public interface IWebsiteService
    {

        IEnumerable<SearchEngine> GetAllSearchEngines();
       
    }
}
