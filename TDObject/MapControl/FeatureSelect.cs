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
    public class featureSelect
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
        public void featureSelects(IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {
                Point point = new PointClass();
                point.PutCoords(e.mapX, e.mapY);
                IGeometry geo = point as IGeometry;
                //ISelectionEnvironment pselectiongEnv;
                //pselectiongEnv = new SelectionEnvironmentClass();
                pselectiongEnv.DefaultColor.RGB = pareRgbToInt(127, 255, 0);

                //axMapControl1.Refresh();
                //axMapControl1.Map.ClearSelection();
                //MainForm.mapcontrol1.Map.SelectByShape(geo, pselectiongEnv, false);
                //MainForm.mapcontrol1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                //如果是shift 多选

                if (e.button == e.shift)
                {
                    //珍贵代码   控制选择的模式(Combination Method组合方法)
                    pselectiongEnv.CombinationMethod = esriSelectionResultEnum.esriSelectionResultXOR;
                }
                else
                {
                    pselectiongEnv.CombinationMethod = esriSelectionResultEnum.esriSelectionResultNew;
                }
                //IFeatureLayer pFeatureLayer =  GlobalVariables.axMapControl.Map.get_Layer(0) as IFeatureLayer ;
                //IFeatureSelection pFeatureSelection = pFeatureLayer as IFeatureSelection;
                //IQueryFilter pQuery = new QueryFilterClass();
                //pQuery.WhereClause = "*";

                //pFeatureSelection.SelectFeatures(pQuery,esriSelectionResultEnum.esriSelectionResultAdd,false);
                GlobalVariables.axMapControl.Map.SelectByShape(geo, pselectiongEnv, false);
                GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
                GlobalVariables.axMapControl.Refresh();

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());

            }

        }
  
    }
}
