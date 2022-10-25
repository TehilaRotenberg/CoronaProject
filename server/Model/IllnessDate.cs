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
       

        public IllnessDate(BsonDocument illness)
        {
           // this._id = new ObjectId((illness["_id"].ToString()));
            this._id = illness["_id"].ToString();
            this.positive_result_date = DateTime.Parse(illness["positive_result_date"].ToString());
            this.recovery_date = DateTime.Parse(illness["recovery_date"].ToString());
        }
        public IllnessDate()
        {

        }
        public string _id { get; set; }
        //public ObjectId _id { get; set; }
        public DateTime positive_result_date { get; set; }
        public DateTime recovery_date { get; set; }
    }
}
