using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SunMvcExpress.Dao;


namespace TDObject.DAOBLL
{
    public class RoleRelBll
    {
        public static List<bsDynCondition> GetRightItem()
        {
            List<bsDynCondition> conds;
            if (MainForm.LoginUser.bsO_Id == Guid.Parse("C6D2FF6A-10AC-4A42-B228-2EB8584EFB98"))
                conds = MainForm.EM.GetListNoPaging<bsDynCondition>("RoleName is not null", "Id");
            else
                conds = MainForm.EM.GetListNoPaging<bsDynCondition>("RoleName ='所有' or RoleName='" + MainForm.LoginUser.bsO_Name + "'", "Id");

            return conds;
        }


        /// <summary>
        /// 针对ltdbase获取符合条件的记录
        /// </summary>
        /// <param name="cond"></param>
        /// <param name="itemtext"></param>
        /// <returns></returns>
        public static string GetItemCondition(bsDynCondition cond, string itemtext)
        {
            string Conditions = "";
            string itemname = cond.condName;

            string[] sqls = cond.Sql.Split(new char[] { '|' });
            int sqlindex = 0;
            if (cond.compType == "textbox")
            {
                Conditions += " and " + cond.Sql.Replace("@@@@", itemtext);
            }
            else if (cond.compType == "combox")
            {
                foreach (string c in cond.compitems.Split(new char[] { ',' }))
                {
                    if (c == itemtext)
                        break;
                    sqlindex++;
                }


                if (sqlindex + 1 > sqls.Length)
                    sqlindex = sqls.Length - 1;//没有对应的就用最后一个


                if ("技术中心获批级别" == itemname || itemtext == "全部")
                    Conditions += " and " + sqls[sqlindex];
                else if ("智能车间,清洁生产".Contains(itemname))
                    Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(0, 4));

                else if ("地标性企业".Contains(itemname))
                {
                    if (sqlindex == 1)
                        Conditions += " and " + sqls[sqlindex].Replace("@@@@", "1");
                    else
                        Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(1, itemtext.Length - 3));
                }
                else if ("营业额，税收，土地盘活计划".Contains(itemname))
                    Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(0, itemtext.Length - 3));

                else
                    Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext);


            }


            if (itemtext.Trim() == "")
                return "";



            //if ("地块编号,纳税人识别号,行业大类,经营范围,用地单位名称,租赁单位名称,红黄牌处罚情况,标准化等级,智能工厂,安全事故情况".Contains(itemname))
            //    Conditions += " and "+ sqls[sqlindex].Replace("@@@@",itemtext);



            //if ("上市情况" == itemname)
            //{ 
            //    if (itemtext == "全部")
            //    {
            //        Conditions += " and (DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";
            //        Conditions += " or DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";
            //        Conditions += " or DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";
            //        Conditions += ")";
            //    }
            //    if (itemtext== "台资拟上市")
            //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";

            //    if (itemtext == "三板挂牌")
            //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";

            //    if (itemtext == "主板后备")
            //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";
            //}

            return Conditions;
        }


        public static string Get企业范围WhereCondition(bsDynCondition dc,string item)
        {
            string Conditions = GetItemCondition(dc,item);

            if (Conditions.Length > 5)
            {
                Conditions = Conditions.Substring(4);
                Conditions = "YDQYMC in (select 纳税人名称 from bsLtdInfo where" + Conditions + ")";
            }

            return Conditions;
        }

    }
}
