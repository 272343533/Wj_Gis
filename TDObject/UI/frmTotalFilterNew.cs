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

using QyTech.Auth.Dao;
using QyTech.SkinForm.UICreate;


using System.Reflection;
using System.IO;

namespace TDObject.UI
{
    public partial class frmTotalFilterNew : QyTech.SkinForm.qyFormWithTitle
    {

        bsFunConf CurrFunConf;
        DataTable CurrDt = new DataTable();
        List<bsFunField> CurrFunFields = new List<bsFunField>();

        string tName;

        int CurrId;
        int CurrRowIndex=-1;


        public frmTotalFilterNew()
        {
            InitializeComponent();
        }

        int[] Table_Rb_LocationYs = new int[1000];

        private void frmTotalFilter_Load(object sender, EventArgs e)
        {

            try
            {
                this.Title = "分项维护";

                List<bsFunConf> fcs = MainForm.QyTech_EM.GetListNoPaging<bsFunConf>("bsN_Id='9CCB8C3B-7939-4B74-A048-713E30003C3B' and tName like 't%' and tName not  in ('t开发区2000万企业','t闲置土地盘活计划表')", "FunName");
                int locationX = 27, LocationY = 10;
                vScrollBar1.Top = 10;
                vScrollBar1.Size = new Size(10, gbTable.Height - 10);


                foreach (bsFunConf dc in fcs)
                {
                    RadioButton rb = new RadioButton();
                    rb.Text = dc.FunName;
                    rb.Tag = dc;
                    rb.Location = new System.Drawing.Point(locationX, LocationY); LocationY += 30;
                    rb.Width = gbTable.Width - 20;
                    rb.Click += new System.EventHandler(this.rb1_Click);

                    gbTable.Controls.Add(rb);
                }
                int index = 0;
                foreach (Control gbox in gbTable.Controls)
                {
                    if (gbox is VScrollBar) continue;
                    if (index == 0)
                    {
                        (gbox as RadioButton).Checked = true;
                        rb1_Click(gbox, null);
                    }
                    Table_Rb_LocationYs[index++] = gbox.Location.Y;

                }
                vScrollBar1.Maximum = Table_Rb_LocationYs[index - 1];
                this.splitContainer1.Panel1.VerticalScroll.Value = this.splitContainer1.Panel1.VerticalScroll.Maximum;

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
                CurrFunConf = rb.Tag as bsFunConf;
                tName = CurrFunConf.TName;
                CurrRowIndex = -1;
                try
                {
                    int stepY = 36;
                    int LocationX, LocationY;
                    gbContainer.Controls.Clear();
                    List<bsFunQuery> fqs = MainForm.QyTech_EM.GetListNoPaging<bsFunQuery>("TName='"+tName+"'", "FQNo");
                    if (fqs.Count > 0)
                    {
                        //刷新查询条件，每行三个
                        for (int i = 0; i < fqs.Count; i++)
                        {
                            bsFunQuery fq = fqs[i];
                            LocationX = i % 3 * 250;
                            LocationY = 10 + i / 3 * stepY;
                            if (fq.OperType == "select")//combox
                            {
                                if (fq.OperName != "年月")
                                {
                                    UICreate.CreateCombobox(gbContainer, fq.OperName, fq.FName, fq.DataEx, "", LocationX, LocationY, fq.DataExSql);
                                }
                                else
                                {
                                    //获取年月的数据
                                    List<string> items = TDObject.DAOBLL.ImportTBll.GetYearMonths(tName);
                                    string stritems = "";
                                    for(int it = 0; it < items.Count; it++)
                                    {
                                        stritems += "," + items[it];
                                    }
                                    if (stritems.Length > 0) { stritems = stritems.Substring(1); }

                                    UICreate.CreateCombobox(gbContainer, fq.OperName, fq.FName, stritems, "", LocationX, LocationY, fq.DataExSql);


                                }
                            }
                            else if (fq.OperType == "text")
                            {
                                //text
                                UICreate.CreateTextDisplay(gbContainer, fq.OperName, fq.FName, "", LocationX, LocationY, fq.DataExSql);
                            }

                        }
                        splitContainer2.SplitterDistance = 30 + (int)Math.Ceiling(fqs.Count / 3.0) * stepY;
                        splitContainer2.Panel1.Refresh();
                        splitContainer2.Panel2.Refresh();

                    }
                    else
                    {
                        splitContainer2.SplitterDistance = 30;

                    }

                    RefreshData(CurrFunConf, "");//"Id=-1"
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void RefreshData(bsFunConf fc,string sqlwhere="")
        {
            try
            {
                string sqlOrderby = "";

                if (sqlwhere == "")
                {
                    ManageWhereOrderby(ref sqlwhere, ref sqlOrderby);
                }

                //根据表名获取不同的表格数据
                QyTech.SQLDA.SqlUtil.ProgressChangeddEvent += new QyTech.SQLDA.SqlUtil.delegateProgressHandler(RefreshEvent);
                CurrDt = QyTech.SQLDA.SqlUtil.RefreshDbTable(qyDgv1, MainForm.sqlConn, tName, sqlwhere, sqlOrderby, out CurrFunFields);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void RefreshEvent(int v,int max)
        {
            if (v == 1)
            {
                qyPbr1.Visible = true;
                qyPbr1.Minimum = 0;
                qyPbr1.Maximum = max;
                qyPbr1.Refresh();
            }
            else if (v == max)
            {
                qyPbr1.Visible = false;
            }
            qyPbr1.Value = v;
        }
        private void ManageWhereOrderby(ref string where,ref string orderby)
        {
            orderby = "Id";
            where = "";
            foreach (Control c in this.gbContainer.Controls)
            {
                if (c.Text != "")
                {
                    if (c is TextBox)
                    {
                        where += " and ("+c.Tag.ToString().Replace("@@@@",c.Text)+")";
                    }
                    else if (c is ComboBox)
                    {
                        ComboBox cb = c as ComboBox;
                        string[] items = cb.Tag.ToString().Split(new char[] { '|' });
                        if (items.Length > 1)
                        {
                            where += " and (" + items[cb.SelectedIndex - 1] + ")";
                        }
                        else if (items.Length == 1)
                        {
                            if (items[0] !="")
                            {
                                where += " and (" + c.Tag.ToString().Replace("@@@@", c.Text) + ")";
                            }

                            else
                            {
                                string ymcondition = TDObject.DAOBLL.ImportTBll.WhereSql(tName, c.Text);
                                where += " and (" + ymcondition+")";
                            }
                        }

                    }
                }
            }
            if (where.Length >5)
            {
                where = where.Substring(5);
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int index = 0;
            foreach (Control gbox in gbTable.Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Location = new System.Drawing.Point(gbox.Location.X, Table_Rb_LocationYs[index++] - e.NewValue);
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                if (DialogResult.Cancel == MessageBox.Show("确定要删除吗，删除后不可恢复!", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                {
                    return;
                }
                //delete 删除
                string sql = "delete from " + CurrDt.TableName + " where Id=" + CurrId.ToString();
                QyTech.SQLDA.SqlUtil.ExceuteSql(MainForm.sqlConn, sql);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void gbTable_Enter(object sender, EventArgs e)
        {
        }



        private void qyDgv1_Click(object sender, EventArgs e)
        {
           
        }

        private void qyDgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                CurrId = Convert.ToInt32(qyDgv1.Rows[e.RowIndex].Cells[0].Value);
                CurrRowIndex = e.RowIndex;
            }
        }

        //新增
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            object obj=null;
           
            frmAdd objfrm = new frmAdd(tName, obj, MainForm.EM);
            objfrm.ShowDialog();
        }

        //编辑
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (CurrRowIndex == -1)
            {
                MessageBox.Show("请首先选择数据");
                return;
            }
            object obj=new object();
            if (tName == "t安全事故情况")
            {
                QyTech.SQLDA.DbTableConvertor<t安全事故情况> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t安全事故情况>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t标准化级别")
            {
                QyTech.SQLDA.DbTableConvertor<t标准化级别> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t标准化级别>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t高企")
            {
                QyTech.SQLDA.DbTableConvertor<t高企> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t高企>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t工程技术研究中心")
            {
                QyTech.SQLDA.DbTableConvertor<t工程技术研究中心> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t工程技术研究中心>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t工业固定资产")
            {
                QyTech.SQLDA.DbTableConvertor<t工业固定资产> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t工业固定资产>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t规上企业名单")
            {
                QyTech.SQLDA.DbTableConvertor<t规上企业名单> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t规上企业名单>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t经发局表格")
            {
                QyTech.SQLDA.DbTableConvertor<t经发局表格> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t经发局表格>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t立案处罚情况")
            {
                QyTech.SQLDA.DbTableConvertor<t立案处罚情况> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t立案处罚情况>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t企业基础数据")
            {
                QyTech.SQLDA.DbTableConvertor<t企业基础数据> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t企业基础数据>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if(tName == "t企业技术中心台账")
            {
                QyTech.SQLDA.DbTableConvertor<t企业技术中心台账> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t企业技术中心台账>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t清洁生产历年")
            {
                QyTech.SQLDA.DbTableConvertor<t清洁生产历年> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t清洁生产历年>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t市局表格")
            {
                QyTech.SQLDA.DbTableConvertor<t市局表格> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t市局表格>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t同里镇开发区上市企业台帐三板")
            {
                QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐三板> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐三板>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t同里镇开发区上市企业台帐台资")
            {
                QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐台资> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐台资>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t同里镇开发区上市企业台帐主版后备")
            {
                QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐主版后备> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t同里镇开发区上市企业台帐主版后备>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t吴江区智能制造示范试点企业名单")
            {
                QyTech.SQLDA.DbTableConvertor<t吴江区智能制造示范试点企业名单> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t吴江区智能制造示范试点企业名单>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t新地标计划企业名单")
            {
                QyTech.SQLDA.DbTableConvertor<t新地标计划企业名单> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t新地标计划企业名单>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }
            else if (tName == "t智能车间")
            {
                QyTech.SQLDA.DbTableConvertor<t智能车间> dbTableConvertor = new QyTech.SQLDA.DbTableConvertor<t智能车间>();
                obj = dbTableConvertor.ConvertToEntity(CurrDt, CurrRowIndex);
            }

            if (obj != null)
            {
                frmAdd objfrm = new frmAdd(tName, obj, MainForm.EM);
                objfrm.ShowDialog();
            }
            else
            {
                MessageBox.Show("请首先选择数据！");
            }
        }

        private void qyBtn_Search1_Click(object sender, EventArgs e)
        {
            RefreshData(CurrFunConf);
        }



       
    }
}
