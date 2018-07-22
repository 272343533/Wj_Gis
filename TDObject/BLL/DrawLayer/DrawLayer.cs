using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System.Collections;
using TDObject.DrawLayer;
using TDObject.MapControl;
namespace TDObject.DrawLayer
{
    class DrawLayer
    {
        private IWorkspaceEdit sdeWorkspace;
        private AxMapControl axMapControl1;
        private   IFeatureWorkspace pFtWs ;
        IFeatureLayer pFeatureLayer;
        EngineEditorClass pEngineEditor = new EngineEditorClass();
         private List<LayerFilter> layerFilterSet= new List<LayerFilter>();
        public void DrawLayers(IWorkspaceEdit we,AxMapControl amc) {
            sdeWorkspace = we;
            axMapControl1 = amc;
            sdeWorkspace.StartEditing(false);
            sdeWorkspace.StartEditOperation();
            pFtWs = sdeWorkspace as IFeatureWorkspace;
            SetFeatureLayer();
        }

        public void SetFeatureLayer(){

            pEngineEditor.StartEditing(pFtWs as IWorkspace, axMapControl1.Map);
            
            pEngineEditor.StartOperation();

            //设置目标图层
            GetFeatureLayer();
            IEngineEditLayers pEditLayer = pEngineEditor as IEngineEditLayers;

            ILayer ZYFQlayer = null;
            for (int i = 0; i < layerFilterSet.Count; i++)
            {
                if (layerFilterSet[i].LayerFilterName.Contains(GlobalVariables.LayerName2FullName["自由分区"]))
                {
                    ZYFQlayer = layerFilterSet[i].TargetLayer;
                }
                

            }

            pFeatureLayer = GetIFeatureLayer(ZYFQlayer);


            pEditLayer.SetTargetLayer(pFeatureLayer, 0);
        
        }
        public void GetFeatureLayer()
        {

            IMap map = axMapControl1.Map;
            if (map.LayerCount < 1) return;
            //获取指定类型图层
            UID uid = new UIDClass();
            //表示搜索的是IDataLayer
            uid.Value = "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}";
            //布尔参数表示要搜索GroupLayer中的图层
            IEnumLayer layers = map.get_Layers(uid, true);
            layers.Reset(); ILayer layer = layers.Next();
            while (layer != null)
            {
                LayerFilter layerProperty = new LayerFilter();
                //layerProperty.HeaderImage = null;
                //layerProperty.LayerCategory = string.Empty;
                layerProperty.LayerFilterName = layer.Name;
                layerProperty.LayerFeatureType = GetLayerFeatureType(layer);
                if (layerProperty.LayerFeatureType == LayerFeatureType.Polygon)

                    layerProperty.TargetLayer = layer;
                //保存引用
                if (layerProperty.LayerFilterName.Contains(GlobalVariables.LayerName2FullName[ "自由分区"]))
                    layerFilterSet.Add(layerProperty);



                layer = layers.Next();
            }
        }
        /// <summary>
        /// 获取要素图层的类型
        /// </summary>
        /// <param name="layer"></param>
        /// <returns></returns>
        private LayerFeatureType GetLayerFeatureType(ILayer layer)
        {
            LayerFeatureType featureType = LayerFeatureType.None;
            if (layer is IFeatureLayer)
            {
                IFeatureClass featureClass = (layer as IFeatureLayer).FeatureClass;
                switch (featureClass.ShapeType)
                {
                    case esriGeometryType.esriGeometryPoint:
                        featureType = LayerFeatureType.Point;
                        break;
                    case esriGeometryType.esriGeometryPolyline:
                        featureType = LayerFeatureType.Polyline;
                        break;
                    case esriGeometryType.esriGeometryPolygon:
                        featureType = LayerFeatureType.Polygon;
                        break;
                }
            }
            else if (layer is IRasterLayer)
            {
                featureType = LayerFeatureType.Raster;
            }
            else if (layer is IGroupLayer)
            {
                featureType = LayerFeatureType.GroupLayer;
            }
            return featureType;
        }

        /// <summary>
        /// 在指定图层使用指定范围查询结果
        /// </summary>
        /// <param name="identifyLayer">查询图层</param>
        /// <param name="identifyGeom">查询范围</param>
        /// <returns>查询结果</returns>
        private IFeatureLayer GetIFeatureLayer(ILayer identifyLayer)
        {

            IFeatureLayer featureLayer = null;
            ///判断图层的类型并作相应处理
            ///图层是要素图层
            if (identifyLayer is IFeatureLayer)
            {
                //获取要素图层
                featureLayer = identifyLayer as IFeatureLayer;
                //获取查询结果
           
            }
            //返回获取要素的集合
            return featureLayer;
        }
        public void DrawLayerSave(String creatName,String creatTime,String creatUser){

                pEngineEditor.StopEditing(true);
                IFeatureClass pFeatureClass = pFeatureLayer.FeatureClass;
                IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                IFeature pFeature = pFeatureCursor.NextFeature();

                if (pFeatureClass.AliasName.Contains(GlobalVariables.LayerName2FullName[ "自由分区"]))
                {
                
                    IFeature pfea = pFeature;

                    while (pFeature != null)
                    {
                           pfea = pFeature;
                           pFeature = pFeatureCursor.NextFeature();
                    }

                    IWorkspaceEdit workSpaceEdit = sdeWorkspace as IWorkspaceEdit;
                    workSpaceEdit.StartEditing(false);
                    workSpaceEdit.StartEditOperation();

                    pfea.set_Value(pfea.Fields.FindField("createName"), creatName);
                    pfea.set_Value(pfea.Fields.FindField("createTime"),DateTime.Parse(creatTime));
                    pfea.set_Value(pfea.Fields.FindField("createUser"), creatUser);
                    //修改完成，要用IFeature.store()方法保存：
                    pfea.Store();
                    workSpaceEdit.StopEditing(true);
                    //GlobalVariables.RefZYFQ();
                }
        }


    }
}
