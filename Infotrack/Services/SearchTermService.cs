using Infotrack.Interfaces;
using Infotrack.Models;
using Infotrack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Services
{
    public class SearchTermService : ISearchTermService
    {
        private readonly IRepository<SearchTerm> _searchTermRepository;

        public SearchTermService(IRepository<SearchTerm> SearchTermRepository)
        {
            _searchTermRepository = SearchTermRepository;
        }
        public void Add(SearchTerm searchTerm)
        {
            _searchTermRepository.Add(searchTerm);
        }
    }
}
