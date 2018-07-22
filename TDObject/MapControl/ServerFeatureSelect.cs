using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDObject.MapControl
{
    class ServerFeatureSelect
    {
        private ISelectionEnvironment pselectiongEnv = new SelectionEnvironmentClass();

        public int pareRgbToInt(int R, int G, int B)
        {
            int rgb = R + G * 256 + B * 256 * 256;
            return rgb;

        }
        /// <summary>
        /// FeatureSelect方法实现  单选（Shift多选）
        /// </summary>
        /// <param name="e"></param>
        public String featureSelects(IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {
                Point point = new PointClass();
                point.PutCoords(e.mapX, e.mapY);
                IGeometry geo = point as IGeometry;
               
                IMapServer pMapServer = GlobalVariables.pMapServer;
                  SpatialFilter filter = new SpatialFilter();

　　              filter.Geometry = geo;//图形查询方式，设置查询图形

　　              filter.SpatialRel =  esriSpatialRelEnum.esriSpatialRelIntersects;//空间查询关系

　　           //   filter.WhereClause=strSql;//设置属性条件查询SQL语句

            //3、执行查询

                IRecordSet rcdset = pMapServer.QueryFeatureData(pMapServer.DefaultMapName, 1, filter);//查询结果保存在IRecordSet对象中，mapname表示地图服务地图的名称，lyrId表示要查询的地图服务子图层的I的号，通常为图层序号
                ICursor cursor = rcdset.get_Cursor(true);
                string value = "";
                IRow row = cursor.NextRow();
                if(row!=null){

                    value += row.get_Value(rcdset.Fields.FindField("行政村代码")) + ",";
                    row = cursor.NextRow();
                }

                    
                
               // GlobalVariables.axMapControl.Map.SelectByShape(geo, pselectiongEnv, false);
               // GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                GlobalVariables.axMapControl.Refresh();
                return value;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());

                return "";
            }

        }
   
    }
}
