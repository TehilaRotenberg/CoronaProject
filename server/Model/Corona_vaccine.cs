using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Models
{
    public class Corona_vaccine
    {
        public ObjectId _id { get; set; }
        public DateTime injection_date { get; set; }
        public Vaccine_company vaccine_Company { get; set; }

        public Corona_vaccine(BsonDocument vaccine)
        {
            _id= new ObjectId(vaccine["_id"].ToString());
            injection_date= DateTime.Parse(vaccine["injection_date"].ToString());
        }

        public DateTime Date_of_vaccine { get; set; }
    }
}
