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
            collection = database.GetCollection<BsonDocument>("personalInformation");
           
            var filter = Builders<BsonDocument>.Filter.Eq("id", personalInformation.id);
            //var docs = collection.Find(new BsonDocument()).ToList();

            var p=collection.FindOneAndDelete(filter);
            // var p=collection.FindOneAndDelete(filter);


            // collection.DeleteOne(p);
            foreach (var vacine in personalInformation.vaccines) { corona_Vaccine_DAL.Delete(vacine); }
           foreach (var illness in personalInformation.illnessDates) { illnessDates_DAL.Delete(illness); }
            
            return personalInformation;

        }

        public void Add(PersonalInformation personalInformation)
        {
            List<string> v, i;
            (v,i)=GetRef(personalInformation);
            
           
            BsonDocument bsonDocuments = CreatBsonDocument(personalInformation,v,i);
            
            collection.InsertOne(bsonDocuments);
            

        }
        public (List<string>,List<string>) GetRef(PersonalInformation personalInformation)
        {
            List<string> key_vaccins = new List<string>();
            List<string> key_illness = new List<string>();
            
            
            foreach (var vaccine in personalInformation.vaccines)
            {
                BsonDocument bsonDoc = corona_Vaccine_DAL.CreatBsonDocument(vaccine);
                corona_Vaccine_DAL.Add(bsonDoc);
                key_vaccins.Add(bsonDoc["_id"].ToString());
            }
            foreach (var illness in personalInformation.illnessDates)
            {
                BsonDocument bsonDoc = illnessDates_DAL.CreatBsonDocument(illness);
                illnessDates_DAL.Add(bsonDoc);
                key_illness.Add(bsonDoc["_id"].ToString());
            }
            return (key_vaccins, key_illness);
        }
        public  void Update(PersonalInformation personalInformation)
      {
            List<string> v, i;
            (v,i)=GetRef(personalInformation);
            var doc = documents.Where(d => d["id"] == personalInformation.id).FirstOrDefault();
            if (doc.Contains("corona_vaccion"))
            {
                foreach (var document in doc["corona_vaccion"].AsBsonArray)
                {
                    corona_Vaccine_DAL.Delete(document.AsBsonArray);
                }
            }
            if(doc.Contains("illnessDates"))
            {
                foreach (var document in doc["illnessDates"].AsBsonArray)
                {
                    illnessDates_DAL.Delete(document.AsBsonArray);
                }
            }
            collection.FindOneAndUpdate(doc, CreatBsonDocument(personalInformation, v, i));
         

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
                {"mobile",obj.mobile } };
            return bsaondocument;
        }
        public  BsonDocument CreatBsonDocument(PersonalInformation obj,List<string>v,List<string>i)
        {
            BsonDocument bsaondocument = new BsonDocument
            {
                {"first_name",obj.first_name },
                {"last_name",obj.last_name },
                {"id",obj.id },
                {"address",obj.address },
                {"phone",obj.phone },
                {"mobile",obj.mobile },
               
              
                {"birthday",obj.birthday.ToString() }
            };
            if (v.Count() > 0)
            {
                bsaondocument.Add("corona_vaccion", new BsonArray { corona_Vaccine_DAL.ConvertTOBasonArray(v) });
            }
            if (i.Count() > 0)
            {
                bsaondocument.Add("illnessDates", new BsonArray { illnessDates_DAL.ConvertTOBasonArray(i) });
            }

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
            
            {
                    if (document.Contains("corona_vaccion")){
                        foreach (var vaccions in document["corona_vaccion"].AsBsonArray)
                        {


                            MongoDBRef dbRef = new MongoDBRef(vaccions[0]["$ref"].ToString(), new ObjectId(vaccions[0]["$id"].ToString()));
                            Corona_vaccine corona_Vaccine = corona_Vaccine_DAL.FindCoronaVccine(((ObjectId)dbRef.Id));
                            corona_Vaccines[i] = corona_Vaccine;
                            i++;
                        }
                    }
                    if (document.Contains("illnessDates"))
                    {
                        foreach (var illnessDate in document["illnessDates"].AsBsonArray)
                        {

                            MongoDBRef dbRef = new MongoDBRef(illnessDate[0]["$ref"].ToString(), new ObjectId(illnessDate[0]["$id"].ToString()));
                            IllnessDate illensDate = illnessDates_DAL.FindIllnessDate(((ObjectId)dbRef.Id));
                            illensDates.Add(illensDate);
                        }
                    }
                      list.Add(new PersonalInformation(document,corona_Vaccines, illensDates));
                }
            }
            return list;
        }
        public BsonDocument find(long id)
        {
            return documents.Find(d => d["id"] == id);
        }
    }
}
