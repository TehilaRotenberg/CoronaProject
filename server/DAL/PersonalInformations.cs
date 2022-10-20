using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;




namespace DAL
{
    public class PersonalInformations : mongoDBconnection<PersonalInformation>
    {
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
            foreach (BsonDocument document in documents)
            {
                list.Add(new PersonalInformation(document));
            }
          return list;
        }
    }
}
