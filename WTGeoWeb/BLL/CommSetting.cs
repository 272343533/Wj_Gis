using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Objects;
using QyTech.Core.BLL;

namespace WTGeoWeb.BLL
{
    public class CommSetting
    {
        
        public static ObjectContext dblink = new SunMvcExpress.Dao.wj_GisDbEntities();

        public static EntityManager EM = new EntityManager(dblink);
        public static EntityManager EM_Base = new EntityManager(new QyTech.Auth.Dao.QyTech_AuthEntities());
    }
}