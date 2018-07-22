using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using WTGeoWeb.BLL;
using QyTech.Json;
using Newtonsoft.Json;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;

namespace WTGeoWeb.Controllers
{
    public class ShowViewController : Controller
    {
        //
        // GET: /ShowView/
        ILog log = log4net.LogManager.GetLogger("ShowView");

        

        //没有使用
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ResultView1(String QueryType,String QueryLayer,String CountArea, String Ids,String Json)
        {
            //Json = "[{"ItemName":"工业","RegionCount":200,"RegionArea":10000},{"ItemName":"农业","RegionCount":200,"RegionArea":10000}]";
            log.Error("ResultView:" + QueryType + "-" + QueryLayer + "-" + CountArea + "-" + Ids);
            log.Error("zhb"+Json);
            ViewBag.QueryType = QueryType;
            ViewBag.QueryLayer = QueryLayer;
            ViewBag.CountArea = CountArea;
            ViewBag.Ids = Ids;
            ViewBag.Json = Json;
            return View();
        }
        //public ActionResult ResultView(String Json)
        //{
        //    log.Error("ResultView:"+Json);
              
        //    //Json="{\"LayerName\":\"村界\",\"ObjCode\":\"320507100204\"}";
        //    Session["totaldata"] = "";
           
        //    IntersectTotalInfo total = JsonHelper.DeserializeJsonToObject<IntersectTotalInfo>(Json);
        //    if (total.LayerName == "镇界" || total.LayerName == "村界")
        //    {
        //        Json = GetAdminTotalInfo(total);
        //    }
        //    else
        //    {
        //        IntersectTotalInfo newTotal = new IntersectTotalInfo();
        //        newTotal.LayerName = total.LayerName;
        //        newTotal.ObjCode = total.ObjCode;
        //        newTotal.ObjName = total.ObjName;
        //        newTotal.totalLayers = new List<TotalLayerInfo>();
        //        TotalLayerInfo[] layers = new TotalLayerInfo[4];
        //        foreach(TotalLayerInfo tli in total.totalLayers)
        //        {
        //            if (tli.ItemName == "土地现状数据")
        //                layers[0] = tli;
        //            else if (tli.ItemName == "城市规划")
        //                layers[1] = tli;
        //            else if (tli.ItemName == "土地规划")
        //                layers[2] = tli;
        //            else if (tli.ItemName == "历年批次")
        //            {
        //                //按照地块编码分组
        //                TotalLayerInfo temptli = new TotalLayerInfo();
        //                temptli.BuildingArea = tli.BuildingArea;
        //                temptli.FloorArea = tli.FloorArea;
        //                temptli.ItemName = tli.ItemName;
        //                temptli.ItemNo = tli.ItemNo;
        //                temptli.RegionArea =Math.Round(tli.RegionArea,2);
        //                temptli.RegionCount = 0;
        //                temptli.totalTypes = new List<TotalTypeInfo>();

        //                int ltdno = 1;
        //                foreach (TotalTypeInfo tti in tli.totalTypes)
        //                {
        //                    foreach (TotalLtdInfo ltdi in tti.totalLtds.Values)
        //                    {
        //                       TotalTypeInfo temptti = new TotalTypeInfo();
        //                       temptti.BuildingArea = ltdi.BuildingArea;
        //                       temptti.FloorArea = ltdi.FloorArea;
        //                       temptti.ItemName = ltdi.LtdName;
        //                       temptti.ItemNo = ltdno++;
        //                       temptti.RegionArea = ltdi.RegionArea;
        //                       temptti.RegionCodes = ltdi.RegionCode;
        //                       temptti.RegionCount = 1;

        //                       temptli.totalTypes.Add(temptti);
        //                    }
        //                }
        //                layers[3] = temptli;
        //            }
        //        }
        //        foreach (TotalLayerInfo tli in layers)
        //        {
        //            newTotal.totalLayers.Add(tli);
        //        }

        //        Json = JsonConvert.SerializeObject(newTotal);

        //        log.Error("trans:"+Json);
        //        Session["totaldata"] = Json;
        //    }
        //    ViewBag.Json = Json;
        //    return View();
        //}


        //public string GetAdminTotalInfoForPc(string LayerName,string objCode,string objName)
        //{
        //    IntersectTotalInfo total =new IntersectTotalInfo();

        //    total.LayerName=LayerName;
        //    total.ObjCode=objCode;
        //    total.ObjName=objName;

        //    return GetAdminTotalInfo(total);
        //}

