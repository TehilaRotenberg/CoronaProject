using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL
{
    public abstract class mongoDBconnection<T>
    {
        const string DATABASE_NAME = "CoronaProject";
        public MongoClient connection =new MongoClient(@"mongodb://localhost:27017/?readPreference=primary&directConnection=true&ssl=false");
        public MongoDatabaseBase database { get; set; }
        public IMongoCollection<BsonDocument> collection { get; set; }
        

        List<BsonDocument> documents;
        List<T> list;
       
        public mongoDBconnection(string collection_name)
        {
            this.database=(MongoDatabaseBase)connection.GetDatabase(DATABASE_NAME);
            this.collection = collection = database.GetCollection<BsonDocument>(collection_name);
            List<BsonDocument> documents = collection.Find(new BsonDocument()).ToList();
        }

        //Create
        public void Create(T obj)
        {
            collection.InsertOne(CreatBsonDocument(obj));
        }
        
        //Read
       public abstract List<T> Get();

        //Update
        //Delete


        public abstract BsonDocument CreatBsonDocument(T obj);

    }

 
}
