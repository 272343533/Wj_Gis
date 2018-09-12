using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading;


using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

using TDObject.MapControl;

using log4net;

namespace TDObject.IdentifyTool
{
    public class FlashObjectsClass 
    {
        log4net.ILog log = log4net.LogManager.GetLogger("FlashObjectsClass");
             
        private List<IGeometry>             pointsFlashObject;
        private List<IGeometry>             polylinesFlashObject;
        private List<IGeometry>             polygonsFlashObject;
        private IScreenDisplay              screenDisplay;
        private IMapControl2                mapControl2;

        private ISymbol                     pointSymbol;
        private ISymbol                     lineSymbol;
        private ISymbol                     regionSymbol;

        public FlashObjectsClass()
        {
            pointsFlashObject = new List<IGeometry>();
            polylinesFlashObject = new List<IGeometry>();
            polygonsFlashObject = new List<IGeometry>();
            //初始化显示样式
            InitialSymbols();
        }

        public IMapControl2 MapControl
        {
            set
            {
                try
                {
                    mapControl2 = value;
                    screenDisplay = value.ActiveView.ScreenDisplay;
                }
                catch { }
            }
        }

        private void InitialSymbols()
        {
            IColor displayColor = DefineRgbColor(255,0,0);// (255, 128, 128);
            IColor outLineColor = DefineRgbColor(0,128, 0);
            ILineSymbol outLineSymbol = DefineLineSymbol(1.5, outLineColor, esriSimpleLineStyle.esriSLSSolid);
            pointSymbol = DefinePointSymbol(13, displayColor, esriSimpleMarkerStyle.esriSMSCircle, outLineSymbol) as ISymbol;
            lineSymbol = DefineLineOutLineSymbol() as ISymbol;
            regionSymbol = DefineFillSymbol(displayColor, esriSimpleFillStyle.esriSFSSolid, outLineSymbol) as ISymbol;
        }

        public void Init() 
        {
            pointsFlashObject.Clear();
            polylinesFlashObject.Clear();
            polygonsFlashObject.Clear();
        }

        public void AddGeometry(IGeometry geo)
        {
            switch (geo.GeometryType) 
            {
                case esriGeometryType.esriGeometryPoint:
                    pointsFlashObject.Add(geo);
                    break;
                case esriGeometryType.esriGeometryPolyline:
                    polylinesFlashObject.Add(geo);
                    break;
                case esriGeometryType.esriGeometryPolygon:
                    polygonsFlashObject.Add(geo);
                    break;
            }
        }

        public void FlashObjects(int mseconds)
        {
            try
            {
                //if ((screenDisplay.IsCacheDirty((System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriScreenRecording)))
                //{
                    //screenDisplay.StartRecording();
                    //screenDisplay.RemoveAllCaches();
                    screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache);//.esriNoScreenCache);esriAllScreenCaches
                                                                                                                                       //注意其先后顺序
                                                                                                                                       //画面
                    screenDisplay.SetSymbol(regionSymbol);
                    for (int i = 0; i < polygonsFlashObject.Count; i++)
                    {
                        screenDisplay.DrawPolygon(polygonsFlashObject[i]);
                    }
                    //画线
                    screenDisplay.SetSymbol(lineSymbol);
                    for (int i = 0; i < polylinesFlashObject.Count; i++)
                    {
                        screenDisplay.DrawPolyline(polylinesFlashObject[i]);
                    }
                    //画点
                    screenDisplay.SetSymbol(pointSymbol);
                    for (int i = 0; i < pointsFlashObject.Count; i++)
                    {
                        screenDisplay.DrawPoint(pointsFlashObject[i]);
                    }
                    if (mseconds > 0)
                    {
                        Thread.Sleep(mseconds);
                    }
                    screenDisplay.FinishDrawing();

                    //screenDisplay.StopRecording();
                //}
                //else
                //{
                //    screenDisplay.DrawCache(screenDisplay.hDC, (System.Int16)esriScreenCache.esriScreenRecording,ref 0, ref 0);
                //}
                if (mseconds > 0)
                {
                    mapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                }
            }
            catch (Exception ex)
            {
               log.Error(ex.Message);
            }
        }

