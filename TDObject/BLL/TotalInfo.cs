using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using QyTech.Core.BLL;
using TDObject.AsyncHttp;
using QyTech.Json;

using TDObject;

namespace WTGeoWeb.BLL
{

    public class IntersectTotalInfo
    {
        /// <summary>
        /// 层名称
        /// </summary>
        public string LayerName { get; set; }
        /// <summary>
        /// //地块编码（选择的）
        /// </summary>
        public string ObjCode { get; set; }
        /// <summary>
        /// //地块名称（选择的）
        /// </summary>
        public string ObjName { get; set; }
        public List<TotalLayerInfo> totalLayers { get; set; }
    }

    /// <summary>
    /// 每层的统计信息
    /// </summary>
    public class TotalLayerInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int ItemNo { get; set; }//序号
        /// <summary>
        /// //统计名称，相交层名，分类名称
        /// </summary>
        public string ItemName { get; set; }//分析的图层名臣g
        /// <summary>
        /// 地块面积
        /// </summary>
        public decimal RegionArea { get; set; }//相交的图层的地块面积
        /// <summary>
        /// 地块数量
        /// </summary>
        public int RegionCount { get; set; }//相交的图层的地块数量
        /// <summary>
        /// 建筑面积
        /// </summary>
        public decimal BuildingArea { get; set; }//相交的图层的建筑面积
        /// <summary>
        /// 建筑占地面积
        /// </summary>
        public decimal FloorArea { get; set; }//相交的图层的建筑占地面积
        /// <summary>
        /// 分类统计数据
        /// </summary>
        public Dictionary<string, TotalTypeInfo> totalTypes { get; set; }//分类统计数据
    }

    /// <summary>
    /// 每层的分类的统计信息
    /// </summary>
    public class TotalTypeInfo
    {
        /// <summary>
        /// 序号
        /// </summary>
        public int ItemNo { get; set; }//序号
        /// <summary>
        /// 统计名称，相交层名，分类名称
        /// </summary>
        public string ItemName { get; set; }//统计名称，相交层名，分类名称
        /// <summary>
        /// 地块面积
        /// </summary>
        public decimal RegionArea { get; set; }//地块面积
        /// <summary>
        /// 地块数量
        /// </summary>
        public int RegionCount { get; set; }//地块数量
        /// <summary>
        /// 建筑面积
        /// </summary>
        public decimal BuildingArea { get; set; }//建筑面积
        /// <summary>
        /// 建筑占地面积
        /// </summary>
        public decimal FloorArea { get; set; }//建筑占地面积
        /// <summary>
        /// 逗号分隔的地块列表，房屋不会分割成多块
        /// </summary>
        public string RegionCodes { get; set; }//逗号分隔的地块列表，房屋不会分割成多块
        /// <summary>
        /// 土地现状中包含的每个地块的企业单位数据
        /// </summary>
        public Dictionary<string, TotalLtdInfo> totalLtds { get; set; }//土地现状中包含的每个地块的企业单位数据

    }

    /// <summary>
    /// 每个分类的企业统计信息
    /// </summary>
    public class TotalLtdInfo
    {
        public int LtdNo { get; set; }
        public string LtdName { get; set; }
        public string RegionCode { get; set; }
        public decimal RegionArea { get; set; }
        /// <summary>
        /// 建筑面积
        /// </summary>
        public decimal BuildingArea { get; set; }//建筑面积
        /// <summary>
        /// 建筑占地面积
        /// </summary>
        public decimal FloorArea { get; set; }//建筑占地面积

    }

    /// <summary>
    /// 企业的详细信息
    /// </summary>
    public class LtdInfo
    {

        public string Name;//企业名称
        public string DKBM;//地块编码
        public string DLMC;//地类名称
        public string PreName;//原企业名称
        public string YDDMWC;//用地单位名称
        public string TDZLQYMC;//土地租赁企业名称
        public string SSXZCMC;//所属行政村名称
        public string KFSMC;//开发商名称
        public decimal ZDMJ;//占地面积
        public decimal DKFUJZZDMJ;//地块附属建筑占地面积
        public decimal DMFSJZMJ;//地块附属建筑面积

    }





    /// <summary>
    /// 统计的配置规则
    /// </summary>
    public class LayTotalConf
    {
        public string LayName { get; set; }

        public int TotalFIndex { get; set; }
        public string TotalFName { get; set; }

        public Dictionary<string, string> FValue2TotalName { set; get; }

    }

    public class LayControl
    {
        public Dictionary<string, List<LayTotalConf>> GetLayerTotalConf()
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


            //List<string> objs = TDObject.BLL.CommSetting.EM.GetAllByStorProcedure<string>("splyGetCGDLTotalType",new object[]{});
            string detailUrl = MainForm.URI + "lyRemoteServ/GetCGDLTotalTyp";
            string json = CommFun.GetRemoteJson(detailUrl);
            List<string> objs = JsonHelper.DeserializeJsonToList<string>(json);
            
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
            lconf.TotalFName = "";
            lconf.TotalFIndex = -1;
            lconf.FValue2TotalName = new Dictionary<string, string>();
            lconf.FValue2TotalName.Add("*", "历年批次");
            lconfs.Add(lconf);

            layconf.Add(lconf.LayName, lconfs);

            #endregion




            return layconf;
        }
    }

}
