using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using BL;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IllnessController : ControllerBase
    {
        IllnessDates_BL illnessDates_BL = new IllnessDates_BL();
        [HttpGet]
        [Route("getall")]
        public List<IllnessDate> GetAll()
        {
            return illnessDates_BL.GetAll();
        }

        //[HttpPost]'
        //[Route("update")]
        //public IllnessDate Update(IllnessDate illness)
        //{
        //    return illnessDates_BL.Update(illness);
        //}
        //[HttpPost]
        //[Route("delete")]
        //public IllnessDate Delete(IllnessDate illness)
        //{
        //    return illnessDates_BL.Delete();
        //}
        //[HttpPost]
        //[Route("create")]
        //public IllnessDate Add(IllnessDate illnessDate)
        //{
        //    return illnessDates_BL.Add(illnessDate);
        //}
    }
}
