using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDObject.BLL;
using TDObject.UI;
using WTGeoWeb.BLL;

using System.Drawing;

namespace TDObject.MapControl
{
    /// <summary>
    /// 全局变量
    /// </summary>
    public static class GlobalVariables
    {
        public delegate void FinishedIntersetctAnalysisHandler(IntersectTotalInfo iti);

       static  log4net.ILog log = log4net.LogManager.GetLogger("MainForm");
       public static Dictionary<string, string> FieldName2Desp_Gyqs= new Dictionary<string,string>();
       public static Dictionary<string, string> FieldName2Desp_Jbnt= new Dictionary<string,string>();
        public static Dictionary<string, string> FieldName2Desp_Tdlyxz= new Dictionary<string,string>();

        public static Dictionary<string, Dictionary<string, string>> FieldName2Desps = new Dictionary<string, Dictionary<string, string>>();
 

        static GlobalVariables()
        {
            LayerName2FullName.Add("行政区", "行政区");
            LayerName2FullName.Add("管理区", "管理区");
            LayerName2FullName.Add("河流", "河流");
            LayerName2FullName.Add("道路", "道路");//"TD_Spatial.SDE.自由分区");
            LayerName2FullName.Add("道路注记", "道路注记");
            LayerName2FullName.Add("河流注记", "河流注记");
            LayerName2FullName.Add("企业范围", "企业范围");
            LayerName2FullName.Add("房屋建筑", "房屋建筑");
            LayerName2FullName.Add("红牌警告点位置", "红牌警告点位置");
            LayerName2FullName.Add("黄牌警告点位置", "黄牌警告点位置");
            LayerName2FullName.Add("安全检查点位置", "安全检查点位置");
            LayerName2FullName.Add("企业照片点位置", "企业照片点位置");
            LayerName2FullName.Add("影像", "WTMap/WTService");



           

//添加默认标注信息
            GlobalVariables.LayTextSymbolStyleName.Clear();
            GlobalVariables.LayTextSymbolStyleName.Add("历年批次", "默认标注");
            GlobalVariables.LayTextSymbolStyleName.Add("城市规划", "默认标注");
            GlobalVariables.LayTextSymbolStyleName.Add("土地规划", "默认标注");
            GlobalVariables.LayTextSymbolStyleName.Add("土地现状数据", "默认标注");
            GlobalVariables.LayTextSymbolStyleName.Add("相城区道路中心镇及湖泊注记", "土地规划(新)");
            GlobalVariables.LayTextSymbolStyleName.Add("基本农田保护区", "国土数据(权属性质)");
            GlobalVariables.LayTextSymbolStyleName.Add("供地", "国土数据(权属性质)");
            GlobalVariables.LayTextSymbolStyleName.Add("国有权属", "国土数据(权属性质)");
            GlobalVariables.LayTextSymbolStyleName.Add("可建设区", "国土数据(权属性质)");
            GlobalVariables.LayTextSymbolStyleName.Add("企业范围", "国土数据(权属性质)");
            GlobalVariables.LayTextSymbolStyleName.Add("土地利用现状", "土地利用现状");





            Dictionary<string, string> dicField2Desp = new Dictionary<string, string>();


            dicField2Desp.Add("DKBH", "建筑编号");
            dicField2Desp.Add("NSRSBH", "所属地块编号");
            dicField2Desp.Add("SSYDQYMC", "所属用地企业名称");
            dicField2Desp.Add("SSZLQYDM", "所属租赁企业代码");
            dicField2Desp.Add("LCS", "楼层数");
            dicField2Desp.Add("JZZDMJ", "建筑占地面积");
            dicField2Desp.Add("JZMJ", "建筑面积");
            dicField2Desp.Add("SSXZQDM", "所属行政区代码");
            dicField2Desp.Add("SSXZQMC", "所属行政区名称");
            dicField2Desp.Add("SSGLQDM", "所属管理区代码");
            dicField2Desp.Add("SSGLQMC", "所属管理区名称");

            FieldName2Desps.Add("房屋建筑", dicField2Desp);

            dicField2Desp = new Dictionary<string, string>();
            dicField2Desp.Add("DKBH", "地块编号");
            dicField2Desp.Add("NSRSBH", "纳税人识别号");
            dicField2Desp.Add("YDQYMC", "用地企业名称");
            dicField2Desp.Add("TDZL", "土地坐落");
            dicField2Desp.Add("ZCLX", "注册类型");
            dicField2Desp.Add("ZCSJ", "注册时间");
            dicField2Desp.Add("JYFW", "经营范围");
            dicField2Desp.Add("HYDL", "行业大类");
            dicField2Desp.Add("HYLXXF", "行业类型细分");
            dicField2Desp.Add("FZMJ_", "发证面积");
            dicField2Desp.Add("ZDMJ", "占地面积");
            dicField2Desp.Add("JZZDMJ", "建筑占地面积");
            dicField2Desp.Add("JZMJ", "建筑面积");
            dicField2Desp.Add("QSXZ", "权属性质");
            dicField2Desp.Add("TDYT", "土地用途");
            dicField2Desp.Add("LZZJGDM", "老组织机构代码");
            dicField2Desp.Add("HGDM", "海关代码");

            FieldName2Desps.Add("企业范围", dicField2Desp);

        }
        public static Dictionary<string, string> LayerName2FullName=new Dictionary<string, string>();

