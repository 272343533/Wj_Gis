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
    public partial class FrmRegionTotal : FlatForm
    {
        public FrmRegionTotal()
        {
            InitializeComponent();
        }

        string CurrGlqName ="运东";
        string CurrTotalType = "投资类型分析";

        private void FrmRegionTotal_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvT2_11.AutoGenerateColumns = false;
                this.dgvT2_12.AutoGenerateColumns = false;

                dgvT2_11.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgvT2_12.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgvT2_11.RowPostPaint += new DataGridViewRowPostPaintEventHandler(FormSkin.dgv_RowPostPaint);
                dgvT2_12.RowPostPaint += new DataGridViewRowPostPaintEventHandler(FormSkin.dgv_RowPostPaint);

                treeView1.ExpandAll();

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

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //刷新列表数据 
            try
            {
                TreeNode tn = e.Node;
                CurrGlqName = tn.Text;
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType;
                string strDm = tn.Tag.ToString();
                List<企业范围> _ltdobjs = TDObject.BLL.CommSetting.EM.GetListNoPaging<企业范围>("charindex(ssglqdm,'" + strDm + "')>0", "");
                this.dgvT2_11.DataSource = _ltdobjs;


                List<z租赁企业信息表> _ltdobjs1 = TDObject.BLL.CommSetting.EM.GetListNoPaging<z租赁企业信息表>("charindex(ssglqdm,'" + strDm + "')>0", "");
                this.dgvT2_12.DataSource = _ltdobjs1;

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
           
            //更改图形数据
           List<bsTotalResult> ts = new List<bsTotalResult>();
            chart1.Series[0].ChartType = SeriesChartType.Column;

            if (CurrTotalType == "投资类型分析")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='管理区"+CurrTotalType+"' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "行业企业数量")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='管理区" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");

            }
            else if (CurrTotalType == "销售额统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "税收统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
            }
            else if (CurrTotalType == "土地面积统计")
            {
                ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='管理区行业" + CurrTotalType + "' and GLQName='" + CurrGlqName + "'", "");
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
                else if (CurrTotalType== "土地面积统计")
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "亩";
                else
                    chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "万元";

                chart1.Series[0].Points[i].LabelToolTip = item.TypeDesp;
                chart1.Series[0].Points[i].AxisLabel = item.TypeDesp;
                //chart1.Series[0].ax

            }
            if (CurrTotalType == "投资类型分析" || CurrTotalType == "行业企业数量")
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString() + "家)";
            else if (CurrTotalType == "土地面积统计")
                chart1.Titles[0].Text = CurrGlqName + " " + CurrTotalType + "    (共" + sum.ToString()  + "亩";
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
                FormSkin.MouseMoveForm(this.Handle);
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
