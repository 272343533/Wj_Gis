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

using WTGeoWeb.BLL;
namespace WTGeoWeb.Controllers
{
    public class HomeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger("Home");



        public ActionResult Index_NewForCust()
        {
            return View();
        }
        //
        // GET: /Home/

        public ActionResult Index(string userid)
        {

            if (userid == null)
                userid = Guid.Empty.ToString();

            log.Error("Index:userid="+userid);
            //根据userid 返回不同的 地址
            if (IsMobileDevice())
            {
                RedirectResult rr = Redirect(Url.Content("~/Home/index_m?userid=" + userid));
                log.Error(HttpContext.Request.UserHostAddress + ":" + rr.Url);
                return rr;
            }
            else
            {
                ViewBag.bsU_Id = userid;
                return View();
            }
        }

        public ActionResult Index_m(string userid)
        {
            bsUser obj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_Id", Guid.Parse(userid));
            log.Info("login1:" + obj.bsR_Name);
            if (obj != null)
            {
                ViewBag.bsU_Id = userid;
                ViewBag.bsR_Name = obj.bsR_Name;
                ViewBag.UserName = obj.UserName;
            }
            return View();
        }
        public ActionResult Index_m_F()
        {
            return View();
        }

        public string Login(string username, string password)
        {
            try
            {
                log.Info("login:"+username + "--" + password+".");
                if ((username != null && password != null))
                {
                    bsUser obj = WTGeoWeb.BLL.CommSetting.EM.GetBySql<bsUser>("LoginName='" + username + "' and Pwd='" + MD5(password) + "'");

                    log.Info("login1:" + obj.bsR_Name);
                    if (obj != null)
                    {
                        return obj.bsU_Id.ToString();
                    }
                    else
                        return "fail";

                }
                else
                {
                    return "fail";
                }
            }
            catch (Exception ex)
            {
                // log.Error("Login:"+ex.Message);
                return "fail";
            }
        }

        public static string MD5(string source)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(source);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");

        }
        public string LoginByJson(string username, string password)
        {
           // JsonResult json=new JsonResult();
            string json = "";
            try
            {
                log.Error("login:" + username + "--" + password + ".");
                if ((username != null && password != null))
                {
                    bsUser obj = WTGeoWeb.BLL.CommSetting.EM.GetBySql<bsUser>("LoginName='" + username + "' and Pwd='" + MD5(password) + "'");

                    json = JsonHelper.SerializeObject<bsUser>(obj,null);
                    //json=JsonHelper.SerializeObject<bsUser>(obj,new List<string>(){"bsU_Id","Name","bsR_Name"});
                    
                }
                return json;
            }
            catch (Exception ex)
            {
                // log.Error("Login:"+ex.Message);
                return json;
            }
        }


        public ActionResult Login_m()
        {
            return View();
        }


        public ActionResult Register()
        {
            return View();
        }


        /// <summary>
        /// 判断是否移动设备。
        /// </summary>
        /// <returns></returns>
        public bool IsMobileDevice()
        {
            string[] mobileAgents = { "iphone", "android", "phone", "mobile", "wap", "netfront", "java", "opera mobi", "opera mini", "ucweb", "windows ce", "symbian", "series", "webos", "sony", "blackberry", "dopod", "nokia", "samsung", "palmsource", "xda", "pieplus", "meizu", "midp", "cldc", "motorola", "foma", "docomo", "up.browser", "up.link", "blazer", "helio", "hosin", "huawei", "novarra", "coolpad", "webos", "techfaith", "palmsource", "alcatel", "amoi", "ktouch", "nexian", "ericsson", "philips", "sagem", "wellcom", "bunjalloo", "maui", "smartphone", "iemobile", "spice", "bird", "zte-", "longcos", "pantech", "gionee", "portalmmm", "jig browser", "hiptop", "benq", "haier", "^lct", "320x320", "240x320", "176x220", "w3c ", "acs-", "alav", "alca", "amoi", "audi", "avan", "benq", "bird", "blac", "blaz", "brew", "cell", "cldc", "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq", "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d", "lg-g", "lge-", "maui", "maxo", "midp", "mits", "mmef", "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", "oper", "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap", "sage", "sams", "sany", "sch-", "sec-", "send", "seri", "sgh-", "shar", "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo", "teli", "tim-", "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "googlebot-mobile" };

            bool isMoblie = false;

            //string userAgent = HttpContext.Current.Request.UserAgent.ToString().ToLower();
            string userAgent = HttpContext.Request.UserAgent.ToString().ToLower();
            
            //排除 Windows 桌面系统或苹果桌面系统 
            if (!string.IsNullOrEmpty(userAgent) && !userAgent.Contains("macintosh") && (!userAgent.Contains("windows nt") || (userAgent.Contains("windows nt") && userAgent.Contains("compatible; msie 9.0;"))))
            {
                for (int i = 0; i < mobileAgents.Length; i++)
                {
                    if (userAgent.ToLower().IndexOf(mobileAgents[i]) >= 0)
                    {
                        isMoblie = true;
                        break;
                    }
                }
            }

            return isMoblie;
        }
    }
}