using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QyTech.Core.BLL;
using QyTech.Core.Common;
using QyTech.Core;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;


namespace WTGeoWeb.Controllers
{
    public class QueryTotalController : Controller
    {
        //
        // GET: /QueryTotal/

        public ActionResult Index()
        {
            return View();
        }


        /// <summary>
        /// 获取所有土地信息
        /// </summary>
        /// <param name="QueryLayer">层名</param>
        /// <param name="Ids">层id</param>
        /// <returns></returns>
        //////public JsonResult QueryAllTotalResult(string QueryLayer, string Ids)
        //////{
        //////    QueryLayer = QueryLayer == null ? "" : QueryLayer;
        //////    Ids = Ids == null ? "" : Ids;

        //////    return QueryTotalResult(15, QueryLayer, Ids);
        //////}


        /// <summary>
        /// 获取现状信息
        /// </summary>
        /// <param name="QueryLayer">层名</param>
        /// <param name="Ids">层id</param>
        /// <returns></returns>
        //////public JsonResult QueryPresentTotalResult(string QueryLayer, string Ids)
        //////{

        //////    return QueryTotalResult(1, QueryLayer, Ids);
        //////}

        ///// <summary>
        ///// 获取土地信息
        ///// </summary>
        ///// <param name="QueryType">查询内容：所有，现状/规划，批次/土地</param> 
        ///// <param name="QueryLayer">查询图层</param>
        ///// <param name="Ids">对应图层对象的id（可以多个）</param>
        ///// <returns></returns>
        //private JsonResult QueryTotalResult(int QueryType,string QueryLayer,string Ids)
        //{
        //    //List<tmpTotalItem> dbobjs = EntityManagerUsingT.GetAllByStorProcedure<tmpTotalItem>("[splyQueryTotalItem]", "'" + QueryType + "','" + QueryLayer + "','" + Ids + "'");
        //    List<tmpTotalItem> dbobjs = WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<tmpTotalItem>("[splyQueryTotalItem]", new object[]{QueryType.ToString() + ",'" + QueryLayer + "','" + Ids + "'"});


        //    List<tmpTotalItem> objs = new List<tmpTotalItem>();
        //    foreach (tmpTotalItem dbobj in dbobjs)
        //    {
        //        tmpTotalItem obj = EntityOperate.Copy<tmpTotalItem>(dbobj);
        //        objs.Add(obj);
        //    }

        //    JsonResult json = new JsonResult();
        //    json.Data = objs;
        //    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //    return json;
        //}


        /// <summary>
        /// 获取当前建筑的土地线状的建筑信息，假设建筑不会与其他分层相交，
        /// </summary>
        /// <param name="Ids">建筑编号列表</param>
        /// <returns></returns>
        //////public JsonResult QueryTotalItemIntersect(string Ids)
        //////{
        //////    //List<tmpTotalItem> dbobjs = EntityManagerUsingT.GetAllByStorProcedure<tmpTotalItem>("[splyQueryTotalItem]", "'" + QueryType + "','" + QueryLayer + "','" + Ids + "'");
        //////    List<tmpTotalItem> dbobjs = WTGeoWeb.BLL.CommSetting.EM.GetAllByStorProcedure<tmpTotalItem>("[splyQueryTotalItemIntersect]", new object[]{"'" + Ids + "'"});


        //////    List<tmpTotalItem> objs = new List<tmpTotalItem>();
        //////    foreach (tmpTotalItem dbobj in dbobjs)
        //////    {
        //////        tmpTotalItem obj = EntityOperate.Copy<tmpTotalItem>(dbobj);
        //////        objs.Add(obj);
        //////    }

        //////    JsonResult json = new JsonResult();
        //////    json.Data = objs;
        //////    json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
        //////    return json;
        //////}

    }
}