        /// <summary>
        /// total.LayerName == "村界" || total.LayerName == "镇界"
        /// </summary>
        /// <param name="Json"></param>
        /// <returns></returns>
        //public string GetAdminTotalInfo(IntersectTotalInfo total)
        //{
          
            
        //    if (total.LayerName == "" || total.LayerName ==null)
        //        return null;
           
        //    //List<tmpadminTotalInfo> tmplayerinfos = EntityManager<tmpadminTotalInfo.GetAllByStorProcedure<tmpadminTotalInfo>("splyQueryTotalItem", "15,'"+total.LayerName+"','"+total.ObjCode+"'");
        //    List<tmpadminTotalInfo> tmplayerinfos = WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<tmpadminTotalInfo>("splyQueryTotalItem", new object[]{15,total.LayerName,total.ObjCode});
             
        //     total.totalLayers = new List<TotalLayerInfo>();

        //    int layno = 0;
        //    foreach (tmpadminTotalInfo item in tmplayerinfos)
        //    {
        //        if (item.ItemName == "")
        //        {
        //            TotalLayerInfo tli = new TotalLayerInfo();
        //            tli.totalTypes = new List<TotalTypeInfo>();

        //            tli.ItemNo = ++layno;
        //            tli.ItemName = item.ItemName;
        //            tli.RegionCount = (int)item.RegionCount;
        //            tli.RegionArea = (decimal)item.RegionArea;
        //            tli.BuildingArea = (decimal)item.BuildingArea;
        //            tli.FloorArea = (decimal)item.FloorArea;
                
        //            total.totalLayers.Add(tli);
        //        }
        //        else
        //        {
        //            TotalTypeInfo tti = new TotalTypeInfo();
        //            tti.ItemNo = item.ItemNo;
        //            tti.ItemName = item.ItemName;
        //            tti.BuildingArea = (decimal)item.BuildingArea;
        //            tti.FloorArea = (decimal)item.FloorArea;
        //            tti.RegionArea = (decimal)item.RegionArea;
        //            tti.RegionCount = (int)item.RegionCount;
        //            tti.RegionCodes = item.RegionCodes;

        //            total.totalLayers[layno - 1].totalTypes.Add(tti);
        //        }
        //    }

        //    return JsonConvert.SerializeObject(total);
        //}

        public JsonResult TestResultView()
        {
            IntersectTotalInfo total = GetTestData();
            JsonResult json = new JsonResult();
            json.Data = total;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
          
            //ViewBag.Json = Json;
            return json;
        }

