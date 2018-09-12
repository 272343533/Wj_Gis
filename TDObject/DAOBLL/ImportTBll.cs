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
            string strSql = "select * from [" + tname + "] where " + where;//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
            SqlDataAdapter da = new SqlDataAdapter(Cmd);//建立数据适配器
            ds.Tables.Clear();
            da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                        //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
            return ds.Tables[0];
        }
    }
}
