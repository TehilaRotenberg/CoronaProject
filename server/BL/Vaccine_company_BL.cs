using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;

namespace BL
{
    public class Vaccine_company_BL
    {
        Vaccine_company_DAL vaccine_Company;
        public Vaccine_company_BL()
        {
            vaccine_Company = new Vaccine_company_DAL("vaccine_company");
        }
        public List<Vaccine_company> GetAll()
        {
            return vaccine_Company.GetAll();
        }
    }
}
