using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;
using System.Collections.Generic;

namespace API.Controllers
{
    [Route("api/personalInformation")]
    [ApiController]
    public class personalInformationController : ControllerBase
    {
        [Route("getall")]
        [HttpGet]
        public List<PersonalInformation> GetAll()
        {
            BL_PersonalInformation personalInformationBL = new BL_PersonalInformation();
            return personalInformationBL.GetAll();
        }
    }
}
