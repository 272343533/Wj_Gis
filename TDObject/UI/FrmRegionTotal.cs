using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

using SunMvcExpress.Dao;
using QyTech.Core.BLL;
using QyTech.Auth.Dao;

namespace TDObject.UI
{
    public partial class FrmRegionTotal : QyTech.SkinForm.qyFormWithTitle
    {
        public FrmRegionTotal()
        {
            InitializeComponent();
        }

        string CurrGlqName ="运东";
        string CurrTotalType = "投资类型分析";

        string tName = "t企业基础数据";
        List<bsFunField> bsffs = new List<bsFunField>();

        DataTable dtYdLtds;
        DataTable dtRentLtds;


        Dictionary<string, string> dicFields = new Dictionary<string, string>();

        List<string> yms;
        private void FrmRegionTotal_Load(object sender, EventArgs e)
        {
           
            try
            {
                this.Title = "按管理区统计";

                //获取统计时间数据
                List<string> items = TDObject.DAOBLL.ImportTBll.GetYearMonths("t企业基础数据");
                cboYearMonth.DataSource = items;
                if (cboYearMonth.Items.Count > 0)
                    cboYearMonth.SelectedIndex = 0;

                cboYearMonth.Refresh();


                this.dgvT2_11.AutoGenerateColumns = false;
                this.dgvT2_12.AutoGenerateColumns = false;

                dgvT2_11.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                dgvT2_12.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                dgvT2_11.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_RowPostPaint);
                dgvT2_12.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_RowPostPaint);

                treeView1.ExpandAll();

                //首先获取最新年月
                yms = TDObject.DAOBLL.ImportTBll.GetYearMonths("t企业基础数据");
                if (yms.Count == 0)
                {
                    MessageBox.Show("请确保有企业基础数据！");
                }

                bsffs = MainForm.QyTech_EM.GetListNoPaging<bsFunField>("TName='" + tName + "'", "NoInList");
                foreach (bsFunField ff in bsffs)
                {
                    if ((bool)ff.VisibleInList.Value)
                    {
                        dicFields.Add(ff.FName, ff.FDesp);
                    }
                }

