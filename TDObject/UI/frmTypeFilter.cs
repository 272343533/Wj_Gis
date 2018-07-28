using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using SunMvcExpress.Dao;
using log4net;


using TDObject.MapControl;

using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;


namespace TDObject.UI
{
    public partial class frmTypeFilter : FlatForm
    {
       
        List<IFeature> pGeos = new List<IFeature>();//用于高亮
        IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
        List<IGeometry> Geos = new List<IGeometry>();

        TDObject.BLL.UIBLL.bllTypeFilter blluifiler = new TDObject.BLL.UIBLL.bllTypeFilter(GlobalVariables.axMapControl);
        int typeindex = 1;

        int CurrPageFlag = 1;

        QyTech.ExcelExport.QyExcelHelper excl = new QyTech.ExcelExport.QyExcelHelper("local");
                       
        public frmTypeFilter()
        {
            InitializeComponent();
        }

        private void frmTypeFilter_Load(object sender, EventArgs e)
        {
            try
            {
                tabControl1.ItemSize = new Size(0, 1);
                tabControl2.ItemSize = new Size(0, 1);

                //设置默认风格
                dgv1.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv2.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv31.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv32.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv33.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv4.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv5.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv6.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv7.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv8.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv9.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;

                //初始化列数据属性字段
                RefreshDgvColumnPropertyValue(dgv1);
                RefreshDgvColumnPropertyValue(dgv2);
                RefreshDgvColumnPropertyValue(dgv31);
                RefreshDgvColumnPropertyValue(dgv32);
                RefreshDgvColumnPropertyValue(dgv33);
                RefreshDgvColumnPropertyValue(dgv4);
                RefreshDgvColumnPropertyValue(dgv5);
                RefreshDgvColumnPropertyValue(dgv6);
                RefreshDgvColumnPropertyValue(dgv7);
                RefreshDgvColumnPropertyValue(dgv8);
                RefreshDgvColumnPropertyValue(dgv9);
                foreach (TabPage tp in tabControl1.TabPages)
                {
                    tp.Text = "";
                }
                dgv1.Dock = DockStyle.Fill;
                dgv2.Dock = DockStyle.Fill;
                dgv31.Dock = DockStyle.Fill;
                dgv32.Dock = DockStyle.Fill;
                dgv33.Dock = DockStyle.Fill;
                dgv4.Dock = DockStyle.Fill;
                dgv5.Dock = DockStyle.Fill;
                dgv6.Dock = DockStyle.Fill;
                dgv7.Dock = DockStyle.Fill;
                dgv8.Dock = DockStyle.Fill;
                dgv9.Dock = DockStyle.Fill;


                dgv1.Columns.RemoveAt(0);
                dgv2.Columns.RemoveAt(0);
                dgv31.Columns.RemoveAt(0);
                dgv32.Columns.RemoveAt(0);
                dgv33.Columns.RemoveAt(0);
                dgv4.Columns.RemoveAt(0);
                dgv5.Columns.RemoveAt(0);
                dgv6.Columns.RemoveAt(0);
                dgv7.Columns.RemoveAt(0);
                dgv8.Columns.RemoveAt(0);
                dgv9.Columns.RemoveAt(0);

                dgv1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv31.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv32.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv33.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv5.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv6.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv7.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv8.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgv9.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                excl.eventNumChanged += new QyTech.ExcelExport.DelegateForExportNo(RefreshPgb);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void RefreshPgb(int val, int maxvalue)
        {
            if (val == 1)
            {
                this.progressBar1.Visible = true;
                this.progressBar1.Maximum = maxvalue;
            }
            else if (val == maxvalue)
                this.progressBar1.Visible = false;
            else
                this.progressBar1.Value = val;
        }
        private void RefreshDgvColumnPropertyValue(DataGridView dgv)
        {
            try
            {
                foreach (DataGridViewColumn dgvc in dgv.Columns)
                {
                    if (dgvc.DataPropertyName == null || dgvc.DataPropertyName == "")
                    {
                        dgvc.DataPropertyName = dgvc.HeaderText;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void rb1_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = sender as RadioButton;
                typeindex = Convert.ToInt16(rb.Name.Substring(2, 1));

                tabControl2.SelectedIndex = typeindex - 1;

                if (typeindex <= 2)
                {
                    tabControl1.SelectedIndex = typeindex - 1;
                    CurrPageFlag = typeindex;
                }
                else if (typeindex == 3)
                {
                    tabControl1.SelectedIndex = 2;
                    rb31.Checked = true;
                    CurrPageFlag = typeindex;
                }
                else if (typeindex <= 9)
                {
                    tabControl1.SelectedIndex = typeindex + 1;
                    CurrPageFlag = typeindex;
                }
                //else if (refreshflag > 130)
                //    tabControl1.SelectedIndex = refreshflag - 130 + 1;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageWhereOrderby(int refreshflag, ref string sqlwhere, ref string sqlOrderby)
        {
            try
            {
                sqlwhere = "";
                sqlOrderby = "序号";

                if (refreshflag == 1)
                {
                    sqlOrderby = "序号";
                    if (!chk1_0.Checked)
                    {
                        if (chk1_1.Checked)
                        {
                            sqlwhere += " or 累计销售额合计>=2000";
                        }
                        if (chk1_2.Checked)
                        {
                            sqlwhere += " or 累计销售额合计>=3000";
                        }
                        if (chk1_3.Checked)
                        {
                            sqlwhere += " or 累计销售额合计>=5000";
                        }
                        if (chk1_4.Checked)
                        {
                            sqlwhere += " or 累计销售额合计>=100000";
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 2)
                {
                    sqlOrderby = "序号";
                    if (!chk2_0.Checked)
                    {
                        if (chk2_1.Checked)
                        {
                            sqlwhere += " or 标准化级别='" + chk2_1.Text + "'";
                        }
                        if (chk2_2.Checked)
                        {
                            sqlwhere += " or  标准化级别='" + chk2_2.Text + "'";
                        }
                        if (chk2_3.Checked)
                        {
                            sqlwhere += " or  标准化级别='" + chk2_3.Text + "'";
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 131 || refreshflag == 3)
                {
                    sqlOrderby = "序号";
                    sqlwhere = "@@@@";
                    //if (cbo31_1.Text != "全部")
                    //{
                    //    sqlwhere += " or 年度=" + cbo31_1.Text;
                    //}
                }
                else if (refreshflag == 132)
                {
                    sqlOrderby = "序号";
                    sqlwhere = "@@@@";
                    //if (cbo32_1.Text != "全部")
                    //{
                    //    sqlwhere += " or 年度=" + cbo32_1.Text;
                    //}
                }
                else if (refreshflag == 133)
                {
                    sqlOrderby = "序号";
                    sqlwhere = "@@@@";
                    //if (cbo33_1.Text != "全部")
                    //{
                    //    sqlwhere += " or 年度=" + cbo33_1.Text;
                    //}
                }
                else if (refreshflag == 4)
                {
                    if (!chk4_0.Checked)
                    {
                        if (chk4_1.Checked)
                        {
                            sqlwhere += " or 年度=" + chk4_1.Text.Substring(0, 4);
                        }
                        if (chk4_2.Checked)
                        {
                            sqlwhere += " or 年度=" + chk4_2.Text.Substring(0, 4);
                        }
                        if (chk4_3.Checked)
                        {
                            sqlwhere += " or 年度=" + chk4_3.Text.Substring(0, 4);
                        }
                        if (chk4_4.Checked)
                        {
                            sqlwhere += " or 年度=" + chk4_4.Text.Substring(0, 4);
                        }
                        if (chk4_5.Checked)
                        {
                            sqlwhere += " or 年度=" + chk4_5.Text.Substring(0, 4);
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 5)
                {
                    if (!chk5_0.Checked)
                    {
                        if (chk5_1.Checked)
                        {
                            sqlwhere += " or 所属环节='" + chk5_1.Text + "'";
                        }
                        if (chk5_2.Checked)
                        {
                            sqlwhere += " or 所属环节='" + chk5_2.Text + "'";
                        }
                        if (chk5_3.Checked)
                        {
                            sqlwhere += " or 所属环节='" + chk5_3.Text + "'";
                        }
                        if (chk5_4.Checked)
                        {
                            sqlwhere += " or 所属环节='" + chk5_4.Text + "'";
                        }
                        if (chk5_5.Checked)
                        {
                            sqlwhere += " or 所属环节='" + chk5_5.Text + "'";
                        }
                    }
                    else
                        sqlwhere = " or 类型='示范企业'"; 
                }
                else if (refreshflag == 6)
                {
                    if (!chk6_0.Checked)
                    {
                        if (chk6_1.Checked)
                        {
                            sqlwhere += " or SUBSTRING(目标,2,len(目标)-3)>='" + chk6_1.Text.Substring(1,chk6_1.Text.Length-3) + "'";
                        }
                        if (chk6_2.Checked)
                        {
                            sqlwhere += " or SUBSTRING(目标,2,len(目标)-3)>='" + chk6_2.Text.Substring(1, chk6_2.Text.Length - 3) + "'";
                        }
                        if (chk6_3.Checked)
                        {
                            sqlwhere += " or SUBSTRING(目标,2,len(目标)-3)>='" + chk6_3.Text.Substring(1, chk6_3.Text.Length -3) + "'";
                        }
                        if (chk6_4.Checked)
                        {
                            sqlwhere += " or SUBSTRING(目标,2,len(目标)-3)>='" + chk6_4.Text.Substring(1, chk6_4.Text.Length - 3) + "'";
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 7)
                {
                    if (!chk7_0.Checked)
                    {
                        if (chk7_1.Checked)
                        {
                            sqlwhere += " or 获评年份=" + chk7_1.Text.Substring(0, 4);
                        }
                        if (chk7_2.Checked)
                        {
                            sqlwhere += " or 获评年份=" + chk7_2.Text.Substring(0, 4);
                        }
                        if (chk7_3.Checked)
                        {
                            sqlwhere += " or 获评年份=" + chk7_3.Text.Substring(0, 4);
                        }
                        if (chk7_4.Checked)
                        {
                            sqlwhere += " or 获评年份=" + chk7_4.Text.Substring(0, 4);
                        }
                        if (chk7_5.Checked)
                        {
                            sqlwhere += " or 获评年份=" + chk7_5.Text.Substring(0, 4);
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 8)
                {
                    if (!chk8_0.Checked)
                    {
                        if (chk8_1.Checked)
                        {
                            sqlwhere += " or 土地面积>=" + chk8_1.Text.Substring(0, 2);
                        }
                        if (chk8_2.Checked)
                        {
                            sqlwhere += " or 土地面积>=" + chk8_2.Text.Substring(0, 2);
                        }
                        if (chk8_3.Checked)
                        {
                            sqlwhere += " or 土地面积>=" + chk8_3.Text.Substring(0, 2);
                        }
                        if (chk8_4.Checked)
                        {
                            sqlwhere += " or 土地面积>=" + chk8_4.Text.Substring(0, 3);
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
                else if (refreshflag == 9)
                {
                    sqlOrderby = " Convert(int,序号)";
                    if (!chk9_0.Checked)
                    {
                        if (chk9_1.Checked)
                        {
                            sqlwhere += " or 级别='" + chk9_1.Text + "'";
                        }
                        if (chk9_2.Checked)
                        {
                            sqlwhere += " or 级别='" + chk9_2.Text + "'";
                        }
                        if (chk9_3.Checked)
                        {
                            sqlwhere += " or 级别='" + chk9_3.Text + "'";
                        }
                    }
                    else
                        sqlwhere = "@@@@";
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData(DataGridView dgv, int refreshflag)
        {

            try
            {
                string sqlwhere = "";
                string sqlOrderby = "";
                ManageWhereOrderby(refreshflag, ref sqlwhere, ref sqlOrderby);

                if (sqlwhere== "@@@@")
                    sqlwhere = "";
                else if (sqlwhere.Length > 0)
                    sqlwhere = sqlwhere.Substring(4);
                else //if (refreshflag < 130) 没有任何选择，原来没有全部，所以要是否是131，132，133
                {
                    dgv.DataSource = null;
                    return;
                }
                if (refreshflag == 1)
                {
                    List<t开发区2000万企业> objs = MainForm.EM.GetListNoPaging<t开发区2000万企业>(sqlwhere, sqlOrderby);

                    this.dgv1.AutoGenerateColumns = false;
                    this.dgv1.DataSource = objs;

                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 2)
                {
                    List<t标准化级别> objs = MainForm.EM.GetListNoPaging<t标准化级别>(sqlwhere, sqlOrderby);

                    this.dgv2.AutoGenerateColumns = false;
                    this.dgv2.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 131 || refreshflag == 3)
                {
                    List<t同里镇开发区上市企业台帐台资> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐台资>(sqlwhere, sqlOrderby);

                    this.dgv31.AutoGenerateColumns = false;
                    this.dgv31.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 132)
                {
                    List<t同里镇开发区上市企业台帐三板> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐三板>(sqlwhere, sqlOrderby);

                    this.dgv32.AutoGenerateColumns = false;
                    this.dgv32.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 133)
                {
                    List<t同里镇开发区上市企业台帐主版后备> objs = MainForm.EM.GetListNoPaging<t同里镇开发区上市企业台帐主版后备>(sqlwhere, sqlOrderby);

                    this.dgv33.AutoGenerateColumns = false;
                    this.dgv33.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 4)
                {
                    List<t清洁生产历年> objs = MainForm.EM.GetListNoPaging<t清洁生产历年>(sqlwhere, sqlOrderby);

                    this.dgv4.AutoGenerateColumns = false;
                    this.dgv4.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 5)
                {
                    List<t吴江区智能制造示范试点企业名单> objs = MainForm.EM.GetListNoPaging<t吴江区智能制造示范试点企业名单>(sqlwhere, sqlOrderby);

                    this.dgv5.AutoGenerateColumns = false;
                    this.dgv5.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 6)
                {
                    List<t新地标计划企业名单> objs = MainForm.EM.GetListNoPaging<t新地标计划企业名单>(sqlwhere, sqlOrderby);

                    this.dgv6.AutoGenerateColumns = false;
                    this.dgv6.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 7)
                {
                    List<t智能车间> objs = MainForm.EM.GetListNoPaging<t智能车间>(sqlwhere, sqlOrderby);

                    this.dgv7.AutoGenerateColumns = false;
                    this.dgv7.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 8)
                {
                    List<t闲置土地盘活计划表> objs = MainForm.EM.GetListNoPaging<t闲置土地盘活计划表>(sqlwhere, sqlOrderby);

                    this.dgv8.AutoGenerateColumns = false;
                    this.dgv8.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
                else if (refreshflag == 9)
                {
                    List<t企业技术中心台账> objs = MainForm.EM.GetListNoPaging<t企业技术中心台账>(sqlwhere, sqlOrderby);

                    this.dgv9.AutoGenerateColumns = false;
                    this.dgv9.DataSource = objs;
                    this.label11.Text = "查询结果：记录共" + objs.Count.ToString() + "。";
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void rb7_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chk1_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv1,typeindex);
        }
        private void chk2_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv2, typeindex);
        }

        private void rb31_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void rb31_Click(object sender, EventArgs e)
        {
            try
            {
                RadioButton rb = sender as RadioButton;
                int itypeindex = Convert.ToInt16(rb.Name.Substring(3));

                tabControl1.SelectedIndex = itypeindex + 1;
                typeindex = itypeindex + 130;
                CurrPageFlag = typeindex;
                RefreshData(dgv31, typeindex);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void chk4_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv4, typeindex);

        }

        private void chk5_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv5, typeindex);
        }

        private void chk6_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv6, typeindex);
        }

        private void chk7_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv7, typeindex);
        }

        private void chk8_1_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv8, typeindex);
        }

        private void checkBox28_CheckedChanged(object sender, EventArgs e)
        {
            RefreshData(dgv9, typeindex);
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            int rcount = 0;
            try
            {
                bool findflag = false;
                string dkbhs = "";
                ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                      
                if (CurrPageFlag == 1)
                {
                    List<t开发区2000万企业> uis = dgv1.DataSource as List<t开发区2000万企业>;
                    foreach (t开发区2000万企业 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);
                }
                else if (CurrPageFlag == 2)
                {
                    List<t标准化级别> uis = dgv2.DataSource as List<t标准化级别>;
                    foreach (t标准化级别 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                {
                    List<t同里镇开发区上市企业台帐台资> uis = dgv31.DataSource as List<t同里镇开发区上市企业台帐台资>;
                    foreach (t同里镇开发区上市企业台帐台资 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 132)
                {
                    List<t同里镇开发区上市企业台帐三板> uis = dgv32.DataSource as List<t同里镇开发区上市企业台帐三板>;
                    foreach (t同里镇开发区上市企业台帐三板 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 133)
                {
                    List<t同里镇开发区上市企业台帐主版后备> uis = dgv33.DataSource as List<t同里镇开发区上市企业台帐主版后备>;
                    foreach (t同里镇开发区上市企业台帐主版后备 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 4)
                {
                    List<t清洁生产历年> uis = dgv4.DataSource as List<t清洁生产历年>;
                    foreach (t清洁生产历年 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 5)
                {
                    List<t吴江区智能制造示范试点企业名单> uis = dgv5.DataSource as List<t吴江区智能制造示范试点企业名单>;
                    foreach (t吴江区智能制造示范试点企业名单 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);
                }
                else if (CurrPageFlag == 6)
                {
                    List<t新地标计划企业名单> uis = dgv6.DataSource as List<t新地标计划企业名单>;
                    foreach (t新地标计划企业名单 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 7)
                {
                    List<t智能车间> uis = dgv7.DataSource as List<t智能车间>;
                    foreach (t智能车间 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);
                }
                else if (CurrPageFlag == 8)
                {
                    List<t闲置土地盘活计划表> uis = dgv8.DataSource as List<t闲置土地盘活计划表>;
                    foreach (t闲置土地盘活计划表 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);

                }
                else if (CurrPageFlag == 9)
                {
                    List<t企业技术中心台账> uis = dgv9.DataSource as List<t企业技术中心台账>;
                    foreach (t企业技术中心台账 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            dkbhs += "," + obj.地块编号;
                        }
                    }
                    pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);
                }

                if (Geos.Count==0)
                    MessageBox.Show("请先查询企业，目前没有企业定位或企业数据不全！");
                else
                {
                    LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
               }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
           try
            {
              
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter="Excel Files|*.xls";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    string filename = sfd.FileName;
                    if (CurrPageFlag == 1)
                    {
                        List<t开发区2000万企业> uis = dgv1.DataSource as List<t开发区2000万企业>;
                        string items = "序号,纳税人名称,年度,累计销售额合计,上年同期,增减率,税收,税收上年同期,税收增减率,地块编号";
                        string saveToPath = excl.ExportListToExcl<t开发区2000万企业>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 2)
                    {
                        List<t标准化级别> uis = dgv2.DataSource as List<t标准化级别>;
                        string items = "序号,企业名称,年份,是否公告,标准化级别,地块编号";
                        string saveToPath = excl.ExportListToExcl<t标准化级别>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                    {
                        List<t同里镇开发区上市企业台帐台资> uis = dgv31.DataSource as List<t同里镇开发区上市企业台帐台资>;

                       string items = "序号,年度,企业名称,联系人,职务,联系电话,地块编号";
                        string saveToPath = excl.ExportListToExcl<t同里镇开发区上市企业台帐台资>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 132)
                    {
                        List<t同里镇开发区上市企业台帐三板> uis = dgv32.DataSource as List<t同里镇开发区上市企业台帐三板>;

                        string items = "序号,年度,企业名称,统一社会信用代码,股票名称,挂牌代码,董事长,签约券商,挂牌时间,备注,地块编号";
                        string saveToPath = excl.ExportListToExcl<t同里镇开发区上市企业台帐三板>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 133)
                    {
                        List<t同里镇开发区上市企业台帐主版后备> uis = dgv33.DataSource as List<t同里镇开发区上市企业台帐主版后备>;

                        string items = "序号,年度,企业名称,董事长,电话,董秘,董秘电话,签约时间,签约券商,年底进度,进入程序,完成股改,进入辅导,报证监会,三板挂牌,成功上市,地块编号";
                        string saveToPath = excl.ExportListToExcl<t同里镇开发区上市企业台帐主版后备>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 4)
                    {
                        List<t清洁生产历年> uis = dgv4.DataSource as List<t清洁生产历年>;

                        string items = "序号,企业名称,备注";
                        string saveToPath = excl.ExportListToExcl<t清洁生产历年>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 5)
                    {
                        List<t吴江区智能制造示范试点企业名单> uis = dgv5.DataSource as List<t吴江区智能制造示范试点企业名单>;

                        string items = "序号,企业名称,所属环节,区镇,类型,地块编号";
                        string saveToPath = excl.ExportListToExcl<t吴江区智能制造示范试点企业名单>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 6)
                    {
                        List<t新地标计划企业名单> uis = dgv6.DataSource as List<t新地标计划企业名单>;

                        string items = "序号,年度,单位,区域,行业,细分,销售,目标,地块编号";
                        string saveToPath = excl.ExportListToExcl<t新地标计划企业名单>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 7)
                    {
                        List<t智能车间> uis = dgv7.DataSource as List<t智能车间>;
                        
                        string items = "序号,企业名称,车间名称,获评年份,区镇,地块编号";
                        string saveToPath = excl.ExportListToExcl<t智能车间>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 8)
                    {
                        List<t闲置土地盘活计划表> uis = dgv8.DataSource as List<t闲置土地盘活计划表>;

                        string items = "序号,年度,企业名称,地块位置,土地面积,回购情况,地块编号";
                        string saveToPath = excl.ExportListToExcl<t闲置土地盘活计划表>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                    else if (CurrPageFlag == 9)
                    {
                        List<t企业技术中心台账> uis = dgv9.DataSource as List<t企业技术中心台账>;

                        string items = "序号,企业名称,级别,获评时间,镇区,备注"; ;
                        string saveToPath = excl.ExportListToExcl<t企业技术中心台账>(uis, filename, items);
                        MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStrip1_MouseMove(object sender, MouseEventArgs e)
        {
            FormSkin.MouseMoveForm(this.Handle);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (Geos.Count > 0)
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, this.Geos);
            else
                MessageBox.Show("请首先定位企业，然后高亮显示！");
        }

        private void dgv1_Click(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string DKBH="";
            try
            {
                DKBH = GetDkbhForCurrentRow(dgv);
                if (DKBH!="")
                    blluifiler.ExPostionOneLtdFeature(DKBH);
            }
            catch (Exception ex)
            {
            }
        }

        private void dgv1_DoubleClick(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string DKBH = "";
            try
            {
                DKBH=GetDkbhForCurrentRow(dgv);
                if (DKBH != "")
                    blluifiler.ExPositionAndDisply(DKBH);
            }
            catch (Exception ex)
            {
            }
        }

        private int GetDgvColumnIndex(DataGridView dgv, string DataPropertyName)
        {
            DataGridViewColumn dgvc;
            int cIndex = -1;
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgvc = dgv.Columns[i];
                if (dgvc.DataPropertyName == DataPropertyName)
                {
                    cIndex = i;
                    break;
                }
            }
            return cIndex;
        }
    private string GetDkbhForCurrentRow(DataGridView dgv)
        {
            string DKBH = "";
            if (dgv.CurrentCell != null)
            {
                if (dgv.CurrentCell.RowIndex >= 0)
                {
                    int dkghIndex = GetDgvColumnIndex(dgv, "地块编号");

                    if (dkghIndex == -1)
                    {
                        MessageBox.Show("没有找到地块编号列！，请联系管理员核实数据.");
                    }
                    else if (dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dkghIndex].Value != null)
                    {
                        DKBH = dgv.Rows[dgv.CurrentCell.RowIndex].Cells[dkghIndex].Value.ToString();

                    }
                }
            }
            return DKBH;
        }
    }
}
