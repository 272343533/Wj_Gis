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

namespace TDObject.UI
{
    public partial class FrmRegionTotal : QyTech.SkinForm.qyForm
    {
        public FrmRegionTotal()
        {
            InitializeComponent();
        }

        string CurrGlqName ="运东";
        string CurrTotalType = "投资类型分析";

        List<string> yms;
        private void FrmRegionTotal_Load(object sender, EventArgs e)
        {
            try
            {
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

                CurrGlqName = treeView1.Nodes[0].Text;
                CurrTotalType = treeView2.Nodes[0].Text;
                treeView1.SelectedNode = treeView1.Nodes[0];

                

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
                List<t企业基础数据> _ltdobjs = TDObject.BLL.CommSetting.EM.GetListNoPaging<t企业基础数据>(where, "");
                //dgvT2_11.Columns.Clear();
                //this.dgvT2_11.DataSource = _ltdobjs;
                TDObject.UI.UIDgvColumnsSetting.RefreshLtdImportInfo(dgvT2_11, _ltdobjs, "t企业基础数据", 0);

                where = "年度+'-'+月份='" + yms[0] + "' and 单位 in (select 纳税人名称 from bsLtdInfo where 租赁企业否=1 and charindex(所属管理区,'" + strDm + "')>0)";
                List<t企业基础数据> _ltdobjs1 = TDObject.BLL.CommSetting.EM.GetListNoPaging<t企业基础数据>(where, "");
                //dgvT2_12.Columns.Clear();
                //this.dgvT2_12.DataSource = _ltdobjs1;
                TDObject.UI.UIDgvColumnsSetting.RefreshLtdImportInfo(dgvT2_12, _ltdobjs1, "t企业基础数据", 0);

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

            if (CurrTotalType == "投资类型分析")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("YearMonth='" + Ym.Substring(0, 4) + "' and " + "TotalType='管理区" +CurrTotalType+"' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "行业企业数量")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>(YearMonth + "TotalType='管理区" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");

            }
            else if (CurrTotalType == "销售额统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>(YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "税收统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>(YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "土地面积统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>(YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "能耗统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>(YearMonth + "TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
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
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "千瓦时";
                else
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "万元";

                chart1.Series[0].Points[i].LabelToolTip = item.TypeDesp;
                chart1.Series[0].Points[i].AxisLabel = item.TypeDesp;
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
    }
}
