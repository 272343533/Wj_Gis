using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using TDObject;

using TDObject.BLL;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;
using SunMvcExpress.Dao;
using QyTech.Core.BLL;
using TDObject.MapControl;
using QyTech.Json;

namespace TDObject.UI
{


    public partial class frmComplexQuery : FlatForm
    {

        IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
        List<IGeometry> Geos = new List<IGeometry>();

        Dictionary<string, string> comboitems = new Dictionary<string, string>();

        public int SetLabelY { get; private set; }
      

        int objid=0 ;//= Convert.ToInt32(this.dgvT2_11.Rows[this.dgvT2_11.CurrentCell.RowIndex].Cells[1].Value);

        public frmComplexQuery()
        {
            InitializeComponent();
        }



       
        private void button3_Click(object sender, EventArgs e)
        {
            try

            {
                string Querys1 = string.Empty;//保存查询条件
                string Querys2 = string.Empty;//保存查询条件
                SetLabelY = 0;
                int SelectNum = -1;
                int LocationX, LocationY;
                this.button1.Enabled = false;
                this.gbConditon.Controls.Clear();
                foreach (TreeNode tn in this.treeView1.Nodes[0].Nodes)
                {
                    if (tn.Checked)
                    {
                        this.button1.Enabled = true;
                        SelectNum++;
                        LocationX = SelectNum % 4 * 250;
                        LocationY = 10 + SelectNum / 4 * 45;

                        string cname = tn.Name.Substring(3);

                        if (cname.Substring(0, 3) == "cbo")//combox
                        {
                            CreateCombobox(tn.Text, cname, comboitems[cname], LocationX, LocationY);
                            Querys1 += tn.Text + ",";
                            Querys2 += tn.Name + ",";
                        }
                        else if (cname.Substring(0, 3) == "txt")
                        {
                            //text
                            CreateTextDisplay(tn.Text, cname, LocationX, LocationY);
                            Querys1 += tn.Text + ",";
                            Querys2 += tn.Name + ",";
                        }//else if (NumRangeFields.Contains<string>(tn.Text))
                         //{
                         //    //number range
                         //    CreateNumRange(tn.Text, tn.Name, SelectNum % 2 == 1 ? 500 : 20, 10 + SelectNum / 2 * 45);
                         //    Querys1 += tn.Text + ",";
                         //    Querys2 += tn.Name + ",";

                        //}
                        //else if (DaRangeFields.Contains<string>(tn.Text))
                        //{
                        //    CreatDaRange(tn.Text, tn.Name, SelectNum % 2 == 1 ? 500 : 20, 10 + SelectNum / 2 * 45);
                        //    Querys1 += tn.Text + ",";
                        //    Querys2 += tn.Name + ",";
                        //}


                        panel3.Height = 90 + SelectNum / 4 * 45;

                    }

                }
                //保存查询条件
                MainForm.LoginUser.ExComplQueryCond = Querys1;
                bsUser dbobj = MainForm.EM.GetByPk<bsUser>("bsU_Id", MainForm.LoginUser.bsU_Id);
                dbobj.ExComplQueryCond = Querys1;
                string ret = MainForm.EM.Modify<bsUser>(dbobj);
                if (ret != "")
                {
                    MessageBox.Show("保存条件失败!(" + ret + ")");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void SetLastQuery(string query)
        {

            foreach (TreeNode tn in this.treeView1.Nodes[0].Nodes)
            {
                if (query.Contains(tn.Text))
                {
                    tn.Checked = true;
                }
            }

        }
        private void frmComplexStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvT2_11.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;

                this.treeView1.ExpandAll();
                string query = MainForm.LoginUser.ExComplQueryCond;
                string showCell = string.Empty;
              
                if (query != null)
                {
                    SetLastQuery(MainForm.LoginUser.ExComplQueryCond);

                }
                if (showCell != null)
                {
                    refdgvT2_11(showCell);
                }
                //Refresh the tree with the checked
                treeView1.Nodes[0].Nodes[0].Checked = true;
                treeView1.Nodes[0].Nodes[1].Checked = true;

          
                //填充combox选项
                comboitems.Add("cbo_aqscdj", "全部,一级,二级,三级");
                comboitems.Add("cbo_hhpcf", "全部,红牌,黄牌");
                comboitems.Add("cbo_xdbqy", "全部,超1亿元,超5亿元,超10亿元,超20亿元");
                //comboitems.Add("cbo_hydl", "全部,");从数据库中获取
                comboitems.Add("cbo_yye", "全部,2000万以上,3000万以上,5000万以上,1亿以上");
                comboitems.Add("cbo_ss", "全部,,2000万以上,3000万以上,5000万以上");
                comboitems.Add("cbo_zncj", "全部,2015年,2016年,2017年,2018年");//智能车间
                comboitems.Add("cbo_tdphjh", "全部,10亩以上,20亩以上,50亩以上,100亩以上");
                comboitems.Add("cbo_ssqk", "台资拟上市,三板挂牌,主板后备");
                comboitems.Add("cbo_zxhp", "全部,市级,省级,国家级");
                comboitems.Add("cbo_znzz", "全部,台智能设计,智能生产,智能装备,供应链管理,生产性电商");


                button3_Click(this.button3, null);


            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        #region 条件创建
        private void CreateTextDisplay(string labText, string textName, int x, int y, int labwidth = 90, int textwidth = 150)
        {
            Label l = new Label();
            l.Text = labText;
            l.Location = new System.Drawing.Point(x, y);//(300,...)
            l.Width = labwidth;
            l.TextAlign = ContentAlignment.MiddleRight;
            this.gbConditon.Controls.Add(l);

            TextBox tb = new TextBox();
            tb.Location = new System.Drawing.Point(x + 100, y);
            tb.Width = textwidth;
            tb.Name = textName;

            this.gbConditon.Controls.Add(tb);
        }
        private void CreateCombobox(string labText, string comname,string items, int x, int y, int labwidth = 90, int comboxwidth = 150)
        {
            Label l = new Label();
            l.Text = labText;
            l.Location = new System.Drawing.Point(x, y);
            l.Width = labwidth;
            l.TextAlign = ContentAlignment.MiddleRight;
            this.gbConditon.Controls.Add(l);

            ComboBox cb = new ComboBox();
            cb.Location = new System.Drawing.Point(x + 100, y);
            cb.Width = comboxwidth;
            cb.Name = comname;
            if (items.Trim() != "")
            {
                string[] sitems = items.Split(new char[] { ',' });
                cb.Items.Clear();
                cb.Items.Add("");
                foreach (string s in sitems)
                {
                    cb.Items.Add(s);
                }
            }
            if (comname =="cbo_hydl")
            {
                //行业大类
                List<bsHYDL> hydls = MainForm.EM.GetListNoPaging<bsHYDL>("", "HYDL");
                cb.Items.Clear();
                cb.Items.Add("");
                foreach (bsHYDL hydl in hydls)
                {
                    cb.Items.Add(hydl.HYDL);
                }
            }

            this.gbConditon.Controls.Add(cb);
        }   
        //private void CreateNumRange(string labText, string textName, int x, int y, int labwidth = 90, int textwidth = 150)
        //{
        //    Label l = new Label();
        //    l.Text = labText;
        //    l.Location = new System.Drawing.Point(x, y + 4);//(300,...)
        //    l.Width = labwidth;
        //    this.groupBox1.Controls.Add(l);

        //    TextBox tb = new TextBox();
        //    tb.Location = new System.Drawing.Point(x + 100, y);
        //    tb.Width = textwidth / 2 - 10;
        //    tb.Name = textName;
        //    this.groupBox1.Controls.Add(tb);

        //    TextBox tb1 = new TextBox();
        //    tb1.Location = new System.Drawing.Point(x + 185, y);
        //    tb1.Width = textwidth / 2 - 10;
        //    tb1.Name = textName + "_";
        //    this.groupBox1.Controls.Add(tb1);
        //    //tb1.Dispose();
        //}
        //private void CreatDaRange(string labText, string textName, int x, int y, int labwidth = 90, int textwidth = 150)
        //{
        //    Label l = new Label();
        //    l.Text = labText;
        //    l.Location = new System.Drawing.Point(x, y + 4);//(300,...)
        //    l.Width = labwidth - 30;
        //    this.groupBox1.Controls.Add(l);

        //    DateTimePicker dt = new DateTimePicker();
        //    dt.Location = new System.Drawing.Point(x + 70, y);
        //    dt.Width = textwidth / 2 + 30;
        //    dt.Name = textName;
        //    this.groupBox1.Controls.Add(dt);

        //    DateTimePicker dt1 = new DateTimePicker();
        //    dt1.Location = new System.Drawing.Point(x + 185, y);
        //    dt1.Width = textwidth / 2 + 30;
        //    dt1.Name = textName + "_";
        //    this.groupBox1.Controls.Add(dt1);

        //}


        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                
                List<企业范围> list = new List<企业范围>();

                string Conditions = GetWhereCondition();
        

                //list = EntityManager<土地现状数据>.GetListNoPaging<土地现状数据>(Conditions,"");
                //Conditions = Conditions.Replace("%", "%%%");
                //Conditions += MainForm.LoginUserRights;
                //string detailUrl="";
                //if (Conditions!="")
                //    detailUrl = MainForm.URI+ "lyRemoteServ/DoComplexQuery?sqlconf=" + Conditions;
                //else
                //    detailUrl = MainForm.URI + "lyRemoteServ/DoComplexQuery" ;
                //string ret = AsyncHttp.CommFun.GetRemoteJson(detailUrl);
                //list = JsonHelper.DeserializeJsonToList<企业范围>(ret);

                list = MainForm.EM.GetListNoPaging<企业范围>(Conditions, "");


                this.dgvT2_11.AutoGenerateColumns = false;
                this.dgvT2_11.DataSource = list;
                if (list==null)
                    this.label1.Text = "符合条件的共计 0 条";
                else
                    this.label1.Text = "符合条件的共计" + list.Count.ToString() + "条";
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show("请检查查询条件：" + ex.Message);
            }
        }

        private string GetItemCondition(string itemname, string itemtext)
        {
            string Conditions = "";
            if (itemtext.Trim() == "")
                return "";

            if ("txt_dkbm" == itemname)
                Conditions += " and DKBH ='" + itemtext + "'";
            if ("txt_nsrsbh" == itemname)
                Conditions += " and NSRSBH = '" + itemtext + "'";
            if ("cbo_hydl" == itemname)
                Conditions += " and HYDL like '%" + itemtext + "%'";
            if ("txt_jyfw" == itemname)
                Conditions += " and JYFW like '%" + itemtext + "%'";
            if ("txtyddwmc" == itemname)
                Conditions += " and YDQYMC like '%" + itemtext + "%'";
            if ("this.txt_zdzlyy" == itemname)
                Conditions += " and ZLQYMC_ like '%" + itemtext + "%'";




            if ("cbo_hhpcf" == itemname)
                Conditions += " and DKBH in (" + " select SSDKBM from LtdProblem " + (itemtext == "全部" ? ")" : "where CCLX='"+ itemtext+"')");

            if ("cbo_zncj" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t智能车间 " + (itemtext == "全部" ? ")" : "where 获评年份='" + itemtext.Substring(0, 4) + "')");

            if ("cbo_xdbqy" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t新地标计划企业名单 " + (itemtext == "全部" ? ")" : "where substring(目标,1,len(目标)-3)='" + itemtext.Substring(1,itemtext.Length-3) + "')");

