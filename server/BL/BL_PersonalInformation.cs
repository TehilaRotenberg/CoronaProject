using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
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

        public PersonalInformation Update(PersonalInformation personalInformation)
        {
            return personalInformations.Update(personalInformation);
        }
    }
}
