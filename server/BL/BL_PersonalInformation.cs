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
        public List<PersonalInformation> GetAll()
        {
            PersonalInformations personalInformations = new PersonalInformations("personalInformations");
            return personalInformations.GetAll();
        }
        
    }
}
