using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTGeoWeb.Controllers
{
    public class Gps
    {
        private double Lng;
        private double Lat;
        public Gps(double lat, double lng)
        {
            Lng =lng;
            Lat = lat;
        }
        public double getWgLon { get { return Lng; } }
        public double getWgLat { get { return Lat; } }
    }
    public class Gcj02ToWGS84Controller : Controller
    {

        public static double pi = 3.1415926535897932384626;
        public static double a = 6378245.0;
        public static double ee = 0.00669342162296594323;  


        // GET: /Gcj02ToWGS84/

        public ActionResult Index()
        {
            return View();
        }

        public static bool outOfChina(double lat, double lng)
        {
            return false;
        }
        /** 
    * * 火星坐标系 (GCJ-02) to 84 * * @param lon * @param lat * @return 
    * */
        public static Gps gcj_To_Gps84(double lat, double lon)
        {
            Gps gps = transform(lat, lon);
            double lontitude = lon * 2 - gps.getWgLon;
            double latitude = lat * 2 - gps.getWgLat;
            return new Gps(latitude, lontitude);
        }  

        public static Gps transform(double lat, double lon)
        {
            //if (outOfChina(lat, lon))
            //{
            //    return new Gps(lat, lon);
            //}
            double dLat = transformLat(lon - 105.0, lat - 35.0);
            double dLon = transformLon(lon - 105.0, lat - 35.0);
            double radLat = lat / 180.0 * Math.PI;
            double magic = Math.Sin(radLat);
            magic = 1 - ee * magic * magic;
            double sqrtMagic = Math.Sqrt(magic);
            dLat = (dLat * 180.0) / ((a * (1 - ee)) / (magic * sqrtMagic) * pi);
            dLon = (dLon * 180.0) / (a / sqrtMagic * Math.Cos(radLat) * pi);
            double mgLat = lat + dLat;
            double mgLon = lon + dLon;
            return new Gps(mgLat, mgLon);
        }

        public static double transformLat(double x, double y)
        {
            double ret = -100.0 + 2.0 * x + 3.0 * y + 0.2 * y * y + 0.1 * x * y
                    + 0.2 * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(y * pi) + 40.0 * Math.Sin(y / 3.0 * pi)) * 2.0 / 3.0;
            ret += (160.0 * Math.Sin(y / 12.0 * pi) + 320 * Math.Sin(y * pi / 30.0)) * 2.0 / 3.0;
            return ret;
        }

        public static double transformLon(double x, double y)
        {
            double ret = 300.0 + x + 2.0 * y + 0.1 * x * x + 0.1 * x * y + 0.1
                    * Math.Sqrt(Math.Abs(x));
            ret += (20.0 * Math.Sin(6.0 * x * pi) + 20.0 * Math.Sin(2.0 * x * pi)) * 2.0 / 3.0;
            ret += (20.0 * Math.Sin(x * pi) + 40.0 * Math.Sin(x / 3.0 * pi)) * 2.0 / 3.0;
            ret += (150.0 * Math.Sin(x / 12.0 * pi) + 300.0 * Math.Sin(x / 30.0
                    * pi)) * 2.0 / 3.0;
            return ret;
        }  
    }
}
