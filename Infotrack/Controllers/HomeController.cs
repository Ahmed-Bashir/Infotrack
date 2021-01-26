using Infotrack.Interfaces;
using Infotrack.Models;
using Infotrack.Service;
using Infotrack.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IScraperService _scraperService;
        private readonly ISearchTermService _searchTermService;
        private readonly ISearchEngineService _searchEngineService;
        private readonly IWebsiteService _website;

        public HomeController(ILogger<HomeController> logger, IScraperService scraperService, ISearchTermService searchTermService, ISearchEngineService searchEngineService, IWebsiteService website)
        {
            _logger = logger;
            _scraperService = scraperService;
            _searchTermService = searchTermService;
            _searchEngineService = searchEngineService;
            _website = website;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var searchEngines = _website.GetAllSearchEngines();
            var searchTerm = new SearchTerm();
            var formViewModel = new HomeFormViewModel()
            {
                SearchEngines = searchEngines,
                SearchTerm = searchTerm
            };
            return View(formViewModel);
        }

     
        public async Task<IActionResult> Index(HomeFormViewModel homeViewModel)
        {

           

          
            return View(homeViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Hits(SearchTerm searchTerm)
        {
            if (!ModelState.IsValid)
            {
                var formViewModel = new HomeFormViewModel()
                {
                    SearchEngines = _website.GetAllSearchEngines(),
                    SearchTerm = searchTerm
                };

              

                return View("Index",formViewModel);
            }

             _searchTermService.Add(searchTerm);

           var scrapes = await _scraperService.ScrapeMatches(searchTerm);

            

            return View(scrapes); ;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
