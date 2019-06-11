using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Bd_web.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Bd_web
{
    public class Program
    {
  

        public static void Main(string[] args)
        {
            using (Context_app db = new Context_app())
            {


                //Footballer footballer1 = new Footballer { Name = "Roman", Amplya = "Gp" };
                //footballer1.club = db.Clubs.FirstOrDefault(p => p.Name_club == "Real Madrid");

                //// добавляем их в бд
                //db.Footballers.Add(footballer1);
                //db.SaveChanges();
                CreateWebHostBuilder(args).Build().Run();
            }
       
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