        public IntersectTotalInfo GetTestData()
        {
            IntersectTotalInfo total;
            TotalLayerInfo tiLayer;
            TotalTypeInfo item;
            TotalLtdInfo ltdinfo;

            total = new IntersectTotalInfo();
            total.LayerName = "工业管理区";
            total.ObjCode = "111111";
            total.ObjName = "工业管理区1";
            total.totalLayers = new List<TotalLayerInfo>();

            tiLayer = new TotalLayerInfo();
            tiLayer.ItemNo = 1;
            tiLayer.ItemName = "土地现状数据";
            tiLayer.BuildingArea = 12;
            tiLayer.FloorArea = 12;
            tiLayer.RegionArea = 120000;
            tiLayer.RegionCount = 12;
            tiLayer.totalTypes = new List<TotalTypeInfo>();
            for (int i = 0; i < 5; i++)
            {
                item = new TotalTypeInfo();
                item.ItemNo = i + 1;
                item.ItemName = "土地现状数据类型" + item.ItemNo.ToString();
                item.BuildingArea = 22 * item.ItemNo;
                item.FloorArea = 11 * item.ItemNo;
                item.RegionArea = 100000 * item.ItemNo;
                item.RegionCount = 10 * item.ItemNo;
                item.RegionCodes = "111,112,113";

                item.totalLtds = new Dictionary<string,TotalLtdInfo>();

                for (int j = 0; j < 3; j++)
                {
                    ltdinfo = new TotalLtdInfo();
                    ltdinfo.LtdNo = j + 1;
                    ltdinfo.LtdName = "公司" + item.ItemNo.ToString();
                    ltdinfo.BuildingArea = 22 * item.ItemNo;
                    ltdinfo.FloorArea = 11 * item.ItemNo;
                    ltdinfo.RegionCode = ltdinfo.LtdNo.ToString();

                    item.totalLtds.Add(ltdinfo.RegionCode,ltdinfo);
                }
                tiLayer.totalTypes.Add(item);

            }
            total.totalLayers.Add(tiLayer);

            tiLayer = new TotalLayerInfo();
            tiLayer.ItemNo = 2;
            tiLayer.ItemName = "城市规划";
            tiLayer.BuildingArea = 12;
            tiLayer.FloorArea = 12;
            tiLayer.RegionArea = 120000;
            tiLayer.RegionCount = 12;
            tiLayer.totalTypes = new List<TotalTypeInfo>();
            for (int i = 0; i < 5; i++)
            {
                item = new TotalTypeInfo();
                item.ItemNo = i + 1;
                item.ItemName = "城市规划类型" + item.ItemNo.ToString();
                item.BuildingArea = 22 * item.ItemNo;
                item.FloorArea = 11 * item.ItemNo;
                item.RegionArea = 100000 * item.ItemNo;
                item.RegionCount = 10 * item.ItemNo;

                tiLayer.totalTypes.Add(item);
            }
            total.totalLayers.Add(tiLayer);


            tiLayer = new TotalLayerInfo();
            tiLayer.ItemNo = 3;
            tiLayer.ItemName = "土地规划";
            tiLayer.BuildingArea = 12;
            tiLayer.FloorArea = 12;
            tiLayer.RegionArea = 120000;
            tiLayer.RegionCount = 12;
            tiLayer.totalTypes = new List<TotalTypeInfo>();
            for (int i = 0; i < 5; i++)
            {
                item = new TotalTypeInfo();
                item.ItemNo = i + 1;
                item.ItemName = "土地规划类型" + item.ItemNo.ToString();
                item.BuildingArea = 22 * item.ItemNo;
                item.FloorArea = 11 * item.ItemNo;
                item.RegionArea = 100000 * item.ItemNo;
                item.RegionCount = 10 * item.ItemNo;

                tiLayer.totalTypes.Add(item);
            }
            total.totalLayers.Add(tiLayer);


            tiLayer = new TotalLayerInfo();
            tiLayer.ItemNo = 4;
            tiLayer.ItemName = "批次供地";
            tiLayer.BuildingArea = 12;
            tiLayer.FloorArea = 12;
            tiLayer.RegionArea = 120000;
            tiLayer.RegionCount = 12;
            tiLayer.totalTypes = new List<TotalTypeInfo>();
            for (int i = 0; i < 5; i++)
            {
                item = new TotalTypeInfo();
                item.ItemNo = i + 1;
                item.ItemName = "批次号" + item.ItemNo.ToString();
                tiLayer.totalTypes.Add(item);
            }
            total.totalLayers.Add(tiLayer);

            return total;
        }

        //public ActionResult UrbanPlanning()
        //{
        //    return View();
        //}
        //public ActionResult LandPlanning()
        //{
        //    return View();
        //}
        //public ActionResult BatchLandSupply()
        //{
        //    return View();
        //}
        //public ActionResult Details(string TotalTypeName, string bsOCodes, int CodeType = 1)
        //{
        //    ViewBag.TotalTypeName = TotalTypeName;
        //    ViewBag.bsOCodes = bsOCodes;
        //    ViewBag.CodeType = CodeType;
        //    return View();
        //}

        //public ActionResult Details(string StrJson)
        //{
        //    IntersectTotalInfo total = JsonHelper.DeserializeJsonToObject<IntersectTotalInfo>(StrJson);

        //    List<TotalLtdInfo> ltdinfs = total.totalLayers[0].totalTypes[0].totalLtds;

        //    return View();
        //}

        public ActionResult Details(string TotalTypeName,string regionCodes)
        {

            ViewBag.TotalTypeName = TotalTypeName;
            ViewBag.regionCodes = regionCodes;

            return View();
        }

        //public JsonResult GetTypeDetails(string regionCodes, string typename)
        //{
        //    JsonResult json = new JsonResult();
        //    int ltdno = 1;
        //     List<TotalLtdInfo> ltdinfos = new List<TotalLtdInfo>();// total.totalLayers[0].totalTypes[0].totalLtds;
        
        //    string Json = Session["totaldata"].ToString();
        //    if (Json!="")
        //    {
        //        IntersectTotalInfo total = JsonHelper.DeserializeJsonToObject<IntersectTotalInfo>(Json);
          
        //        foreach (TotalTypeInfo tti in total.totalLayers[0].totalTypes)
        //        {
        //            if (tti.ItemName == typename)
        //            {
        //                foreach (TotalLtdInfo tltdi in tti.totalLtds.Values)
        //                {
        //                    TotalLtdInfo tempi = tltdi;
        //                    tempi.LtdNo = ltdno++;
        //                    ltdinfos.Add(tempi);
        //                }
        //            }

