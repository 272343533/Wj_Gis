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

namespace TDObject.UI
{
    public partial class frmTotalHY : QyTech.SkinForm.qyForm
    {
        public frmTotalHY()
        {
            InitializeComponent();
        }

         string CurrTotalType = "";

        string CurrHYName = "";


        private void treeView2_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = e.Node;
                CurrTotalType = tn.Text;

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

        private void FrmRegionTotal_Load(object sender, EventArgs e)
        {
            try
            {
                treeView1.Nodes.Clear();

                List<bsHYDL> hydl = MainForm.EM.GetListNoPaging<bsHYDL>("", "");
                foreach (bsHYDL item in hydl)
                {
                    treeView1.Nodes.Add(item.HYDL);
                }
                treeView1.Nodes[0].ExpandAll();

                CurrHYName = treeView1.Nodes[0].Text;
                CurrTotalType = treeView2.Nodes[0].Text;

                treeView1.SelectedNode = treeView1.Nodes[0];

                RefreshChart();
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = e.Node;
                CurrHYName = tn.Text;
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
            try
            {
              
                //更改图形数据
                chart1.Series[0].Points.Clear();
                List<bsTotalResult> ts = new List<bsTotalResult>();

                if (CurrTotalType == "投资类型分析")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业投资类型分析' and GLQName='" + CurrHYName + "'", "");
                }
                else if (CurrTotalType == "行业企业数量")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业管理区企业数量' and GLQName='" + CurrHYName + "'", "");

                }
                else if (CurrTotalType == "销售额统计")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业管理区销售额统计' and GLQName='" + CurrHYName + "'", "");
                }
                else if (CurrTotalType == "税收统计")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业管理区税收统计' and GLQName='" + CurrHYName + "'", "");
                }
                else if (CurrTotalType == "能耗统计")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业管理区能耗统计' and GLQName='" + CurrHYName + "'", "");
                }
                else if (CurrTotalType == "土地面积统计")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Column;
                    ts = MainForm.EM.GetListNoPaging<bsTotalResult>("TotalType='行业管理区土地面积统计' and GLQName='" + CurrHYName + "'", "");
                }
                double sum = 0;
                for (int i = 0; i < ts.Count; i++)
                {
                    bsTotalResult item = ts[i];
                    sum += item.TotalValue.Value;

                    chart1.Series[0].Points.AddXY(i + 1, item.TotalValue);
                    chart1.Series[0].Points[i].LegendText = item.TypeDesp;
                    if (CurrTotalType == "投资类型分析" ||CurrTotalType == "管理区企业数量")
                        chart1.Series[0].Points[i].Label = item.TotalValue.ToString()+"家";
                    else if (CurrTotalType == "土地面积统计")
                        chart1.Series[0].Points[i].Label = item.TotalValue.ToString()+"亩";
                    else
                        chart1.Series[0].Points[i].Label = item.TotalValue.ToString() + "万元";
                    chart1.Series[0].Points[i].LabelToolTip = item.TypeDesp;
                    chart1.Series[0].Points[i].AxisLabel = item.TypeDesp;
                    //chart1.Series[0].ax

                }
                if (CurrTotalType == "投资类型分析" || CurrTotalType == "管理区企业数量")
                    chart1.Titles[0].Text = CurrHYName + " " + CurrTotalType + "    (共" + sum.ToString() + "家)";
                else if (CurrTotalType == "土地面积统计")
                    chart1.Titles[0].Text = CurrHYName + " " + CurrTotalType + "    (共" + sum.ToString() + "亩)";
                else
                    chart1.Titles[0].Text = CurrHYName + " " + CurrTotalType + "    (共" + sum.ToString() + "万元)";
            
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

        private void chart1_MouseMove(object sender, MouseEventArgs e)
        {
            QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void radioButton2_Click(object sender, EventArgs e)
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
