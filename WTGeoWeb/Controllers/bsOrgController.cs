using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WTGeoWeb.Controllers
{
    public class ZTreeNode
    {
        public bool Checked { get; set; }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PId { get; set; }
        public bool open { get; set; }
        public string Url { get; set; }
        public string target { get; set; }
        public string rel { get; set; }
        public bool noAddBtn { get; set; }
        public bool noEditBtn { get; set; }
        public bool noRemoveBtn { get; set; }

    }

    public class bsOrgController : Controller
    {
        //
        // GET: /bsOrg/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetTree()
        {
            string[] laynames=new string[6]{"镇界","村界","工业管理区","自由分区","土地规划","土地现状"};
    

            List<ZTreeNode> treenodes = new List<ZTreeNode>();

            ZTreeNode pnode = new ZTreeNode();
            pnode.Id = Guid.NewGuid();
            pnode.Name = "图层信息";
            pnode.rel = "-1";

            treenodes.Add(pnode);

            for (int i = 0; i < laynames.Length; i++)
            {
                ZTreeNode node = new ZTreeNode();
                node.Id = Guid.NewGuid();
                node.Name = laynames[i];
                node.PId = pnode.Id;
                node.rel = (i + 1).ToString();

                treenodes.Add(node);

            }

            JsonResult json = new JsonResult();
            json.Data = treenodes;
            json.JsonRequestBehavior = JsonRequestBehavior.AllowGet;




            return json;
        }
    }
}
