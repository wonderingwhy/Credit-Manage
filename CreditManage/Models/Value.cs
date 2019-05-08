using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Value
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int Num { get; set; }
        public string Date { get; set; }
        public string Other { get; set; }
    }
}
