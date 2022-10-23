using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
namespace API.Controllers
{

   [Produces("application/json")]
   [Consumes("application/json")]
    [Route("api/personalinformation")]
    [ApiController]
    public class PersonalInformatioController : Controller
    {
        BL_PersonalInformation BL_PersonalInformation=new BL_PersonalInformation();
        [Route("getall")]
        [HttpGet]
        public List<PersonalInformation> GetAll()
        {
            return BL_PersonalInformation.GetAll();
        }
        [Route("get")]
        [HttpGet]
        public string get()
        {
            return "aaa";
        }
        [Route("update")]
        [HttpPost]
        public int Update([FromBody]string value)
        {
            return -1;
        }

        
    }
}
