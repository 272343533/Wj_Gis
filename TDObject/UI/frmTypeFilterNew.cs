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

using QyTech.Auth.Dao;

namespace TDObject.UI
{
    public partial class frmTypeFilterNew : QyTech.SkinForm.qyFormWithTitle
    {
       
        List<IFeature> pGeos = new List<IFeature>();//用于高亮
        IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
        List<IGeometry> Geos = new List<IGeometry>();

        TDObject.BLL.UIBLL.bllTypeFilter blluifiler = new TDObject.BLL.UIBLL.bllTypeFilter(GlobalVariables.axMapControl);

        int stepY = 30;//空间之间的差

        QyTech.ExcelOper.QyExcelHelper excl = new QyTech.ExcelOper.QyExcelHelper("local");


        int[] Table_Rb_LocationYs = new int[1000];

        bsDynCondition CurrDynCondition;
        List<string> selectedItem = new List<string>();


        DataTable CurrDt=new DataTable();
        List<bsFunField> CurrFunFields = new List<bsFunField>();
        string tName;


        bool ResetDataSouce = true;

        public frmTypeFilterNew()
        {
            InitializeComponent();
        }

        private void frmTypeFilter_Load(object sender, EventArgs e)
        {
            try
            {
                //初始化列数据属性字段
                RefreshDgvColumnPropertyValue(qyDgv1);
                excl.eventNumChanged += new QyTech.ExcelOper.DelegateForExportNo(RefreshPgb);

                this.qyDgv1.Click += new System.EventHandler(this.dgv1_Click);
                this.qyDgv1.DoubleClick += new System.EventHandler(this.dgv1_DoubleClick);

                List<bsDynCondition> dcs = TDObject.DAOBLL.RoleRelBll.GetRightItem();
                int locationX = 27, LocationY = 10;
                vScrollBar1.Top = 10;
                vScrollBar1.Size = new Size(10, gbTable.Height-10);


                foreach (bsDynCondition dc in dcs)
                {
                    if (dc.compType!= "combox") continue;
                    RadioButton rb = new RadioButton();
                    rb.Text = dc.condName;
                    rb.Tag = dc;
                    rb.Location = new System.Drawing.Point(locationX, LocationY); LocationY += 30;
                    rb.Width = gbTable.Width - 20;
                    rb.Click+=new System.EventHandler(this.rb1_Click);
                    
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
                    Table_Rb_LocationYs[index++]=gbox.Location.Y;
                    
                }
                vScrollBar1.Maximum = Table_Rb_LocationYs[index-1];
                this.splitContainer2.Panel1.VerticalScroll.Value = this.splitContainer2.Panel1.VerticalScroll.Maximum;
                

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
                this.qyPbr1.Visible = true;
                this.qyPbr1.Maximum = maxvalue;
            }
            else if (val == maxvalue)
                this.qyPbr1.Visible = false;
            else
                this.qyPbr1.Value = val;
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
                ResetDataSouce = true;
                RadioButton rb = sender as RadioButton;
                CurrDynCondition = rb.Tag as bsDynCondition;
                string[] items = CurrDynCondition.compitems.Split(new char[] { ',' });

                int index = 0;
                for (int i = 0; i < items.Length; i++)
                {
                    if (items[i] != "全部"&& items[i].Trim()!="")
                    {
                        index++;
                    }
                }
                Item[] itemS = new Item[index];
                index = 0;
                for (int i=0;i<items.Length;i++)
                {
                    if (items[i] != "全部" && items[i].Trim() != "")
                    {
                        itemS[index++] = new Item(items[i]);
                    }
                }
                qyDgvItem.AutoGenerateColumns = true;
                qyDgvItem.DataSource = itemS;


                ResetDataSouce = false;
                if (itemS.Length>0)
                    qyDgvItem.Rows[0].Cells[0].Value = true;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void chkitem_CheckedChanged(object sender, EventArgs e)
        {
            //RefreshData(dgv7, typeindex);
        }
        private void ManageWhereOrderby(int refreshflag, ref string sqlwhere, ref string sqlOrderby)
        {
            try
            {
                sqlwhere = "";
                sqlOrderby = "序号";

                
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
               
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

      


        private void btnShowMap_Click(object sender, EventArgs e)
        {
            try
            {
               string ltdnames = "", dkbhs="";
                ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");

                bsTable bt = MainForm.QyTech_EM.GetBySql<bsTable>("TName='" + CurrDt.TableName + "' and bsD_Name='wj_GisDb'");

                for(int i=0;i< CurrDt.Rows.Count;i++)
                {
                    if (CurrDt.Rows[i][bt.NotNullField] !=null && CurrDt.Rows[i][bt.NotNullField].ToString() != "")
                    {
                        ltdnames += "," + CurrDt.Rows[i][bt.NotNullField].ToString();
                    }
                }
                //根据
                List<bsLtdInfo> ltds = MainForm.EM.GetListNoPaging<bsLtdInfo>("纳税人名称 in ('" + ltdnames.Substring(1).Replace(",","','")+"')", "");

                for (int i = 0; i < ltds.Count; i++)
                {
                    if (ltds[i].地块编号!=null && ltds[i].地块编号!="")
                        dkbhs += "," + ltds[i].地块编号.ToString();
                }
                pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);
                if (Geos.Count> 0)
                    LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp); 
                else
                {
                    MessageBox.Show("不能定位，请确定企业数据是否整！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
        }


        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xls";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    string filename = sfd.FileName;

                    string items = "";
                    Dictionary<string, string> dicFields = new Dictionary<string, string>();
                    foreach(bsFunField ff in CurrFunFields)
                    {
                        if ((bool)ff.VisibleInList.Value)
                        {
                            items += "," + ff.FName;

                            dicFields.Add(ff.FName, ff.FDesp);
                        }
                    }
                    if (items.Length > 0)
                        items = items.Substring(1);
                    //string saveToPath = excl.ExportDataTableToExcl(CurrDt, filename, items);
                    string saveToPath = excl.ExportDataTableToExcl(CurrDt, filename, dicFields);




                    MessageBox.Show("文件导出完毕！", "提示", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
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
                    blluifiler.ExDisplayOneLtdFeature(DKBH);
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
                    blluifiler.ExPostionOneLtdFeature(DKBH);
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

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            int index = 0;
            foreach (Control gbox in gbTable.Controls)
            {
                if (gbox is VScrollBar) continue;
                gbox.Location = new System.Drawing.Point(gbox.Location.X, Table_Rb_LocationYs[index++] - e.NewValue);
            }
        }

        private void qyDgvItem_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void qyDgvItem_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (ResetDataSouce)
                return;

            tName= CurrDynCondition.TName;
            string where = "",whereindex="";

            try
            {
                if (e.ColumnIndex == 0)//checked 发生变化
                {
                    if (CurrDynCondition.condName == "上市情况"|| CurrDynCondition.condName == "科技创新")
                    {
                        #region 控制单选或多选
                        if (Convert.ToBoolean(qyDgvItem.Rows[e.RowIndex].Cells[0].Value))
                        {
                            for (int i = 0; i < qyDgvItem.Rows.Count; i++)
                            {
                                if (e.RowIndex != i)
                                {
                                    ResetDataSouce = true;//避免引起连锁赋值
                                    qyDgvItem.Rows[i].Cells[0].Value = false;
                                }
                            }
                            ResetDataSouce = false;
                        }
                        //根据位置获取对应的表名
                        string[] tNames = tName.Split(new char[] { ',' });
                        tName = tNames[e.RowIndex];

                        #endregion
                    }
                    //else
                    //{
                    //    //RefreshData();
                    //}
                    //根据表名获取不同的表格数据
                    if (CurrFunFields[0].TName != tName)
                    {
                        CurrDt = QyTech.SQLDA.SqlUtil.RefreshDbTable(qyDgv1, MainForm.sqlConn, tName, "Id=-1", "", out CurrFunFields);
                    }
                }


            }
            catch(Exception ex)
            { }
        }

        private void qyDgvItem_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (qyDgvItem.IsCurrentCellDirty)
            {
                qyDgvItem.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void RefreshData()
        {
            string where = "", whereindex = "";

            #region 显示数据，转移到按钮处
            if ("上市情况,科技创新,规上".Contains(CurrDynCondition.condName))
            {
                //根据表名获取不同的表格数据
                CurrDt = QyTech.SQLDA.SqlUtil.RefreshDbTable(qyDgv1, MainForm.sqlConn, tName, where, "", out CurrFunFields);

            }
            else
            {
                //获取所有被选择的对象
                for (int i = 0; i < qyDgvItem.Rows.Count; i++)
                {
                    if (qyDgvItem.Rows[i].Cells[0].Value != null && (bool)(qyDgvItem.Rows[i].Cells[0].Value))
                    {
                        where += "," + qyDgvItem.Rows[i].Cells[1].Value.ToString();
                        whereindex += "," + i.ToString();
                    }
                }
                if (where.Length > 0)
                {
                    where = where.Substring(1);
                    if ("标准化等级,安全事故情况,立案处罚情况,智能工厂,智能车间,技术中心获批级别,行业大类".Contains(CurrDynCondition.condName))//文本类型字段
                    {
                        if ("智能车间".Contains(CurrDynCondition.condName))
                        {
                            where = where.Replace("年", "");
                        }
                        where = CurrDynCondition.MulSql.Replace("@@@@", "'" + where.Replace(",", "','") + "'");
                    }
                    else if ("地标性企业".Contains(CurrDynCondition.condName))
                    {
                        string[] sours = CurrDynCondition.MulSql.Split(new char[] { '|' });
                        string[] indexs = whereindex.Substring(1).Split(new char[] { ',' });
                        where = "";
                        for (int i = 0; i < indexs.Length; i++)
                        {
                            where += " or " + sours[Convert.ToInt32(indexs[i])];
                        }
                        if (where.Length > 4)
                        {
                            where = where.Substring(4);
                        }
                    }
                    else if ("清洁生产".Contains(CurrDynCondition.condName))//数值类型字段
                    {
                        if ("清洁生产".Contains(CurrDynCondition.condName))
                        {
                            where = where.Replace("年", "");
                        }
                        where = CurrDynCondition.MulSql.Replace("@@@@", where);

                    }
                    else//特殊处理 
                    {
                        //多条件根据索引，对应|替换为or,在拼在一起
                        string[] sours = CurrDynCondition.MulSql.Split(new char[] { '|' });
                        string[] indexs = whereindex.Substring(1).Split(new char[] { ',' });
                        where = "";
                        for (int i = 0; i < indexs.Length; i++)
                        {
                            where += " or " + sours[Convert.ToInt32(indexs[i])];
                        }
                        if (where.Length > 4)
                        {
                            where = where.Substring(4);
                        }

                    }
                    //where=CurrDynCondition.
                }
                //根据表名获取不同的表格数据
                CurrDt = QyTech.SQLDA.SqlUtil.RefreshDbTable(qyDgv1, MainForm.sqlConn, tName, where, "", out CurrFunFields);
            }
            #endregion
        }

        private void qyBtn_Search1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }
    }

    class Item
    {
        private string _text;
        public string Text
        {
            get { return _text; }
        }
        public Item(string text)
        {
            this._text = text;
        }
    }
}
