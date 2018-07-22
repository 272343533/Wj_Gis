using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMvcExpress.Dao;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using QyTech.Core.BLL;
using QyTech.Json;
using log4net;
using System.Security.Cryptography;

namespace WTGeoWeb.Controllers
{
    public class LtdInfoZuLinController : Controller
    {
        //
        // GET: /LtdInfoZuLin/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult QueryLtdInfo(string dkbm)
        {
           // dkbm = "KFQQY055";
            List<z租赁企业信息表> objs = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<z租赁企业信息表>("DKBH='"+dkbm+"'","ZLQYMC_");
            List<string> ltdNames = new List<string>();
            if (objs.Count > 0)
            {
                foreach (z租赁企业信息表 obj in objs)
                {
                    ltdNames.Add(obj.ZLQYMC_);
                }
            }
            var source = ltdNames;
            return Json(source, JsonRequestBehavior.AllowGet);
        } 

    }
}
