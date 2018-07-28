using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TDObject.BLL;

using TDObject.IdentifyTool;

namespace TDObject.MapControl
{

    public struct LoadParas
    {
        public IWorkspace Workspace;
        public string[] FeatureDatasetStr;
        public string LayerName;

    }
    public static class LayerControl
    {

        static log4net.ILog log = log4net.LogManager.GetLogger("LayerControl");



        public static void RemoveLayer(AxMapControl ax1, string layname)
        {
            try
            {
                for (int i = 0; i < ax1.LayerCount; i++)
                {
                    ILayer layer = GlobalVariables.GetOverviewLayer(ax1.Map, i);
                    if (layer.Name == layname)
                        ax1.DeleteLayer(i);
                }
            }
            catch (Exception e)
            {
                log.Error("RemoveLayer:" + e.Message);
            }
        }


        public static void SetVisibleReDirect(AxMapControl ax1, string displayname)
        {
            try
            {
                for (int i = 0; i < ax1.Map.LayerCount; i++)
                {
                    ILayer layobj = ax1.get_Layer(i);
                    if (displayname == layobj.Name)
                    {
                        layobj.Visible = !layobj.Visible;
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        public static void SetVisibleStatus(AxMapControl ax1, string displayname,bool dispornot)
        {
            try
            {
                for (int i = 0; i < ax1.Map.LayerCount; i++)
                {
                    ILayer layobj = ax1.get_Layer(i);
                    if (displayname == layobj.Name)
                    {
                        layobj.Visible = dispornot;

                        //IActiveView pView = null;
                        //pView = ax1.ActiveView;

                        //if (pView != null)
                        //{
                        //    if (layobj != null)
                        //        pView.PartialRefresh(esriViewDrawPhase.esriViewGeography, layobj, pView.Extent);
                        //    else
                        //        pView.Refresh();

                        //}       
                        IViewRefresh viewRefresh = ax1.Map as IViewRefresh;
                        viewRefresh.ProgressiveDrawing = false;
                        viewRefresh.RefreshItem(layobj);  
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            ax1.Refresh();
        }

        public static void SetVisibleLayer(AxMapControl ax1, string preLayerName, string dispLaynames)
        {
            try
            {
                for (int i = 0; i < ax1.Map.LayerCount; i++)
                {
                    ILayer layobj = ax1.get_Layer(i);
                    if (dispLaynames.Contains(layobj.Name))
                    {
                        layobj.Visible = true;
                    }
                    else
                        layobj.Visible = false;

                }
                ax1.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void SetVisibleLayer(string dispLaynames,bool setValue)
        {
            try
            {
                for (int i = 0; i < GlobalVariables.axMapControl.Map.LayerCount; i++)
                {
                    ILayer layobj = GlobalVariables.axMapControl.get_Layer(i);
                    if (dispLaynames.Contains(layobj.Name))
                    {
                        layobj.Visible = setValue;
                    }
                }
                GlobalVariables.axMapControl.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static bool GetVisibleStatus( string LayersName)
        {
            try
            {
                for (int i = 0; i < GlobalVariables.axMapControl.Map.LayerCount; i++)
                {
                    ILayer layobj = GlobalVariables.axMapControl.get_Layer(i);
                    if (LayersName.Contains(layobj.Name))
                    {
                        return layobj.Visible;
                    }
                }
                return false;
            
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }

        public static bool GetVisibleStatus(AxMapControl axmc, string LayersName)
        {
            try
            {
                for (int i = 0; i < axmc.Map.LayerCount; i++)
                {
                    ILayer layobj = axmc.get_Layer(i);
                    if (LayersName.Contains(layobj.Name))
                    {
                        return layobj.Visible;
                    }
                }
                return false;

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                return false;
            }
        }
        public static void SetVisibleLayerWithPos(AxMapControl ax1,string dispLaynames)
        {
            bool posOk = false;
            try
            {
                for (int i = 0; i < ax1.Map.LayerCount; i++)
                {
                    ILayer layobj = ax1.get_Layer(i);
                    if (dispLaynames.Contains(layobj.Name))
                    {
                        layobj.Visible = true;
                        if (!posOk)
                        {
                            ax1.Map.MoveLayer(layobj, 0);
                            posOk = true;
                        }
                    }
                    else
                        layobj.Visible = false;

                }
                ax1.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        public static void SetLayerPos(AxMapControl ax1, string layername)
        {
            SetLayerPos(ax1, layername, 0);
        }

        public static void SetLayerPos(AxMapControl ax1, string layername, int posindex)
        {
            posindex = posindex >= ax1.Map.LayerCount ? ax1.Map.LayerCount - 1 : posindex;
            for (int i = 0; i < ax1.Map.LayerCount; i++)
            {
                ILayer layobj = ax1.get_Layer(i);
                if (layername == layobj.Name)
                {
                    ax1.Map.MoveLayer(layobj, posindex);
                    break;
                }

            }
            ax1.Refresh();
        }
        public static IGeoFeatureLayer getGeoLayer(AxMapControl axm,string layerName)
        {
            try
            {
                ILayer layer;
                IGeoFeatureLayer geoFeatureLayer;
                for (int i = 0; i < axm.LayerCount; i++)
                {
                    layer = axm.get_Layer(i);
                    if (layer != null && layer.Name == layerName)
                        if (layer != null)
                        {
                            geoFeatureLayer = layer as IGeoFeatureLayer;
                            return geoFeatureLayer;
                        }
                }
                return null;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return null;
        
        }

        /// <summary>
        /// 单独对土地现状图层进行处理
        /// </summary>
        /// <param name="ax1"></param>
        /// <param name="IsSimple"></param>
        public static void CreateFillSymbol(AxMapControl ax1, bool IsSimple)
        {
            for (int i = 0; i < ax1.Map.LayerCount; i++)
            {
                ILayer layer = ax1.get_Layer(i);
              //  if (layer.Name.Contains(LayerName2FullName[ "土地规划")
              //|| layer.Name.Contains(LayerName2FullName[ "城市规划")
              //|| layer.Name.Contains(LayerName2FullName[ "土地现状数据"))
                if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "土地现状数据"]))
                {
                    string symbolName = layer.Name.Substring(layer.Name.LastIndexOf(".") + 1);
                    IFeatureLayer pIFeatureLayer = layer as IFeatureLayer;
                    IFeatureClass fc = pIFeatureLayer.FeatureClass;
                    if (fc!=null && fc.ShapeType == esriGeometryType.esriGeometryPolygon)
                    {
                        if (IsSimple)
                        {
                            ColorSymbel color = new ColorSymbel(ax1, pIFeatureLayer.Name);
                            color.CreateFillSymbolByFields("地类名称", "LineHole");
                        }
                        else
                        {
                            ColorSymbel color = new ColorSymbel(ax1, pIFeatureLayer.Name);
                            color.CreateFillSymbolByFields("地类名称", "WTStyle");
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ax1">地图控件</param>
        /// <param name="OverlayName">图层名称</param>
        /// <param name="fieldName">如果字段样式，则为字段，否则为“”</param>
        /// <param name="styleName">样式表名</param>
        /// <param name="symbolName"></param>
        public static void CreateOverLaySymbol(AxMapControl ax1, string OverlayName, string fieldName, string styleName, string symbolName)
        {
            for (int i = 0; i < ax1.Map.LayerCount; i++)
            {
                ILayer layer = ax1.get_Layer(i);
                if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ OverlayName]))
                {
                    GlobalVariables.FillSymbolLayerByName(layer, OverlayName, fieldName, styleName, symbolName);
                    break;
                }
            }

        }

        public static void CreateTextSymbol(AxMapControl ax1, string OverlayName,string styleName,string TextSymbolName,double minScale,double maxScale,double scaleNow)
        {
            string[] overnames = new string[1];
            overnames[0] = OverlayName;
            for (int i = 0; i < ax1.Map.LayerCount; i++)
            {
                ILayer layer = ax1.get_Layer(i);
                if (layer.Name.Contains(GlobalVariables.LayerName2FullName[OverlayName]))
                {
                    IFeatureLayer pflayer = layer as IFeatureLayer;
                    FieldsTextSymbol.addLayerTextSymbol(pflayer, overnames, styleName, TextSymbolName, minScale, maxScale, scaleNow);
                    break;
                }
            }                 
        }

        //public static void CreateOverLaySymbol(AxMapControl ax1, string OverlayName,string fieldName,string styleName,string symbolName, bool isOverlay)
        //{
        //    if (isOverlay)
        //    {
        //        for (int i = 0; i < ax1.Map.LayerCount; i++)
        //        {
        //            ILayer layer = ax1.get_Layer(i);
        //            if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "土地现状数据"]))
        //            {
        //                switch (OverlayName)
        //                {
        //                    case "土地规划":
        //                    case "城市规划":
        //                        GlobalVariables.FillSymbolLayerByName(layer, "土地现状数据", "地类名称", "土地现状数据与土地规划叠加样式", "");
        //                        break;
        //                    case "历年批次":
        //                        GlobalVariables.FillSymbolLayerByName(layer, "土地现状数据", "地类名称", "土地现状数据与批次叠加样式", "");
        //                        break;
        //                    default: break;
        //                }
        //            }
        //            else if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "历年批次"]))
        //            {
        //                GlobalVariables.FillSymbolLayerByName(layer, "历年批次", "", "土地现状数据与批次叠加样式", "历年批次");
        //               // break;
        //            }
        //            else if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "土地规划"])&&OverlayName.Equals("土地规划"))
        //            {
                  
        //                 GlobalVariables.FillSymbolLayerByName(layer, "土地规划", fieldName, styleName, symbolName);
        //              //  break;
        //            }
        //            else if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "城市规划"]) && OverlayName.Equals("城市规划"))
        //            {
        //                GlobalVariables.FillSymbolLayerByName(layer, "城市规划", fieldName, styleName, symbolName);
        //             //   break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < ax1.Map.LayerCount; i++)
        //        {
        //            ILayer layer = ax1.get_Layer(i);
        //            if (layer.Name.Contains(GlobalVariables.LayerName2FullName[ "土地现状数据"]))
        //                GlobalVariables.FillSymbolLayerByName(layer, "土地现状数据", "地类名称", "土地现状数据默认样式", "");
        //            //else if (layer.Name.Contains(LayerName2FullName[ "土地规划"))
        //            //    GlobalVariables.FillSymbolLayerByName(layer, "土地规划", "建设用地管理区类型", "土地现状数据默认样式", "");
        //            //else if (layer.Name.Contains(LayerName2FullName[ "城市规划"))
        //            //    GlobalVariables.FillSymbolLayerByName(layer, "城市规划", "城规地类名称", "土地现状数据默认样式", "");
        //            //else if (layer.Name.Contains(LayerName2FullName[ "历年批次"))
        //            //    GlobalVariables.FillSymbolLayerByName(layer, "历年批次", "", "土地现状数据与批次叠加样式", "历年批次");

        //        }

        //    }

        //}
        public static void CreateFillSymbolSimple(AxMapControl ax1, int layerIndex)
        {
            IGeoFeatureLayer layer = ax1.get_Layer(layerIndex) as IGeoFeatureLayer;

            CreateFillSymbolSimple(ax1, layer);
        }
  

        public static void CreateFillSymbolSimple(AxMapControl ax1, IGeoFeatureLayer layer)
        {
            //设置填充符号的属性
            IColor pRgbClr = new RgbColorClass();
            pRgbClr.NullColor = true;

            ISimpleFillSymbol pSmplFillSymbol = new SimpleFillSymbol();
            pSmplFillSymbol.Color = pRgbClr;

            IFeatureRenderer InitRenderobj = layer.Renderer;
            if (InitRenderobj != null)
            {
                UniqueValueRendererClass usym = InitRenderobj as UniqueValueRendererClass;

                IFillSymbol sym = InitRenderobj as IFillSymbol;
                if (sym != null)
                {
                    ILineSymbol outlinesym = pSmplFillSymbol.Outline;
                    outlinesym.Color = sym.Color;
                    pSmplFillSymbol.Outline = outlinesym;
                }
                else
                {
                    IUniqueValueRenderer urender = InitRenderobj as IUniqueValueRenderer;
                }
            }
            IFillSymbol pFillSymbol = pSmplFillSymbol;


            ISimpleRenderer renderer = new SimpleRendererClass();
            renderer.Description = "简单的渲染一下";
            renderer.Label = "符号的标签";
            //假设sym是一个和该图层中Geometry类型对应的符号；
            renderer.Symbol = pFillSymbol as ISymbol;
            //为图层设置渲染，注意需要刷新该图层。
            layer.Renderer = renderer as IFeatureRenderer;


        }


        public static void CreateFillSymbolWithStyle(AxMapControl ax1,string layerName,string SymbolName)
        {
            ISymbol pSymbol = null;
            pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\WTStyle.ServerStyle", "Fill Symbols", SymbolName);

            //渲染对象
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = pSymbol;
            simpleRender.Label = "";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer(ax1,layerName);
            IFeatureRenderer InitRenderobj = geoFeatureLayer.Renderer;
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }



        }

      

        public static ISymbol ReadStyleServer(string styleName, string sGalleryClassName, string symbolName)
        {
            // styleName= System.Windows.Forms.Application.StartupPath + @"\Style\ESRI.ServerStyle"
            try
            {

                //ServerStyleGallery对象

                IStyleGallery pStyleGaller = new ServerStyleGalleryClass();

                IStyleGalleryStorage pStyleGalleryStorage = pStyleGaller as IStyleGalleryStorage;
                IEnumStyleGalleryItem pEnumSyleGalleryItem = null;
                IStyleGalleryItem pStyleGallerItem = null;
                IStyleGalleryClass pStyleGalleryClass = null;

                //使用IStyleGalleryStorage接口的AddFile方法加载ServerStyle文件

                pStyleGalleryStorage.AddFile(styleName);

                //遍历ServerGallery中的Class

                for (int i = 0; i < pStyleGaller.ClassCount; i++)
                {
                    pStyleGalleryClass = pStyleGaller.get_Class(i);

                    if (pStyleGalleryClass.Name != sGalleryClassName)

                        continue;

                    //获取EnumStyleGalleryItem对象
                    pEnumSyleGalleryItem = pStyleGaller.get_Items(sGalleryClassName, styleName, "");
                    pEnumSyleGalleryItem.Reset();

                    //遍历pEnumSyleGalleryItem
                    pStyleGallerItem = pEnumSyleGalleryItem.Next();


                    while (pStyleGallerItem != null)
                    {
                        if (pStyleGallerItem.Name == symbolName)
                        {

                            //获取符号

                            ISymbol pSymbol = pStyleGallerItem.Item as ISymbol;

                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);

                            System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);



                            return pSymbol;

                        }

                        pStyleGallerItem = pEnumSyleGalleryItem.Next();

                    }
                }

                System.Runtime.InteropServices.Marshal.ReleaseComObject(pEnumSyleGalleryItem);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(pStyleGalleryClass);

                return null;

            }

            catch (Exception Err)
            {

                MessageBox.Show(Err.Message, "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return null;

            }

        }


        public static void ChangePos(AxMapControl ax1, Dictionary<string,int> name2pos)
        {
            for (int i = 0; i < ax1.Map.LayerCount; i++)
            {
                ILayer layobj = ax1.get_Layer(i);
                try
                {
                    ax1.Map.MoveLayer(layobj, name2pos[layobj.Name]);
                }
                catch(Exception ex)
                {
                    log.Error("ChangePos:" + ex.Message);
                }
            }
        }
        public static void ChangeMapExtent(AxMapControl mapControl, IGeometry pGeo)
        {
            if (pGeo != null)
            {
                try
                {
                    //IEnvelope range = pGeo.Envelope;
                    //range.Expand(1.1, 1.1, true);
                    //mapControl.FullExtent= pGeo.Envelope;

                    mapControl.Extent = pGeo.Envelope;
                }
                catch(Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }
        /// <summary>
        /// 得到某图层符合属性条件的要素
        /// </summary>
        /// <param name="layer"></param>
        /// <param name="field"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static List<IFeature> getIGeoByFields(ILayer layer, string field, string value)
        {
            List<IFeature> pGeo = new List<IFeature>();
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = field + "='" + value+"'";
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
            IFeature pFeature = featureCursor.NextFeature();
            while (pFeature != null)
            {                
                pGeo.Add(pFeature);
                pFeature = featureCursor.NextFeature();
            }
              
            return pGeo;
        }
        public static List<IFeature> getIGeoByFields(ILayer layer, string field, int value)
        {
            List<IFeature> pGeo = new List<IFeature>();
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = field + "=" + value.ToString() + "";
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
            IFeature pFeature = featureCursor.NextFeature();
            while (pFeature != null)
            {
                pGeo.Add(pFeature);
                pFeature = featureCursor.NextFeature();
            }

            return pGeo;
        }

        public static List<IFeature> getIGeoByFields(ILayer layer, string field, string values,string sepratorchar)
        {
            List<IFeature> pGeo = new List<IFeature>();
            Dictionary<int,IFeature> dicGeos=new Dictionary<int,IFeature>();
            IEnvelope newunion = (IEnvelope)new Envelope();
            List<IGeometry> Geos = new List<IGeometry>();

            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = field + " in ('" + values.Replace(sepratorchar, "'" + sepratorchar + "'") + "')";
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
            bool findflag = false;
            while (true)
            {
               IFeature pFeature1 = featureCursor.NextFeature();
               if (pFeature1 != null)
               {
                   Geos.Add(pFeature1.Shape);
                   if (!findflag)
                   {
                       newunion = pFeature1.Extent;
                       findflag = true;
                   }
                   else
                   {
                       newunion.Union(pFeature1.Extent);
                   }

                   pGeo.Add(pFeature1);
                   dicGeos.Add(pFeature1.OID, pFeature1);
               }
               else
                   break;



            
            }

            return pGeo;
        }

        public static List<IFeature> getIGeoByFields(ILayer layer, string field, string values, string sepratorchar, ref IEnvelope newunion, ref List<IGeometry> Geos)
        {
            List<IFeature> pGeo = new List<IFeature>();
            Geos.Clear();
            Dictionary<int, IFeature> dicGeos = new Dictionary<int, IFeature>();
      
            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = field + " in ('" + values.Replace(sepratorchar, "'" + sepratorchar + "'") + "')";
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
            bool findflag = false;
            while (true)
            {
                IFeature pFeature1 = featureCursor.NextFeature();
                if (pFeature1 != null)
                {
                    IGeometry tmp = pFeature1.ShapeCopy;
                    Geos.Add(tmp);
                    if (!findflag)
                    {
                        newunion = tmp.Envelope;
                        findflag = true;
                    }
                    else
                    {
                        newunion.Union( tmp.Envelope);
                    }

                    pGeo.Add(pFeature1);
                 
                }
                else
                    break;
            }

            return pGeo;
        }

        public static void ExDisplayLtdFeature(AxMapControl ax1, ILayer layer, string field, string  valueswithcomma)
        {
            List<IFeature> FindGeos= new List<IFeature>();

            IFeatureLayer featureLayer = layer as IFeatureLayer;
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection;
            IFeatureClass featureClass = featureLayer.FeatureClass;

            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = field + " in ('" + valueswithcomma.Replace(",","','" + "')");
            IFeatureCursor featureCursor = featureClass.Search(queryFilter, true);
            IFeature pFeature = featureCursor.NextFeature();
            while (pFeature != null)
            {
                FindGeos.Add(pFeature);
                pFeature = featureCursor.NextFeature();
            }



            ExDisplayLtdFeature(ax1, FindGeos);
        }

        public  static void ExDisplayLtdFeature(AxMapControl ax1,List<IFeature> FindGeos)
        {
            FlashObjectsClass flashObjects = new FlashObjectsClass();
            flashObjects.MapControl = ax1.Object as IMapControl2;
            flashObjects.Init();

            if (FindGeos.Count > 0)
            {
                foreach (IFeature fea in FindGeos)
                    flashObjects.AddGeometry(fea.Shape);
            }

            flashObjects.FlashObjects(0);
        }
        
        public  static void ExDisplayLtdFeature(AxMapControl ax1,List<IGeometry> FindGeos)
        {
            FlashObjectsClass flashObjects = new FlashObjectsClass();
            flashObjects.MapControl = ax1.Object as IMapControl2;
            flashObjects.Init();

            if (FindGeos.Count > 0)
            {
                foreach (IGeometry geo in FindGeos)
                    flashObjects.AddGeometry(geo);
            }

            flashObjects.FlashObjects(0);
        }
    }
}
