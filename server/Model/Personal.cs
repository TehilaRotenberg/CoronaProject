using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Personal
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long id { get; set; }
        public string address { get; set; }
        // public string city { get; set; }
        public DateTime birthday { get; set; }
        public long phone { get; set; }
        public long mobile { get; set; }
    }
}
