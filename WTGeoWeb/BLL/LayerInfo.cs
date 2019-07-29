using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WTGeoWeb.BLL
{

    public class LayerInfo
    {
        public int LayerNo { get; set; }

        public string LayerName { get; set; }
        public string RestAddr { get; set; }
        public int PubLayIndex { get; set; }


        public Dictionary<string,LayerInfo> SubLayers;


        public Dictionary<string,LayerInfo> GetPubLayers()
        {

            string GisServerPubAddr="http://122.112.245.147:80";

            //string UrlChangePart = "TdDemo_SpatialServer";//Demo使用
            string UrlChangePart = "TD_SpatialServerTest";//望亭使用

               
            Dictionary<string,LayerInfo> LayInfos = new Dictionary<string,LayerInfo>();

            LayerInfo obj = new LayerInfo();
            LayerInfo subLayerInfo;
            int LayIndex = 1;
            
            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "镇界";
            obj.PubLayIndex = 0;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName,obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "村界";
            obj.PubLayIndex = 1;
            obj.RestAddr = GisServerPubAddr + "/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "工业管理区";
            obj.PubLayIndex = 2;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "自由分区";
            obj.PubLayIndex = 3;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "历年批次";
            obj.PubLayIndex = 4;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            obj.SubLayers = new Dictionary<string, LayerInfo>();
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName="彩色填充";
            subLayerInfo.PubLayIndex = 4;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName="彩色漏空";
            subLayerInfo.PubLayIndex = 4;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName="单色漏空";
            subLayerInfo.PubLayIndex = 4;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName="单色填充";
            subLayerInfo.PubLayIndex = 4;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            LayInfos.Add(obj.LayerName,obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "房屋建筑";
            obj.PubLayIndex = 5;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "城市规划";
            obj.PubLayIndex = 6;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/6" ;
            obj.SubLayers = new Dictionary<string, LayerInfo>();
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色填充";
            subLayerInfo.PubLayIndex = 7;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色漏空";
            subLayerInfo.PubLayIndex = 8;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色漏空";
            subLayerInfo.PubLayIndex = 9;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色填充";
            subLayerInfo.PubLayIndex = 10;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerName = "土地规划";
            obj.LayerNo = LayIndex++;
            obj.PubLayIndex = 11;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/11";
            obj.SubLayers = new Dictionary<string, LayerInfo>();
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色填充";
            subLayerInfo.PubLayIndex = 12;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色漏空";
            subLayerInfo.PubLayIndex = 13;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色漏空";
            subLayerInfo.PubLayIndex = 14;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色填充";
            subLayerInfo.PubLayIndex = 15;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "道路线";
            obj.PubLayIndex =16;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "道路中线";
            obj.PubLayIndex = 17;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "桥";
            obj.PubLayIndex = 18;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + obj.PubLayIndex.ToString();
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerName = "土地现状数据";
            obj.LayerNo = LayIndex++;
            obj.PubLayIndex = 19;
            obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/19";
            obj.SubLayers = new Dictionary<string, LayerInfo>();
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色填充";
            subLayerInfo.PubLayIndex = 20;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "彩色漏空";
            subLayerInfo.PubLayIndex = 21;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色漏空";
            subLayerInfo.PubLayIndex = 22;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            subLayerInfo = new LayerInfo();
            subLayerInfo.LayerName = "单色填充";
            subLayerInfo.PubLayIndex = 23;
            subLayerInfo.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/" + UrlChangePart + "/MapServer/" + subLayerInfo.PubLayIndex.ToString();
            obj.SubLayers.Add(subLayerInfo.LayerName, subLayerInfo);
            LayInfos.Add(obj.LayerName, obj);

            obj = new LayerInfo();
            obj.LayerNo = LayIndex++;
            obj.LayerName = "影像图";
            obj.PubLayIndex = 0;
            if (UrlChangePart == "TD_SpatialServerTest")
            {
                obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/WTService/MapServer";
            }
            else if (UrlChangePart == "TdDemo_SpatialServer")
            {
                obj.RestAddr = GisServerPubAddr+"/arcgis/rest/services/WTMap/SLService/MapServer";
            }
            LayInfos.Add(obj.LayerName, obj);

            return LayInfos;
        }
    }

    
}