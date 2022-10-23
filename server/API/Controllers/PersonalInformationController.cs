using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
namespace API.Controllers
{

 
    [Route("api/personalinformation")]
    [ApiController]
    public class PersonalInformationController : Controller
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
        public int Update([FromBody]PersonalInformation personalInformation)
        {
            return -1;
        }
      

        
    }
}
