using System;
using System.Collections;
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
    public partial class frmTotalFilter : QyTech.SkinForm.qyForm
    {

        log4net.ILog log = log4net.LogManager.GetLogger("MainForm");
     

        public frmTotalFilter()
        {
            InitializeComponent();
        }

        //0不使用，从1开始，1-100 用于主page变化，131-130用于子page变化
        private bool[] RefreshedFlag = new bool[200];
        private int CurrPageFlag = 1;


        private int[] CurrId = new int[200];
        private object[] CurrObj = new object[200];

        private int[] RowIndex = new int[200];
        
        private void frmTotalFilter_Load(object sender, EventArgs e)
        {

            try
            {
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

                //
                cbo2_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo2_2.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo31_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo32_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo33_1.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo4_1.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo5_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo5_2.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo6_1.DropDownStyle = ComboBoxStyle.DropDownList;
                cbo6_2.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo7_1.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo8_1.DropDownStyle = ComboBoxStyle.DropDownList;

                cbo9_1.DropDownStyle = ComboBoxStyle.DropDownList;

                //初始化默认条件
                cbo1_1.SelectedIndex = 0;
                cbo1_2.SelectedIndex = 0;
                cbo1_3.SelectedIndex = 0;
                cbo1_4.SelectedIndex = 0;
                cbo1_5.SelectedIndex = 0;

                cbo2_1.SelectedIndex = 0;
                cbo2_2.SelectedIndex = 0;

                cbo31_1.SelectedIndex = 0;
                cbo32_1.SelectedIndex = 0;
                cbo33_1.SelectedIndex = 0;

                cbo4_1.SelectedIndex = 0;

                cbo5_1.SelectedIndex = 0;
                cbo5_2.SelectedIndex = 0;

                cbo6_1.SelectedIndex = 0;
                cbo6_2.SelectedIndex = 0;

                cbo7_1.SelectedIndex = 0;

                cbo8_1.SelectedIndex = 0;

                cbo9_1.SelectedIndex = 0;
                cbo9_2.SelectedIndex = 0;

                dgv1.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv2.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv31.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv32.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv33.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv4.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv5.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv6.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv7.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv8.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgv9.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                //取消第o列
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
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TabControl tc = (TabControl)sender;
                CurrPageFlag = tc.SelectedIndex + 1;
                if (RefreshedFlag[CurrPageFlag] == false)
                {
                    //设置刷新标志
                    RefreshedFlag[CurrPageFlag] = true;

                    if (CurrPageFlag == 3)
                    {
                        if (RefreshedFlag[131] == false)
                            CurrPageFlag = 131;
                    }

                    //开始刷新数据
                    RefreshData(CurrPageFlag);
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                TabControl tc = (TabControl)sender;
                CurrPageFlag = tc.SelectedIndex + 1 + 130;
                if (RefreshedFlag[CurrPageFlag] == false)
                {
                    //设置刷新标志
                    RefreshedFlag[CurrPageFlag] = true;
                    //开始刷新数据
                    RefreshData(CurrPageFlag);
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void ManageWhereOrderby(int refreshflag,ref string sqlwhere, ref string sqlOrderby)
        {
            try
            {
                sqlwhere = "";
                sqlOrderby = "序号";

                if (refreshflag == 1)
                {
                    sqlOrderby = "序号";
                    if (cbo1_1.Text != "全部")
                    {
                        sqlwhere += " and 年度=" + cbo1_1.Text;
                    }
                    if (cbo1_2.Text != "全部")
                    {
                        sqlwhere += " and 累计销售额合计" + cbo1_2.Text.Substring(0, cbo1_2.Text.Length - 1);
                    }
                    if (cbo1_3.Text != "全部")
                    {
                        sqlwhere += " and 增减率" + cbo1_3.Text.Substring(0, cbo1_3.Text.Length - 1);
                    }
                    if (cbo1_4.Text != "全部")
                    {
                        sqlwhere += " and 税收" + cbo1_4.Text.Substring(0, cbo1_4.Text.Length - 1);
                    }
                    if (cbo1_5.Text != "全部")
                    {
                        sqlwhere += " and 税收增减率" + cbo1_5.Text.Substring(0, cbo1_5.Text.Length - 1);
                    }
                }
                else if (refreshflag == 2)
                {
                    sqlOrderby = "序号";
                    if (cbo2_1.Text != "全部")
                    {
                        sqlwhere += " and 年份 like '%" + cbo2_1.Text + "%'";
                    }
                    if (cbo2_2.Text != "全部")
                    {
                        sqlwhere += " and 标准化级别='" + cbo2_2.Text+"'";
                    }
                }
                else if (refreshflag == 131 || refreshflag == 3)
                {
                    sqlOrderby = "序号";
                    if (cbo31_1.Text != "全部")
                    {
                        sqlwhere += " and 年度=" + cbo31_1.Text;
                    }
                }
                else if (refreshflag == 132)
                {
                    sqlOrderby = "序号";
                    if (cbo32_1.Text != "全部")
                    {
                        sqlwhere += " and 年度=" + cbo32_1.Text;
                    }
                }
                else if (refreshflag == 133)
                {
                    if (cbo33_1.Text != "全部")
                    {
                        sqlwhere += " and 年度=" + cbo33_1.Text;
                    }
                }
                else if (refreshflag == 4)
                {
                    if (cbo4_1.Text != "全部")
                    {
                        sqlwhere += " and 年度=" + cbo4_1.Text;
                    }
                }
                else if (refreshflag == 5)
                {
                    if (cbo5_1.Text != "全部")
                    {
                        sqlwhere += " and 类型='" + cbo5_1.Text + "'";
                    }
                    if (cbo5_2.Text != "全部")
                    {
                        sqlwhere += " and 所属环节='" + cbo5_2.Text + "'";
                    }
                }
                else if (refreshflag == 6)
                {
                    if (cbo6_1.Text != "全部")
                    {
                        sqlwhere += " and 行业='" + cbo6_1.Text + "'";
                    }
                    if (cbo6_2.Text != "全部")
                    {
                        sqlwhere += " and 目标='" + cbo6_2.Text + "'";
                    }
                }
                else if (refreshflag == 7)
                {
                    if (cbo7_1.Text != "全部")
                    {
                        sqlwhere += " and 获评年份='" + cbo7_1.Text + "'";
                    }
                }
                else if (refreshflag == 8)
                {
                    if (cbo8_1.Text != "全部")
                    {
                        sqlwhere += " and 土地面积>=" + cbo8_1.Text.Substring(0,cbo8_1.Text.Length-3);
                    }
                }
                else if (refreshflag == 9)
                {
                    sqlOrderby = " Convert(int,序号)";
                    if (cbo9_1.Text != "全部")
                    {
                        sqlwhere += " and 获评时间 like '%" + cbo9_1.Text + "%'";
                    }
                    if (cbo9_2.Text != "全部")
                    {
                        sqlwhere += " and 级别='" + cbo9_2.Text + "'";
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshData(int refreshflag)
        {
            try
            {
                string sqlwhere = "";
                string sqlOrderby = "";
                ManageWhereOrderby(refreshflag, ref sqlwhere, ref sqlOrderby);

                if (sqlwhere.Length > 0)
                    sqlwhere = sqlwhere.Substring(4);

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
                log.Error(ex.Message);
            }
        }

        private void RefreshDgvColumnPropertyValue(DataGridView dgv)
        {
            foreach (DataGridViewColumn dgvc in dgv.Columns)
            {
                if (dgvc.DataPropertyName==null || dgvc.DataPropertyName=="")
                {
                    dgvc.DataPropertyName=dgvc.HeaderText;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            RefreshData(CurrPageFlag);
        }

        private void btnPosDisp_Click(object sender, EventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv1_MouseMove(object sender, MouseEventArgs e)
        {
            QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void AddDefaultRecord(object sender, EventArgs e)
        {
            if (CurrPageFlag == 1)
            {
                t开发区2000万企业 obj = new t开发区2000万企业();
                obj.序号 = 0;
                MainForm.EM.Add<t开发区2000万企业>(obj);
            }
            else if (CurrPageFlag == 2)
            {
                t标准化级别 obj = new t标准化级别();
                obj.序号 = 0;
                MainForm.EM.Add<t标准化级别>(obj);
            }
            else if (CurrPageFlag == 3 || CurrPageFlag == 131)
            {
                t同里镇开发区上市企业台帐台资 obj = new t同里镇开发区上市企业台帐台资();
                obj.序号 = 0;
                MainForm.EM.Add<t同里镇开发区上市企业台帐台资>(obj);
            }
            else if (CurrPageFlag == 132)
            {
                t同里镇开发区上市企业台帐三板 obj = new t同里镇开发区上市企业台帐三板();
                obj.序号 = 0;
                MainForm.EM.Add<t同里镇开发区上市企业台帐三板>(obj);
            }
            else if (CurrPageFlag == 133)
            {
                t同里镇开发区上市企业台帐主版后备 obj = new t同里镇开发区上市企业台帐主版后备();
                obj.序号 =0;
                MainForm.EM.Add<t同里镇开发区上市企业台帐主版后备>(obj);
            }
            else if (CurrPageFlag == 4)
            {
                t清洁生产历年 obj = new t清洁生产历年();
                obj.序号 = 0;
                MainForm.EM.Add<t清洁生产历年>(obj);
            }
            else if (CurrPageFlag == 5)
            {
                t吴江区智能制造示范试点企业名单 obj = new t吴江区智能制造示范试点企业名单();
                obj.序号 = 0;
                MainForm.EM.Add<t吴江区智能制造示范试点企业名单>(obj);
            }
            else if (CurrPageFlag == 6)
            {
                t新地标计划企业名单 obj = new t新地标计划企业名单();
                obj.序号 = 0;
                MainForm.EM.Add<t新地标计划企业名单>(obj);
            }
            else if (CurrPageFlag == 7)
            {
                t智能车间 obj = new t智能车间();
                obj.序号 = 0;
                MainForm.EM.Add<t智能车间>(obj);
            }
            else if (CurrPageFlag == 8)
            {
                t闲置土地盘活计划表 obj = new t闲置土地盘活计划表();
                obj.序号 = 0;
                MainForm.EM.Add<t闲置土地盘活计划表>(obj);
            }
            else if (CurrPageFlag == 9)
            {
                t企业技术中心台账 obj = new t企业技术中心台账();
                obj.序号 = 0;
                MainForm.EM.Add<t企业技术中心台账>(obj);

            }
            RefreshData(CurrPageFlag);
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {

                    if (CurrPageFlag == 1)
                    {
                        List<t开发区2000万企业> uis = dgv1.DataSource as List<t开发区2000万企业>;

                        t开发区2000万企业 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t开发区2000万企业>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }

                    }
                    else if (CurrPageFlag == 2)
                    {
                        List<t标准化级别> uis = dgv1.DataSource as List<t标准化级别>;

                        t标准化级别 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t标准化级别>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                    {
                        List<t同里镇开发区上市企业台帐台资> uis = dgv1.DataSource as List<t同里镇开发区上市企业台帐台资>;

                        t同里镇开发区上市企业台帐台资 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t同里镇开发区上市企业台帐台资>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 132)
                    {
                        List<t同里镇开发区上市企业台帐三板> uis = dgv1.DataSource as List<t同里镇开发区上市企业台帐三板>;

                        t同里镇开发区上市企业台帐三板 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t同里镇开发区上市企业台帐三板>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 133)
                    {
                        List<t同里镇开发区上市企业台帐主版后备> uis = dgv1.DataSource as List<t同里镇开发区上市企业台帐主版后备>;

                        t同里镇开发区上市企业台帐主版后备 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t同里镇开发区上市企业台帐主版后备>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 4)
                    {
                        List<t清洁生产历年> uis = dgv1.DataSource as List<t清洁生产历年>;

                        t清洁生产历年 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t清洁生产历年>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 5)
                    {
                        List<t吴江区智能制造示范试点企业名单> uis = dgv1.DataSource as List<t吴江区智能制造示范试点企业名单>;

                        t吴江区智能制造示范试点企业名单 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t吴江区智能制造示范试点企业名单>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 6)
                    {
                        List<t新地标计划企业名单> uis = dgv1.DataSource as List<t新地标计划企业名单>;

                        t新地标计划企业名单 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t新地标计划企业名单>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 7)
                    {
                        List<t智能车间> uis = dgv1.DataSource as List<t智能车间>;

                        t智能车间 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t智能车间>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 8)
                    {
                        List<t闲置土地盘活计划表> uis = dgv1.DataSource as List<t闲置土地盘活计划表>;

                        t闲置土地盘活计划表 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t闲置土地盘活计划表>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                    else if (CurrPageFlag == 9)
                    {
                        List<t企业技术中心台账> uis = dgv1.DataSource as List<t企业技术中心台账>;

                        t企业技术中心台账 obj;// = uis[e.RowIndex];
                        if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                        {
                            obj = uis[e.RowIndex];
                            string ret = MainForm.EM.Modify<t企业技术中心台账>(obj);
                            if (ret == "")
                                MessageBox.Show("修改成功！");
                            else
                                MessageBox.Show(ret);
                        }
                    }
                }
             }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrPageFlag == 1)
                {
                    frmAdd2000 obj = new frmAdd2000();
                    obj.ShowDialog();
                }
                else if (CurrPageFlag == 2)
                {
                    FrmAdd2Bzh obj2 = new FrmAdd2Bzh();
                    obj2.ShowDialog();
                }
                else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                {
                    frmAdd31Ssqy obj31 = new frmAdd31Ssqy();
                    obj31.ShowDialog();
                }
                else if (CurrPageFlag == 132)
                {
                    FrmAdd32Ssqy obj32 = new FrmAdd32Ssqy();
                    obj32.ShowDialog();
                }
                else if (CurrPageFlag == 133)
                {
                    frmAdd33Ssqy obj33 = new frmAdd33Ssqy();
                    obj33.ShowDialog();
                }
                else if (CurrPageFlag == 4)
                {
                    FrmAdd4Qjsc obj4 = new FrmAdd4Qjsc();
                    obj4.ShowDialog();
                }
                else if (CurrPageFlag == 5)
                {
                    FrmAdd5Znzz obj5 = new FrmAdd5Znzz();
                    obj5.ShowDialog();
                }
                else if (CurrPageFlag == 6)
                {
                    FrmAdd6Xdb obj6 = new FrmAdd6Xdb();
                    obj6.ShowDialog();
                }
                else if (CurrPageFlag == 7)
                {
                    FrmAdd7Zncj obj7 = new FrmAdd7Zncj();
                    obj7.ShowDialog();
                }
                else if (CurrPageFlag == 8)
                {
                    FrmAdd8Xztd obj8 = new FrmAdd8Xztd();
                    obj8.ShowDialog();
                }
                else if (CurrPageFlag == 9)
                {
                    FrmAdd9Qyjstz obj9 = new FrmAdd9Qyjstz();
                    obj9.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgv1_Click(object sender, EventArgs e)
        {

        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                this.CurrId[CurrPageFlag] = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[0].Value);
                RowIndex[CurrPageFlag] = e.RowIndex;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (CurrPageFlag == 1)
                {
                    List<t开发区2000万企业> uis = dgv1.DataSource as List<t开发区2000万企业>;

                    t开发区2000万企业 obj;// = uis[e.RowIndex];
                    if (dgv1.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        frmAdd2000 frmobj = new frmAdd2000(obj);
                        frmobj.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 2)
                {
                    List<t标准化级别> uis = dgv2.DataSource as List<t标准化级别>;

                    t标准化级别 obj;// = uis[e.RowIndex];
                    if (dgv2.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd2Bzh obj2 = new FrmAdd2Bzh(obj);
                        obj2.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                {
                    List<t同里镇开发区上市企业台帐台资> uis = dgv31.DataSource as List<t同里镇开发区上市企业台帐台资>;

                    t同里镇开发区上市企业台帐台资 obj;// = uis[e.RowIndex];
                    if (dgv31.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        frmAdd31Ssqy obj31 = new frmAdd31Ssqy(obj);
                        obj31.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 132)
                {
                    List<t同里镇开发区上市企业台帐三板> uis = dgv32.DataSource as List<t同里镇开发区上市企业台帐三板>;

                    t同里镇开发区上市企业台帐三板 obj;// = uis[e.RowIndex];
                    if (dgv32.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd32Ssqy obj32 = new FrmAdd32Ssqy(obj);
                        obj32.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 133)
                {
                    List<t同里镇开发区上市企业台帐主版后备> uis = dgv33.DataSource as List<t同里镇开发区上市企业台帐主版后备>;

                    t同里镇开发区上市企业台帐主版后备 obj;// = uis[e.RowIndex];
                    if (dgv33.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        frmAdd33Ssqy obj33 = new frmAdd33Ssqy(obj);
                        obj33.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 4)
                {
                    List<t清洁生产历年> uis = dgv4.DataSource as List<t清洁生产历年>;

                    t清洁生产历年 obj;// = uis[e.RowIndex];
                    if (dgv4.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd4Qjsc obj4 = new FrmAdd4Qjsc(obj);
                        obj4.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 5)
                {
                    List<t吴江区智能制造示范试点企业名单> uis = dgv5.DataSource as List<t吴江区智能制造示范试点企业名单>;

                    t吴江区智能制造示范试点企业名单 obj;// = uis[e.RowIndex];
                    if (dgv5.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd5Znzz obj5 = new FrmAdd5Znzz(obj);
                        obj5.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 6)
                {
                    List<t新地标计划企业名单> uis = dgv6.DataSource as List<t新地标计划企业名单>;

                    t新地标计划企业名单 obj;// = uis[e.RowIndex];
                    if (dgv6.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd6Xdb obj6 = new FrmAdd6Xdb(obj);
                        obj6.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 7)
                {
                    List<t智能车间> uis = dgv7.DataSource as List<t智能车间>;

                    t智能车间 obj;// = uis[e.RowIndex];
                    if (dgv7.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd7Zncj obj7 = new FrmAdd7Zncj(obj);
                        obj7.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 8)
                {
                    List<t闲置土地盘活计划表> uis = dgv8.DataSource as List<t闲置土地盘活计划表>;

                    t闲置土地盘活计划表 obj;// = uis[e.RowIndex];
                    if (dgv8.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd8Xztd obj8 = new FrmAdd8Xztd(obj);
                        obj8.ShowDialog();
                    }
                }
                else if (CurrPageFlag == 9)
                {
                    List<t企业技术中心台账> uis = dgv9.DataSource as List<t企业技术中心台账>;

                    t企业技术中心台账 obj;// = uis[e.RowIndex];
                    if (dgv9.Rows[RowIndex[CurrPageFlag]].Cells[1].Value != null)
                    {
                        obj = uis[RowIndex[CurrPageFlag]];
                        FrmAdd9Qyjstz obj9 = new FrmAdd9Qyjstz(obj);
                        obj9.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Cancel == MessageBox.Show("确定要删除吗，删除后不可恢复!", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return;
                }
                if (CurrPageFlag == 1)
                {
                    MainForm.EM.DeleteById<t开发区2000万企业>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t标准化级别>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t同里镇开发区上市企业台帐台资>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t同里镇开发区上市企业台帐三板>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t同里镇开发区上市企业台帐主版后备>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t清洁生产历年>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t吴江区智能制造示范试点企业名单>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t新地标计划企业名单>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t智能车间>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t闲置土地盘活计划表>("Id", this.CurrId[CurrPageFlag]);
                }
                else if (CurrPageFlag == 2)
                {
                    MainForm.EM.DeleteById<t企业技术中心台账>("Id", this.CurrId[CurrPageFlag]);
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshData(CurrPageFlag);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        //这个定位有bug，参考TypeFilter 中的定位
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try{
                IEnvelope newdisp = (IEnvelope)new Envelope();
                bool findflag = false;
                if (CurrPageFlag == 1)
                {
                    List<t开发区2000万企业> uis = dgv1.DataSource as List<t开发区2000万企业>;
                    foreach (t开发区2000万企业 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 2)
                {
                    List<t标准化级别> uis = dgv1.DataSource as List<t标准化级别>;
                    foreach (t标准化级别 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 3 || CurrPageFlag == 131)
                {
                    List<t同里镇开发区上市企业台帐台资> uis = dgv31.DataSource as List<t同里镇开发区上市企业台帐台资>;

                    foreach (t同里镇开发区上市企业台帐台资 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 132)
                {
                    List<t同里镇开发区上市企业台帐三板> uis = dgv32.DataSource as List<t同里镇开发区上市企业台帐三板>;

                    foreach (t同里镇开发区上市企业台帐三板 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 133)
                {
                    List<t同里镇开发区上市企业台帐主版后备> uis = dgv33.DataSource as List<t同里镇开发区上市企业台帐主版后备>;

                    foreach (t同里镇开发区上市企业台帐主版后备 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 4)
                {
                    List<t清洁生产历年> uis = dgv4.DataSource as List<t清洁生产历年>;

                    foreach (t清洁生产历年 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 5)
                {
                    List<t吴江区智能制造示范试点企业名单> uis = dgv5.DataSource as List<t吴江区智能制造示范试点企业名单>;

                    foreach (t吴江区智能制造示范试点企业名单 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 6)
                {
                    List<t新地标计划企业名单> uis = dgv6.DataSource as List<t新地标计划企业名单>;

                    foreach (t新地标计划企业名单 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 7)
                {
                    List<t智能车间> uis = dgv7.DataSource as List<t智能车间>;
                    foreach (t智能车间 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 8)
                {
                    List<t闲置土地盘活计划表> uis = dgv8.DataSource as List<t闲置土地盘活计划表>;

                    foreach (t闲置土地盘活计划表 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }
                else if (CurrPageFlag == 9)
                {
                    List<t企业技术中心台账> uis = dgv9.DataSource as List<t企业技术中心台账>;

                    foreach (t企业技术中心台账 obj in uis)
                    {
                        if (obj.地块编号 != null && obj.地块编号 != "")
                        {
                            ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
                            List<IFeature> pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", obj.地块编号);
                            if (pGeo.Count > 0)
                            {
                                newdisp.Union(pGeo[0].Extent);
                                findflag = true;
                            }
                        }
                    }
                }

                if (!findflag)
                    MessageBox.Show("请先查询企业，目前没有企业定位！");
                else
                    LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
        }
     
    }
}
