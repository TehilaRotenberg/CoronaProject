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
        ObjectId _id;
        private BsonDocument vaccine;

        public Corona_vaccine(BsonDocument vaccine)
        {
            this.vaccine = vaccine;
        }

        public DateTime Date_of_vaccine { get; set; }
    }
}
