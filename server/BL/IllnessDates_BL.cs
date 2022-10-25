using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
using DAL;
using MongoDB.Bson;
using MongoDB.Driver;
namespace BL
{
    public class IllnessDates_BL
    {
        IllnessDate_DAL illnessDate_DAL;
        public IllnessDates_BL()
        {
            illnessDate_DAL = new IllnessDate_DAL("illnessDates");
        }
        public List<IllnessDate> GetAll()
        {
            return illnessDate_DAL.GetAll();
        }

        public IllnessDate Update(IllnessDate illness)
        {
            return null;
          //  return illnessDate_DAL.Update(illness);
        }

        public IllnessDate Delete()
        {
            throw new NotImplementedException();
        }

        public BsonDocument Add(IllnessDate illness)
        {
          return illnessDate_DAL.Create(illness);

        }
    }
}
