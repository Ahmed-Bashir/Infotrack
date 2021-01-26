using HtmlAgilityPack;
using Infotrack.Interfaces;
using Infotrack.Models;
using Infotrack.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Service
{
    public class ScraperService : IScraperService
    {


        private readonly ISearchEngineService _searchEngine;
        private readonly IRepository<Scrape> _scrapeRepository;
        private readonly IRepository<SearchTerm> _searchTermRepository;

        public ScraperService(ISearchEngineService searchEngine, IRepository<Scrape> scrapeRepository, IRepository<SearchTerm> searchTermRepository)
        {
            
            _searchEngine = searchEngine;
            _scrapeRepository = scrapeRepository;
            _searchTermRepository = searchTermRepository;
        }


       


        public async Task<IEnumerable<Scrape>> ScrapeMatches(SearchTerm searchTerm)
        {
           
            var queryLink =  _searchEngine.CreateQueryLink(searchTerm.Keywords);

            var web = new HtmlWeb();
            var document = new HtmlDocument();
            document = await web.LoadFromWebAsync(queryLink);
            var nodes = document.DocumentNode.SelectNodes("//div[@class='yuRUbf']/a[@href]");

            var links = new List<string>();
            foreach (var item in nodes)
            { 
                links.Add(item.Attributes["href"].Value);
            }

            var scrapes = new List<Scrape>();
            for (var i = 0; i < links.Count; i++)
            {
                if (!links[i].Contains(searchTerm.Url, StringComparison.CurrentCultureIgnoreCase)) continue;

                var scrape = new Scrape
                {
                    Rank = i + 1,
                    Link = links[i],
                    SearchTermId = searchTerm.Id,
                    
                };

                scrapes.Add(scrape);
              await  _scrapeRepository.Add(scrape);
            }

         

            return scrapes;
        }
    }
}
