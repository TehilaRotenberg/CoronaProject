using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MongoDB.Bson;
using MongoDB.Driver;


namespace DAL
{
  public class Corona_vaccine_DAL : mongoDBconnection<Corona_vaccine>
  {
       

        public Corona_vaccine_DAL(string collection_name) : base(collection_name)
        {
        }

        public override BsonDocument CreatBsonDocument(Corona_vaccine obj)
      {
            
            return null;
      }

        public  Corona_vaccine FindCoronaVccine(ObjectId objectId)
     {
           BsonDocument coronavaccine = base.Find(objectId);
            //BsonDocument coronavaccine= collection.Find(filter).FirstOrDefault();
            if (coronavaccine != null)
                return new Corona_vaccine(coronavaccine);
          return null;
        }
 
      public override List<Corona_vaccine> GetAll()
      {
            return null;
      }
  }
}
