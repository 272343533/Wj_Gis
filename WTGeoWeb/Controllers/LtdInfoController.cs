using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QyTech.Core.BLL;
using QyTech.Core.Common;
using QyTech.Core;

using SunMvcExpress.Dao;
using QyTech.Json;


namespace WTGeoWeb.Controllers
{
    public class LtdInfoController : Controller
    {
        //
        // GET: /LtdInfo/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult QueryLtdInfo(string regionCode)
        {
            企业范围 obj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<企业范围>("Name", regionCode);
            var source= obj;
            return Json(source, JsonRequestBehavior.AllowGet);
        }


        public ActionResult LtdInfo()
        {
            return View();
        }

      
    }
}
