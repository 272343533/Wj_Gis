using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

using System.Data;
using QyTech.Auth.Dao;


using QyTech.SkinForm.Controls;
using System.Windows.Forms;

using QyTech.ExcelOper;
namespace QyTech.SQLDA
{
    public class SqlUtil
    {
        public delegate void delegateProgressHandler(int value, int maxvalue);
        public static event delegateProgressHandler ProgressChangeddEvent;

        public static DataTable RefreshDbTable(DataGridView dgv,SqlConnection sqlconn,string tname,string wheresql,string order,out List<bsFunField> bffs)
        {
            if (ProgressChangeddEvent != null)
                ProgressChangeddEvent(1, 100);

            DataSet ds=new DataSet();
            string strSql = "select * from [" + tname + "] "+(wheresql==""?"":" where "+ wheresql)+(order==""?"":" order by "+order) ;//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
            if (ProgressChangeddEvent != null)
                ProgressChangeddEvent(5, 100);

            SqlDataAdapter da = new SqlDataAdapter(Cmd);//建立数据适配器
            da.Fill(ds,tname);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                              //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]

            if (ProgressChangeddEvent != null)
                ProgressChangeddEvent(15, 100);


            DataTable dt= ds.Tables[tname];

            dgv.DataSource = dt;

            if (ProgressChangeddEvent != null)
                ProgressChangeddEvent(25, 100);


            bffs = TDObject.MainForm.QyTech_EM.GetListNoPaging<bsFunField>("TName='" + tname + "'", "NoInList");
            dgv.Columns[0].Visible = false;
            for (int i = 1; i < bffs.Count; i++)
            {
                try
                {
                    dgv.Columns[i].Visible = bffs[i].VisibleInList == null ? true : (bool)bffs[i].VisibleInList;
                    dgv.Columns[i].HeaderText = bffs[i].FDesp;
                    dgv.Columns[i].Width = (int)bffs[i].FWidthInList;

                    if (ProgressChangeddEvent != null)
                    {   
                        ProgressChangeddEvent(25 + i>=100?99:25+i, 100);
                    }
                }
                catch { }
            }
            if (ProgressChangeddEvent != null)
                ProgressChangeddEvent(100, 100);
            return dt;


        }

        public static int ExceuteSql(SqlConnection sqlconn,string strSql)
        {
            try
            {
                sqlconn.Open();
                SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
                int ret = Cmd.ExecuteNonQuery();
                sqlconn.Close();
                return ret;
            }
            catch(Exception ex)
            {
                return -1;
            }
        }
    }
}
