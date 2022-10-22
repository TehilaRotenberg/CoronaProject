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

        public override BsonDocument CreatBsonDocument(PersonalInformation obj)
        {
            throw new NotImplementedException();
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
