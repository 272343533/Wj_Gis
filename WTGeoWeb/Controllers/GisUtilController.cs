using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTGeoWeb.Controllers
{
    public class GisUtilController : Controller
    {
        //
        // GET: /GisUtil/
        double targetZ = new double();
        double targetB = new double();
        double targetL = new double();

        public ActionResult Index()
        {
            return View();
        }
        public JsonResult WGS84ToWT(double wgB, double wgL, double wgH = 0)// private void button1_Click(object sender, EventArgs e)
        {
            JsonResult js = new JsonResult();

            double[] newXyz=BLHtoXYZ(wgB, wgL, wgH, 6378137, 6356752.314);
            double[] targetZBL= XYZtoBLH(newXyz[0], newXyz[1], newXyz[2], 6378245, 6356863.0188);
            double[] result=gaussBLtoXY(targetZBL[0], targetZBL[1], targetZBL[2]);

            js.Data = result;
            js.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return js;
        }
        //第一步转换，大地坐标系换换成空间直角坐标系
  
        private double[] BLHtoXYZ(double wgB, double wgL, double wgH, double aAxis, double bAxis)
        {
            double newX = new double();
            double newY = new double();
            double newZ = new double();
      
            //double targetX = new double();
            //double targetY = new double();
            //double targetZ = new double();

            double dblD2R = Math.PI / 180;

            double e1 = Math.Sqrt(Math.Pow(aAxis, 2) - Math.Pow(bAxis, 2)) / aAxis;

            double N = aAxis / Math.Sqrt(1.0 - Math.Pow(e1, 2) * Math.Pow(Math.Sin(wgB * dblD2R), 2));
            double targetX = (N + wgH) * Math.Cos(wgB * dblD2R) * Math.Cos(wgL * dblD2R);
            double targetY = (N + wgH) * Math.Cos(wgB * dblD2R) * Math.Sin(wgL * dblD2R);
            double targetZ = (N * (1.0 - Math.Pow(e1, 2)) + wgH) * Math.Sin(wgB * dblD2R);

            //第二步转换，空间直角坐标系里七参数转换
            double XRotate = -1.49779;//X旋转
            double YRotate = 4.016604;//Y旋转
            double ZRotate = -3.591758;//Z旋转

            double XOffset = 148.309;//X平移
            double YOffset = 218.731;//Y平移
            double ZOffset = 86.562;//Z平移
            double dbScale =-0.00000644782521;//尺度比

            double Ex = XRotate /3600/ 180 * Math.PI;
            double Ey = YRotate / 3600 / 180 * Math.PI;
            double Ez = ZRotate / 3600 / 180 * Math.PI;

            newX = XOffset + dbScale * targetX + targetY * Ez - targetZ * Ey + targetX;
            newY = YOffset + dbScale * targetY - targetX * Ez + targetZ * Ex + targetY;
            newZ = ZOffset + dbScale * targetZ + targetX * Ey - targetY * Ex + targetZ;

            return new double[] { newX, newY, newZ };
        }
        //第三步转换，空间直接坐标系转换为大地坐标系
        private double[] XYZtoBLH(double X, double Y, double Z, double aAxis, double bAxis)
        {
            double e1 = (Math.Pow(aAxis, 2) - Math.Pow(bAxis, 2)) / Math.Pow(aAxis, 2);
            double e2 = (Math.Pow(aAxis, 2) - Math.Pow(bAxis, 2)) / Math.Pow(bAxis, 2);

            double S = Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2));
            double cosL = X / S;
            double B = 0;
            double L = 0;

            L = Math.Acos(cosL);
            L = Math.Abs(L);

            double tanB = Z / S;
            B = Math.Atan(tanB);
            double c = aAxis * aAxis / bAxis;
            double preB0 = 0.0;
            double ll = 0.0;
            double N = 0.0;
            //迭代计算纬度
            do
            {
                preB0 = B;
                ll = Math.Pow(Math.Cos(B), 2) * e2;
                N = c / Math.Sqrt(1 + ll);

                tanB = (Z + N * e1 * Math.Sin(B)) / S;
                B = Math.Atan(tanB);
            }
            while (Math.Abs(preB0 - B) >= 0.0000000001);

            ll = Math.Pow(Math.Cos(B), 2) * e2;
            N = c / Math.Sqrt(1 + ll);

            targetZ = Z / Math.Sin(B) - N * (1 - e1);
            targetB = B * 180 / Math.PI;
            targetL = L * 180 / Math.PI;

            return new double[] { targetB, targetL, targetZ };
        }
        //第四部转换，高斯变换，大地坐标系转平面坐标系，54
        private double[] gaussBLtoXY(double mB, double mL, double mZ)
        {
            double m_aAxis = 6378245; //参考椭球长半轴
            double m_bAxis = 6356863.0188; //参考椭球短半轴
            double m_dbMidLongitude = 120.58333333333333;//中央子午线度
            double m_xOffset =-3421129;
            double m_yOffset =50805;
            try
            {
                //角度到弧度的系数
                double dblD2R = Math.PI / 180;
                //代表e的平方
                double e1 = (Math.Pow(m_aAxis, 2) - Math.Pow(m_bAxis, 2)) / Math.Pow(m_aAxis, 2);
                //代表e'的平方
                double e2 = (Math.Pow(m_aAxis, 2) - Math.Pow(m_bAxis, 2)) / Math.Pow(m_bAxis, 2);
                //a0
                double a0 = m_aAxis * (1 - e1) * (1.0 + (3.0 / 4.0) * e1 + (45.0 / 64.0) * Math.Pow(e1, 2) + (175.0 / 256.0) * Math.Pow(e1, 3) + (11025.0 / 16384.0) * Math.Pow(e1, 4));
                //a2                
                double a2 = -0.5 * m_aAxis * (1 - e1) * (3.0 / 4 * e1 + 60.0 / 64 * Math.Pow(e1, 2) + 525.0 / 512.0 * Math.Pow(e1, 3) + 17640.0 / 16384.0 * Math.Pow(e1, 4));
                //a4
                double a4 = 0.25 * m_aAxis * (1 - e1) * (15.0 / 64 * Math.Pow(e1, 2) + 210.0 / 512.0 * Math.Pow(e1, 3) + 8820.0 / 16384.0 * Math.Pow(e1, 4));
                //a6
                double a6 = (-1.0 / 6.0) * m_aAxis * (1 - e1) * (35.0 / 512.0 * Math.Pow(e1, 3) + 2520.0 / 16384.0 * Math.Pow(e1, 4));
                //a8
                double a8 = 0.125 * m_aAxis * (1 - e1) * (315.0 / 16384.0 * Math.Pow(e1, 4));
                ////纬度转换为弧度表示
                //B
                double B = mB * dblD2R;
                //l
                double l = (mL - m_dbMidLongitude) * dblD2R;
                ////X
                double X = a0 * B + a2 * Math.Sin(2.0 * B) + a4 * Math.Sin(4.0 * B) + a6 * Math.Sin(6.0 * B) + a8 * Math.Sin(8.0 * B);
                //
                double ll = Math.Pow(Math.Cos(B), 2) * e2;
                double c = m_aAxis * m_aAxis / m_bAxis;
                //N
                double N = c / Math.Sqrt(1 + ll);
                //t
                double t = Math.Tan(B);
                double p = Math.Cos(B) * l;
                double dbx = X + N * t * (1 + ((5.0 - t * t + (9.0 + 4.0 * ll) * ll) + ((61.0 + (t * t - 58.0) * t * t + (9.0 - 11.0 * t * t) * 30.0 * ll) + (1385.0 + (-31111.0 + (543 - t * t) * t * t) * t * t) * p * p / 56.0) * p * p / 30.0) * p * p / 12.0) * p * p / 2.0;
                double dby= N * (1.0 + ((1.0 - t * t + ll) + ((5.0 + t * t * (t * t - 18.0 - 58.0 * ll) + 14 * ll) + (61.0 + (-479.0 + (179.0 - t * t) * t * t) * t * t) * p * p / 42.0) * p * p / 20.0) * p * p / 6.0) * p;
                double mTargetX = dbx + m_xOffset;
                double mTargetY = dby + m_yOffset;
                double[] zb={mTargetX,mTargetY,mZ};


                return new double[] { mTargetX, mTargetY, mZ };
            }
            catch (Exception ex)
            {
                return new double[]{0,0,0};
            }
        }



    }
}
