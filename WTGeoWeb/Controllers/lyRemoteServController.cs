using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SunMvcExpress.Dao;
using System.ComponentModel;
using System.Data;
using System.Data.Objects;
using QyTech.Core.BLL;
using QyTech.Json;
using log4net;
using System.Security.Cryptography;

using QyTech.Auth.Dao;

namespace WTGeoWeb.Controllers
{
    public class lyRemoteServController : Controller
    {
        //
        // GET: /lyRemoteServ/
        ILog log = log4net.LogManager.GetLogger("lyRemoteServ");

        EntityManager EM = new EntityManager(new SunMvcExpress.Dao.wj_GisDbEntities()); 


        public ActionResult Index()
        {
            return View();
        }

        #region store
        public string GetCGDLTotalTyp()
        {
            log.Info("GetLtdInfo:");
            string json = "";
            List<string> objs = EM.GetAllByStorProcedure<string>("splyGetCGDLTotalType", new object[] { });
            json = JsonHelper.SerializeObjects<string>(objs);

            return json;
        }

        
        #endregion


        #region gis对象

        /// <summary>
        /// 获取土地现状信息
        /// </summary>
        /// <param name="dkbm"></param>
        /// <returns></returns>
        public string GetLtdInfo(string dkbm)
        {
            log.Info("GetLtdInfo:" + dkbm );
            string json = "";
            企业范围 obj = EM.GetBySql<企业范围>("地块编码='" + dkbm + "'");
            json = JsonHelper.SerializeObject<企业范围>(obj, null);

            return json;
        }

        /// <summary>
        /// 根据id获取获取gis对象
        /// </summary>
        /// <param name="sqlconf"></param>
        /// <returns></returns>
        public string GetGisObj(string TType,string id)
        {
            log.Info("GetGisObj:" + TType + "---" + id);
            string json = "";
            if (TType == "房屋建筑")
            {
                房屋建筑 tobject = EM.GetByPk<房屋建筑>("OBJECTID", id);
                json = JsonHelper.SerializeObject<房屋建筑>(tobject, null);
            }
           
            else if (TType == "企业范围")
            {
                企业范围 tobject = EM.GetByPk<企业范围>("OBJECTID", id);
                json = JsonHelper.SerializeObject<企业范围>(tobject, null);
            }
            else if (TType == "城市规划")
            {
                城市规划 tobject = EM.GetByPk<城市规划>("OBJECTID", id);
                json = JsonHelper.SerializeObject<城市规划>(tobject, null);
            }


            return json;

        }


        public string UpdGisObj(string TType ,string json)
        {
            log.Info("UpdGisObj:" + TType + "---" + json);
            string ret = "";
           if (TType == "房屋建筑")
            {
                房屋建筑 obj = JsonHelper.DeserializeFormtJsonToObject<房屋建筑>(json);
                房屋建筑 tobject = EM.GetByPk<房屋建筑>("OBJECTID", obj.OBJECTID);
                EntityOperate.Copy<房屋建筑>(obj, tobject, "OBJECTID");

                ret = EM.Modify<房屋建筑>(tobject);
            }
            else if (TType == "企业范围")
            {
                企业范围 obj = JsonHelper.DeserializeFormtJsonToObject<企业范围>(json);
                企业范围 tobject = EM.GetByPk<企业范围>("OBJECTID", obj.OBJECTID);
                EntityOperate.Copy<企业范围>(obj, tobject, "OBJECTID");

                ret = EM.Modify<企业范围>(tobject);
            }
            else if (TType == "城市规划")
            {
                城市规划 obj = JsonHelper.DeserializeFormtJsonToObject<城市规划>(json);
                城市规划 tobject = EM.GetByPk<城市规划>("OBJECTID", obj.OBJECTID);
                EntityOperate.Copy<城市规划>(obj, tobject, "OBJECTID");

                ret = EM.Modify<城市规划>(tobject);
            }
            return ret;
        }


        #endregion


        //复杂非空间查询
        public string DoComplexQuery(string sqlconf)
        {
            log.Info("DoComplexQuery:"+sqlconf);
            string json = "";

            List<企业范围> list = new List<企业范围>();
            list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<企业范围>(sqlconf, "");

            json = JsonHelper.SerializeObjects<企业范围>(list, new List<string>());

            return json;

        }

        /// <summary>
        /// 根据用户号码获取组织机构
        /// </summary>
        /// <param name="userid"></param>
        /// <returns></returns>
        //public string GetAllOrgData(string userid)
        //{
        //    log.Info("DoComplexQuery:" + userid);
        //    List<bsOrganize> list = new List<bsOrganize>();
        //    if (userid == null || userid.Trim() == "")
        //    {
        //        list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<bsOrganize>("OrgType='村' or OrgType='镇'", "");
           
        //    }
        //    else
        //    {
        //        bsUser userobj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_id", Guid.Parse(userid));
        //        if (userobj.bsO_RightsCode == "全部村镇")
        //        {
        //            list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<bsOrganize>("OrgType='村' or OrgType='镇'", "");
        //        }
        //        else
        //        {
        //            list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<bsOrganize>(" Name like '%镇%' or Name like '%" + userobj.bsO_RightsCode + "%' and (OrgType='村' or OrgType='镇')", "");
        //        }
        //    }
        //    string json = JsonHelper.SerializeObjects<bsOrganize>(list, new List<string>());

