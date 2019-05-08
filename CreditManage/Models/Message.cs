using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Message
    {
        public int Id { get; set; }
        public int From { get; set; }
        public int To { get; set; }
        public string Content { get; set; }
        public string Date { get; set; }
        public bool IsRead { get; set; }
        public bool IsDelFrom { get; set; }
        public bool IsDelTo { get; set; }
    }
}
