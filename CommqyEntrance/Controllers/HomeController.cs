﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QyTech.Core.BLL;
using QyTech.Core.Common;
using QyTech.Core;
using QyTech.Auth.Dao;
using log4net;
using QyTech.Json;
using System.Security.Cryptography;

using QyTech.BLL;
using System.Data.Objects;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace CommEntrance.Controllers
{

    public class LoginMess
    {
        public string UserId;
        public string UserUrl;
        public string AppName;
        public string AppVer;
        public string ValidUrl;
        public string HelpUrl;
    }
    
    public class HomeController : Controller
    {
        ILog log = log4net.LogManager.GetLogger("Home");

        [HttpPost]
        public string Login(string username, string password)
        {
            log.Info("login:" + username + "--" + password + ".");
            string jsonret = "http://122.114.190.250:8080/Wjkfq_gis/Home/Helper";
            LoginMess lm = new LoginMess();
            lm.HelpUrl = "http://122.114.190.250:8080/wjkfq_gis/Home/helper";
            try
            {
                 if ((username != null && password != null))
                {
                    //ObjectContext dblink = new QyTech_AuthEntities();
                    //EntityManager EM = new EntityManager(dblink);

                    bsUser obj = CommSetting.EM.GetBySql<bsUser>("LoginName='" + username + "' and LoginPwd='" + MD5(password) + "'");
                    lm.ValidUrl = "http://122.114.190.250:8080/commentrance/home/login";
                    lm.ValidUrl += "," + "http://117.121.102.226:80/commentrance/home/login";
                    lm.ValidUrl += "," + "http://219.243.12.234:80/commentrance/home/login";
                    lm.ValidUrl += "," + "http://219.243.12.231:80/commentrance/home/login";
                    lm.ValidUrl += "," + "http://60.2.27.75:8081/commentrance/home/login";
                    if (obj != null)
                    {
                        lm.UserId = obj.bsU_Id.ToString();
                        bsOrganize org = QyTech.BLL.CommSetting.EM.GetByPk<bsOrganize>("bsO_Id", obj.bsO_Id);
                        bsSoftCustInfo sciobj = QyTech.BLL.CommSetting.EM.GetByPk<bsSoftCustInfo>("bsS_Id", org.bsS_Id);
                        if (sciobj != null)
                        {
                            lm.UserUrl = sciobj.AppHomeUrl + "?userid=" + lm.UserId;
                            lm.AppName =sciobj.AppName;
                            lm.AppVer = sciobj.LastVersion;
                        }

                        List<bsCommEntranceUrl> Urls = QyTech.BLL.CommSetting.EM.GetListNoPaging<bsCommEntranceUrl>("", "Id");
                        if (Urls.Count > 0)
                        {
                            lm.ValidUrl = "";
                            foreach (bsCommEntranceUrl ce in Urls)
                            {
                                lm.ValidUrl += "," + ce.CommEntrance+ "/commentrance/home/login";
                            }
                       
                            lm.ValidUrl = lm.ValidUrl.Substring(1);
                        }
                       

                        jsonret = jsonMsgHelper.Create(0, lm, "");
                    }
                    else
                        jsonret = jsonMsgHelper.Create(1, null, "用户名或密码错误!");

                }
                else
                {
                    jsonret = jsonMsgHelper.Create(1, null, "用户名或密码不能为空!");
                }
            }
            catch (Exception ex)
            {
                // log.Error("Login:"+ex.Message);
                jsonret = jsonMsgHelper.Create(1, null, "出现错误!("+ex.Message+")");
            }
            return jsonret;
        }

        public static string MD5(string source)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(source);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");

        }


        public string AddWebUser(string username, string pwd)
        {
            bsUser obj = new bsUser();
            obj.bsU_Id = Guid.NewGuid();
            obj.bsO_Id = Guid.Parse("8E0CEA4C-1F0E-4E8B-AB16-960FF9570C8B");
            obj.bsO_Name = "望亭镇";
            obj.UserName = "web_"+username;
            obj.LoginName = username;
            obj.LoginPwd = MD5(pwd);
            obj.NickName = username;
            obj.bsR_Name = "浏览人员";

            obj.RegDt = DateTime.Now;
            obj.ValidDate = Convert.ToDateTime("2099-12-31");
            obj.AccountStatus = "正常";
            obj.bsR_Name = "浏览人员";
            string ret = QyTech.BLL.CommSetting.EM.Add<bsUser>(obj);
            log.Error(username + ":" + pwd + "---" + ret);
            if (ret == "")
                return "";
            else if (ret.Contains("Ix_LoginName"))
                return "账号已使用，请更改登录名！";
            else
                return ret;
            return "系统正在测试！";
        }

        

    }
}