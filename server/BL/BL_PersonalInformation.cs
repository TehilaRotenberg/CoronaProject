using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BL;
using Models;
namespace BL
{
    public class BL_PersonalInformation
    {
        public PersonalInformations personalInformations;
        public BL_PersonalInformation()
        {
            personalInformations = new PersonalInformations("personalInformation");
        }
        public List<PersonalInformation> GetAll()
        {
             personalInformations = new PersonalInformations("personalInformation");
            return personalInformations.GetAll();

        }

        public string Update(PersonalInformation personalInformation)
        {
            try
            {
                cheackLegal(personalInformation);
                personalInformations.Update(personalInformation);
                return "succes";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
            
        }

        public PersonalInformation Delete(PersonalInformation personalInformation)
        {
            return personalInformations.Delete(personalInformation);
        }
        public string Add(PersonalInformation personalInformation)
        {
            try {
                containId(personalInformation.id);
                cheackLegal(personalInformation);
                personalInformations.Add(personalInformation);
                return "השמירה בוצעה בהצלחה";
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
          
        }
        public void containId(long id)
        {
            if (personalInformations.find(id) != null)
            {
                throw new Exception("תעודת הזהות קיימת במערכת");
            }
        }
        public void cheackLegal(PersonalInformation personalInformation)
        {
          


            if(!Legal.LegalId(personalInformation.id.ToString()))
            {
                throw new Exception("תעודת זהות אינה תקינה");

            }
            if(!Legal.Normalcharacters(personalInformation.first_name))
            {
                throw new Exception("השם פרטי אינו תקין");

            }
            if (!Legal.Normalcharacters(personalInformation.last_name))
            {
                throw new Exception("השם משפחה אינו תקין");

            }
            if (!Legal.Normalcharacters(personalInformation.address))
            {
                throw new Exception("הכתובת אינה תקינה");

            }
            if(!Legal.IsTelephone("0"+personalInformation.phone.ToString()))
            {
                throw new Exception("הטלפון אינו תקין");
            }

            if(!Legal.IsCellPhone("0"+personalInformation.mobile.ToString()))
               {
                throw new Exception("הטלפון הנייד אינו תקין");
               }

            if(Legal.GetAge(personalInformation.birthday)>120 ||Legal.GetAge(personalInformation.birthday)<0)
            {
                throw new Exception("תאריך לא תקין");
            }

        }

      
    }
}
