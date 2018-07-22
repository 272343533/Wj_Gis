using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using TDObject.MapControl;
namespace TDObject.BLL
{
    class ClassCotrolLayerShow
    {

        /// <summary>
        /// 控制图层显示
        /// </summary>
        /// <param name="XZCDM">拼接的显示条件</param>
        public void ControlLayerShow(AxMapControl axMapControl1, string XZCDM,string XZZDM)
        {

            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                try
                {

                    ILayer layer = GetOverviewLayer(axMapControl1.Map, i);
                    IFeatureLayer new_FeatureLayer = layer as IFeatureLayer;
                    string str = new_FeatureLayer.Name;
                    string str1 = new_FeatureLayer.Name;
                     string filter = string.Empty;
                    switch (new_FeatureLayer.Name) { 
                        //case "行政区":
                        //    filter = "XZQDM in " + XZZDM;
                        //    ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                        //    break;
                        case "管理区":
                            filter = "GLQDM in " + XZCDM;
                            ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                            break;
                        case "企业范围":
                            filter = "SSGLQDM in  " + XZCDM;
                            ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                            break;
                        case "房屋建筑":
                            filter = "SSGLQDM in  " + XZCDM;
                            ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                            break;

                        case "道路":
                        case "道路线":
                            filter = "SSGLQDM in  " + XZCDM;
                            ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                            break;
                        case "河流":
                            filter = "SSGLQDM in  " + XZCDM;
                            ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                            break;
                        //default:
                        //    filter = "SSGLQDM not in  " + XZCDM;
                        //    ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                        //    break;
                    }
                   

                }

                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }

        //自由分区的显示
        public void ControlZYFQShow(AxMapControl axMapControl1, string Name)
        {

            for (int i = 0; i < axMapControl1.LayerCount; i++)
            {
                try
                {

                    ILayer layer = GetOverviewLayer(axMapControl1.Map, i);
                    IFeatureLayer new_FeatureLayer = layer as IFeatureLayer;
                    string str = new_FeatureLayer.Name;
                    string str1 = new_FeatureLayer.Name;

                    if (new_FeatureLayer.Name =="自由分区")
                    {
                        string filter = "createName in " + Name;
                        ShowByFilter(axMapControl1, new_FeatureLayer, filter);
                    }
                    //  axMapControl1.Extent = axMapControl1.FullExtent;
                    //IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
                    //IActiveView pAv = pGra as IActiveView;

                    //// 刷新鹰眼
                    //pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                    //axMapControl2.Extent = axMapControl2.FullExtent;


                }
                catch (Exception Exception){
                    MessageBox.Show(Exception.Message);
                }

            }

        }
       
        /// <summary>
        /// 控制某一Layer中某一Feature是否显示
        /// </summary>
        /// <param name="sMapCtr"></param>
        /// <param name="sFlyr">处理的Layer</param>
        /// <param name="sFilter">表达式 </param>
        public void ShowByFilter(AxMapControl sMapCtr, IFeatureLayer sFlyr, string sFilter)
        {
            ESRI.ArcGIS.Carto.IFeatureLayerDefinition pDef = (ESRI.ArcGIS.Carto.IFeatureLayerDefinition)sFlyr;

            pDef.DefinitionExpression = sFilter;
            //  string[] fieldNames = {"GLFQDM"};
            //LabelByFieldnames(sFlyr, fieldNames);
            //UpdataLabel(axMapControl1, sFlyr);

            //     axMapControl1.CtlRefresh(esriViewDrawPhase.esriViewBackground,null,null);
            sMapCtr.ActiveView.Refresh();
        }

        /// <summary>
        /// 获取已经加载的图层
        /// </summary>
        /// <param name="map"></param>
        /// <param name="index">要获取图层的ID（tocControl中位序）</param>
        /// <returns></returns>
        public ILayer GetOverviewLayer(IMap map, int index)
        {
            //获取主视图的图层
            ILayer pLayer = map.get_Layer(index);
            double scale = map.MapScale;
            string name = pLayer.Name;
            return pLayer;

        }


        public  void RefMapByLtd(AxMapControl mapcontrol1, IGeometry IGeo)
        {
            if (IGeo != null)
            {
                try
                {
                    mapcontrol1.FullExtent = IGeo.Envelope;
                    mapcontrol1.Refresh();
                }catch(Exception ex){
                    MessageBox.Show(ex.Message);
                }
                
            }
        }
    }
}
