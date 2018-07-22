using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using QyTech.Core.BLL;
using QyTech.Core.Common;
using QyTech.Core;
using SunMvcExpress.Dao;
using log4net;
using QyTech.Json;
using System.Security.Cryptography;

using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace WTGeoWeb.Controllers
{
    public class takePhotoController : Controller
    {
        //
        // GET: /takePhoto/
        ILog log = log4net.LogManager.GetLogger("takePhoto");
      
        public ActionResult Index(string paras)
        {
            log.Error(paras);
            string[] strs = paras.Split(new char[] { ';' });
            if (strs.Length!=3)
            {
                ViewBag.dkbh = "000000";
                ViewBag.ltdname = "测试公司";
                ViewBag.pos = "0,0";
            }
            else
            {
                ViewBag.dkbh = strs[0];
                ViewBag.ltdname = strs[1];
                ViewBag.pos = strs[2];
            }
            return View();
        }


        /// <summary>
        /// 上传图片
        /// </summary>
        /// <param name="picString"></param>
        /// <returns></returns>

        public ActionResult SavePicture(string picString, string phototype, string SSDKBM, string SSQYMC, string WZZB, string PicMemo)
        {
              bool isOk = true;
              string msg = "";
              try
              {
                  var tmpArr = picString.Split(',');
                  for (int i = 0; i < tmpArr.Length-1; i++)
                  {
                  
                      byte[] bytes = Convert.FromBase64String(tmpArr[i+1]);
                      MemoryStream ms = new MemoryStream(bytes);
                      ms.Write(bytes, 0, bytes.Length);
                      var img = Image.FromStream(ms, true);

                      var path = System.AppDomain.CurrentDomain.BaseDirectory;
                      var imagesPath = System.IO.Path.Combine(path, @"Uploads\");
                      if (!System.IO.Directory.Exists(imagesPath))
                          System.IO.Directory.CreateDirectory(imagesPath);
                      string fileName1 = DateTime.Now.ToString("yyyyMMddHHmmss_ffff", System.Globalization.DateTimeFormatInfo.InvariantInfo);
                      string fileName = fileName1 + ".jpg";
                      string fullname=imagesPath + fileName;
                      string srcFullname=imagesPath+fileName1+"_1.jpg";
                      img.Save(srcFullname);

                      bool ret=CompressImage(srcFullname, fullname);

                      ////判断文件大小
                      //FileInfo fi=new FileInfo(imagesPath+fileName);
                      //if (fi.Length>500*1024);
                      //{
                      //    fi.MoveTo(imagesPath+fileName1+ "_1.jpg");


                      //    double scale = fi.Length / (500.0 * 512);
                      //    int width = (int)(img.Width / scale);
                      //    int height = (int)(img.Height / scale);
                      //    var bitImage = GetThumbnailImage(img, width, height);

                      //    bitImage.Save(imagesPath + fileName);
                      //}
                    

                      isOk = true;
                      msg = imagesPath + fileName;

                      //将数据写入数据库
                      LtdPhoto photo = new LtdPhoto();
                      photo.SSDKBM = SSDKBM;
                      photo.SSQYMC = SSQYMC;
                      photo.WZZB = WZZB;
                      photo.PhotoType = Convert.ToInt16(phototype);
                      photo.PICTURE = fileName;
                      photo.PicMemo = PicMemo;
                      WTGeoWeb.BLL.CommSetting.EM.Add<LtdPhoto>(photo);
                      i = i + 1;
                  }

              }
              catch (Exception ex)
              {
                  log.Error(ex.Message);
              }
            return Json(new { suc = isOk, msg = msg });
        }

        /// <summary>
        /// 图片压缩至指定尺寸，暂时未用，待用
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image GetThumbnailImage(Image srcImage, int width, int height)
        {
            Image bitmap = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bitmap);

            //设置高质量插值法 
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;

            //在指定位置并且按指定大小绘制原图片的指定部分 
            g.DrawImage(srcImage, new Rectangle(0, 0, width, width),
                new Rectangle(0, 0, srcImage.Width, srcImage.Height),
                GraphicsUnit.Pixel);

            return bitmap;
        }


        /// <summary>
        /// 无损压缩图片
        /// </summary>
        /// <param name="sFile">原图片地址</param>
        /// <param name="dFile">压缩后保存图片地址</param>
        /// <param name="flag">压缩质量（数字越小压缩率越高）1-100</param>
        /// <param name="size">压缩后图片的最大大小</param>
        /// <param name="sfsc">是否是第一次调用</param>
        /// <returns></returns>
        public static bool CompressImage(string sFile, string dFile, int flag = 90, int size = 300, bool sfsc = true)
        {
            //如果是第一次调用，原始图像的大小小于要压缩的大小，则直接复制文件，并且返回true
            FileInfo firstFileInfo = new FileInfo(sFile);
            if (sfsc == true && firstFileInfo.Length < size * 1024)
            {
                firstFileInfo.CopyTo(dFile);
                return true;
            }
            Image iSource = Image.FromFile(sFile);
            ImageFormat tFormat = iSource.RawFormat;
            int dHeight = iSource.Height / 2;
            int dWidth = iSource.Width / 2;
            int sW = 0, sH = 0;
            //按比例缩放
            Size tem_size = new Size(iSource.Width, iSource.Height);
            if (tem_size.Width > dHeight || tem_size.Width > dWidth)
            {
                if ((tem_size.Width * dHeight) > (tem_size.Width * dWidth))
                {
                    sW = dWidth;
                    sH = (dWidth * tem_size.Height) / tem_size.Width;
                }
                else
                {
                    sH = dHeight;
                    sW = (tem_size.Width * dHeight) / tem_size.Height;
                }
            }
            else
            {
                sW = tem_size.Width;
                sH = tem_size.Height;
            }

            Bitmap ob = new Bitmap(dWidth, dHeight);
            Graphics g = Graphics.FromImage(ob);

            g.Clear(Color.WhiteSmoke);
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            g.DrawImage(iSource, new Rectangle((dWidth - sW) / 2, (dHeight - sH) / 2, sW, sH), 0, 0, iSource.Width, iSource.Height, GraphicsUnit.Pixel);

            g.Dispose();

            //以下代码为保存图片时，设置压缩质量
            EncoderParameters ep = new EncoderParameters();
            long[] qy = new long[1];
            qy[0] = flag;//设置压缩的比例1-100
            EncoderParameter eParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, qy);
            ep.Param[0] = eParam;

            try
            {
                ImageCodecInfo[] arrayICI = ImageCodecInfo.GetImageEncoders();
                ImageCodecInfo jpegICIinfo = null;
                for (int x = 0; x < arrayICI.Length; x++)
                {
                    if (arrayICI[x].FormatDescription.Equals("JPEG"))
                    {
                        jpegICIinfo = arrayICI[x];
                        break;
                    }
                }
                if (jpegICIinfo != null)
                {
                    ob.Save(dFile, jpegICIinfo, ep);//dFile是压缩后的新路径
                    FileInfo fi = new FileInfo(dFile);
                    if (fi.Length > 1024 * size)
                    {
                        flag = flag - 10;
                        CompressImage(sFile, dFile, flag, size, false);
                    }
                }
                else
                {
                    ob.Save(dFile, tFormat);
                }
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                iSource.Dispose();
                ob.Dispose();
            }
        }
    }
}
