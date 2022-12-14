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
    public abstract class mongoDBconnection<T>
    {
        const string DATABASE_NAME = "coronaProject";
        public MongoClient connection =new MongoClient(@"mongodb://localhost:27017/?readPreference=primary&directConnection=true&ssl=false");
        public MongoDatabaseBase database { get; set; }
        public IMongoCollection<BsonDocument> collection { get; set; }

       
        public List<BsonDocument> documents;
        public List<T> list;
       
        public mongoDBconnection(string collection_name)
        {
            this.database=(MongoDatabaseBase)connection.GetDatabase(DATABASE_NAME);
            this.collection = collection = database.GetCollection<BsonDocument>(collection_name);
            documents = collection.Find(new BsonDocument()).ToList();
            
        }

        //Create
        public BsonDocument Create(T obj)
        {
            BsonDocument bsondocument = CreatBsonDocument(obj);
                collection.InsertOne(bsondocument);
            return bsondocument;
        }
        
        //Read
       public abstract List<T> GetAll();

        //Update
        //Delete


        public abstract BsonDocument CreatBsonDocument(T obj);

        public virtual BsonDocument Find(ObjectId objectId)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", objectId);
            BsonDocument bsonDocument = documents.Where(doc => doc["_id"] == objectId).FirstOrDefault();
            return bsonDocument;
        }

    

    }

 
}
