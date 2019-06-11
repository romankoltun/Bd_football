using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bd_web.Models
{
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public PersonalEnum personalEnum { get; set; }
    }
}
