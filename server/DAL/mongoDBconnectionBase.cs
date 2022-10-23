using Models;
using MongoDB.Bson;

namespace DAL
{
    public abstract class mongoDBconnectionBase
    {

        public override BsonDocument CreatBsonDocument(IllnessDate illness)
        {
            BsonDocument document = new BsonDocument
            {
                {"positive_result_date" ,illness.positive_result_date},
                {"positive_result_date" ,illness.positive_result_date}
            };
            return document;



        }
    }
}