        //    return json;
        //}

     

        # region  用户信息
        public string GetAllUserInfoData(string bsoname)
        {
            log.Info("GetUserInfoData:");
            List<bsUser> list = new List<bsUser>();
          
            if (bsoname == null || bsoname == "")
            {
                list = WTGeoWeb.BLL.CommSetting.EM_Base.GetListNoPaging<bsUser>("bso_Name!='System'", "bsR_Name,LoginName");
            }
            else
            {
                list = WTGeoWeb.BLL.CommSetting.EM_Base.GetListNoPaging<bsUser>("bsO_Name='" + bsoname + "'", "bsR_Name,LoginName");
            }
            string json = JsonHelper.SerializeObjects<bsUser>(list, new List<string>());

            return json;
        }

        public string GetOneUserData(string id)
        {
            log.Info("AddUserData:" + id);
            bsUser obj = WTGeoWeb.BLL.CommSetting.EM_Base.GetByPk<bsUser>("bsU_Id", Guid.Parse(id));
            string json = JsonHelper.SerializeObject<bsUser>(obj, null);
            return json;
        }

        public string AddUserData(string userinfo)
        {
            log.Info("AddUserData:" + userinfo);
            bsUser obj = JsonHelper.DeserializeFormtJsonToObject<bsUser>(userinfo);
            obj.LoginPwd = MD5(obj.LoginPwd);
            string ret = WTGeoWeb.BLL.CommSetting.EM_Base.Add<bsUser>(obj);

            if (ret == "")
                return "";
            else
                return ret;
        }
        

        public string DelUserData(string id)
        {
            log.Info("DelUserData:" + id);
            string ret = WTGeoWeb.BLL.CommSetting.EM_Base.DeleteById<bsUser>("bsU_Id", Guid.Parse(id));

            if (ret == "")
                return "";
            else
                return ret;
        }

        public static string MD5(string source)
        {
            byte[] result = System.Text.Encoding.Default.GetBytes(source);    //tbPass为输入密码的文本框
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] output = md5.ComputeHash(result);
            return BitConverter.ToString(output).Replace("-", "");

        }

        //public string UdpUserData(string userinfo)
        //{
        //    log.Info("UdpUserData:" + userinfo);
        //    bsUser obj = JsonHelper.DeserializeFormtJsonToObject<bsUser>(userinfo);
        //    bsUser dbobj = WTGeoWeb.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_Id", obj.bsU_Id);
        //    dbobj.LoginName = obj.LoginName;
        //    dbobj.NickName = obj.NickName;
        //    dbobj.bsR_Name = obj.bsR_Name;
        //    dbobj.LoginDt = obj.LoginDt;
        //    dbobj.LoginPwd = obj.LoginPwd;
        //    dbobj.bsO_RightsCode = obj.bsO_RightsCode;
        //    string ret = WTGeoWeb.BLL.CommSetting.EM.Modify<bsUser>(dbobj);

        //    if (ret == "")
        //        return "";
        //    else
        //        return ret;
        //}

        #endregion



        #region 企业模糊查询
        public string AppLtdQuery(string ltdName)
        {
            log.Info("DoAppLtdQuery:" + ltdName);
            string json = "";

            List<企业范围> list = new List<企业范围>();
            list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<企业范围>("用地单位名称 like '%" + ltdName + "%'", "");

            //List<string> fields = new List<string>();
            //fields.Add("地块编码");
            //fields.Add("用地单位名称");
            //json = JsonHelper.SerializeObjects<土地现状数据>(list, fields);


            List<LtdBaseInfo> objs = new List<LtdBaseInfo>();
            foreach (企业范围 item in list)
            {
                LtdBaseInfo obj = new LtdBaseInfo();
                obj.dkbm = item.DKBH;
                obj.name = item.YDQYMC;

                objs.Add(obj);
            }
           // List<string> fields = new List<string>();
            json = JsonHelper.SerializeObjects<LtdBaseInfo>(objs);
            return json;

        }


        public JsonResult JsLtdQuery(string ltdName)
        {
            log.Info("DoAppLtdQuery:" + ltdName);

            List<企业范围> list = new List<企业范围>();
            list = WTGeoWeb.BLL.CommSetting.EM.GetListNoPaging<企业范围>("YDQYMC like '%" + ltdName + "%'", "");

            //List<string> fields = new List<string>();
            //fields.Add("地块编码");
            //fields.Add("用地单位名称");
            //json = JsonHelper.SerializeObjects<土地现状数据>(list, fields);


            List<LtdBaseInfo> objs = new List<LtdBaseInfo>();
            foreach (企业范围 item in list)
            {
                LtdBaseInfo obj = new LtdBaseInfo();
                obj.dkbm = item.DKBH;
                obj.name = item.YDQYMC;

                objs.Add(obj);
            }
            // List<string> fields = new List<string>();

            //json = JsonHelper.SerializeObjects<LtdBaseInfo>(objs);

            JsonResult json = new JsonResult();
            json.Data = objs;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return json;

        }
        public string GetPublishAddr()
        {
            string pubaddr=System.Web.Configuration.WebConfigurationManager.AppSettings["PublishAddr"];
            return pubaddr;
        }

        public class LtdBaseInfo
        {
            public string dkbm{get;set;}
            public string name{get;set;}

        }
        #endregion
    }
}
