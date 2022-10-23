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
        PersonalInformations personalInformations;

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
                cheackLegal(personalInformation);
                personalInformations.Add(personalInformation);
                return "success";
            }
            catch(Exception ex)
            {
                return ex.Message;
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
            if(!Legal.IsTelephone(personalInformation.phone.ToString()))
            {
                throw new Exception("הטלפון אינו תקין");
            }

            if(!Legal.IsCellPhone(personalInformation.mobile.ToString()))
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
