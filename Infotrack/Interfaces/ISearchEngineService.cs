using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Interfaces
{
    public interface ISearchEngineService
    {

        public string Link { get;  }
        string CreateQueryLink(string keywords);

    }
}
