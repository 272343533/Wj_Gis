using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunMvcExpress.Dao;
using SunMvcExpress.Core;
using QyTech.Core.BLL;
using System.Reflection;
//using SunMvcExpress.Core.Models;
using System.Data.Objects;
using System.Data.Objects.DataClasses;
using QyTech.Core;
using QyTech.Json;
using TDObject;
using QyTech.Auth.Dao;

namespace TDObject.BLL
{
    class DatabaseAccess
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(" TDObject.BLL DatabaseAccess");

        public static Dictionary<Type, string[]> canUpdateAttribute = new Dictionary<Type, string[]>();

        
         static DatabaseAccess() {
            //List<bsFunField> ffields = MainForm.QyTech_EM.GetListNoPaging<bsFunField>("", "");

             canUpdateAttribute.Add(typeof(房屋建筑), new string[] { "JZBH", "SSDKBH", "SSYDQYMC", "SSZLQYDM", "SSZLQYMC", "LCS", "JZZDMJ", "JZZDMJ", "SSXZQDM", "SSXZQMC", "SSGLQDM", "SSGLQMC"});
            canUpdateAttribute.Add(typeof(企业范围), new string[] { "DKBH", "NSRSBH", "YDQYMC", "TDZL", "ZCLX", "ZCSJ", "JYFW", "HYDL", "FZMJ_", "ZDMJ", "JZZDMJ", "JZMJ", "QSXZ"});
         }
        
        
        //public static int updateLayerInfoToDB<T>(Dictionary<string,string> layerInfo)where T :EntityObject
        //{
            
        //    int resultCode = 0;
        //    try
        //    {
        //        T tobject = getLayerInfoFromDB<T>(layerInfo["编码"]);


        //        if (tobject == null)
        //        {
        //            resultCode = 1;
        //            return resultCode;
        //        }

        //        Type type = tobject.GetType();
        //        PropertyInfo[] pi = type.GetProperties();
        //        foreach (PropertyInfo p in pi)
        //        {
        //            if (!layerInfo.Keys.Contains<string>(p.Name))
        //                continue;
                
        //            string value = layerInfo[p.Name];

        //            if (canUpdateAttribute[type].Contains(p.Name))
        //            {
        //                if (!p.PropertyType.IsGenericType)
        //                {
        //                    //非泛型
        //                    p.SetValue(tobject, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, p.PropertyType), null);
        //                }
        //                else
        //                {
        //                    //泛型Nullable<>
        //                    Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
        //                    if (genericTypeDefinition == typeof(Nullable<>))
        //                    {
        //                        p.SetValue(tobject, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(p.PropertyType)), null);
        //                    }
        //                }
        //              //  p.SetValue(tobject, (object)layerInfo[p.Name]);
        //            }
        //        }
        //        string ErrMsg = "";

        //        ErrMsg = TDObject.BLL.CommSetting.EM.Modify<T>(tobject);
        //        if (ErrMsg != "")
        //            resultCode = 2;
        //        else
        //            resultCode = 0;
        //        return resultCode;
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //        //这里一般是LayerInfo中没有字段，即本地数据库和服务器不同
        //        resultCode = -1;
        //        return resultCode;

        //    }      

        //}


         public static int updateLayerInfoToDB(string TType, Dictionary<string, string> layerInfo)
        {
            
            int resultCode = 0;
            try
            {
                string detailUrl = MainForm.App_URI + "lyRemoteServ/GetGisObj?TType=" + TType + "&id=" + layerInfo["编码"];

                string ret = AsyncHttp.CommFun.GetRemoteJson(detailUrl);

                object obj = new object();

                if (TType == "房屋建筑")
                   obj = JsonHelper.DeserializeJsonToObject<房屋建筑>(ret);
                else 
                    obj = JsonHelper.DeserializeJsonToObject<企业范围>(ret);
               

                if (obj == null)
                {
                    resultCode = 1;
                    return resultCode;
                }

                Type type = obj.GetType();
                PropertyInfo[] pi = type.GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    if (!TDObject.MapControl.GlobalVariables.FieldName2Desps[TType].ContainsKey(p.Name))
                        continue;
                    string FDesp = TDObject.MapControl.GlobalVariables.FieldName2Desps[TType][p.Name];
                    if (!layerInfo.Keys.Contains<string>(FDesp))
                            continue;
                    string value = layerInfo[FDesp];

                    //if (canUpdateAttribute[type].Contains(p.Name))
                    if (canUpdateAttribute[type].Contains(p.Name))//
                    {
                        if (!p.PropertyType.IsGenericType)
                        {
                            //非泛型
                            p.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, p.PropertyType), null);
                        }
                        else
                        {
                            //泛型Nullable<>
                            Type genericTypeDefinition = p.PropertyType.GetGenericTypeDefinition();
                            if (genericTypeDefinition == typeof(Nullable<>))
                            {
                                p.SetValue(obj, string.IsNullOrEmpty(value) ? null : Convert.ChangeType(value, Nullable.GetUnderlyingType(p.PropertyType)), null);
                            }
                        }
                      //  p.SetValue(tobject, (object)layerInfo[p.Name]);
                    }
                }
                string json = "";
                 if (TType == "房屋")
                     json = JsonHelper.SerializeObject<房屋建筑>(obj as 房屋建筑, null);
                 else
                    json = JsonHelper.SerializeObject<企业范围>((企业范围)obj, null);
 
                
                //not finished by zhwsun on 2017-08-19
                //ErrMsg = TDObject.BLL.CommSetting.EM.Modify<T>(obj);
                if (TType == "企业范围")
                {
                    企业范围 obj1 = JsonHelper.DeserializeFormtJsonToObject<企业范围>(json);
                    企业范围 tobject = MainForm.EM.GetByPk<企业范围>("OBJECTID", obj1.OBJECTID);
                    EntityOperate.Copy<企业范围>(obj, tobject, "OBJECTID");

                    ret = MainForm.EM.Modify<企业范围>(tobject);
                }
                else if (TType=="城市规划")
                {
                    城市规划 obj2 = obj as 城市规划;
                    城市规划 tobject = MainForm.EM.GetByPk<城市规划>("OBJECTID", obj2.OBJECTID);
                    EntityOperate.Copy<城市规划>(obj2, tobject, "OBJECTID");

                    ret = MainForm.EM.Modify<城市规划>(obj2);
                }
                else
                {
                    detailUrl = MainForm.App_URI + "lyRemoteServ/UpdGisObj?TType=" + TType + "&json=" + json;

                    ret = AsyncHttp.CommFun.GetRemoteJson(detailUrl);
                }

                if (ret != "")
                    resultCode = 2;
                else
                    resultCode = 0;
                return resultCode;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                //这里一般是LayerInfo中没有字段，即本地数据库和服务器不同
                resultCode = -1;
                return resultCode;

            }      

        }
          


        public static T getLayerInfoFromDB<T>(string oBJECTID) where T : EntityObject
        {
            T tobject = TDObject.BLL.CommSetting.EM.GetByPk<T>("OBJECTID", oBJECTID);
            return tobject;
        }

    
    }

    
}
