using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Models
{
    public class Vaccine_company
    {
        public string company_name { get; set; }
        public ObjectId company_id { get; set; }
        
    }
}
