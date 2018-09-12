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


    public class ProblemLtdPhotoController : Controller
    {
        //
        // GET: /ProblemLtdPhoto/
        ILog log = log4net.LogManager.GetLogger("lyRemoteServ");

        EntityManager EM = new EntityManager(new SunMvcExpress.Dao.wj_GisDbEntities());


        public string GetDkbms()
        {
            string strs = "";
            List<LtdPhoto> list = new List<LtdPhoto>();
            //list = EM.GetListNoPaging<LtdPhoto>("SSQYMC in (select 纳税人名称 from bsltdInfo where 地块编号='" + dkbm + "')", "");
            list = EM.GetListNoPaging<LtdPhoto>("", "");
            for (int i=0;i< list.Count; i++)
            {
                strs += ",'" + list[i].SSDKBM + "'";
            }
            
            return strs.Substring(1);
        }
        public string GetByDkbm(string dkbm)
        {
            log.Info("GetByDkbm:" + dkbm);
            string json = "";

            string layername = "企业照片点位置";

            List<LtdPhoto> list = new List<LtdPhoto>();
            //list = EM.GetListNoPaging<LtdPhoto>("SSQYMC in (select 纳税人名称 from bsltdInfo where 地块编号='" + dkbm + "')", "");
            list = EM.GetListNoPaging<LtdPhoto>("SSDKBM='" + dkbm + "'", "");


            json = JsonHelper.SerializeObjects<LtdPhoto>(list, new List<string>());

            return json;
        }

        public ActionResult index(string dkbm)
        {
            return View();
        }
    }
}
