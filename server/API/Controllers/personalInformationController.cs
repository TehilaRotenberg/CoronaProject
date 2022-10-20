using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;


namespace API.Controllers
{
    [Route("api/personalInformation")]
    [ApiController]
    public class personalInformationController : ControllerBase
    {
        [Route("getall")]
        [HttpPost]
        public List<PersonalInformation> GetAll()
        {
            BL_PersonalInformation personalInformationBL = new BL_PersonalInformation();
            return personalInformationBL.GetAll();
        }
    }
}
