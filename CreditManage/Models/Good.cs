using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Good
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public int Num { get; set; }
        public bool IsDel { get; set; }
        public string Img { get; set; }
        public string Other { get; set; }
    }
}
