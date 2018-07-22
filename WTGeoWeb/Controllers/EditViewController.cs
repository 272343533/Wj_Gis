using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QyTech.Core.BLL;
using QyTech.Core.Common;
using QyTech.Core;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;
using QyTech.Json;
using System.Globalization;
using log4net;
using log4net.Config;
using QyTech.Json;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace WTGeoWeb.Controllers
{
    public class EditViewController : Controller
    {
        //
        // GET: /EditView/
        ILog log = log4net.LogManager.GetLogger("EditView");
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 土地现状
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult TdxzWebView(string id = "320507100202CQ0001")
        {
            log.Error("id:" + id.ToString());
            ViewBag.Id = id;
            return View();
        }


        /// <summary>
        /// 房屋建筑建筑
        /// </summary>
        /// <returns></returns>
        public ActionResult FwjzWebView(string id,string bsU_Id)
        {
            bsUser obj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_Id", Guid.Parse(bsU_Id));
            log.Info("login1:" + obj.bsR_Name);
            if (obj != null)
            {
                ViewBag.bsU_Id = bsU_Id;
                ViewBag.UserCanEdit = obj.bsR_Name == "管理员" ? "true" : "false";
            }

            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public JsonResult GetFwjzInfo(int id)
        {
            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                房屋建筑 obj = db.房屋建筑.Where(t => t.OBJECTID == id).FirstOrDefault<房屋建筑>();
                JsonResult json = new JsonResult();
                json.Data = new
                {
                    OBJECTID = obj.OBJECTID,
                    JZBH = obj.JZBH,
                    JZMJ = obj.JZMJ,
                    JZZDMJ = obj.JZZDMJ,
                    //ssdkdm = obj.所属地块代码,
                    SSYDQYMC = obj.SSYDQYMC,
                    LCS = obj.LCS,
                    SSZLQYMC = obj.SSZLQYMC,
                    SSXZQMC = obj.SSXZQMC,
                    SSGLQMC = obj.SSGLQMC,
                    //bz = obj.备注
                };
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
        }

        
    
        public JsonResult SaveFwjzInfo(FormCollection fc)
        {

            int objid =Convert.ToInt32( fc["OBJECTID"]);
            JsonResult json = new JsonResult();
            json.Data = "保存成功";
              
            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                房屋建筑 obj = db.房屋建筑.SingleOrDefault<房屋建筑>(t => t.OBJECTID == objid);
                try
                {
                    obj.JZBH = fc["JZBH"];
                    obj.JZMJ =fc["JZMJ"];
                    obj.JZZDMJ = fc["JZZDMJ"];
                    //obj.SSDKBH = fc["SSDKBH"];
                    obj.SSYDQYMC = fc["SSYDQYMC"];
                    obj.LCS = fc["LCS"];
                    //obj.开发商名称 = fc["开发商名称"];
                    obj.SSZLQYMC = fc["SSZLQYMC"];
                    //obj.所属行政镇名称 = fc["所属行政镇名称"];
                    //obj.所属行政村名称 = fc["所属行政村名称"];
                    //obj.备注 = fc["bz"];
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    log.Error("SaveFwjzInfo" + e.Message);
                    json.Data = "保存失败";
                }
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;
        }

        public ActionResult LtdProblemWebView(string id = "320507100208QY0072f001")
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public JsonResult GetLtdProblemInfo(string id)
        {
            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                LtdProblem obj = db.LtdProblem.Where(t => t.SSDKBM == id).FirstOrDefault<LtdProblem>();
                JsonResult json = new JsonResult();
                if (obj != null)
                {
                    json.Data = new
                    {
                        SSDKBM = obj.SSDKBM,
                        CCLX = obj.CCLX,
                        CCDM = obj.CCDM,
                        CCNR = obj.CCNR,
                        CCRQ = obj.CCRQ,
                        CXDM = obj.CXDM,
                        CXRQ = obj.CXRQ,
                        SCDM = obj.SCDM,
                        SCRQ = obj.SCRQ,
                        SSQYBM = obj.SSQYBM,
                        AQZPDBM = obj.AQZPDBM
                    };
                }
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
        }


        public ActionResult LtdRegularWebView(string id = "320507100208QY0072f001")
        {
            ViewBag.Id = id;
            return View();
        }
        [HttpPost]
        public JsonResult GetLtdRegularInfo(string id)
        {
            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                LtdRegular obj = db.LtdRegular.Where(t => t.SSDKBM == id).FirstOrDefault<LtdRegular>();
                JsonResult json = new JsonResult();
                if (obj != null)
                {
                    if (obj.SBRQ != null)
                    {
                        json.Data = new
                        {
                            SSDKBM = obj.SSDKBM,
                            SSQYBM = obj.SSQYBM,
                            AQZD = obj.AQZD,
                            XFZD = obj.XFZD,
                            CWZD = obj.CWZD,
                            SBND = obj.SBND,
                            SBRQ = obj.SBRQ.Value.ToString("yyyy-MM-dd"),
                            AQZPDBM = obj.AQZPDBM

                        };
                    }
                    else
                    {
                        json.Data = new
                        {
                            SSDKBM = obj.SSDKBM,
                            SSQYBM = obj.SSQYBM,
                            AQZD = obj.AQZD,
                            XFZD = obj.XFZD,
                            CWZD = obj.CWZD,
                            SBND = obj.SBND,
                            SBRQ =DateTime.Today.ToString("yyyy-MM-dd"),
                            AQZPDBM = obj.AQZPDBM

                        };
                    }
                }
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
        }
      

        /// <summary>
        /// 企业范围
        /// </summary>
        /// <returns></returns>
        public ActionResult QyxxWebView(string id, string bsU_Id)
        {
            log.Error("id:" + id.ToString()+"---bsU_Id"+bsU_Id);
            ViewBag.Id = id;
            bsUser obj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_Id", Guid.Parse(bsU_Id));
            log.Info("login1:" + obj.bsR_Name);
            if (obj != null)
            {
                ViewBag.bsU_Id = bsU_Id;
                ViewBag.UserCanEdit = obj.bsR_Name == "管理员" ? "true" : "false";
            }
            return View();
        }
        [HttpPost]
        public JsonResult GetQyxxInfo(string id)
        {
            log.Error("id:" + id);
            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                //土地现状数据 obj = EntityManagerUsingT.GetBySql<土地现状数据>("土地现状数据", "[地块编码]='" + id + "'");
                企业范围 obj = db.企业范围.Where(t => t.DKBH == id).FirstOrDefault<企业范围>();
                JsonResult json = new JsonResult();
                json.Data = new
                {
                   // dkmc = obj.地块名称,
                    DKBH = obj.DKBH,
                    YDQYMC = obj.YDQYMC,
                    SSGLQDM = obj.SSGLQDM,
                    ZLQYMC_ = obj.ZLQYMC_,
                    ZDMJ=obj.ZDMJ,
                    FZMJ_ = obj.FZMJ_,
                    JZZDMJ = obj.JZZDMJ,
                    JZMJ = obj.JZMJ,
                    TDZL = obj.TDZL,
                    QSXZ = obj.QSXZ

                };
                json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                return json;
            }
        }
      
        public ActionResult SaveLtdRegularInfo(FormCollection fc)
        {
            string dkbm = fc["SSDKBM"];
            JsonResult json = new JsonResult();
            json.Data = "保存成功";

             using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                LtdRegular obj = db.LtdRegular.SingleOrDefault<LtdRegular>(t => t.SSDKBM == dkbm);
                try
                {
                    obj.SSDKBM = fc["SSDKBM"];
                    //obj.地块编码 = fc["地块编码"];
                    obj.SSQYBM = fc["SSQYBM"];
                    obj.AQZD = fc["AQZD"];
                    obj.XFZD = fc["XFZD"];
                    obj.CWZD = fc["CWZD"];
                    obj.SBND = fc["SBND"];
                    try
                    {
                        obj.SBRQ =Convert.ToDateTime(fc["SBRQ"]);
                    }
                    catch (Exception ex)
                    {
                        obj.SBRQ = DateTime.Today;
                    }
                    obj.AQZPDBM = fc["AQZPDBM"];
                     db.SaveChanges();
                }
                catch (Exception e)
                {
                    log.Error("SaveLtdRegularInfo" + e.Message);
                    json.Data = "保存失败,请确保所有数据正确输入！";
                }
            }
             json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
             return json;
        
        }

        public ActionResult SaveQyxxInfo(FormCollection fc)
        {
            string dkbm = fc["DKBH"];
            JsonResult json = new JsonResult();
            json.Data = "保存成功";

            using (wj_GisDbEntities db = new wj_GisDbEntities())
            {
                企业范围 obj = db.企业范围.SingleOrDefault<企业范围>(t => t.DKBH == dkbm);
                try
                {
                    obj.DKBH = fc["DKBH"];
                    //obj.地块编码 = fc["地块编码"];
                    obj.YDQYMC = fc["YDQYMC"];
                    try
                    {
                        obj.JZMJ = decimal.Parse(fc["JZMJ"]);
                    }
                    catch { }
                    try
                    {
                        obj.ZDMJ = decimal.Parse(fc["ZDMJ"]);
                    }
                    catch { }
                    try
                    {
                        obj.FZMJ_ = decimal.Parse(fc["FZMJ_"]);
                    }
                    catch { }
                    try
                    {
                        obj.JZZDMJ = decimal.Parse(fc["JZZDMJ"]);
                    }
                    catch { }

                    obj.SSGLQDM = fc["SSGLQDM"];
                    obj.TDZL = fc["TDZL"];
                    obj.QSXZ = fc["QSXZ"];
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    log.Error("SaveQyxxInfo" + e.Message);
                    json.Data = "保存失败,请确保所有数据正确输入！";
                }
            }
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;


        }

        public JsonResult GetLtdRentInfo(string id)
        {
            List<z租赁企业信息表> objs=BLL.CommSetting.EM.GetListNoPaging<z租赁企业信息表>("DKBH='"+id+"'","");

            JsonResult json = new JsonResult();
            json.Data = objs;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;

        }
    }
}
