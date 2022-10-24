using MongoDB.Bson;
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
    
    public class PersonalInformations : mongoDBconnection<PersonalInformation>
    {
        Corona_vaccine_DAL corona_Vaccine_DAL = new Corona_vaccine_DAL("corona_vaccion ");
       IllnessDate_DAL illnessDates_DAL = new IllnessDate_DAL("illnessDates");
        public PersonalInformations(string collection_name) : base(collection_name)
        {
        }

        public PersonalInformation Delete(PersonalInformation personalInformation)
        {
           var filter = Builders<BsonDocument>.Filter.Eq("id",personalInformation.id);
            collection.FindOneAndDelete(filter);
            foreach (var vacine in personalInformation.vaccines) { corona_Vaccine_DAL.Delete(vacine); }
            foreach (var illness in personalInformation.illnessDates) { illnessDates_DAL.Delete(illness); }
            collection.FindOneAndDelete(filter);
            return personalInformation;

        }

        public void Add(PersonalInformation personalInformation)
        {
            BsonDocument bsonDocuments = CreatBsonDocument(personalInformation);
            collection.InsertOne(bsonDocuments);
            foreach(var vaccine in personalInformation.vaccines)
            {
                BsonDocument bsonDoc= corona_Vaccine_DAL.CreatBsonDocument(vaccine);
                corona_Vaccine_DAL.Add(bsonDoc);
            }
            foreach(var illness in personalInformation.illnessDates)
            {
                BsonDocument bsonDoc = illnessDates_DAL.CreatBsonDocument(illness);
                illnessDates_DAL.Add(bsonDoc);
            }
          
        }

        ///public void UpdateUserRef(MongoDBRef mongoDBRef,ObjectId objectId)
        ///{
        ///    BsonDocument doc = (BsonDocument)collection.Find(documents.Where(document => document["illnessDates"].AsBsonArray.Contains(new MongoDBRef("illnessDates", objectId).ToBsonDocument())).FirstOrDefault());
        ///    var copyDoc = doc;
        ///    foreach (var bd in doc["illnessDates"].AsBsonArray)
        ///    {
        ///        if(bd["$id"].Equals(objectId))
        ///        {
        ///            doc = mongoDBRef.ToBsonDocument();
        ///        }
        ///    }  
        //}    ///

        public  void Update(PersonalInformation personalInformation)
        {
            BsonDocument bsonDocuments = CreatBsonDocument(personalInformation);
            var doc=documents.Where(d => d["id"] == personalInformation.id).FirstOrDefault();
            foreach (var vaccine in personalInformation.vaccines)
            {
                BsonDocument bsonDoc = corona_Vaccine_DAL.CreatBsonDocument(vaccine);
                corona_Vaccine_DAL.Add(bsonDoc);
            }
            foreach (var illness in personalInformation.illnessDates)
            {
                BsonDocument bsonDoc = illnessDates_DAL.CreatBsonDocument(illness);
                illnessDates_DAL.Add(bsonDoc);
            }
           
            foreach(BsonDocument document in doc["corona_vaccion"].AsBsonArray)
            {
                corona_Vaccine_DAL.Delete(document);
            }
            foreach (BsonDocument document in doc["corona_vaccion"].AsBsonArray)
            {
                corona_Vaccine_DAL.Delete(document);
            }

        }
        
       
        public override BsonDocument CreatBsonDocument(PersonalInformation obj)
        {
            BsonDocument bsaondocument = new BsonDocument
            {
                {"first_name",obj.first_name },
                {"last_name",obj.last_name },
                {"id",obj.id },
                {"address",obj.address },
                {"phone",obj.phone },
                {"mobile",obj.mobile },
                {"corona_vaccion",new BsonArray{ corona_Vaccine_DAL.ConvertTOBasonArray(obj.vaccines) } },
                {"illnessDates",new BsonArray{ illnessDates_DAL.ConvertTOBasonArray (obj.illnessDates)} }
            };
            return bsaondocument;
        }

        public override List<PersonalInformation> GetAll()
        {
            list = new List<PersonalInformation>();
            if (documents.Count < 0)
                return null;
        
            foreach (BsonDocument document in documents)
            { 
                Corona_vaccine[] corona_Vaccines = new Corona_vaccine[4];
                int i = 0;
                List<IllnessDate> illensDates = new List<IllnessDate>();
            
            {   foreach (BsonDocument vaccions in document["corona_vaccion"].AsBsonArray)
                {

                    MongoDBRef dbRef = new MongoDBRef(vaccions["$ref"].ToString(), new ObjectId(vaccions["$id"].ToString()));
                    Corona_vaccine corona_Vaccine = corona_Vaccine_DAL.FindCoronaVccine(((ObjectId)dbRef.Id));
                    corona_Vaccines[i] = corona_Vaccine;
                    i++;
                }
                    foreach (BsonDocument illnessDate in document["illnessDates"].AsBsonArray)
                    {

                        MongoDBRef dbRef = new MongoDBRef(illnessDate["$ref"].ToString(), new ObjectId(illnessDate["$id"].ToString()));
                        IllnessDate illensDate =illnessDates_DAL.FindIllnessDate (((ObjectId)dbRef.Id));
                        illensDates.Add(illensDate);
                    }
                      list.Add(new PersonalInformation(document,corona_Vaccines, illensDates));
                }
            }
            return list;
        }
    }
}
