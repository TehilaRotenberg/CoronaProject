using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DAL
{
    public class mongoDBconnection
    {
        const string DATABASE_NAME = "CoronaProject";
        public MongoClient connection =new MongoClient( @"mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&directConnection=true&ssl=false");
        public MongoDatabaseBase database { get; set; }
        public IMongoCollection<BsonDocument> collection { get; set; }
       
        public mongoDBconnection(string collection_name)
        {
            this.database=(MongoDatabaseBase)connection.GetDatabase(DATABASE_NAME);
            this.collection = collection = database.GetCollection<BsonDocument>(collection_name);
        }
    }

 
}