        //        }
        //    }
        //    else
        //    {
        //        List<tmpTotalLtdInfo> tmpltdinfos;
        //        //tmpltdinfos = EntityManager<tmpTotalLtdInfo>.GetAllByStorProcedure<tmpTotalLtdInfo>("splyGetLtdTotalInfo", "'" + typename + "','" + regionCodes + "'");
        //        tmpltdinfos = WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<tmpTotalLtdInfo>("splyGetLtdTotalInfo", new object[] { typename, regionCodes });
        //         foreach (tmpTotalLtdInfo item in tmpltdinfos)
        //        {
        //            TotalLtdInfo ltdinfo = new TotalLtdInfo();
        //            ltdinfo.LtdNo = ltdno++;
        //            ltdinfo.LtdName = item.LtdName;
        //            ltdinfo.BuildingArea = Convert.ToDecimal(item.BuildingArea);
        //            ltdinfo.FloorArea = Convert.ToDecimal(item.FloorArea);
        //            ltdinfo.RegionArea = Convert.ToDecimal(item.RegionArea);
        //            ltdinfo.RegionCode = item.RegionCode;

        //            ltdinfos.Add(ltdinfo);
        //        }

        //     }
        //    json.Data = ltdinfos;
        //    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

        //    return json;
        //}

        ////public string GetTypeDetailsForPc(string regionCodes,string typename)
        ////{
        ////    log.Info("GetTypeDetailsForPc:" + regionCodes);
        ////    List<TotalLtdInfo> ltdinfos = new List<TotalLtdInfo>();// total.totalLayers[0].totalTypes[0].totalLtds;
        ////    List<tmpTotalLtdInfo> tmpltdinfos;
        ////    //tmpltdinfos = EntityManager<tmpTotalLtdInfo>.GetAllByStorProcedure<tmpTotalLtdInfo>("splyGetLtdTotalInfo", "'" + typename + "','" + regionCodes + "'");
        ////    tmpltdinfos = WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<tmpTotalLtdInfo>("splyGetLtdTotalInfo", new object[]{ typename , regionCodes});
        ////    log.Info("GetTypeDetailsForPc:tmpltdinfos");
        ////    int ltdno = 1;
        ////    foreach (tmpTotalLtdInfo item in tmpltdinfos)
        ////    {
        ////        TotalLtdInfo ltdinfo = new TotalLtdInfo();
        ////        ltdinfo.LtdNo = ltdno++;
        ////        ltdinfo.LtdName = item.LtdName;
        ////        ltdinfo.BuildingArea = Convert.ToDecimal(item.BuildingArea);
        ////        ltdinfo.FloorArea = Convert.ToDecimal(item.FloorArea);
        ////        ltdinfo.RegionArea = Convert.ToDecimal(item.RegionArea);
        ////        ltdinfo.RegionCode = item.RegionCode;

        ////        ltdinfos.Add(ltdinfo);
        ////    }

        ////    string ret = JsonConvert.SerializeObject(ltdinfos);

        ////    return ret;
        ////}

        public ActionResult CompanyDetails(string regionCode, string ltdName)
        {
            ViewBag.ltdName = ltdName;
            ViewBag.REgionCode = regionCode;
            return View();
        }

        public JsonResult GetLtdDetails(string regionCode, string ltdName)
        {
            企业范围 obj = WTGeoWeb.BLL.CommSetting.EM.GetBySql<企业范围>("地块编码='" + regionCode + "'");
            LtdInfo jobj = new LtdInfo();
            //jobj.Name = obj.企业名称;
            jobj.DKBM = obj.DKBH;
            //jobj.DLMC = obj.地类名称;
            //jobj.PreName = obj.原企业名称;
            //jobj.YDDMWC = obj.用地单位名称;
            //jobj.TDZLQYMC = obj.土地租赁企业名称;
            //jobj.SSXZCMC = obj.所属行政村名称;
            //jobj.KFSMC = obj.开发商名称;
            //jobj.ZDMJ = (decimal)obj.占地面积;
            //jobj.DKFUJZZDMJ = (decimal)obj.地块附属建筑占地面积;
            //jobj.DMFSJZMJ = (decimal)obj.地块附属建筑面积;

            JsonResult json = new JsonResult();
            json.Data = jobj;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }
    }
}
