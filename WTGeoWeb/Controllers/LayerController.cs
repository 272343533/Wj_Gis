using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WTGeoWeb.BLL;
using SunMvcExpress.Dao;
using SunMvcExpress.Core;
using QyTech.Core.BLL;

namespace WTGeoWeb.Controllers
{

    public class LayTotalConf
    {
        public string LayName { get; set; }

        public int TotalFIndex { get; set; }
        public string TotalFName { get; set; }

        public Dictionary<string, string> FValue2TotalName { set;get; }

    }

    public class LayerController : Controller
    {
        
        // GET: /Layer/
        public JsonResult GetLayerAddr()
        {
            LayerInfo obj = new LayerInfo();
            Dictionary<string, LayerInfo> layers = obj.GetPubLayers();

            JsonResult json = new JsonResult();
            json.Data = layers;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;

            return json;
        }


        public JsonResult GetLayerTotalConf()
        {
          

            Dictionary<string, List<LayTotalConf>> layconf = new Dictionary<string, List<LayTotalConf>>();

            #region config
            List<LayTotalConf> lconfs;
            LayTotalConf lconf;
            //土地现状数据
            lconfs = new List<LayTotalConf>();
            lconf = new LayTotalConf();
            lconf.LayName = "土地现状数据";
            lconf.TotalFName = "地类名称";
            lconf.TotalFIndex = 3;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            lconf.FValue2TotalName.Add("工业用地", "工业");
            lconf.FValue2TotalName.Add("经营性住宅用地", "经营性住宅");
            lconf.FValue2TotalName.Add("行政事业用地", "行政事业用地");
            lconf.FValue2TotalName.Add("行政事业单位", "行政事业用地");
            lconf.FValue2TotalName.Add("商业用地", "商业用地");
            lconf.FValue2TotalName.Add("拆迁安置用地", "拆迁安置区");
            lconf.FValue2TotalName.Add("空闲地", "空闲地");
            lconf.FValue2TotalName.Add("铁路", "交通用地");
            lconf.FValue2TotalName.Add("道路面", "交通用地");
            lconf.FValue2TotalName.Add("河流", "河流水域");
            lconf.FValue2TotalName.Add("旱地", "农用地");
            lconf.FValue2TotalName.Add("果园", "农用地");
            lconf.FValue2TotalName.Add("耕地", "农用地");
            lconf.FValue2TotalName.Add("村庄", "农村宅基地");
            lconf.FValue2TotalName.Add("宗教用地", "宗教用地");
            lconfs.Add(lconf);

            layconf.Add(lconf.LayName, lconfs);



            //土地规划：
            lconfs = new List<LayTotalConf>();
            lconf = new LayTotalConf();
            lconf.LayName = "土地规划";
            lconf.TotalFName = "建设用地管理区类型";
            lconf.TotalFIndex = 8;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            lconf.FValue2TotalName.Add("允许建设区", "允许建设区");
            lconf.FValue2TotalName.Add("有条件建设区", "有条件建设区");
            lconf.FValue2TotalName.Add("限制建设区", "限制建设区");
            lconfs.Add(lconf);

            lconf = new LayTotalConf();
            lconf.LayName = "土地规划";
            lconf.TotalFName = "土地用途区类型";
            lconf.TotalFIndex = 11;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            lconf.FValue2TotalName.Add("城镇建设用地区", "城镇建设用地区");
            lconf.FValue2TotalName.Add("村镇建设用地区", "村镇建设用地区");
            lconf.FValue2TotalName.Add("独立工矿用地区", "独立工矿用地区");
            lconf.FValue2TotalName.Add("基本农田保护区", "基本农田保护区");
            lconf.FValue2TotalName.Add("一般农地区", "一般农地区");
            lconfs.Add(lconf);

            layconf.Add(lconf.LayName, lconfs);




            //城市规划
            lconfs = new List<LayTotalConf>();
            lconf = new LayTotalConf();
            lconf.LayName = "城市规划";
            lconf.TotalFName = "城规地类名称";
            lconf.TotalFIndex = 3;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            List<string> objs =  WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<string>("splyGetCGDLTotalType",new object[]{});
            foreach (string obj in objs)
            {
                if (obj.Contains("R"))
                    lconf.FValue2TotalName.Add(obj, "居住用地");
                else if (obj.Contains("A"))
                    lconf.FValue2TotalName.Add(obj, "公共管理与公共服务用地");
                else if (obj.Contains("B"))
                    lconf.FValue2TotalName.Add(obj, "商业服务业设施用地");
                else if (obj.Contains("M"))
                    lconf.FValue2TotalName.Add(obj, "工业用地");
                else if (obj.Contains("W"))
                    lconf.FValue2TotalName.Add(obj, "物流仓储用地");
                else if (obj.Contains("S"))
                    lconf.FValue2TotalName.Add(obj, "交通设施用地");
                else if (obj.Contains("U"))
                    lconf.FValue2TotalName.Add(obj, "公共设施用地");
                else if (obj.Contains("G"))
                    lconf.FValue2TotalName.Add(obj, "绿地");
                else if (obj.Contains("H"))
                    lconf.FValue2TotalName.Add(obj, "城乡建设用地");
                else if (obj.Contains("E"))
                    lconf.FValue2TotalName.Add(obj, "城乡非建设用地");
                else if (obj == "旅游度假用地")
                    lconf.FValue2TotalName.Add(obj, "旅游度假用地");
                else
                    lconf.FValue2TotalName.Add(obj, "其它类型");

            }
            lconfs.Add(lconf);
            layconf.Add(lconf.LayName, lconfs);

            lconfs = new List<LayTotalConf>();
            lconf = new LayTotalConf();
            lconf.LayName = "历年批次";
         
            //lconf.TotalFName = "地块编码";//"";
            //lconf.TotalFIndex = 2;// -1;
            //lconf.FValue2TotalName = new Dictionary<string, string>();
            ////lconf.FValue2TotalName.Add("*", "历年批次");
            //objs = EntityManager<string>.GetAllByStorProcedure<string>("splyGetLNPCTotalType", "");
            //foreach (string obj in objs)
            //{
            //    lconf.FValue2TotalName.Add(obj, obj);
            //}

            lconf.TotalFName = "";
            lconf.TotalFIndex = -1;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            lconf.FValue2TotalName.Add("*", "历年批次");
            
            lconfs.Add(lconf);

            layconf.Add(lconf.LayName, lconfs);

            #endregion


            JsonResult json = new JsonResult();
            json.Data = layconf;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;




            return json;
        }

        public string Test()
        {
            //ESRI.ArcGIS.Server.GISServerConnectionClass gisconnection = new ESRI.ArcGIS.Server.GISServerConnectionClass();
            //gisconnection.Connect("localhost");
            //ESRI.ArcGIS.Server.IServerObjectManager som = gisconnection.ServerObjectManager;
            //string servertype = "MapServer";
            //string serverobjectname = "china";
            //ESRI.ArcGIS.Server.IServerContext servercontext = som.CreateServerContext(serverobjectname, servertype);
            //IMapServer ms = (IMapServer)servercontext.ServerObject;
            //IMapServerObjects pMapServerObjs = ms as IMapServerObjects;
            //IMap pMap = pMapServerObjs.get_Map(ms.DefaultMapName);
            //for (int i = 0; i < pMap.LayerCount; i++)
            //{
            //    IFeatureLayer pFLayer = pMap.get_Layer(i) as IFeatureLayer;
            //    IFeatureClass pFeatureClass = pFLayer.FeatureClass;
            //    Console.WriteLine(pFeatureClass.FeatureCount(null).ToString());
            //}
            //servercontext.ReleaseContext();
            return "";
        }
    }
}
