using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Models
{
    public class BuyShow
    {
        public Buy buy { get; set; }
        public Person person { get; set; }
        public Good good { get; set; }
        public double sum { get; set; }
    }
}
