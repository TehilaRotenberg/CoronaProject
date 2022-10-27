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
        Vaccine_company_DAL vaccine_Company_DAL = new Vaccine_company_DAL("vaccine_company");
        
        public Corona_vaccine_DAL(string collection_name) : base(collection_name)
        {
        }
        public Corona_vaccine_DAL():base("corona_vaccion ")
        {
            
        }
        public Corona_vaccine FindCoronaVccine(ObjectId objectId)
     {
           
           BsonDocument coronavaccine = base.Find(objectId);
            var a = coronavaccine["vaccine_Company"];
            MongoDBRef dbRef = new MongoDBRef(coronavaccine["vaccine_Company"]["$ref"].ToString(), new ObjectId(coronavaccine["vaccine_Company"]["$id"].ToString()));
            Vaccine_company vaccine_Company = vaccine_Company_DAL.FindCompany(((ObjectId)dbRef.Id));
            
            if (coronavaccine != null)
                return new Corona_vaccine(coronavaccine,vaccine_Company);
          return null;
        }

        public Corona_vaccine Delete(Corona_vaccine vacines)
        {
            if (vacines != null)
            {
           var filter = Builders<BsonDocument>.Filter.Eq("_id", vacines._id);
                collection = database.GetCollection<BsonDocument>("corona_vaccion ");
            var v = collection.FindOneAndDelete(filter);
                
            vaccine_Company_DAL.Delete(vacines.vaccine_Company);
            }
            return vacines;
        }
        public void Delete(BsonArray bsonDocument)
        {
            var filter = Builders<BsonDocument>.Filter.Eq("_id", bsonDocument[0]["$id"]);
            collection.FindOneAndDelete(filter);
        }
        public void Add(BsonDocument bsonDoc)
        {
           collection.InsertOne(bsonDoc);
        }
        public override List<Corona_vaccine> GetAll()
      {
            return null;
      }

        public BsonArray ConvertTOBasonArray(List<string> corona_Vaccines)
        {  
            BsonArray bsonarry = new BsonArray();
            foreach (string vaccine in corona_Vaccines)
            {
                bsonarry.Add(new BsonDocument { { "$ref", "corona_vaccion" }, { "$id", vaccine } });
                 
               
            }
            return bsonarry;
        }
public override BsonDocument CreatBsonDocument(Corona_vaccine obj)
        {
           // BsonDocument vaccinBsob = vaccine_Company_DAL.CreatBsonDocument(obj.vaccine_Company)
           var filter=Builders<BsonDocument>.Filter.Eq("company", obj.vaccine_Company.company_name);
            var v = database.GetCollection<BsonDocument>("vaccine_company").Find(filter).FirstOrDefault();
            BsonDocument bsondoc = new BsonDocument {
                { "injection_date", obj.injection_date },

                { "vaccine_Company",new BsonDocument{ {  "$ref", "vaccine_Company" }, { "$id", v["_id"] } }


            }};
            return bsondoc;

        }
            

        
    }
}
