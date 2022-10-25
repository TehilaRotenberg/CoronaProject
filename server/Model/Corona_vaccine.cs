using System;
using MongoDB.Bson;

namespace Models
{
    public class Corona_vaccine
    {
     // public ObjectId _id { get; set; }
        public string _id { get; set; }
        public DateTime injection_date { get; set; }
        public Vaccine_company vaccine_Company { get; set; }

        public Corona_vaccine(BsonDocument vaccine,Vaccine_company vaccine_Company)
        {
            _id= vaccine["_id"].ToString();
            //_id= new ObjectId(vaccine["_id"].ToString());
            injection_date= DateTime.Parse(vaccine["injection_date"].ToString());
            this.vaccine_Company = vaccine_Company;

        }
        public Corona_vaccine()
        {

        }
       
    }
}