        public static Dictionary<string, string> LayTextSymbolStyleName=new Dictionary<string,string>();

      
        private static KeyValuePair<string, string>[] TDType = { new KeyValuePair<string,string>("工业","工业用地"),
                                                                 new KeyValuePair<string,string>("经营性住宅","经营性住宅用地"),
                                                                 new KeyValuePair<string,string>("行政事业用地","行政事业用地,行政事业单位"),
                                                                 new KeyValuePair<string,string>("商业用地",""),
                                                                 new KeyValuePair<string,string>("拆迁安置区","拆迁安置用地"),

                                                                 
                                                                 new KeyValuePair<string,string>("空闲地","空闲地"),
                                                                 new KeyValuePair<string,string>("农村宅基地",""),
                                                                 new KeyValuePair<string,string>("交通用地","道路面,铁路"),
                                                                 new KeyValuePair<string,string>("河流水域","河流") ,
                                                                 new KeyValuePair<string,string>("农用地","旱地,果园,耕地")};
                                                               
  


    

        private static KeyValuePair<string, string>[] GHType = { new KeyValuePair<string,string>("工业用地","独立工矿用地区"),
                                                                 new KeyValuePair<string,string>("公共设施用地","城镇建设用地区,村镇建设用地区"),
                                                                 new KeyValuePair<string,string>("农田","基本农田保护区,一般农地区")};
        public static List<FieldsRef> tmpTotalRef =new List<FieldsRef>();
       
    
        

        public static bool addLayer = false;
        /// <summary>
        /// sde工作空间
        /// </summary>
        public static List<KeyValuePair<string, IWorkspaceEdit>> sdeWorkspace = new List<KeyValuePair<string, IWorkspaceEdit>>();
        
       /// <summary>
       /// 主地图控件
       /// </summary>
        public static AxMapControl axMapControl { get; set; }
        /// <summary>
        /// 鹰眼地图控件
        /// </summary>
        public static AxMapControl axMapControlEagle { get; set; }
       
        /// <summary>
        /// 选择方式
        /// </summary>
        public enum SelectType
        {
            enull = 0,
            SingleSelect = 1,
            MultiSelect,
            RectangleSelect,
            PolygonSelect
        }

        public enum SelectFunGroup
        {
            eNull=0,
            /// <summary>
            /// 空间统计
            /// </summary>
            TotalSpatialInteract=100,
            /// <summary>
            /// 空间查询
            /// </summary>
            QueryLayerInfo=200,
            /// <summary>
            /// 画自由地块
            /// </summary>
            DrawFreeRegion=300 ,
            
            /// <summary>
            /// 企业范围查处需要
            /// </summary>
            QueryQyCc=400,
            
            /// <summary>
            /// 企业信息图片框
            /// </summary>
            LtdPicInfo=500
        }

