using Infotrack.Interfaces;
using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Services
{
    public class WebsiteService : IWebsiteService
    {
        private readonly IRepository<SearchEngine> _searchEngineRepository;

        public WebsiteService( IRepository<SearchEngine> searchEngineRepository)
        {
           _searchEngineRepository = searchEngineRepository;
        }
        public IEnumerable<SearchEngine> GetAllSearchEngines()
        {
           return _searchEngineRepository.GetEntities();
        }
    }
}
