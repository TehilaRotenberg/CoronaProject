using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Models
{
    public class IllnessDate
    {
        private BsonDocument date;

        public IllnessDate(BsonDocument date)
        {
            this.date = date;
        }

        public ObjectId _id { get; set; }
        public DateTime positive_result_date { get; set; }
        public DateTime recovery_date { get; set; }
    }
}
