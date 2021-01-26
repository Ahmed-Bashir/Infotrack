using Infotrack.Interfaces;
using Infotrack.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Service
{
    public class GoogleService : ISearchEngineService
    {
        public string Link { get => "https://www.google.co.uk/search?num=100&q="; }

        public string CreateQueryLink( string keywords)
        {
            return   $"{Link}{keywords.Replace(' ', '+')}"; 
        }
    }
}
