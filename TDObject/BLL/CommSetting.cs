using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Objects;
using SunMvcExpress.Dao;
using QyTech.Core.BLL;

namespace TDObject.BLL
{
    public class CommSetting
    {
        public static ObjectContext dblink = new SunMvcExpress.Dao.wj_GisDbEntities();

        public static EntityManager EM = new EntityManager(dblink);
    }
}
