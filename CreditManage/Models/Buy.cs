using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Buy
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int GoodId { get; set; }
        public int Num { get; set; }
        public bool IsCheck { get; set; }
        public string Date { get; set; }
    }
}