        /// <summary>
        /// 选择类型
        /// </summary>
        public enum SelectFeatureValue
        {
            enull = 0,//空
            Cunjie = 1,//村
            Zhenjie,//镇
            GLQ,//管理区
            XZ,//土地现状
            GH,//土地规划
            PC,//批次
            FW,//房屋
            FreeRegion,//自由分区
            Tdlyxz,//土地利用现状
            Gyqs,//国有权属
            Kjsq,//可建设区
            Jbntbhq,//基本农田保护区
            Qyfw,//企业范围
            Gd, //供地
            LtdPic//企业照片信息
        }
        /// <summary>
        /// 选择类
        /// </summary>
        public static class Select {
            public delegate void ChangedEventHandler();//定义委托
            public static event ChangedEventHandler Changed;//定义事件
            private static SelectType sType = SelectType.enull;

            public static SelectType SType
            {
                get { return Select.sType; }
                set { Select.sType = value; }
            }


            public static SelectFunGroup SOperFun = SelectFunGroup.eNull;

            private static SelectFeatureValue sValue = SelectFeatureValue.enull;

            public static SelectFeatureValue SValue
            {
                get { return Select.sValue; }
                set
                {
                    if (Select.sValue != value)
                    {
                        Select.sValue = value;
                        OnChanged();
                    }
                }
            }
            /// <summary>
            /// 选择方式
            /// </summary>
           
            /// <summary>
            /// 选择图层改变
            /// </summary>
            public static void OnChanged()
            {
                if (Changed != null)
                {
                    Changed();
                }
            }
            /// <summary>
            /// 选择类型
            /// </summary>
          
