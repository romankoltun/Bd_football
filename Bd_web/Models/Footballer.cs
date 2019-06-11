using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Footballer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Amplya { get; set; }
        public Club club { get; set; }
    }
}
