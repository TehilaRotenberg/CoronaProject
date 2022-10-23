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
            //personalInformations = new PersonalInformations("personalInformation");

        }
       // public  BsonDocument CreatBsonDocument(IllnessDate obj)
       // {
       //     BsonDocument BsonDocument = new BsonDocument {
       //         {"positive_result_date",obj.positive_result_date },
       //         {"recovery_date",obj.recovery_date }
       //     };
       //     return BsonDocument;
       // }

       

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


        public override BsonDocument CreatBsonDocument(IllnessDate illness)
        {
            BsonDocument document = new BsonDocument
            {
                {"positive_result_date" ,illness.positive_result_date},
                {"positive_result_date" ,illness.positive_result_date}
            };
            return document;
        }

            public void Delete(IllnessDate illness)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", illness._id);
            collection.FindOneAndDelete(filter);
           

        }
        public void Delete(BsonDocument bsonDocument)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", bsonDocument["%id"]);
            collection.FindOneAndDelete(filter);
        }

        internal void Add(BsonDocument bsonDocuments)
        {
            collection.InsertOne(bsonDocuments);
        }

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

        public BsonValue ConvertTOBasonArray(List<IllnessDate> illnessDates)
        {
            BsonArray bsonarry = new BsonArray();
            foreach (IllnessDate illnessDate in illnessDates)
            {
                bsonarry.Add(new MongoDBRef("illnessDates", illnessDate._id).ToBson());
            }
            return bsonarry;
        }
    }
    }

