using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geoprocessing;
using SunMvcExpress.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WTGeoWeb.BLL;

namespace TDObject.MapControl
{
    public class SelectControl
    {
 
        static log4net.ILog log = log4net.LogManager.GetLogger("SelectControl");

        public static bool m_TerminatedAnalysis = false;

        /// <summary>
        /// 设置可选图层
        /// </summary>
        public static void SetSelectableLayer()
        {
            try
            {
                string LayerName = string.Empty;
                if (GlobalVariables.Select.SValue != GlobalVariables.SelectFeatureValue.enull)
                {
                    switch (GlobalVariables.Select.SValue)
                    {
                        case GlobalVariables.SelectFeatureValue.Cunjie:
                            //村界
                            LayerName = GlobalVariables.LayerName2FullName["村界"];
                            break;
                        case GlobalVariables.SelectFeatureValue.Zhenjie:
                            LayerName = GlobalVariables.LayerName2FullName[ "镇界"];
                            break;
                        //镇界
                        case GlobalVariables.SelectFeatureValue.FreeRegion:
                            LayerName = GlobalVariables.LayerName2FullName[ "自由分区"];
                            break;

                        case GlobalVariables.SelectFeatureValue.GLQ:
                            LayerName = GlobalVariables.LayerName2FullName[ "工业管理区"];
                            break;
                        case GlobalVariables.SelectFeatureValue.XZ:
                            LayerName = GlobalVariables.LayerName2FullName[ "土地现状数据"];
                            break;
                        case GlobalVariables.SelectFeatureValue.GH:
                            LayerName = GlobalVariables.LayerName2FullName[ "土地规划"];
                            break;
                        case GlobalVariables.SelectFeatureValue.PC:
                            LayerName = GlobalVariables.LayerName2FullName[ "历年批次"];
                            break;

                        case GlobalVariables.SelectFeatureValue.Kjsq:
                            LayerName = GlobalVariables.LayerName2FullName["可建设区"];
                            break;
                        case GlobalVariables.SelectFeatureValue.Tdlyxz:
                            LayerName = GlobalVariables.LayerName2FullName["土地利用现状"];
                            break;
                        case GlobalVariables.SelectFeatureValue.Gd:
                            LayerName = GlobalVariables.LayerName2FullName["供地"];
                            break;
                        case GlobalVariables.SelectFeatureValue.Qyfw:
                            LayerName = GlobalVariables.LayerName2FullName["企业范围"];
                            break;
                        case GlobalVariables.SelectFeatureValue.Gyqs:
                            LayerName = GlobalVariables.LayerName2FullName["国有权属"];
                            break;
                        case GlobalVariables.SelectFeatureValue.LtdPic:
                            LayerName = GlobalVariables.LayerName2FullName["企业照片点位置"];
                            break;
                        case GlobalVariables.SelectFeatureValue.FW:
                            LayerName = GlobalVariables.LayerName2FullName["房屋建筑"];
                            break;
                    

                        //管理区
                        default: break;
                    }
                }

                for (int i = 0; i < GlobalVariables.axMapControl.LayerCount; i++)
                {
                    ILayer pLayer = GlobalVariables.axMapControl.get_Layer(i);
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (pFeatureLayer != null)// && pLayer.Name != "WTMap/WTService"
                    {
                        if (LayerName.Contains(pLayer.Name))
                        {
                            pFeatureLayer.Selectable = true;
                        }
                        else
                        {
                            pFeatureLayer.Selectable = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        /// <summary>
        /// 设置图层可选性
        /// </summary>
        /// <param name="LayerName">要设置的图层名称</param>
        /// <param name="ifSetOtherFalse">是否设置其他图层不可选 true为设置其他图层不可选，false为其他图层保持原状态</param>
        public static void SetSelectableLayer(String LayerNames,bool ifSetOtherFalse) 
        {
            try
            {
                for (int i = 0; i < GlobalVariables.axMapControl.LayerCount; i++)
                {
                    ILayer pLayer = GlobalVariables.axMapControl.get_Layer(i);
                    IFeatureLayer pFeatureLayer = pLayer as IFeatureLayer;
                    if (LayerNames.Contains(pLayer.Name))
                    {
                        pFeatureLayer.Selectable = true;
                    }
                    else
                    {
                        if (ifSetOtherFalse)
                            pFeatureLayer.Selectable = false;

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error("SetSelectableLayer1:" + ex.Message);
            }
        }
        /// <summary>
        /// Feature选择处理方法
        /// </summary>
        public static string DealFeatureSelect()
        {
            string value = "";
            try
            {

                GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

                IMap pMap = GlobalVariables.axMapControl.Map;
                //////得到地图中已选择的要素
                ISelection selection = pMap.FeatureSelection;
                IEnumFeatureSetup enumFeatureSetup = selection as IEnumFeatureSetup;    //这里很必要
                enumFeatureSetup.AllFields = true;                                      //这里很必要
                IEnumFeature enumFeature = enumFeatureSetup as IEnumFeature;
                enumFeature.Reset();
                //selection.Clear();
                // IFeature feature = enumFeature.Next();
                IFeature feature = enumFeature.Next();
                int index = -1;
                string layerName = string.Empty;
                IFields pFields;
                while (feature != null)
                {

                    //判断图层
                    index = GlobalVariables.findIndexByFeature(feature);
                    if (index != -1)
                    {
                        layerName = GlobalVariables.GetOverviewLayer(pMap, index).Name;
                    }
                    pFields = feature.Fields;
                    try
                    {
                        int field = 0;
                        switch (GlobalVariables.Select.SValue)
                        {
                            case GlobalVariables.SelectFeatureValue.Cunjie:
                                field = pFields.FindField("行政村代码");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.Zhenjie:
                                field = pFields.FindField("行政镇代码");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.GLQ:
                                field = pFields.FindField("地块编号");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.XZ:
                                field = pFields.FindField("地块编码");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.GH:
                                field = pFields.FindField("地块编号");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.PC:
                                field = pFields.FindField("地块编码");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            case GlobalVariables.SelectFeatureValue.Qyfw:
                                field = pFields.FindField("OBJECTID");
                                value += feature.get_Value(field).ToString() + ",";//.get_Value(1).ToString();//就可以得到任意字段的值了 
                                break;
                            default: break;
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                    }
                    feature = enumFeature.Next();
                }

            }
            catch (Exception ex)
            {
                log.Error("DealFeatureSelect:" + ex.Message);
            }
            return value;

        }
        /// <summary>
        /// FeatureSelect选择方法返回值处理
        /// </summary>
        /// <returns></returns>
        public static List<IFeature> DealFeatureSelectRetFeatureList()
        {

           // GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            IMap pMap = GlobalVariables.axMapControl.Map;
            //////得到地图中已选择的要素
            ISelection selection = pMap.FeatureSelection;
            IEnumFeatureSetup enumFeatureSetup = selection as IEnumFeatureSetup;    //这里很必要
            enumFeatureSetup.AllFields = true;                                      //这里很必要
            IEnumFeature enumFeature = enumFeatureSetup as IEnumFeature;
            enumFeature.Reset();
            //selection.Clear();
            // IFeature feature = enumFeature.Next();
            IFeature feature = enumFeature.Next();
            List<IFeature> FeatureList = new List<IFeature>();

            while (feature != null)
            {

                FeatureList.Add(feature);
                feature = enumFeature.Next();
            }

            return FeatureList;
        }
       

        public static ILayer SelectLayerIns(ILayer pInputLayer, ILayer pOutLayer)
        {   //分析层

            IFeatureLayer pInputFeatLayer = pInputLayer as IFeatureLayer;
            ITable pInputTable = pInputLayer as ITable;
            IFeatureClass pInputFeatClass = pInputFeatLayer.FeatureClass;

            //叠加表
            ITable pOverlayTable = pOutLayer as ITable;

            //叠加分析表
            IFeatureClassName pFeatClassName = new FeatureClassNameClass();
            pFeatClassName.FeatureType = esriFeatureType.esriFTSimple;
            pFeatClassName.ShapeFieldName = "shape";
            pFeatClassName.ShapeType = pInputFeatClass.ShapeType;

            //工作空间名称
            IWorkspaceName pNewWSName = new WorkspaceNameClass();
            pNewWSName.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
            pNewWSName.PathName = @"C:\temp";

            //数据集名称
            IDatasetName pDatasetName = pFeatClassName as IDatasetName;
            pDatasetName.Name = "缓存";
            pDatasetName.WorkspaceName = pNewWSName;

            //几何处理
            IBasicGeoprocessor pBGP = new BasicGeoprocessorClass();
            IFeatureClass pOutputFeatClass = pBGP.Intersect(pInputTable, false, pOverlayTable, false, 0.01, pFeatClassName);

            //输出要素层设置
            IFeatureLayer pOutputFeatLayer = new FeatureLayerClass();
            pOutputFeatLayer.FeatureClass = pOutputFeatClass;
            pOutputFeatLayer.Name = pOutputFeatClass.AliasName;

            return (ILayer)pOutputFeatClass;

        }
        
        
        /// <summary>
        /// 根据Feature集合交图层，
        /// </summary>
        /// <param name="pFes">Feature集合</param>
        /// <param name="LayerNames">图层名称</param>
        /// <param name="FieldsName">非空间筛选字段</param>
        /// <param name="FieldsValue">非空间筛选字段值</param>
        /// <returns>Feature集合</returns>
        public static List<IFeature> SelectFeaturesByFeatures(List<IFeature> pFes, string LayerNames, string FieldsName = "*", string FieldsValue = "*")
        {


            SelectControl.SetSelectableLayer(LayerNames, true);
            bool visibleStatus = LayerControl.GetVisibleStatus(LayerNames);
            LayerControl.SetVisibleLayer(LayerNames, true);
            GlobalVariables.axMapControl.Refresh();
           // GlobalVariables.axMapControl.Map.ClearSelection();
            ISelectionEnvironment pselectiongEnv;
            pselectiongEnv = new SelectionEnvironmentClass();
            /*
             空间过滤器空间关系类型  描述(A是待查询图形，B是过滤条件图形) 
             * esriSpatialRelUndefined 未定义  
             * esriSpatialRelIntersects  A与B图形相交 
             * esriSpatialRelEnvelopeIntersects A的Envelope和B的Envelope相交 
             * esriSpatialRelIndexIntersects   A与B索引相交
             * esriSpatialRelTouches Ａ与B边界相接 
             * esriSpatialRelOverlaps  A与B相叠加 
             * esriSpatialRelCrosses  A与B相交（两条线相交于一点，一条线和一个面相 交） 
             * esriSpatialRelWithin A在B内 
             * esriSpatialRelContains A包含B  
             * esriSpatialRelRelation  A与B空间关联 

             */
            pselectiongEnv.AreaSelectionMethod = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects;
            //pselectiongEnv.CombinationMethod = esriSelectionResultEnum.esriSelectionResultXOR;
            List<IFeature> ResFeatures = new List<IFeature>();
            foreach (IFeature fea in pFes)
            {
               
                pselectiongEnv.LinearSelectionMethod = esriSpatialRelEnum.esriSpatialRelWithin;
                //axMapControl1.DrawShape(fea);
                //查询条件按照属性判断
                if (FieldsName != "*" && FieldsValue != "*")
                {
                    if (fea.get_Value(fea.Fields.FindField(FieldsName)).Equals(FieldsValue))
                    {
                        GlobalVariables.axMapControl.Map.SelectByShape(fea.ShapeCopy, pselectiongEnv, false);

                    }
                }
                else
                {
                    GlobalVariables.axMapControl.Map.SelectByShape(fea.ShapeCopy, pselectiongEnv, false);
                }
              

                GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);



                IMap pMap = GlobalVariables.axMapControl.Map;
                ISelection selection =  pMap.FeatureSelection;

                IEnumFeatureSetup enumFeatureSetup = selection as IEnumFeatureSetup;    //这里很必要
                enumFeatureSetup.AllFields = true;                                      //这里很必要
                IEnumFeature enumFeature = enumFeatureSetup as IEnumFeature;
                enumFeature.Reset();
                if (selection.CanClear())
                {
                    selection.Clear();
                }
                // IFeature feature = enumFeature.Next();
                IFeature feature = enumFeature.Next();
                //axMapControl1.DrawShape(feature.Shape);
                //进行管理区查询的字段

                int index = -1;
                string layerName = string.Empty;
                IFields pFields;
                while (feature != null)
                {
                    index = GlobalVariables.findIndexByFeature(feature);
                    if (index != -1)
                    {
                        layerName = GlobalVariables.GetOverviewLayer(pMap, index).Name;
                    }
                    pFields = feature.Fields;
                    try
                    {

                        if (LayerNames.Contains(layerName))
                        {

                            //这里换成求交图层
                            IGeometry pGeometry = null;// SelectControl.GetSlyIntersectFeatures(feature, GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "土地现状数据"));
                            if (pGeometry != null)
                                feature.Shape = pGeometry;
                            ResFeatures.Add(feature);



                        }

                    }
                    catch (Exception Exception)
                    {

                        log.Error(Exception.Message);
                    }
                    feature = enumFeature.Next();

                }

         
            }
            LayerControl.SetVisibleLayer(LayerNames, visibleStatus);
            return ResFeatures;
           
        }
        /// <summary>
        /// 求相交面积 
        /// </summary>
        /// <param name="featureObj">条件图层</param>
        /// <param name="pLayer">被交图层</param>
        /// <returns>相交结果</returns>
        public static int GetSlyIntersectFeatures(IFeature featureObj, ILayer pLayer, ref TotalLayerInfo tli, List<LayTotalConf> totalconfs,bool m_terminated=false)
        {
            int retV = 0;
            m_TerminatedAnalysis=m_terminated;
            try
            {
                if (pLayer == null || featureObj == null)
                    return -1;
                List<IGeometry> outGeos = new List<IGeometry>();

                IGeometry overGeometry = featureObj.ShapeCopy;

                IFeatureLayer analysisLayer = pLayer as IFeatureLayer;
                IFeatureClass pJCFeaCls = analysisLayer.FeatureClass;
                IFeatureCursor pFeaCurIntersect;


                ISpatialFilter pSFilter = new SpatialFilterClass();
                pSFilter.Geometry = overGeometry;
                pSFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
                pFeaCurIntersect = pJCFeaCls.Search(pSFilter, false);
                IFeature pIntersectFea = null;
                while ((pIntersectFea = pFeaCurIntersect.NextFeature()) != null)
                {
                    if (m_TerminatedAnalysis)
                        return 9999;
                    IGeometry pIntersectGeo = pIntersectFea.ShapeCopy;    //// 被压盖的图形
                    ITopologicalOperator iTopoOperator = (ITopologicalOperator)pIntersectGeo;
                    IGeometry outGeomeity = iTopoOperator.Intersect(overGeometry, esriGeometryDimension.esriGeometry2Dimension);
                    if (outGeomeity != null)
                    {
                        decimal area = Math.Round((decimal)(outGeomeity as IArea).Area, 2);
                        if (area == 0)
                            continue;
                        foreach (LayTotalConf ltc in totalconfs)
                        {
                            string FValue;
                            string TypeValue;
                            if (ltc.TotalFIndex != -1)
                            {
                                FValue = pIntersectFea.get_Value(pIntersectFea.Fields.FindField(ltc.TotalFName)).ToString();
                            }
                            else
                            {
                                FValue = "*";
                            }
                            TypeValue = ltc.FValue2TotalName[FValue];

                            if (!tli.totalTypes.ContainsKey(TypeValue))
                            {
                                TotalTypeInfo tti = new TotalTypeInfo();
                                tti.ItemName = TypeValue;
                                tti.ItemNo = tli.totalTypes.Count + 1;

                                tli.totalTypes.Add(tti.ItemName, tti);
                            }

                            tli.totalTypes[TypeValue].RegionArea += area;
                            tli.totalTypes[TypeValue].RegionCount++;
                            if (ltc.LayName == "土地现状数据")
                            {
                                #region 土地现状数据
                                if (tli.totalTypes[TypeValue].totalLtds == null)
                                {
                                    tli.totalTypes[TypeValue].totalLtds = new Dictionary<string, TotalLtdInfo>();//获取地块的企业信息，三个面积
                                }
                                TotalLtdInfo ltdinfo = new TotalLtdInfo();
                                string regioncode = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("地块编码")).ToString();
                                if (!tli.totalTypes[TypeValue].totalLtds.ContainsKey(regioncode))
                                {
                                    ltdinfo.LtdNo = tli.totalTypes[TypeValue].totalLtds.Count + 1;
                                    ltdinfo.LtdName = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("企业名称")).ToString(); 
                                    ltdinfo.RegionCode = regioncode;
                                    ltdinfo.RegionArea = 0;
                                    ltdinfo.BuildingArea = 0;
                                    ltdinfo.FloorArea = 0;
                                }
                                ltdinfo.RegionArea = area;
                                //ltdinfo.BuildingArea = (decimal)pIntersectFea.get_Value(9); ;
                                //ltdinfo.FloorArea = (decimal)pIntersectFea.get_Value(10);
                                //前面是直接取全面积，应该根据交的房屋来计算

                                retV=GetSlyIntersectBuildLayer(outGeomeity, ref ltdinfo);

                                tli.totalTypes[TypeValue].totalLtds.Add(ltdinfo.RegionCode, ltdinfo);

                                //if (ltdinfo.RegionCode == "320507100208HL0005" || ltdinfo.RegionCode == "320507100208QY0222")
                                //    continue;
                   

                                tli.totalTypes[TypeValue].BuildingArea += ltdinfo.BuildingArea;
                                tli.totalTypes[TypeValue].FloorArea += ltdinfo.FloorArea;
                                tli.totalTypes[TypeValue].RegionCodes += ltdinfo.RegionCode + ",";

                                #endregion
                            }
                            else if (ltc.LayName == "历年批次")
                            {
                                #region 历年批次
                                if (tli.totalTypes[TypeValue].totalLtds == null)
                                {
                                    tli.totalTypes[TypeValue].totalLtds = new Dictionary<string, TotalLtdInfo>();//获取地块的企业信息，三个面积
                                }
                                TotalLtdInfo ltdinfo = new TotalLtdInfo();
                                ltdinfo.LtdNo = tli.totalTypes[TypeValue].totalLtds.Count + 1;
                                ltdinfo.LtdName = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("批次号")).ToString();
                                ltdinfo.RegionCode = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("地块编码")).ToString();
                                ltdinfo.RegionArea =area;

                                tli.totalTypes[TypeValue].totalLtds.Add(ltdinfo.RegionCode, ltdinfo);


                                tli.totalTypes[TypeValue].RegionCodes += ltdinfo.RegionCode + ",";

                                #endregion
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                retV = -1;
            }
            return retV;
        }

        public static int GetSlyIntersectBuildLayer(IGeometry geoObj, ref TotalLtdInfo ltdinfo)
        {
            int retV = 0;
            object val;
            List<IGeometry> outGeos = new List<IGeometry>();

            IGeometry overGeometry = geoObj;

            IFeatureLayer analysisLayer = LayerControl.getGeoLayer(GlobalVariables.axMapControl, "房屋");
            IFeatureClass pJCFeaCls = analysisLayer.FeatureClass;
            IFeatureCursor pFeaCurIntersect;


            ISpatialFilter pSFilter = new SpatialFilterClass();
            pSFilter.Geometry = overGeometry;
            pSFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelIntersects;
            pFeaCurIntersect = pJCFeaCls.Search(pSFilter, false);
            IFeature pIntersectFea = null;
            while ((pIntersectFea = pFeaCurIntersect.NextFeature()) != null)
            {
                IGeometry pIntersectGeo = pIntersectFea.ShapeCopy;    //// 被压盖的图形
                ITopologicalOperator iTopoOperator = (ITopologicalOperator)pIntersectGeo;
                IGeometry outGeomeity = iTopoOperator.Intersect(overGeometry, esriGeometryDimension.esriGeometry2Dimension);
                if (outGeomeity != null)
                {
                    decimal area = Math.Round((decimal)(outGeomeity as IArea).Area, 2);
                    string fvalue = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("所属单位代码")).ToString();
                   
                    if ((double)area <= 0.1)
                        continue;
                    if (fvalue != ltdinfo.RegionCode)
                    {
                        log.Error("现状"+ltdinfo.RegionCode+"与房屋"+fvalue+"图形不准确："); continue;
                    }
                   
                    val = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("建筑面积"));
                    val=val==null?0:val;
                    ltdinfo.BuildingArea += Math.Round(Convert.ToDecimal(val), 2);
                    val = pIntersectFea.get_Value(pIntersectFea.Fields.FindField("建筑占地面积"));
                    val = val == null ? 0 : val;
                    ltdinfo.FloorArea += Math.Round(Convert.ToDecimal(val), 2);
                }
            }
            return retV;
        }


        public static void getIntersectsLayer(ILayer inputLayer,ILayer outputLayer) { 
            try{
                ILayer pLayer = inputLayer;
                 IFeatureLayer pInputFeatLayer =pLayer as IFeatureLayer;    
                 ITable pInputTable=pLayer as ITable;
                 IFeatureClass pInputFeatClass=pInputFeatLayer.FeatureClass;

               
                //叠加表
                 pLayer = outputLayer;
                ITable pOverlayTable=pLayer as ITable;

                //叠加分析表
                IFeatureClassName pFeatClassName=new FeatureClassNameClass();
                pFeatClassName.FeatureType=esriFeatureType.esriFTSimple;
                pFeatClassName.ShapeFieldName="shape";
                pFeatClassName.ShapeType=pInputFeatClass.ShapeType;

                //工作空间名称
                IWorkspaceName pNewWSName=new WorkspaceNameClass();
                pNewWSName.WorkspaceFactoryProgID = "esriDataSourcesFile.ShapefileWorkspaceFactory";
                pNewWSName.PathName = System.Windows.Forms.Application.StartupPath + @"\temp";

                //数据集名称
                IDatasetName pDatasetName=pFeatClassName as IDatasetName;
                pDatasetName.Name = inputLayer.Name + "Intersect"+ outputLayer.Name;
                pDatasetName.WorkspaceName=pNewWSName; 

                //几何处理
                IBasicGeoprocessor pBGP=new BasicGeoprocessorClass();
                IFeatureClass pOutputFeatClass=pBGP.Intersect(pInputTable,true,pOverlayTable,false,0.01,pFeatClassName);  
   
                //输出要素层设置
                IFeatureLayer pOutputFeatLayer=new FeatureLayerClass();
                pOutputFeatLayer.FeatureClass=pOutputFeatClass;
                pOutputFeatLayer.Name=pOutputFeatClass.AliasName;

                GlobalVariables.axMapControl.AddLayer(pOutputFeatLayer, 0);
                GlobalVariables.axMapControl.Update();
            }
            catch(Exception ex)
            {
                log.Error(ex.Message);
               // MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// 根据Feature集合交图层返回某属性值集合字符串
        /// </summary>
        /// <param name="pFes">Feature集合</param>
        /// <param name="LayerNames">图层名称</param>
        /// <param name="queryFieldsName">要返回值的属性字段</param>
        /// <returns>属性值字符串</returns>
        public static String  SelectFeaturesByFeaturesRetString(List<IFeature> pFes, string LayerNames, string queryFieldsName)
        {


            SelectControl.SetSelectableLayer(LayerNames, true);
            bool visibleStatus = LayerControl.GetVisibleStatus(LayerNames);
            LayerControl.SetVisibleLayer(LayerNames,true);
            GlobalVariables.axMapControl.Refresh();
            // GlobalVariables.axMapControl.Map.ClearSelection();
            ISelectionEnvironment pselectiongEnv;
            pselectiongEnv = new SelectionEnvironmentClass();
            /*
             空间过滤器空间关系类型  描述(A是待查询图形，B是过滤条件图形) 
             * esriSpatialRelUndefined 未定义  
             * esriSpatialRelIntersects  A与B图形相交 
             * esriSpatialRelEnvelopeIntersects A的Envelope和B的Envelope相交 
             * esriSpatialRelIndexIntersects   A与B索引相交
             * esriSpatialRelTouches Ａ与B边界相接 
             * esriSpatialRelOverlaps  A与B相叠加 
             * esriSpatialRelCrosses  A与B相交（两条线相交于一点，一条线和一个面相 交） 
             * esriSpatialRelWithin A在B内 
             * esriSpatialRelContains A包含B  
             * esriSpatialRelRelation  A与B空间关联 

             */
            pselectiongEnv.AreaSelectionMethod = ESRI.ArcGIS.Geodatabase.esriSpatialRelEnum.esriSpatialRelIntersects;
            //pselectiongEnv.CombinationMethod = esriSelectionResultEnum.esriSelectionResultXOR;
            string value = string.Empty;
            foreach (IFeature fea in pFes)
            {

                pselectiongEnv.LinearSelectionMethod = esriSpatialRelEnum.esriSpatialRelWithin;
                //axMapControl1.DrawShape(fea);
               
                 GlobalVariables.axMapControl.Map.SelectByShape(fea.ShapeCopy, pselectiongEnv, false);
               

                GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);



                IMap pMap = GlobalVariables.axMapControl.Map;
                ISelection selection = pMap.FeatureSelection;

                IEnumFeatureSetup enumFeatureSetup = selection as IEnumFeatureSetup;    //这里很必要
                enumFeatureSetup.AllFields = true;                                      //这里很必要
                IEnumFeature enumFeature = enumFeatureSetup as IEnumFeature;
                enumFeature.Reset();
                if (selection.CanClear())
                {
                    selection.Clear();
                }
                // IFeature feature = enumFeature.Next();
                IFeature feature = enumFeature.Next();
                //axMapControl1.DrawShape(feature.Shape);
                //进行管理区查询的字段

                int index = -1;
                string layerName = string.Empty;
                IFields pFields;
                while (feature != null)
                {
                    index = GlobalVariables.findIndexByFeature(feature);
                    if (index != -1)
                    {
                        layerName = GlobalVariables.GetOverviewLayer(pMap, index).Name;
                    }
                    pFields = feature.Fields;
                    try
                    {

                        if (LayerNames.Contains(layerName))
                        {
                            value += feature.get_Value(pFields.FindField(queryFieldsName)).ToString()+",";
                        }

                    }
                    catch (Exception Exception)
                    {
                        log.Error(Exception.Message);
                    }
                    feature = enumFeature.Next();

                }

            }
            LayerControl.SetVisibleLayer(LayerNames,visibleStatus);
            return value;

        }

        /// <summary>
        /// 根据属性字段值得到总面积
        /// </summary>
        /// <param name="pFeatures"></param>
        /// <param name="FieldsName"></param>
        /// <param name="Fields"></param>
        /// <returns></returns>
        public static double GetSumArea(List<IFeature> pFeatures,string FieldsName,string Fields) {
            double area = 0;
            foreach (IFeature f in pFeatures)
            {
                
                    if (Fields.Contains(f.get_Value(f.Fields.FindField(FieldsName)).ToString()))
                    {
                        IArea pArea = f.Shape as IArea;
                        area += pArea.Area;
                    }
                    
            }
            return area;
        }
        public static int GetSumCount(List<IFeature> pFeatures, string FieldsName, string Fields)
        {



            int area = 0;
            foreach (IFeature f in pFeatures)
            {

                if (Fields.Contains(f.get_Value(f.Fields.FindField(FieldsName)).ToString()))
                {
                    area++; 
                }

            }
            return area;
        }
  
        //public static decimal GetFieldsValue(List<IFeature> pFeatures, string FieldsName)
        //{
        //    decimal value = 0;
        //    foreach (IFeature f in pFeatures)
        //    {
        //        try
        //        {
        //            value += f.get_Value(f.Fields.FindField(FieldsName));
        //        }
        //        catch(Exception ex){}
                
        //    }
        //    return value;
        //}
        /// <summary>
        /// 根据图层要素集合得到信息
        /// </summary>
        /// <param name="pFeatures"></param>
        /// <param name="Fields"></param>
        /// <returns></returns>
        //public static tmpTotalItem GetTotalInfo(List<IFeature> pFeatures,string FieldsName,string Fields) {
        //    tmpTotalItem t = new tmpTotalItem();
        //    double area = SelectControl.GetSumArea(pFeatures, FieldsName, Fields);
        //    t.RegionArea = Convert.ToDecimal(area).ToString("#0.00") + "㎡(" + (area * 0.0015).ToString("#0.00") + "亩)";
      
        //    return t;

        //}
    }
}
