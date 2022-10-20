using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;


namespace Models
{
    public class PersonalInformation
    {
        public string first_name { get; set; }
        public string last_name { get; set; }
        public long id { get; set; }
        public string address { get; set; }
        public DateTime birthday { get; set; }
        public long phone { get; set; }
        public long mobile { get; set; }
        public Corona_vaccine[] vaccines { get; set; }
        public List<IllnessDate> illnessDates { get; set; }

        public PersonalInformation(BsonDocument personalInformation)
        {
            first_name = personalInformation["first_name"].ToString();
            last_name = personalInformation["last_name"].ToString();
            id = long.Parse(personalInformation["id"].ToString());
            address = personalInformation["address"].ToString();
            birthday = DateTime.Parse( personalInformation["birthday"].ToString());
            phone = long.Parse(personalInformation["phone"].ToString());
            mobile = long.Parse(personalInformation["mobile"].ToString());
            
            
            //חיסונים
            vaccines = new Corona_vaccine[4];
            if(personalInformation.Contains("vaccines"))
            { 
            int i=0;
            foreach(BsonDocument vaccine in personalInformation["vaccines"].AsBsonArray)
            {
                vaccines[i] = new Corona_vaccine(vaccine);
                i++;
            }
            }


            //מועדי מחלה
            if (personalInformation.Contains("illnessDates")) { 
            illnessDates = new List<IllnessDate>();
            foreach(BsonDocument date in personalInformation["illnessDates"].AsBsonArray)
            {
                illnessDates.Add(new IllnessDate(date));
            }
            }


        }

    }
}
