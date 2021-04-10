using DapperHeroes.Contracts.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace DapperHeroes.Contracts
{
    public class HeroesContext : DbContext
    {
        private ILoggerFactory logger;

        public HeroesContext(DbContextOptions options, ILoggerFactory logger) : base(options)
        {
            this.logger = logger;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=app.db;");
            }

            optionsBuilder.LogTo(Console.WriteLine);
        }

        public DbSet<Hero> Heroes { get; set; }
    }
}
