using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.IO;


namespace WTGeoWeb.Controllers
{
    public class Pnt
    {
        public decimal x;
        public decimal y;
    }
    public class BaiDuApiMapFromTo
    {
        public int status;
        public Pnt[] result;
    }
    public class BaiduMapLongLatiJson
    {
        public int error;
        public string x;
        public string y;
        public decimal Longtitude;
        public decimal Latitude;
    }
    public class BdMapCoorsUtilController : Controller
    {
        //
        // GET: /BdMapCoorsUtil/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GcsToBD09II(double lng, double lat)
        {
            BaiDuApiMapFromTo bd092IIobj = GetMapCorrJson(3, 5, lng, lat);

            decimal[] result = new decimal[2];
            result[0] = bd092IIobj.result[0].x;
            result[1] = bd092IIobj.result[0].y;


            JsonResult js = new JsonResult();
            js.Data = result;
            js.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return js;
        }

        public JsonResult Wgs84ToBd09(double lng, double lat)
        {
            BaiDuApiMapFromTo bd092IIobj = GetMapCorrJson(1, 6, lng, lat);


            decimal[] result = new decimal[2];
            result[0] = bd092IIobj.result[0].x;
            result[1] = bd092IIobj.result[0].y;


            JsonResult js = new JsonResult();
            js.Data = result;
            js.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return js;
        }

        public BaiDuApiMapFromTo GetMapCorrJson(int mapfrom, int mapto, double lng, double lat)
        {
            try
            {
                string json = GetHttp("http://api.map.baidu.com/geoconv/v1/?coords=" + lng.ToString() + ",%20" + lat.ToString() + "&from=" + mapfrom + "&to=" + mapto + "&ak=zogQhcGTaQUNycXl5OrdXq9Z");
                BaiDuApiMapFromTo obj = Json2T<BaiDuApiMapFromTo>(json);
                return obj;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }
        public static string GetHttp(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();

            return responseContent;
        }
        public static T Json2T<T>(string json)
        {
            //var ser = new DataContractJsonSerializer(typeof(SearchNews));
            T obj = Activator.CreateInstance<T>();

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }

    }
}
