using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MongoDB.Bson;

namespace DAL
{
    public class IllnessDate_DAL : mongoDBconnection<IllnessDate>
    {
        public IllnessDate_DAL(string collection_name) : base(collection_name)
        {
        }
        public override BsonDocument CreatBsonDocument(Models.IllnessDate obj)
        {
            return null;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public  IllnessDate FindIllnessDate(ObjectId objectId)
        {
            BsonDocument illnessDate= base.Find(objectId);
            if (illnessDate != null)
                return new IllnessDate(illnessDate);
            return null;
        }

        public override List<Models.IllnessDate> GetAll()
        {
            return null;
        }

       

   
    }
}
