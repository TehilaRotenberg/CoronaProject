using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
namespace API.Controllers
{

  //[Produces("application/json")]
  //[Consumes("application/json")]
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
        
        [Route("update")]
        [HttpPost]
        public string Update([FromBody]PersonalInformation personalInformation)
        {
           return BL_PersonalInformation.Update(personalInformation);
        }
        [Route("delete")]
        [HttpPost]
       
        public PersonalInformation Delete([FromBody]PersonalInformation personalInformation)
        {
            //return personalInformation;
           return BL_PersonalInformation.Delete(personalInformation);
        }
        [Route("add")]
        [HttpPost]
        public string Add([FromBody]PersonalInformation personalInformation)
        {
            return BL_PersonalInformation.Add(personalInformation);
        }
        


    }
}
