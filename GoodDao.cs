using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task2
{
    public class GoodDao : IPrimary
    {
        public int Id { get; set; }
        public string Name { get; set; } = " ";
        public string Code { get; set; } = " ";
    }
}
