using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QyTech.Auth.Dao;
using System.Windows.Forms;

namespace TDObject.UI
{
    public class UIDgvColumnsSetting
    {
        public static void ReSetHeader(DataGridView dgv,string tName, bool ClearColumns = false, int FromColIndex=0)
        {
            dgv.AutoGenerateColumns = true;
            List<bsFunField> bffs = MainForm.QyTech_EM.GetListNoPaging<bsFunField>("TName='" + tName + "'", "NoInList");
            for (int i = 0; i < bffs.Count; i++)
            {
                try
                {
                    dgv.Columns[bffs[i].FName].Visible = bffs[i].VisibleInList == null ? true : (bool)bffs[i].VisibleInList;
                    dgv.Columns[bffs[i].FName].HeaderText = bffs[i].FDesp;
                    dgv.Columns[bffs[i].FName].Width = (int)bffs[i].FWidthInList;
                }
                catch(Exception ex) {
                    
                }
            }
        }
        public static void ReSetHeader(DataGridView dgv, List<bsFunField> bffs)
        {
            dgv.AutoGenerateColumns = true;
            if (bffs.Count > 0) { 
                string tName = bffs[0].TName;
                for (int i = 0; i < bffs.Count; i++)
                {
                    try
                    {
                        if ("t企业基础数据,vwLtdJcsj".Contains(tName))
                        {
                            if ("System,委领导,统计站,吴江经济技术开发区".Contains(MainForm.LoginUser.bsO_Name))
                            {
                                dgv.Columns[bffs[i].FName].Visible = (bool)bffs[i].VisibleInList;
                            }
                            else
                            {
                                dgv.Columns[bffs[i].FName].Visible = bffs[i].FNo < 210 ? true : false;
                            }
                        }
                        else
                            dgv.Columns[bffs[i].FName].Visible = bffs[i].VisibleInList == null ? true : (bool)bffs[i].VisibleInList;

                        dgv.Columns[bffs[i].FName].HeaderText = bffs[i].FDesp;
                        dgv.Columns[bffs[i].FName].Width = (int)bffs[i].FWidthInList;
                    }
                    catch (Exception ex)
                    {

                    }
                }
            }
        }

        /// <summary>
        /// 刷新企业基本信息的dgv列
        /// </summary>
        /// <param name="dgv">控件</param>
        /// <param name="datasource">数据源</param>
        /// <param name="ColmnFrom">数据源在dgv中开始的列</param>
        public static void RefreshLtdImportInfo(DataGridView dgv, object datasource,string tName, int ColmnFrom)
        {
            for (int i = dgv.ColumnCount - 1; i > 0; i--)
            {
                dgv.Columns.RemoveAt(i);
            }
            dgv.AutoGenerateColumns = true;

            dgv.DataSource = datasource;

            //对列宽以及显示方式进行调整
            List<QyTech.Auth.Dao.bsFunField> bffs = MainForm.QyTech_EM.GetListNoPaging<QyTech.Auth.Dao.bsFunField>("TName='"+ tName + "'", "NoInList");
            //dgvT2_11.Columns[1].Visible = false;
            for (int i = 0; i < bffs.Count; i++)
            {
                try
                {
                    if ("System,委领导,统计站,吴江经济技术开发区".Contains(MainForm.LoginUser.bsO_Name))
                    {
                        dgv.Columns[bffs[i].FName].Visible =Convert.ToBoolean(bffs[i].VisibleInList);
                    }
                    else
                    {
                        if(i==0)
                            dgv.Columns[bffs[i].FName].Visible = false;
                        else
                            dgv.Columns[bffs[i].FName].Visible = bffs[i].FNo<210 ? true :false;
                    }
                    dgv.Columns[bffs[i].FName].HeaderText = bffs[i].FDesp;
                    dgv.Columns[bffs[i].FName].Width = (int)bffs[i].FWidthInList;
                }
                catch(Exception ex) { Console.WriteLine(ex.Message); }
            }
        }

    }
}
