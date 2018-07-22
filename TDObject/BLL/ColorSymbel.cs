using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesFile;
using ESRI.ArcGIS.Display;
using System.Collections;
using log4net;
//using ESRI.ArcGIS.Framework;//GalleryClass

namespace TDObject.BLL
{
    class ColorSymbel
    {

        log4net.ILog log = log4net.LogManager.GetLogger("ColorSymbel");

        public ColorSymbel(AxMapControl _ax,string _layerName) {
            this.ax = _ax;
            this.layerName = _layerName;
        }
        private AxMapControl ax;
        IFeatureRenderer InitRenderobj;
        private string layerName;
        //获取颜色对象
        private IRgbColor getRGB(int r, int g, int b)
        {
            IRgbColor pColor;
            pColor = new RgbColorClass();
            pColor.Red = r;
            pColor.Green = g;
            pColor.Blue = b;
            return pColor;
        }
        private IGeoFeatureLayer getGeoLayer(string layerName,AxMapControl axm)
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

        public void CreeteFillSymbolForHole(string SymbolName)
        {
            ISymbol pSymbol = null;
            pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\NewStyle\LineHole.ServerStyle", "Fill Symbols", SymbolName);

            //渲染对象
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = pSymbol;
            simpleRender.Label = "";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer(layerName, ax);
            InitRenderobj = geoFeatureLayer.Renderer;
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }
        }

