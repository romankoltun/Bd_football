using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Club
    {
        public int Id { get; set; }
        public string Name_club { get; set; }
        public string Adres { get; set; }
        public int Sector { get; set; }
        public int Row { get; set; }
        public int Seat { get; set; }
        public List<Footballer> Footballers { get; set; }
    }
}
