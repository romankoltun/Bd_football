using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class Сosts
    {
        public int Id { get; set; }
        public Club club { get; set; }
        public string Name_C { get; set; }
        public int? ShopeTypeId { get; set; }
        public Shop ShopeType { get; set; }
        public int Money_C { get; set; }
        public DateTime Date { get; set; }
    }
}
