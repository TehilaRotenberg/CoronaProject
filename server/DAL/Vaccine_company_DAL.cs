using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using MongoDB.Driver;
using MongoDB.Bson;

namespace DAL
{
    public class Vaccine_company_DAL : mongoDBconnection<Vaccine_company>
    {
        public Vaccine_company_DAL(string collection_name) : base(collection_name)
        {
        }

        public override BsonDocument CreatBsonDocument(Vaccine_company obj)
        {
            return new BsonDocument { { "company", obj.company_name }};
        }

        public override List<Vaccine_company> GetAll()
        {
          if(documents.Count<=0)
            {
                return null;
            }
          list = new List<Vaccine_company>();
            foreach(var doc in documents)
            {
                list.Add(new Vaccine_company(doc));
            }
            return list;
        }
        public Vaccine_company FindCompany(ObjectId objectId)
        {
            BsonDocument bsondocument = base.Find(objectId);
            if (bsondocument != null)
                return new Vaccine_company(bsondocument);
            return null;
        }

        internal void Delete(Vaccine_company vaccine_Company)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", vaccine_Company.company_id);
            collection.FindOneAndDelete(filter);
        }
    }
}
