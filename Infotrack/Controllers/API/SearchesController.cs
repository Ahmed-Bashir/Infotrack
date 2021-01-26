using HtmlAgilityPack;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchesController : ControllerBase
    {
       


        public void getPage()
        {
            List<string> Links = new List<string>();

            var web = new HtmlWeb();

            HtmlAgilityPack.HtmlDocument document = new HtmlDocument();

            
            document = web.Load("https://www.google.co.uk/search?num=100&q=land+registry+search");

            HtmlNodeCollection Nodes = document.DocumentNode.SelectNodes("//div[@class='yuRUbf']/a[@href]");

            foreach (var link in Nodes)
            {

                Links.Add(link.Attributes["href"].Value);

            }

          var indexOfInfoTrack =  Links.FindIndex(x => x.Contains("infotrack"));


           
        }

    }
}
