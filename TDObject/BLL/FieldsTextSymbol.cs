using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDObject.BLL
{
    public static class FieldsTextSymbol
    {
        /// <summary>
        /// 属性标注方法
        /// </summary>
        /// <param name="pFeatLyr">要标注的图层</param>
        /// <param name="fieldNames">字段</param>
        /// <param name="styleName">样式文件名</param>
        /// <param name="TextSymbolName">TextSymbol 样式名</param>
        public static void addLayerTextSymbol(IFeatureLayer pFeatLyr, string[] fieldNames, string styleName, string TextSymbolName,double minScale,double maxScale,double scaleNow)
        {

            if (scaleNow < minScale || scaleNow > maxScale)
                return;
            string connectivesStr = "& VbNewLine & ";



            //这里设置文字样式的颜色和字体等
            ITextSymbol pTextSyl;
            pTextSyl = ColorSymbel.ReadStyleServer(System.Windows.Forms.Application.StartupPath + @"\NewStyle\" + styleName + ".ServerStyle", "Text Symbols", TextSymbolName) as ITextSymbol;


            IGeoFeatureLayer pGeoFeatureLayer = pFeatLyr as IGeoFeatureLayer;


            //设置线标注位置
            ILineLabelPosition pLineLabelPosition = new LineLabelPositionClass();
            pLineLabelPosition.Above = false;
            pLineLabelPosition.AtEnd = false;
            pLineLabelPosition.Below = false;
            pLineLabelPosition.Horizontal = false;
            pLineLabelPosition.InLine = true;
            pLineLabelPosition.OnTop = true; pLineLabelPosition.Parallel = true;
            //设置点标注属性        
            IPointPlacementPriorities pPointPlacementPriorities = new PointPlacementPrioritiesClass();
            pPointPlacementPriorities.AboveCenter = 2;
            pPointPlacementPriorities.AboveLeft = 3;
            pPointPlacementPriorities.AboveRight = 1;
            pPointPlacementPriorities.BelowCenter = 3;
            pPointPlacementPriorities.BelowLeft = 3;
            pPointPlacementPriorities.BelowRight = 3;
            pPointPlacementPriorities.CenterLeft = 3;
            pPointPlacementPriorities.CenterRight = 2;
            //设置线标注属性                
            ILineLabelPlacementPriorities pLineLabelPlacementPriorities = new LineLabelPlacementPrioritiesClass();
            pLineLabelPlacementPriorities.AboveAfter = 3;
            pLineLabelPlacementPriorities.AboveAlong = 1;
            pLineLabelPlacementPriorities.AboveBefore = 3;
            pLineLabelPlacementPriorities.AboveEnd = 3;
            pLineLabelPlacementPriorities.AboveStart = 3;
            pLineLabelPlacementPriorities.BelowAfter = 3;
            pLineLabelPlacementPriorities.BelowAlong = 3;
            pLineLabelPlacementPriorities.BelowBefore = 3;
            pLineLabelPlacementPriorities.BelowEnd = 3;
            pLineLabelPlacementPriorities.BelowStart = 3;
            pLineLabelPlacementPriorities.CenterAfter = 3;
            pLineLabelPlacementPriorities.CenterAlong = 3;
            pLineLabelPlacementPriorities.CenterBefore = 3;
            pLineLabelPlacementPriorities.CenterEnd = 3;
            pLineLabelPlacementPriorities.CenterStart = 3;
            //非重叠处理 
            pLineLabelPosition.ProduceCurvedLabels = false;
            IBasicOverposterLayerProperties pBasicOverposterLayerProperties = new BasicOverposterLayerPropertiesClass(); 
            pBasicOverposterLayerProperties.LineLabelPosition = pLineLabelPosition; 
            pBasicOverposterLayerProperties.PointPlacementOnTop = true;
            pBasicOverposterLayerProperties.PointPlacementPriorities = pPointPlacementPriorities;
            pBasicOverposterLayerProperties.LineLabelPlacementPriorities = pLineLabelPlacementPriorities;
            pBasicOverposterLayerProperties.NumLabelsOption = esriBasicNumLabelsOption.esriOneLabelPerPart;
 



            //pGeoFeatureLayer.AnnotationProperties.Clear();//必须执行 有默认标注
            //IBasicOverposterLayerProperties pBasic = new BasicOverposterLayerPropertiesClass();
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
            pLableEngine.BasicOverposterLayerProperties = pBasicOverposterLayerProperties; 
            //pBasic.NumLabelsOption = esriBasicNumLabelsOption.esriOneLabelPerPart;
           // pBasic.PointPlacementMethod = esriOverposterPointPlacementMethod.esriOnTopPoint;
            //pBasic.PointPlacementOnTop = true;
           /// pLableEngine.BasicOverposterLayerProperties = pBasic;
            pLableEngine.Symbol = pTextSyl;
            pGeoFeatureLayer.AnnotationProperties.Add(pLableEngine as IAnnotateLayerProperties);
           
            pGeoFeatureLayer.DisplayAnnotation = true;
            //}

        }

    }
}