            public static void Exit(){
                Select.sValue = SelectFeatureValue.enull;
                Select.sType = SelectType.enull;
            }

        }

      
        /// <summary>
        /// 初始化样式
        /// </summary>
        /// <param name="m_FeatureLayer"></param>
        public static void SymbolLayer(IFeatureLayer m_FeatureLayer)
        {
            //foreach (string layname in GlobalVariables.LayerName2FullName.Keys)
            //{
            //    if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName[layname])
            //    {
            //        ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
            //        color.CreateFillSymbol(layname);
            //        break;
            //    }
            //}

            if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["行政区"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("行政区");
            }
            else if (m_FeatureLayer.Name =="管理区")
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("管理区界线");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["河流"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("河流", "默认");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["河流注记"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("河流注记");
            }
           
            //Line 填充
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["道路"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateLineSymbol("道路", "默认");
            }
           
            //面填充
            else if (m_FeatureLayer.Name == LayerName2FullName["道路注记"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("道路注记");
            }
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["房屋建筑"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("房屋建筑");
            }
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["企业范围"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateFillSymbol("企业范围");
            }
           else if (m_FeatureLayer.Name == LayerName2FullName["红牌警告点位置"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateMarkerSymbol("红牌警告点位置", "默认");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["黄牌警告点位置"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateMarkerSymbol("黄牌警告点位置", "默认");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["企业照片点位置"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateMarkerSymbol("企业照片点位置", "默认");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["安全检查点位置"])
            {
                ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
                color.CreateMarkerSymbol("安全检查点位置", "默认");
            }
        }

        /// <summary>
        /// 初始化样式
        /// </summary>
        /// <param name="m_FeatureLayer"></param>
        public static void SymbolLayer(AxMapControl ax,IFeatureLayer m_FeatureLayer)
        {
            //foreach (string layname in GlobalVariables.LayerName2FullName.Keys)
            //{
            //    if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName[layname])
            //    {
            //        ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, m_FeatureLayer.Name);
            //        color.CreateFillSymbol(layname);
            //        break;
            //    }
            //}

            if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["行政区"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("行政区");
            }
            else if (m_FeatureLayer.Name == "管理区")
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("管理区界线");
            }

            //Line 填充
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["道路"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateLineSymbol("道路", "默认");
            }

            //面填充
            else if (m_FeatureLayer.Name == LayerName2FullName["道路注记"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("道路注记");
            }
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["房屋建筑"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("房屋建筑");
            }
            else if (m_FeatureLayer.Name == GlobalVariables.LayerName2FullName["企业范围"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("企业范围");
            }
            else if (m_FeatureLayer.Name == LayerName2FullName["河流"])
            {
                ColorSymbel color = new ColorSymbel(ax, m_FeatureLayer.Name);
                color.CreateFillSymbol("河流", "默认");
            }

        }

        public static void FillSymbolLayerByName(ILayer layer,string layerName,string fieldName,string StyleName,string SymbolName)
        {
         
                IFeatureLayer pIFeatureLayer = layer as IFeatureLayer;
                IFeatureClass fc = pIFeatureLayer.FeatureClass;
                if (fc.ShapeType == esriGeometryType.esriGeometryPolygon)
                {
                    ColorSymbel color = new ColorSymbel(GlobalVariables.axMapControl, pIFeatureLayer.Name);
                    if (fieldName == "")
                        color.CreateFillSymbol(SymbolName, StyleName);
                    else
                        color.CreateFillSymbolByFields(fieldName, StyleName);
                    
                }
            
        }

       
        /// <summary>
        /// 2017-03-19 created by zhwsun
        /// </summary>
        /// <param name="totalinfo"></param>
        /// <param name="OverlyLayerFlag"></param>
        /// <param name="totalconf"></param>
        /// <returns></returns>
        public static int SearchSlyFeature(ref IntersectTotalInfo totalinfo, int OverlyLayerFlag, Dictionary<string, List<LayTotalConf>> totalconf)
        {
            int retV = 0;
            try
            {
                totalinfo.totalLayers = new List<TotalLayerInfo>();

                List<IFeature> featureList = new List<IFeature>();
                featureList = SelectControl.DealFeatureSelectRetFeatureList();//工业管理区要素集合
                IFields pFields = featureList[0].Fields;
                //string FWFeaturesId = SelectControl.SelectFeaturesByFeaturesRetString(featureList, LayerName2FullName["房屋"], "建筑编号");//土地现状要素集合
                int layno = 0;
                foreach (string layname in totalconf.Keys)
                {
                    ILayer player = LayerControl.getGeoLayer(axMapControl, layname);
                    TotalLayerInfo tli = new TotalLayerInfo();
                    tli.ItemName = layname;
                    tli.ItemNo = layno++;
                    tli.totalTypes = new Dictionary<string, TotalTypeInfo>();
                    retV=SelectControl.GetSlyIntersectFeatures(featureList[0], player, ref tli, totalconf[layname]);
                    if (retV == 9999)
                        return retV;
                    totalinfo.totalLayers.Add(tli);
                }
                //if (AfterIntersectAnalsys != null)
                //{
                //    AfterIntersectAnalsys(totalinfo);
                //}
             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                retV= - 1;
            }
            return retV;
         
        }

      


        /// <summary>
        /// 判断feature所在图层  
        /// </summary>
        /// <param name="pFeature">要判断的feature</param>
        /// <returns>图层在MapControl里的序列号</returns>
        public static int findIndexByFeature(IFeature pFeature)
        {
            int index = -1;
            IFeatureClass pFeatureClass = pFeature.Class as IFeatureClass;
            for (int i = 0; i < axMapControl.Map.LayerCount; i++)
            {
                IFeatureLayer iFeatureLayer = axMapControl.get_Layer(i) as IFeatureLayer;
                IFeatureClass iFeatureCla = iFeatureLayer.FeatureClass;

                if (iFeatureCla == pFeatureClass)
                {
                    index = i;
                    return index;
                }
            }

            return index;
        }


        /// <summary>
        /// 获取已经加载的图层
        /// </summary>
        /// <param name="map"></param>
        /// <param name="index">要获取图层的ID（tocControl中位序）</param>
        /// <returns></returns>
        public static ILayer GetOverviewLayer(IMap map, int index)
        {
            //获取主视图的第一个图层
            ILayer pLayer = map.get_Layer(index);
            //double scale = map.MapScale;
            //this.tsslScale.Text = scale.ToString();
            // string name = pLayer.Name;
         
            return pLayer;

        }

        public static ILayer GetOverviewLayer(AxMapControl axm, string layerName)
        {
            ILayer layer;
            for (int i = 0; i < axm.LayerCount; i++)
            {
                layer = axm.get_Layer(i);
                if (layer != null && layer.Name == layerName)
                    if (layer != null)
                    {
                       // geoFeatureLayer = layer as IGeoFeatureLayer;
                        return layer;
                    }
            }
            return null;
        }

        //public static ILayer GetOverviewLayer(IMap map, string layerName)
        //{
        //    for (int i = 0; i < axMapControl.Map.LayerCount; i++)
        //    {
        //        IFeatureLayer iFeatureLayer = axMapControl.get_Layer(i) as IFeatureLayer;
                

        //        if (iFeatureCla == pFeatureClass)
        //        {
        //            index = i;
        //            return index;

        //        }

        //    }
        //}
        public static void RefreshAnnoLable(AxMapControl ax1)
        {
            try
            {
                ILayer paramLayer = LayerControl.getGeoLayer(ax1, "道路注记");
                System.Drawing.Font font = new System.Drawing.Font("宋体", 12);
                AddlableTolayer(paramLayer as IFeatureLayer, "TextString", font);
                ax1.Refresh();
                //this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

           }
            catch { }

        }
        private static void AddlableTolayer(IFeatureLayer pFeatureLayer, string fieldname, Font font)//shp中需要标注的字段)
        {
            IGeoFeatureLayer pGeoFeatureLayer = pFeatureLayer as IGeoFeatureLayer;
            pGeoFeatureLayer.DisplayAnnotation = true;//允许标注

            IFeatureClass pFeatureClass;
            pFeatureClass = pGeoFeatureLayer.FeatureClass;

            //矢量图层标注信息设置
            IAnnotateLayerPropertiesCollection pAnnotateLayerPropertiesCollection;
            pAnnotateLayerPropertiesCollection = pGeoFeatureLayer.AnnotationProperties;
            pAnnotateLayerPropertiesCollection.Clear();

            //定义一个矢量图层动态标注显示
            IAnnotateLayerProperties pAnnotateLayerProperties;

            //定义控制线标注的相对位置
            ILineLabelPosition pLineLabelPosition;

            //控制线标注的属性设置
            ILineLabelPlacementPriorities pLineLabelPlacementPriorities;
            IBasicOverposterLayerProperties pBasicOverposterLayerProperties;
            ILabelEngineLayerProperties pLabelEngineLayerProperties;

            pLineLabelPosition = new LineLabelPositionClass();
            pLineLabelPosition.Parallel = false;//标注是否水平
            pLineLabelPosition.Perpendicular = true;//标注是否垂直

            pLineLabelPlacementPriorities = new LineLabelPlacementPrioritiesClass();
            pBasicOverposterLayerProperties = new BasicOverposterLayerPropertiesClass();
            pBasicOverposterLayerProperties.FeatureType = esriBasicOverposterFeatureType.esriOverposterPolyline;
            pBasicOverposterLayerProperties.LineLabelPlacementPriorities = pLineLabelPlacementPriorities;
            pBasicOverposterLayerProperties.LineLabelPosition = pLineLabelPosition;

            pLabelEngineLayerProperties = new LabelEngineLayerPropertiesClass();
            pLabelEngineLayerProperties.BasicOverposterLayerProperties = pBasicOverposterLayerProperties;

            //创建标注的颜色  
            IRgbColor pRgbColor = new RgbColorClass();
            pRgbColor.Red = 0;
            pRgbColor.Green = 0;
            pRgbColor.Blue = 255;
            //创建标注的字体样式  
            ITextSymbol pTextSymbol = new TextSymbolClass();
            pTextSymbol.Color = pRgbColor;
            pTextSymbol.Size = 12;
            pTextSymbol.Font.Name = font.Name;
            pTextSymbol.Size = font.Size;//字体大小
            pTextSymbol.Font.Bold = font.Bold;
            pTextSymbol.Font.Italic = font.Italic;

            pLabelEngineLayerProperties.Symbol = pTextSymbol;

            pLabelEngineLayerProperties.Expression = "[" + fieldname + "]";//标注字段

            pAnnotateLayerProperties = pLabelEngineLayerProperties as IAnnotateLayerProperties;


            IAnnotateLayerTransformationProperties pAnnotateLayerTransformationProperties = pLabelEngineLayerProperties as IAnnotateLayerTransformationProperties;
            //设置标注参考比例尺  
            pAnnotateLayerTransformationProperties.ReferenceScale = 1;

            //设置显示标注最大比例尺  
            pAnnotateLayerProperties.AnnotationMaximumScale = 1;
            //设置显示标注的最小比例  
            pAnnotateLayerProperties.AnnotationMinimumScale = 250000;

            pAnnotateLayerPropertiesCollection.Add(pAnnotateLayerProperties);


            //声明标注是否显示  
            pGeoFeatureLayer.DisplayAnnotation = true;
        }
        /// <summary>
        /// 图层标注 设置不同图层在不同比例尺下要标注的字段 调用LabelByFieldnames()
        /// </summary>
        /// <param name="sMapCtr"></param>
        /// <param name="sFlyr">要标注的图层</param>
        public static void UpdataLabel(AxMapControl sMapCtr, IFeatureLayer sFlyr)
        {
            if (sFlyr == null) return;
            try
            {
                ILayer layer = sFlyr as IFeatureLayer;
                double scale = sMapCtr.MapScale;
                if (scale <= 13000)
                {
                    RefreshAnnoLable(sMapCtr);//道路注记
                }
                IGeoFeatureLayer pGeoFeatureLayer = sFlyr as IGeoFeatureLayer;
                pGeoFeatureLayer.AnnotationProperties.Clear();//必须执行 有默认标注

               if (LayerControl.GetVisibleStatus(GlobalVariables.LayerName2FullName["企业范围"]) && layer.Name == GlobalVariables.LayerName2FullName["企业范围"])
                {
                    string[] fieldNames = { "YDQYMC" };
                    //FieldsTextSymbol.addLayerTextSymbol(sFlyr, fieldNames, GlobalVariables.LayTextSymbolStyleName[layer.Name], "企业范围", 1, 5000, scale);
                    FieldsTextSymbol.addLayerTextSymbol(sFlyr, fieldNames,"默认", "企业范围", 1, 8000, scale);
                }
               
            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                //MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 对图层字段进行标注的实现
        /// </summary>
        /// <param name="pFeatLyr">要标注的图层</param>
        /// <param name="fieldNames">要标注的字段</param>
        public static void LabelByFieldnames(IFeatureLayer pFeatLyr, string[] fieldNames)
        {
            //try
            //{

            //设置多字段间以“-”分隔
            string connectivesStr = "& VbNewLine & ";



            //这里设置文字样式的颜色和字体等
            ITextSymbol pTextSyl;
            pTextSyl = new TextSymbolClass();
            stdole.StdFont pFont;
            pFont = new stdole.StdFontClass();
            pFont.Name = "verdana";
            //if (pFeatLyr.Name != "arcgis.DBO.道路名称")
            //{
            //    pFont.Size = 10;
            //    pTextSyl.Font = pFont as stdole.IFontDisp;
            //}
            //else
            //{
                pFont.Size = 12;

                pTextSyl.Font = pFont as stdole.IFontDisp;

                pTextSyl.Color = getRGB(1, 255, 93);
           // }


            IGeoFeatureLayer pGeoFeatureLayer = pFeatLyr as IGeoFeatureLayer;
            


            //pGeoFeatureLayer.AnnotationProperties.Clear();//必须执行 有默认标注
            IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerPropertiesClass();
            //新建一个图层标注引擎，并设置其属性
            ILabelEngineLayerProperties pLableEngine = new LabelEngineLayerPropertiesClass();
            string pLable = string.Empty;
            string mlable = string.Empty;
            foreach (string item in fieldNames)
            {
                mlable = "[" + item + "]";
                pLable += mlable + connectivesStr;

            }
            char[] psign = connectivesStr.ToCharArray();
            pLable = pLable.Trim(psign);

            //设置标注多个字段的表达式
            pLableEngine.Expression = pLable;
            pLableEngine.IsExpressionSimple = true;
            pBasic.NumLabelsOption = esriBasicNumLabelsOption.esriOneLabelPerPart;
            pBasic.PointPlacementMethod = esriOverposterPointPlacementMethod.esriOnTopPoint;
            pBasic.PointPlacementOnTop = true;
            pLableEngine.BasicOverposterLayerProperties = pBasic;
            pLableEngine.Symbol = pTextSyl;
            pGeoFeatureLayer.AnnotationProperties.Add(pLableEngine as IAnnotateLayerProperties);
            pGeoFeatureLayer.DisplayAnnotation = true;
            //}
            //catch (Exception e00)
            //{
            //    MessageBox.Show(e00.ToString());
            //}
        }

     
        //获取颜色对象
        public static IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
    }
}
