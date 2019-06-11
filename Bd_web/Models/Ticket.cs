using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name_T { get; set; }
        public string sector { get; set; }
        public int row { get; set; }
        public int  position { get; set; }
        public Match Match_T { get; set; }
        public DateTime Date_t { get; set; }
    }
}
