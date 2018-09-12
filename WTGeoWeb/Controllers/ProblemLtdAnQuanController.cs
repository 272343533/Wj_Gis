using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using SunMvcExpress.Dao;
using QyTech.Core.BLL;

using QyTech.Json;

namespace WTGeoWeb.Controllers
{


    public class ProblemLtdAnQuanController : Controller
    {
        //
        // GET: /ProblemLtdPhoto/
        ILog log = log4net.LogManager.GetLogger("lyRemoteServ");

        EntityManager EM = new EntityManager(new SunMvcExpress.Dao.wj_GisDbEntities());


        public string GetDkbms()
        {
            string strs = "";
            List<bsLtdInfo> list = new List<bsLtdInfo>();
           list = EM.GetListNoPaging<bsLtdInfo>("立案处罚情况 is not null and 地块编号 is not null", "");
            for (int i=0;i< list.Count; i++)
            {
                if(!strs.Contains(list[i].地块编号))
                    strs += ",'" + list[i].地块编号 + "'";
            }
            
            return strs.Substring(1);
        }
        public string GetByDkbm(string dkbm)
        {
            log.Info("GetByDkbm:" + dkbm);
            string json = "";

            string layername = "安全检查点位置";

            List<t立案处罚情况> list = new List<t立案处罚情况>();
            list = EM.GetListNoPaging<t立案处罚情况>("企业名称 in (select 纳税人名称 from bsLtdInfo where 地块编号='" + dkbm + "')", "");


            json = JsonHelper.SerializeObjects<t立案处罚情况>(list, new List<string>());

            return json;
        }

        public ActionResult index(string dkbm)
        {
            return View();
        }
    }
}
