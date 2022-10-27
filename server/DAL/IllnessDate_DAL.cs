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
    public class IllnessDate_DAL : mongoDBconnection<IllnessDate>
    {
        PersonalInformations personalInformations;
        public IllnessDate_DAL(string collection_name) : base(collection_name)
        {


        }
        
        public  IllnessDate FindIllnessDate(ObjectId objectId)
        {
            BsonDocument illnessDate= base.Find(objectId);
            if (illnessDate != null)
                return new IllnessDate(illnessDate);
            return null;
        }


        public override BsonDocument CreatBsonDocument(IllnessDate illness)
        {
            BsonDocument document = new BsonDocument
            {
                {"positive_result_date" ,illness.positive_result_date.ToString()},
                {"recovery_date" ,illness.recovery_date.ToString()}
            };
            return document;
        }

        //Delete 
        //input:object of type IllnessDate
        //The function find document by id and detele it;
        public void Delete(IllnessDate illness)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", illness._id);
            var c=collection.FindOneAndDelete(filter);
           

        }
        //Delete
        //input:bsondocument that belongs to IllnessDate cillection
        ////The function find document by id and detele it;
        public void Delete(BsonArray bsonDocument)
        {
            collection = database.GetCollection<BsonDocument>("illnessDates");
    
      
           var d = collection.FindOneAndDelete(documents.Where(doc => doc["_id"].ToString() == bsonDocument[0]["$id"].ToString()).FirstOrDefault());
        }
        //Add
        //input:bsondocument that belongs to IllnessDate cillection
        //The function Add the bsonDocument to the illness collction
        public void Add(BsonDocument bsonDocuments)
        {
            collection.InsertOne(bsonDocuments);
        }
        //GetAll
        //output:list of type IllnessDate with all IllnessDates in the database
        public override List<IllnessDate> GetAll()
        {
            list = new List<IllnessDate>();
            if (documents.Count < 0)
                return null;
            foreach(BsonDocument document in documents)
            {
                list.Add(new IllnessDate(document));
            }
            return list;
        }
        
        public BsonValue ConvertTOBasonArray(List<string> illnessDates)
        {
            BsonArray bsonarry = new BsonArray();
            foreach (string illnessDate in illnessDates)
            {
                bsonarry.Add(new BsonDocument { { "$ref", "corona_vaccion" }, { "$id", illnessDate } });
            }
            return bsonarry;
        }
    }
    }

