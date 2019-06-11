using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Profit
    {
        public int Id { get; set; }
        public Club club { get; set; }
        public string Name_P { get; set; }
        public int? ShopeTypeId { get; set; }
        public Shop ShopeType { get; set; }
        public int Money_p { get; set; }
        public DateTime Date { get; set; }
    }
}