        public void ClearDisplay()
        {
            try
            {
                mapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
            }
            catch { }
        }

        public void FlashObjects(LayerIdentifiedResult layerFlash)
        {
            screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriNoScreenCache);
            switch (layerFlash.GeometryType) 
            {
                case LayerFeatureType.Point:
                    screenDisplay.SetSymbol(pointSymbol);
                    break;
                case LayerFeatureType.Polyline:
                    screenDisplay.SetSymbol(lineSymbol);
                    break;
                case LayerFeatureType.Polygon:
                    screenDisplay.SetSymbol(regionSymbol);
                    break;
                default:
                    return;
            }
            List<IFeatureIdentifyObj> identifyObjDefault = layerFlash.IdentifiedFeatureObjList;
            for (int i = 0; i < identifyObjDefault.Count; i++)
            {
                IFeature featureDefault = (identifyObjDefault[i] as IRowIdentifyObject).Row as IFeature;
                switch (layerFlash.GeometryType)
                {
                    case LayerFeatureType.Point:
                        screenDisplay.DrawPoint(featureDefault.Shape);
                        break;
                    case LayerFeatureType.Polyline:
                        screenDisplay.DrawPolyline(featureDefault.Shape);
                        break;
                    case LayerFeatureType.Polygon:
                        screenDisplay.DrawPolygon(featureDefault.Shape);
                        break;
                }
            }
            Thread.Sleep(500);
            screenDisplay.FinishDrawing();
            mapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
        }
        /// <summary>
        /// 定义RGB颜色对象
        /// </summary>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        private IColor DefineRgbColor(int r, int g, int b)
        {
            if (r > 255 || r < 0 || 
                g > 255 || g < 0 || 
                b > 255 || b < 0)
                throw new Exception("颜色值不合法!");
            //
            IRgbColor rgb = new RgbColorClass();
            rgb.Red = r;
            rgb.Green = g;
            rgb.Blue = b;
            return (IColor)rgb;
        }


        public void NoteCenterPnt4LtdRange(AxMapControl ax1,List<string> dkbms, string LayerName)
        {

            //获得点图层  
            IFeatureLayer layer;

            layer = ax1.get_Layer(0) as IFeatureLayer;
            for (int i = 0; i < ax1.Map.LayerCount; ++i)  //寻找点图层  
            {
                layer = ax1.get_Layer(i) as IFeatureLayer;
                if (layer.FeatureClass.ShapeType == esriGeometryType.esriGeometryPoint)
                    break;
            }
            if (layer.FeatureClass.ShapeType != esriGeometryType.esriGeometryPoint)
                return;

            //QI到IGeoFeatureLayer接口  
            IGeoFeatureLayer geoFeatureLayer = layer as IGeoFeatureLayer;  
             

            IColor displayColor = DefineRgbColor(255, 128, 128);
           
            pointSymbol = DefinePointSymbol(13, displayColor, esriSimpleMarkerStyle.esriSMSCircle, null) as ISymbol;


            ILayer pLayer = GlobalVariables.GetOverviewLayer(ax1, LayerName);

            List<IFeature> FindGeos = new List<IFeature>();

            List<IFeature> pGeo = new List<IFeature>();
            IEnvelope newdisp = (IEnvelope)new Envelope();

            List<IGeometry> NoteGeos = new List<IGeometry>();
            try
            {
                foreach (string dkbm in dkbms)
                {
                    pGeo = LayerControl.getIGeoByFields(pLayer, "地块编码", dkbm);

                    if (pGeo.Count > 0)
                    {
                        newdisp.Union(pGeo[0].Extent);
                        FindGeos.Add(pGeo[0]);

                        Polygon region = pGeo as Polygon;
                        double x = 0, y = 0;
                        for (int i = 0; i < region.PointCount; i++)
                        {
                            IPoint pnt = region.get_Point(i);
                            x += pnt.X;
                            y += pnt.Y;
                        }
                        IPoint dpnt = new PointClass();
                        dpnt.X = x / region.PointCount;
                        dpnt.Y = y / region.PointCount;

                        NoteGeos.Add(dpnt);
                    }


                    screenDisplay.StartDrawing(screenDisplay.hDC, (System.Int16)ESRI.ArcGIS.Display.esriScreenCache.esriAllScreenCaches);//.esriNoScreenCache);
                    //画点
                    screenDisplay.SetSymbol(pointSymbol);


                    for (int i = 0; i < NoteGeos.Count; i++)
                    {
                        screenDisplay.DrawPoint(NoteGeos[i]);
                    }
                }
            }
            catch (Exception ex)
            {
              //("系统资源可能不足，请尽量不要全部选择！");
            }

            if (FindGeos.Count> 0)
               LayerControl.ChangeMapExtent(ax1, newdisp);
        }
        /// <summary>
        /// 简单点
        /// </summary>
        /// <param name="size"></param>
        /// <param name="color"></param>
        /// <param name="style"></param>
        /// <param name="outLineSymbol"></param>
        /// <returns></returns>
        private IMarkerSymbol DefinePointSymbol(double size, IColor color, esriSimpleMarkerStyle style, ILineSymbol outLineSymbol=null)
        {
            ISimpleMarkerSymbol simpleMarkerSymbol = new SimpleMarkerSymbolClass();
            IMarkerSymbol markerSymbol = (IMarkerSymbol)simpleMarkerSymbol;
            simpleMarkerSymbol.Size = size;                                      //定义点符号大小
            simpleMarkerSymbol.Color = color;                                    //定义点符号颜色
            simpleMarkerSymbol.Style = style;                                    //定义点符号样式
            if (outLineSymbol == null)
            {
                simpleMarkerSymbol.Outline = false;
            }
            else
            {
                simpleMarkerSymbol.Outline = true;                                  //定义点符号边线
                simpleMarkerSymbol.OutlineColor = outLineSymbol.Color;
                simpleMarkerSymbol.OutlineSize = outLineSymbol.Width;
            }
            return markerSymbol;
        }
        /// <summary>
        /// 简单线
        /// </summary>
        /// <param name="width"></param>
        /// <param name="color"></param>
        /// <param name="style"></param>
        /// <returns></returns>
        private ILineSymbol DefineLineSymbol(double width, IColor color, esriSimpleLineStyle style)
        {
            ISimpleLineSymbol simpleLineSymbol = new SimpleLineSymbolClass();
            simpleLineSymbol.Width = width;
            simpleLineSymbol.Color = color;
            simpleLineSymbol.Style = style;
            ILineSymbol lineSymbol = (ILineSymbol)simpleLineSymbol;
            return lineSymbol;
        }

        private ILineSymbol DefineLineOutLineSymbol()
        {
            ISimpleLineSymbol backBlackLine = new SimpleLineSymbolClass();
            backBlackLine.Width = 5.5;
            backBlackLine.Color = DefineRgbColor(0, 0, 0);
            backBlackLine.Style = esriSimpleLineStyle.esriSLSSolid;

            ISimpleLineSymbol foreGreenLine = new SimpleLineSymbolClass();
            foreGreenLine.Width = 4;
            foreGreenLine.Color = DefineRgbColor(0, 128, 0);
            foreGreenLine.Style = esriSimpleLineStyle.esriSLSSolid;

            IMultiLayerLineSymbol multiLayerLineSymbol = new MultiLayerLineSymbolClass();
            multiLayerLineSymbol.AddLayer(backBlackLine);
            multiLayerLineSymbol.AddLayer(foreGreenLine);
            ILineSymbol lineSymbol = (ILineSymbol)multiLayerLineSymbol;

            return lineSymbol;
        }
        /// <summary>
        /// 简单面
        /// </summary>
        /// <param name="color"></param>
        /// <param name="style"></param>
        /// <param name="outLineSymbol"></param>
        /// <returns></returns>
        private IFillSymbol DefineFillSymbol(IColor color, esriSimpleFillStyle style, ILineSymbol outLineSymbol)
        {
            ISimpleFillSymbol simpleFillSymbol = new SimpleFillSymbolClass();
            simpleFillSymbol.Color = color;                                        //定义面符号颜色
            simpleFillSymbol.Style = style;                                        //定义面符号样式
            simpleFillSymbol.Outline = outLineSymbol;                              //定义面符号边线
            IFillSymbol fillSymbol = (IFillSymbol)simpleFillSymbol;

            return fillSymbol;
        }
    }
}
