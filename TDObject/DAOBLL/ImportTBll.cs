using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using SunMvcExpress.Dao;

namespace TDObject.DAOBLL
{
    public class ImportTBll
    {

        /// <summary>
        /// 获取对应表的年月过滤条件项列表
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static List<string> GetYearMonths(string tableName)
        {
            List<string> list=new List<string>();
            string where = "";
            if (tableName == "t企业基础数据")
            {
                where = "Id in (select min(b.Id) from t企业基础数据 as b where t企业基础数据.年度 + '-' + t企业基础数据.月份 = b.年度 + '-' + b.月份 )  ";
                List<t企业基础数据> ts = MainForm.EM.GetListNoPaging<t企业基础数据>(where, "convert(varchar(10),年度)+'-'+ 月份 desc");
                list.Clear();
                foreach (t企业基础数据 t in ts)
                {
                    list.Add(t.年度 + "-" + t.月份);
                }
            }
            else if (tableName == "t市局表格")
            {
                where = "Id in (select min(b.Id) from t市局表格 as b where t市局表格.ND + '-' + t市局表格.YF = b.ND + '-' + b.YF )  ";

                List<t市局表格> ts = MainForm.EM.GetListNoPaging<t市局表格>(where, "convert(varchar(10),ND)+'-'+ convert(varchar(10),YF) desc");
                list.Clear();
                foreach (t市局表格 t in ts)
                {
                    list.Add(t.ND + "-" + t.YF);
                }
            }
           

            return list;
        }

        public static List<string> GetYearMonths(SqlConnection sqlconn,string tableName)
        {

         

            List<string> list = new List<string>();
            string item = GetYearMonthField(tableName);
            //if (tableName == "t企业基础数据")
            //{
            //    item = "convert(varchar(10),年度)+'-'+ 月份";
               
            //}
            //else if (tableName == "t市局表格")
            //{
            //    item = "convert(varchar(10),ND)+'-'+ convert(varchar(10),YF)";
            //}
            //else if ("t安全事故情况,t标准化级别,t工业固定资产,t规上企业名单,t立案处罚情况,t吴江区智能制造示范试点企业名单".Contains(tableName))
            //{
            //    item = "年份";
            //}
            //else if ("t开发区2000万企业,t清洁生产历年,t同里镇开发区上市企业台帐三板,t同里镇开发区上市企业台帐台资,t同里镇开发区上市企业台帐主版后备,t闲置土地盘活计划表,t新地标计划企业名单".Contains(tableName))
            //{
            //    item = "Convert(varchar(10),年度)"; 
                
            //}
            //else if ("t经发局表格,,,,,".Contains(tableName))
            //{
            //    item = "Convert(varchar(10),ND)";

              
            //}
            //else if ("t智能车间,,,,,".Contains(tableName))
            //{
            //    item = "获评年份"; 
               
            //}
            //else if ("t企业技术中心台账,,,,,".Contains(tableName))
            //{
            //    item = "获评时间";
            //}
            string strSql = "select distinct "+ item + " as item from [" + tableName + "] order by "+item +" desc";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
            SqlDataAdapter da = new SqlDataAdapter(Cmd);//建立数据适配器
            DataSet ds=new DataSet();
            da.Fill(ds,"t");



            list.Clear();
            foreach (DataRow dr in ds.Tables["t"].Rows)
            {
                list.Add(dr[0].ToString());
            }
            return list;
        }
        private static string GetYearMonthField(string tableName)
        {
            string item = "";
            if (tableName == "t企业基础数据")
            {
                item = "convert(varchar(10),年度)+'-'+ 月份";

            }
            else if (tableName == "t市局表格")
            {
                item = "convert(varchar(10),ND)+'-'+ convert(varchar(10),YF)";
            }
            else if ("t安全事故情况,t标准化级别,t工业固定资产,t规上企业名单,t立案处罚情况,t吴江区智能制造示范试点企业名单".Contains(tableName))
            {
                item = "年份";
            }
            else if ("t开发区2000万企业,t清洁生产历年,t同里镇开发区上市企业台帐三板,t同里镇开发区上市企业台帐台资,t同里镇开发区上市企业台帐主版后备,t闲置土地盘活计划表,t新地标计划企业名单".Contains(tableName))
            {
                item = "Convert(varchar(10),年度)";

            }
            else if ("t经发局表格,,,,,".Contains(tableName))
            {
                item = "Convert(varchar(10),ND)";


            }
            else if ("t智能车间,,,,,".Contains(tableName))
            {
                item = "获评年份";

            }
            else if ("t企业技术中心台账,,,,,".Contains(tableName))
            {
                item = "获评时间";
            }
            return item;
        }
        /// <summary>
        /// 获取对应表的实际过滤where条件
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="ym"></param>
        /// <returns></returns>
        public static string WhereSql(string tableName,string ym)
        {
            string year = ym.Substring(0, 4); 
            int seppos = ym.IndexOf('-'); 
            string month = ym.Substring(seppos + 1, ym.Length - seppos - 1); 

            string where = "";
            if (tableName == "t企业基础数据")
            {
                where = "年度=" + year + " and 月份='" + month + "'";
            }
            else if (tableName == "t市局表格")
            {
                where = "ND=" + year + " and YF=" + month;
            }
            else
            {
                string item = GetYearMonthField(tableName);

                where ="Substring("+item+",1,4)='" + year+"'";
            }
            return where;
        }

        /// <summary>
        /// 按照DatatTable获取数据
        /// </summary>
        /// <param name="sqlconn"></param>
        /// <param name="tname"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        public static DataTable GetDataTable(SqlConnection sqlconn, string tname,string where)
        {
            DataSet ds = new DataSet();
            string strSql = "select * from [" + tname + "] "+(where==""?"":" where " + where);//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
            SqlDataAdapter da = new SqlDataAdapter(Cmd);//建立数据适配器
            ds.Tables.Clear();
            da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                        //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
            return ds.Tables[0];
        }
    }
}