                CurrGlqName = treeView1.Nodes[0].Text;
                CurrTotalType = treeView2.Nodes[0].Text;
                treeView1.SelectedNode = treeView1.Nodes[0].Nodes[0];

                

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //刷新列表数据 
            try
            {
                TreeNode tn = e.Node;
                CurrGlqName = tn.Text;
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType;
                string strDm = tn.Tag.ToString();
                
               
                string where = "年度+'-'+月份='" + yms[0] + "' and 单位 in (select 纳税人名称 from bsLtdInfo where 租赁企业否=0 and charindex(所属管理区,'" + strDm + "')>0)";
                dtYdLtds=QyTech.SQLDA.SqlUtil.GetDbTable(MainForm.sqlConn, tName, where, "Id");

                //List<t企业基础数据> _ltdobjs = TDObject.BLL.CommSetting.EM.GetListNoPaging<t企业基础数据>(where, "");
                dgvT2_11.Columns.Clear();
                this.dgvT2_11.DataSource = dtYdLtds;
                TDObject.UI.UIDgvColumnsSetting.ReSetHeader(dgvT2_11, bsffs);

                where = "年度+'-'+月份='" + yms[0] + "' and 单位 in (select 纳税人名称 from bsLtdInfo where 租赁企业否=1 and charindex(所属管理区,'" + strDm + "')>0)";
                dtRentLtds = QyTech.SQLDA.SqlUtil.GetDbTable(MainForm.sqlConn, tName, where, "Id");
                //List<t企业基础数据> _ltdobjs1 = TDObject.BLL.CommSetting.EM.GetListNoPaging<t企业基础数据>(where, "");
                dgvT2_12.Columns.Clear();
                this.dgvT2_12.DataSource = dtRentLtds;
                TDObject.UI.UIDgvColumnsSetting.ReSetHeader(dgvT2_12, bsffs);

                foreach (TreeNode subtn in (sender as TreeView).Nodes)
                {
                    if (subtn.Text == tn.Text)
                        subtn.ForeColor = Color.Red;
                    else
                        subtn.ForeColor = Color.Black;
                }

                RefreshChart();
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshChart()
        {
            string Ym = this.cboYearMonth.Text;
            if (Ym == "")
            {
                MessageBox.Show("请选择月份！"); ;
                return;
            }
            string YearMonth = "YearMonth='" + Ym + "' and ";

            //更改图形数据
            List<bsTotalResult> ts = new List<bsTotalResult>();
            chart1.Series[0].ChartType = SeriesChartType.Column;

            string[] spParams = new string[3];
            spParams[0] =  Ym.ToString() ;
            if ("投资类型分析,行业企业数量".Contains(CurrTotalType))
            {
                spParams[1] = "管理区" + CurrTotalType;
            }
            else
            {
                spParams[1] = "管理区行业" + CurrTotalType;
            }
            spParams[2] =  CurrGlqName  ;
            ts = MainForm.EM.GetAllByStorProcedure<bsTotalResult>("splyTotalWjReportOnTime", spParams);

            #region 固定计算好，直接获取
            //string sqlWhere = "";
            // if (CurrTotalType == "投资类型分析")
            // {
            //     sqlWhere = "YearMonth='" + Ym.Substring(0, 4) + "' and " + "TotalType='管理区" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'";
            // }
            // else if (CurrTotalType == "行业企业数量")
            // {
            //     sqlWhere = YearMonth + "TotalType = '管理区" + CurrTotalType + "' and GLQName = '" + CurrGlqName + "'";
            // }
            // else if (CurrTotalType == "销售额统计")
            // {
            //     sqlWhere = YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'";
            // }
            // else if (CurrTotalType == "税收统计")
            // {
            //     sqlWhere = YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'";
            // }
            // else if (CurrTotalType == "土地面积统计")
            // {
            //     sqlWhere = YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'";
            //}
            // else if (CurrTotalType == "能耗统计")
            // {
            //     sqlWhere = YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'";

            // }
            // ts = MainForm.EM.GetListNoPaging<bsTotalResult>(sqlWhere, "");
            #endregion

            double sum = 0;
            chart1.Series[0].Points.Clear();
            for (int i = 0; i < ts.Count; i++)
            {
                bsTotalResult item = ts[i];
                sum += item.TotalValue==null?0:item.TotalValue.Value;
                chart1.Series[0].Points.AddXY(i + 1, item.TotalValue);
                chart1.Series[0].Points[i].LegendText = item.TypeDesp;

                if (CurrTotalType == "投资类型分析" || CurrTotalType == "行业企业数量")
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "家";
                else if (CurrTotalType == "土地面积统计")
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "亩";
                else if (CurrTotalType== "能耗统计")
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString()+ "千瓦时";
                else
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "万元";

                chart1.Series[0].Points[i].LabelToolTip = item.TypeDesp;
                chart1.Series[0].Points[i].AxisLabel = item.TypeDesp;//.Substring(0,2);
                //chart1.Series[0].ax

            }
            if (CurrTotalType == "投资类型分析" || CurrTotalType == "行业企业数量")
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString() + "家)";
            else if (CurrTotalType == "土地面积统计")
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString() + "亩）";
            else if (CurrTotalType == "能耗统计")
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString() + "千瓦时）";
            else
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString() + "万元)";

            chart1.Show();
         }
        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = e.Node;
                foreach (TreeNode subtn in treeView2.Nodes)
                {

                    subtn.ForeColor = Color.Black;

                }
                (sender as TreeView).SelectedNode.ForeColor = Color.Red;


                CurrTotalType = tn.Text;

                if (CurrTotalType=="投资类型分析")
                    chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
                else
                    chart1.ChartAreas[0].AxisX.Enabled = AxisEnabled.False;
      

                RefreshChart();
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void FrmRegionTotal_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = sender as RadioButton;
                if (rb.Text == "柱状图")
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                else if (rb.Text == "饼图")
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                else if (rb.Text == "折线图")
                    chart1.Series[0].ChartType = SeriesChartType.Line;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void chkYd_CheckedChanged(object sender, EventArgs e)
        {
            if (chkYd.Checked || chkRent.Checked)
            {
                btnExport.Enabled = true;
            }
            else
                btnExport.Enabled = false;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            btnExport.Text = "正在导出...";
            btnExport.Enabled = false;
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xls";

                QyTech.ExcelOper.QyExcelHelper excl = new QyTech.ExcelOper.QyExcelHelper("local");

                if (chkYd.Checked)
                {
                    if (dtYdLtds.Rows.Count > 0)
                    {
                        sfd.Title = "请选择用地企业文件名称";
                        if (DialogResult.OK == sfd.ShowDialog())
                        {
                            string modelName = sfd.FileName;
                            string saveToPath = excl.ExportDataTableToExcl(dtYdLtds, modelName, dicFields);
                            MessageBox.Show("用地企业文件导出完毕！", "提示", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有用地企业数据！", "提示", MessageBoxButtons.OK);
                    }

                }
                if (chkRent.Checked)
                {
                    if (dtRentLtds.Rows.Count > 0)
                    {
                        sfd.Title = "请选择租赁企业文件名称";
                        if (DialogResult.OK == sfd.ShowDialog())
                        {
                            string modelName = sfd.FileName;
                            string saveToPath = excl.ExportDataTableToExcl(dtRentLtds, modelName, dicFields);
                            MessageBox.Show("租赁企业文件导出完毕！", "提示", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("没有租赁企业数据！", "提示", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                btnExport.Text = "导出";
                btnExport.Enabled = true;
            }
        }
    }
}
