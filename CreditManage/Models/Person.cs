using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        public Person()
        {
            IsMale = true;
            Age = 20;
            Address = "";
            IdCard = "";
            Name = "";
            Other = "";
        }
        public int Id { get; set; }
        public string Phone { get; set; }
        public string Psd { get; set; }
        public int Value { get; set; }
        public bool IsMale { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public bool IsAdmin { get; set; }
        public string IdCard { get; set; }
        public string Name { get; set; }
        public string Other { get; set; }
    }
}
