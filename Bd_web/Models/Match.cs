using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Match
    {
        public int Id { get; set; }
        public string Name_M { get; set; }
        public Club Club_game { get; set; }
        public string Ticet_string { get; set; }
        public DateTime DateTime { get; set; }
    }

   
}
