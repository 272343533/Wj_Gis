using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SunMvcExpress.Dao;
using QyTech.Json;
using log4net;


namespace WTGeoWeb.Controllers
{
    public class bsVisitLogController : Controller
    {
        //
        // GET: /bsVisitLog/
        ILog log = log4net.LogManager.GetLogger("bsVisitLog");

        public ActionResult Index()
        {
            return View();
        }
        public string Add(string userid,string browser,string visitdesp)
        {
            log.Info(userid + ":" + browser + ":" + visitdesp);
             string jsonret = "";
            try
            {

                bsVisitLog vl = new bsVisitLog();
                vl.VisitId = Guid.NewGuid();
                vl.VisitDt = DateTime.Now;
                vl.userId = Guid.Parse(userid);
                vl.Brower = browser;
                vl.VisitDesp = visitdesp;

                string ret = WTGeoWeb.BLL.CommSetting.EM.Add<bsVisitLog>(vl);

                if (ret == "")
                    jsonret = jsonMsgHelper.Create(0, null, "Success");

                else
                    jsonret = jsonMsgHelper.Create(1, null, ret);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
               jsonret = jsonMsgHelper.Create(1, null, ex.Message);
            }
            return jsonret;
        }

    }
}