            if ("cbo_yye" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t开发区2000万企业 " + (itemtext == "全部" ? ")" : "where 累计销售额合计" + itemtext.Substring(0, itemtext.Length - 3) + ")");

            if ("cbo_ss" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t开发区2000万企业 " + (itemtext == "全部" ? ")" : "where 税收>=" + itemtext.Substring(0, itemtext.Length - 3) + ")");

            if ("cbo_aqscdj" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t标准化级别 "+ (itemtext == "全部"? ")" : "where 标准化级别='" + itemtext + "')");
               

            if ("cbo_tdphjh" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t闲置土地盘活计划表 " + (itemtext == "全部" ? ")" : "where 土地面积>=" + itemtext.Substring(0, itemtext.Length - 3) + ")");

            if ("cbo_ssqk" == itemname)
            { 
                if (itemtext== "台资拟上市")
                 Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";

                if (itemtext == "三板挂牌")
                    Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";

                if (itemtext == "主板后备")
                    Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";
            }
            if ("cbo_zxhp" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t企业技术中心台账 where 地块编号 is not null)";

            if ("cbo_znzz" == itemname)
                Conditions += " and DKBH in (" + " select 地块编号 from t吴江区智能制造示范试点企业名单 " + (itemtext == "全部" ? ")" : "where 所属环节='" + itemtext + "')");


            return Conditions;
        }

        public string GetWhereCondition()
        {
               string Conditions = "";

            //if (txt_dkbm.Text != "")
            //    Conditions += " and DKBH ='" + txt_dkbm.Text + "'";
            //if (txt_nsrsbh.Text != "")
            //    Conditions += " and NSRSBH = '" + txt_nsrsbh.Text + "'";
            //if (cbo_hydl.Text != "")
            //    Conditions += " and HYDL like '%" + cbo_hydl.Text + "%'";
            //if (txt_jyfw.Text != "")
            //    Conditions += " and JYFW like '%" + txt_jyfw.Text + "%'";
            //if (txtyddwmc.Text != "")
            //    Conditions += " and YDQYMC like '%" + txtyddwmc.Text + "%'";
            //if (this.txt_zdzlyy.Text != "")
            //    Conditions += " and ZLQYMC_ like '%" + txt_zdzlyy.Text + "%'";


            //if (this.cbo_hhpcf.Text != "")
            //    Conditions += " and DKBH in (" + " select SSDKBM from LtdProblem" + ")";

            //if (this.cbo_zncj.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t智能车间 where 获评年份='" + this.cbo_zncj.Text.Substring(0, 4) + "')";

            //if (this.cbo_xdbqy.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t新地标计划企业名单 where 目标='" + this.cbo_xdbqy.Text + "')";

            //if (this.cbo_yye.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t开发区2000万企业 where 累计销售额合计" + this.cbo_yye.Text.Substring(0, cbo_yye.Text.Length - 1) + ")";

            //if (this.cbo_ss.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t开发区2000万企业 where 税收" + this.cbo_ss.Text.Substring(0, cbo_ss.Text.Length - 1) + ")";

            //if (this.cbo_aqscdj.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t标准化级别 where 标准化级别=" + this.cbo_aqscdj.Text + ")";

            //if (this.cbo_tdphjh.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t闲置土地盘活计划表 where 土地面积" + this.cbo_tdphjh.Text.Substring(0, cbo_tdphjh.Text.Length - 1) + ")";

            //if (this.cbo_ssqk.SelectedIndex == 1)
            //    Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";

            //if (this.cbo_ssqk.SelectedIndex ==2)
            //    Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";

            //if (this.cbo_ssqk.SelectedIndex ==3)
            //    Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";

            //if (this.cbo_zxhp.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t企业技术中心台账 where 地块编号 is not null)";

            //if (this.cbo_znzz.Text != "")
            //    Conditions += " and DKBH in (" + " select 地块编号 from t吴江区智能制造示范试点企业名单 where 所属环节='" + this.cbo_znzz.Text + "')";

            foreach (Control c in this.gbConditon.Controls)
            {
                if (c is TextBox)
                {
                    Conditions += GetItemCondition(c.Name, c.Text);
                }
                else if (c is ComboBox)
                {
                    Conditions += GetItemCondition(c.Name, c.Text);
                }
                //else if (c is DateTimePicker)
                //{
                //    DateTimePicker d = (DateTimePicker)c;
                //    //Conditions += c.Name + "==\"" + d.Value.ToString("yyyy-MM-dd") + "\" and "; 
                //    string newStr = c.Text.Replace("年", "-").Replace("月", "-").Replace("日", "-");
                //    newStr = newStr.Substring(0, newStr.Length - 5);
                //    if (d.Name.IndexOf("__") < 0)
                //    {
                //        Conditions += c.Name + ">=\"" + newStr + "\" and ";

                //    }
                //    else
                //        Conditions += c.Name.Substring(0, c.Name.Length - 1) + "<=\"" + newStr + "\" and ";

                //}
            }
            if (Conditions.Length > 5)
               {
                   Conditions = Conditions.Substring(4);
                  // Conditions = Conditions.Substring(0, Conditions.Length - 5);
               }

            return Conditions;
        }

        public void Query()
        {
            

        }




        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //全选
            if (checkBox1.Checked) { 
                if(this.dgvT2_11.RowCount>0)
                    for (int i = 0; i < this.dgvT2_11.RowCount; i++) {
                        this.dgvT2_11.Rows[i].Cells[0].Value = true;
                    }
            
            }else 
            {
                if (this.dgvT2_11.RowCount > 0)
                    for (int i = 0; i < this.dgvT2_11.RowCount; i++)
                    {
                        this.dgvT2_11.Rows[i].Cells[0].Value = false;
                    }
            
            }
        }

        private void btnShowMap_Click(object sender, EventArgs e)
        {
            string ids = "";
            IEnvelope newdisp = (IEnvelope)new Envelope();
            bool findflag = false;

            try
            {
                ILayer pLayer = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl, "企业范围");
              
                for (int i = 0; i < dgvT2_11.Rows.Count; i++)
                {
                    if (this.dgvT2_11.Rows[i].Cells[0].Value == null)
                        continue;
                    if (this.dgvT2_11.Rows[i].Cells[0].Value.ToString().ToLower()=="false")
                    {
                        continue;
                    }
                    try
                    {
                        ids += "," + this.dgvT2_11.Rows[i].Cells[2].Value.ToString();
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex.Message);
                        return;
                    }
                }
                if (ids == "")
                {
                    MessageBox.Show("请先勾选定位企业！");
                }
                else
                {
                    List<IFeature> pGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", ids.Substring(1), ",", ref newdisp, ref Geos);

                    if (Geos.Count == 0)
                        MessageBox.Show("没有找到定位企业，请与管理员联系核实数据！");
                    else
                        LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("请核实数据!");
            }
        }
               


          public void refdgvT2_11(string retShowCells) {
           string[] retShowCell = null;
            if (retShowCells.Length > 0)
            {
                retShowCell = retShowCells.Split(new char[] { ',', ',' });
            }
            if (retShowCells.Count() > 0 )
            {
                for (int i = 0; i < this.dgvT2_11.Columns.Count; i++)
                {
                    this.dgvT2_11.Columns[i].Visible = false;

                }

                for (int i = 0; i < retShowCell.Count() - 1; i++)
                {
                    dgvT2_11.Columns[retShowCell.GetValue(i).ToString()].Visible = true;
                }
            }
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (objid == 0)
            {
                MessageBox.Show("请首选选择企业");
            }
            else
            {
                frmAlarmQuery obj = new frmAlarmQuery(objid);
                FormSkin.ShowForm(obj);
            }
        }

        private void dgvT2_11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            objid= Convert.ToInt32(this.dgvT2_11.Rows[this.dgvT2_11.CurrentCell.RowIndex].Cells[1].Value);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            FormSkin.MouseMoveForm(this.Handle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (Geos.Count > 0)
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, this.Geos);
            else
                MessageBox.Show("请首先定位企业，然后高亮显示！");
        }

        private void frmComplexQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }
    }
}


