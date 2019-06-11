using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Club_Sponsor
    {
        public int Id { get; set; }
        public Club club { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
