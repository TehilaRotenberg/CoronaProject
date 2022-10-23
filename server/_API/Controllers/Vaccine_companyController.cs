using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

namespace _API.Controllers
{
    [Route("api/vaccine_company")]
    [ApiController]
    public class Vaccine_companyController : ControllerBase
    {
        Vaccine_company_BL vaccine_Company_BL = new Vaccine_company_BL();
        [HttpGet]
        [Route("getall")]
        public List<Vaccine_company>GetAll()
        {
            return vaccine_Company_BL.GetAll();
        }


    }
}
