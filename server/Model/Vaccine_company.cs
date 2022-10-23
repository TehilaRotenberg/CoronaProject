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

        public Vaccine_company(BsonDocument bsonDocument)
        {
            company_id =new ObjectId(bsonDocument["_id"].ToString());
            company_name= bsonDocument["company"].ToString();
        }
    }
}
