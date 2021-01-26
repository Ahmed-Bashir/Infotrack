using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infotrack.Models.Data
{
    public class AppDbContext: DbContext
    {


        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {
        }

        public DbSet<SearchEngine> SearchEngines { get; set; }

        public DbSet<Scrape> Scrapes { get; set; }

        public DbSet<SearchTerm> SearchTerms { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SearchEngine>().HasData(

              new SearchEngine()
              {
                  Id = 1,
                  Name= "Google"
                  
              } );
        }



    }
}
