using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bd_web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bd_web
{
    public class Context_app : DbContext
    {
        public DbSet<Club> Clubss { get; set; }
        public DbSet<Footballer> Footballers { get; set; }
        public DbSet<Сosts> Costs_s { get; set; }
        public DbSet<Profit> Profits { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Sponsor> Sponsors { get; set; }
        public DbSet<Club_Sponsor> Club_Sponsors { get; set; }
        public DbSet<PersonalEnum> PersonalEnums { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        
        public Context_app()
        {
            Database.EnsureCreated();

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = DESKTOP-KF67FCF\\SQLEXPRESS; Initial Catalog =BD_WEBb ;" +
                " Integrated Security = True; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; " +
                "ApplicationIntent = ReadWrite; MultiSubnetFailover = False");
        }
    }
}