        public void CreateFillSymbol(string SymbolName, string StyleName = "默认")
        { 
            
            ISymbol pSymbol = null;

            pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\NewStyle\" + StyleName + ".ServerStyle", "Fill Symbols", SymbolName);
 
            
            //渲染对象默认
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = pSymbol;
            simpleRender.Label = "";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer(layerName, ax);
            InitRenderobj = geoFeatureLayer.Renderer;
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }
        }


        public void CreateLineSymbol(string SymbolName, string StyleName = "默认")
        {

            ISymbol pSymbol = null;

            pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\NewStyle\" + StyleName + ".ServerStyle", "Line Symbols", SymbolName);
            

            //渲染对象
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = pSymbol;
            simpleRender.Label = "";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer(layerName, ax);
            InitRenderobj = geoFeatureLayer.Renderer;
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }
        }
        public void CreateMarkerSymbol(string SymbolName, string StyleName = "默认")
        {

            ISymbol pSymbol = null;

            pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\NewStyle\" + StyleName + ".ServerStyle", "Marker Symbols", SymbolName);


            //渲染对象
            ISimpleRenderer simpleRender = new SimpleRendererClass();
            simpleRender.Symbol = pSymbol;
            simpleRender.Label = "";
            simpleRender.Description = "简单渲染";

            IGeoFeatureLayer geoFeatureLayer;
            geoFeatureLayer = getGeoLayer(layerName, ax);
            InitRenderobj = geoFeatureLayer.Renderer;
            if (geoFeatureLayer != null)
            {
                geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
            }
        }
        /// <summary>
        /// 得到唯一字段值
        /// </summary>
        /// <param name="pFeatureClass"></param>
        /// <param name="FieldName"></param>
        /// <returns></returns>
        private List<string> GetUniqueValues(IFeatureClass pFeatureClass, string FieldName)
        {
            List<string> uniquevalues = new List<string>();

            try
            {
                if (!FieldName.Contains(","))
                {
                    IDataStatistics pdatastatics = new DataStatisticsClass();
                    ICursor pcursor = pFeatureClass.Search(null, false) as ICursor;
                    pdatastatics.Cursor = pcursor; pdatastatics.Field = FieldName;
                    IEnumerator enumerator = pdatastatics.UniqueValues; enumerator.Reset();
                    while (enumerator.MoveNext())
                    {
                        object myObject = enumerator.Current;
                        uniquevalues.Add(myObject.ToString());
                    }
                }
                else
                {
                    //not finished for two field on 2017-10-24
                    string[] fields = FieldName.Split(new char[] { ',' });
                    List<string> vals = new List<string>();
                    for (int i = 0; i < fields.Length; i++)
                    {
                        IDataStatistics pdatastatics = new DataStatisticsClass();
                        ICursor pcursor = pFeatureClass.Search(null, false) as ICursor;
                        pdatastatics.Cursor = pcursor; pdatastatics.Field = fields[i] ;
                        IEnumerator enumerator = pdatastatics.UniqueValues; enumerator.Reset();

                        int pointer=-1;
                        while (enumerator.MoveNext())
                        {
                            pointer++;
                            object myObject = enumerator.Current;
                            if (i==0)
                                vals.Add(myObject.ToString());
                            else
                                vals[pointer] = vals[pointer] + "," + myObject.ToString();
                            
                        }
                    }
                    foreach (string val in vals)
                    {
                        if (!uniquevalues.Contains(val))
                            uniquevalues.Add(val);
                  
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            return uniquevalues;
        }
        // 读取现有的渲染符号库
        private Dictionary<string, ISymbol> LoadStyle(esriSymbologyStyleClass styleclass, string StyleName)
        {
            Dictionary<string, ISymbol> SymbolDic = new Dictionary<string,ISymbol>();
            ISymbologyControl symbolcontrol = new SymbologyControlClass();
            string resourcesPath = Application.StartupPath +"\\NewStyle\\" + StyleName + ".ServerStyle";
            symbolcontrol.LoadStyleFile(resourcesPath);
            ISymbologyStyleClass pSymbologyStyleClass =symbolcontrol.GetStyleClass(styleclass);
            int ItemCount =pSymbologyStyleClass.get_ItemCount(pSymbologyStyleClass.StyleCategory);
            for (int i = 0; i < ItemCount; i++)
            {
                string tempname = "12";
                try
                {
                    IStyleGalleryItem temp = pSymbologyStyleClass.GetItem(i);
                    tempname = temp.Name;
                    if (!SymbolDic.ContainsKey(temp.Name))
                        SymbolDic.Add(temp.Name, temp.Item as ISymbol);
                }
                
                catch (Exception ex)
                {
                    if (tempname == "镇政府")
                    {
                        continue;
                    }
                    log.Error("LoadStyle:" + ex.Message);
                }
            }
            return SymbolDic;
        }


        public void CreateFillSymbolByFields(string fieldName, string StyleName)
        {
              //假设layer是一个IFeatureLayer，获取IGeoFeatureLayer
              IGeoFeatureLayer geoLayer=getGeoLayer(layerName,ax);
            
              IFeatureClass pFeatureClass = geoLayer.FeatureClass;
              //构造一个UniqueValueRenderer 
              IUniqueValueRenderer pUniqueValueRenderer=new UniqueValueRendererClass();
              ////假设使用两个字段来渲染
              //pUniqueValueRenderer.FieldCount=1;
              ////假设YSLX字段表示要素类型
              ////假设YSYT字段表示要数用途
              //pUniqueValueRenderer.set_Field(0, fieldName);
              List<string> UniqueValues = GetUniqueValues(pFeatureClass, fieldName);

              if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPoint || pFeatureClass.ShapeType == esriGeometryType.esriGeometryMultipoint)
              {
                  ISimpleMarkerSymbol pSimpleMarkerSymbol = new SimpleMarkerSymbolClass();
                  pSimpleMarkerSymbol.Style = esriSimpleMarkerStyle.esriSMSCircle;
                  pSimpleMarkerSymbol.Size = 8;
                  // 这这些属性应该在添加值之前设置
                  pUniqueValueRenderer.FieldCount = 1;
                  pUniqueValueRenderer.set_Field(0, fieldName);
                  pUniqueValueRenderer.DefaultSymbol = pSimpleMarkerSymbol as ISymbol;
                  pUniqueValueRenderer.UseDefaultSymbol = true;
                  Dictionary<string, ISymbol> SymbolDic = LoadStyle(esriSymbologyStyleClass.esriStyleClassMarkerSymbols, StyleName);
                  for (int i = 0; i < UniqueValues.Count; i++)
                  {
                      string classValue = UniqueValues[i];
                      if (SymbolDic.ContainsKey(classValue) == true)
                      {
                          // pUniqueValueRenderer.set_Label(classValue,pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[classValue]); 
                          try
                          {
                              //pUniqueValueRenderer.set_Symbol(classValue, SymbolDic[classValue]);
                              pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[classValue]);
                          }
                          catch (Exception ex)
                          {
                              log.Error(ex.Message);
                          }
                      }
                  }
              }
              else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolyline)
              {
                  ISimpleLineSymbol pSimpleLineSymbol = new SimpleLineSymbolClass();
                  pSimpleLineSymbol.Style = esriSimpleLineStyle.esriSLSSolid;
                  pSimpleLineSymbol.Width = 0.4;

                   pUniqueValueRenderer.FieldCount = 1;
                  pUniqueValueRenderer.set_Field(0, fieldName);
                  pUniqueValueRenderer.DefaultSymbol = pSimpleLineSymbol as ISymbol;
                  pUniqueValueRenderer.UseDefaultSymbol = true;
                  Dictionary<string, ISymbol> SymbolDic = LoadStyle(esriSymbologyStyleClass.esriStyleClassLineSymbols, StyleName);
                  for (int i = 0; i < UniqueValues.Count; i++)
                  {
                      string classValue = UniqueValues[i];
                      if (SymbolDic.ContainsKey(classValue) == true)
                      {

                          pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[classValue]);
                      }
                      else
                      {
                          foreach (string key in SymbolDic.Keys)
                          {
                              if (key.Contains(classValue))
                              {
                                  pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[key]);
                                  break;
                              }
                          }
                      }
                  }
              }
              else if (pFeatureClass.ShapeType == esriGeometryType.esriGeometryPolygon)
              {
                  ISimpleFillSymbol pSimpleFillSymbol = new SimpleFillSymbolClass();
                  pSimpleFillSymbol.Style = esriSimpleFillStyle.esriSFSSolid;
                  pSimpleFillSymbol.Outline.Width = 0.4;

                  pUniqueValueRenderer.FieldCount = 1;
                  pUniqueValueRenderer.set_Field(0, fieldName);
                  pUniqueValueRenderer.DefaultSymbol = pSimpleFillSymbol as ISymbol;
                  pUniqueValueRenderer.UseDefaultSymbol = true;
                  Dictionary<string, ISymbol> SymbolDic = LoadStyle(esriSymbologyStyleClass.esriStyleClassFillSymbols, StyleName);
                  for (int i = 0; i < UniqueValues.Count; i++)
                  {
                      string classValue = UniqueValues[i];
                      if (SymbolDic.ContainsKey(classValue) == true)
                      {

                          pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[classValue]);
                      }
                      else
                      {
                          foreach (string key in SymbolDic.Keys)
                          {
                              if (key.Contains(classValue))
                              {
                                  pUniqueValueRenderer.AddValue(classValue, fieldName, SymbolDic[key]);
                                  break;
                              }
                          }
                      }
                  }
              }
              //pUniqueValueRenderer.ColorScheme = "Custom";
              //bool isString = pFeatureClass.Fields.get_Field(0).Type == esriFieldType.esriFieldTypeString;
              //pUniqueValueRenderer.set_FieldType(0, isString);
              //geoLayer.Renderer = pUniqueValueRenderer as IFeatureRenderer;
              //IUID pUID = new UIDClass();
              //pUID.Value = "{683C994E-A17B-11D1-8816-080009EC732A}";
              //geoLayer.RendererPropertyPageClassID = pUID as UIDClass; 


              InitRenderobj = geoLayer.Renderer;
              if (geoLayer != null)
              {
                  geoLayer.Renderer = pUniqueValueRenderer as IFeatureRenderer;
              }
            }
        ////简单渲染专题图 用地范围 房屋建筑
        //public void CreatSymbel()
        //{
        //    ISymbol pSymbol = null;
        //    if (layerName == "arcgis.DBO.用地范围")
        //    {
        //        pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Fill Symbols", "YDFW");
        //    }
        //    else if (layerName == "arcgis.DBO.房屋建筑")
        //    {
        //        pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Fill Symbols", "FWJZ");
        //    }
        //    //渲染对象
        //    ISimpleRenderer simpleRender = new SimpleRendererClass();
        //    simpleRender.Symbol = pSymbol;
        //    simpleRender.Label = "";
        //    simpleRender.Description = "简单渲染";

        //    IGeoFeatureLayer geoFeatureLayer;
        //    geoFeatureLayer = getGeoLayer(layerName, ax);
        //    InitRenderobj = geoFeatureLayer.Renderer;
        //    if (geoFeatureLayer != null)
        //    {
        //        geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
        //    }


        //}

        ////简单渲染专题图  道路
        //public void CreatDLSymbel()
        //{
        //    ISymbol pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Line Symbols", "DL");

        //    //渲染对象
        //    ISimpleRenderer simpleRender = new SimpleRendererClass();
        //    simpleRender.Symbol = pSymbol;
        //    simpleRender.Label = "";
        //    simpleRender.Description = "简单渲染";

        //    IGeoFeatureLayer geoFeatureLayer;
        //    geoFeatureLayer = getGeoLayer(layerName, ax);
        //    InitRenderobj = geoFeatureLayer.Renderer;
        //    if (geoFeatureLayer != null)
        //    {
        //        geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
        //    }


        //}

        ////简单渲染专题图 道路名称
        //public void CreatDLMCSymbel()
        //{
        //    ISymbol pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Marker Symbols", "DLMC");

        //    //渲染对象
        //    ISimpleRenderer simpleRender = new SimpleRendererClass();
        //    simpleRender.Symbol = pSymbol;
        //    simpleRender.Label = "";
        //    simpleRender.Description = "简单渲染";

        //    IGeoFeatureLayer geoFeatureLayer;
        //    geoFeatureLayer = getGeoLayer(layerName, ax);
        //    InitRenderobj = geoFeatureLayer.Renderer;
        //    if (geoFeatureLayer != null)
        //    {
        //        geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
        //    }

        //}

        ////简单渲染专题图 管理区
        //public void CreatGLQSymbel()
        //{
        //    ISymbol pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Fill Symbols", "GLQ");

        //    //渲染对象
        //    ISimpleRenderer simpleRender = new SimpleRendererClass();
        //    simpleRender.Symbol = pSymbol;
        //    simpleRender.Label = "";
        //    simpleRender.Description = "简单渲染";

        //    IGeoFeatureLayer geoFeatureLayer;
        //    geoFeatureLayer = getGeoLayer(layerName, ax);
        //    InitRenderobj = geoFeatureLayer.Renderer;
        //    if (geoFeatureLayer != null)
        //    {
        //        geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
        //    }

        //}
        ////简单渲染专题图 镇行政区
        //public void CreatZXZQSymbel()
        //{
        //    ISymbol pSymbol = ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\Style\LayerSymbol.ServerStyle", "Fill Symbols", "ZXZQ");
          
        //    //渲染对象
        //    ISimpleRenderer simpleRender = new SimpleRendererClass();
        //    simpleRender.Symbol = pSymbol;
        //    simpleRender.Label = "";
        //    simpleRender.Description = "简单渲染";

        //    IGeoFeatureLayer geoFeatureLayer;
        //    geoFeatureLayer = getGeoLayer(layerName, ax);
        //    InitRenderobj = geoFeatureLayer.Renderer;
        //    if (geoFeatureLayer != null)
        //    {
        //        geoFeatureLayer.Renderer = simpleRender as IFeatureRenderer;
        //    }

        //}

        ///<summary>

        ///获取符号库中符号

        ///</summary>

        ///<param name="styleName">符号库全路径名称</param>

        ///<param name="sGalleryClassName">GalleryClass名称</param>

        ///<param name="symbolName">符号名称</param>

        ///<returns>符号</returns>

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
       
    }
}
