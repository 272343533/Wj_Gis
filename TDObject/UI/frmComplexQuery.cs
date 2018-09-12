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


    public partial class frmComplexQuery : QyTech.SkinForm.qyForm
    {

        IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
        List<IGeometry> Geos = new List<IGeometry>();

        Dictionary<string, string> comboitems = new Dictionary<string, string>();
      

        int objid=0 ;//= Convert.ToInt32(this.dgvT2_11.Rows[this.dgvT2_11.CurrentCell.RowIndex].Cells[1].Value);

        public frmComplexQuery()
        {
            InitializeComponent();
        }



       
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                this.button1.Enabled = false;
                this.gbConditon.Controls.Clear();


                string Querys1 = string.Empty;//保存查询条件
                int SelectNum = -1;
                //先创建年月条件
                List<string> items = TDObject.DAOBLL.ImportTBll.GetYearMonths("t企业基础数据");
                string stritems = "";
                for (int it = 0; it < items.Count; it++)
                {
                    stritems += "," + items[it];
                }
                if (stritems.Length > 0) { stritems = stritems.Substring(1); }

                SelectNum++;
                int LocationX = SelectNum % 4 * 250;
                int LocationY = 10 + SelectNum / 4 * 45;
                ComboBox cb=QyTech.SkinForm.UICreate.UICreate.CreateCombobox(gbConditon, "年月", "年月", stritems, "", LocationX, LocationY, "");
                if (cb.Items.Count > 1)
                    cb.SelectedIndex = 1;

                CreateDynConditionDisplay(treeView1.Nodes[0], ref SelectNum, ref Querys1);

                if (SelectNum > -1)
                {
                    this.button1.Enabled = true;
                }
                //foreach (TreeNode tn in this.treeView1.Nodes[0].Nodes)
                //{
                //    if (tn.Checked)
                //    {
                //        this.button1.Enabled = true;
                //        SelectNum++;
                //        LocationX = SelectNum % 4 * 250;
                //        LocationY = 10 + SelectNum / 4 * 45;

                //        //string cname = tn.Name.Substring(3);

                //        CreateDynConditionDisplay(tn.Tag as bsDynCondition, LocationX, LocationY);
                //        Querys1 += "," + tn.Text;

                //        panel3.Height = 90 + SelectNum / 4 * 45;

                //    }

                //}
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
        private void CreateDynConditionDisplay(TreeNode tn,ref int SelectNum, ref string Querys1)
        {
            int LocationX, LocationY;

            if (tn.Nodes.Count == 0)
            {
                if (tn.Checked)
                {
                    SelectNum++;
                    LocationX = SelectNum % 4 * 250;
                    LocationY = 10 + SelectNum / 4 * 45;

                    CreateDynConditionDisplay(tn.Tag as bsDynCondition, LocationX, LocationY);
                    Querys1 += "," + tn.Text;

                    panel3.Height = 90 + SelectNum / 4 * 45;

                }
            }
            else
            {
                foreach(TreeNode stn in tn.Nodes)
                {
                    CreateDynConditionDisplay(stn, ref SelectNum,ref Querys1);
                }
            }
        }

        private void SetLastQuery(string query,TreeNode ptn)
        {
            
            if (query.Contains("," + ptn.Text))
            {
                ptn.Checked = true;
            }
            else
            {
                ptn.Checked = false;
                foreach (TreeNode tn in ptn.Nodes)
                {
                    SetLastQuery(query, tn);
                }
            }
        }

        private void frmComplexStatistics_Load(object sender, EventArgs e)
        {
            try
            {
                this.dgvT2_11.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;


                //根据用户填充左侧条件列表
                List<bsDynCondition> conds = TDObject.DAOBLL.RoleRelBll.GetRightItem();
               
                RefreshTv(conds, treeView1);
                //this.treeView1.Nodes[0].Nodes.Clear();

                //foreach (bsDynCondition cond in conds)
                //{
                //    TreeNode tn = new TreeNode(cond.condName);
                //    tn.Tag = cond;
                //    if (cond.CompName!=null)
                //        tn.Name = cond.CompName;
                //    this.treeView1.Nodes[0].Nodes.Add(tn);
                //}
                this.treeView1.ExpandAll();


                string query = MainForm.LoginUser.ExComplQueryCond;
                string showCell = string.Empty;
              
                if (query != null)
                {
                    SetLastQuery(MainForm.LoginUser.ExComplQueryCond,treeView1.Nodes[0]);
                }
                if (showCell != null)
                {
                    refdgvT2_11(showCell);
                }

                button3_Click(this.button3, null);
                RefreshDgv("Id=-1");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void RefreshTv(List<bsDynCondition> objs,TreeView tv)
        {
            tv.Nodes.Clear();
            for (int i = 0; i < objs.Count; i++)
            {
                if (objs[i].PId == 0)
                {
                    TreeNode tn = new TreeNode(objs[i].condName);
                    tn.Tag =objs[i];
                    RefreshTn(objs,tn);
                    tv.Nodes.Add(tn);
                }
            }
        }
        private void RefreshTn(List<bsDynCondition> objs,TreeNode tn)
        {
            for (int i = 0; i < objs.Count; i++)
            {
                if (objs[i].PId == (tn.Tag as bsDynCondition).Id)
                {
                    TreeNode tn1 = new TreeNode(objs[i].condName);
                    tn1.Tag =objs[i];
                    RefreshTn(objs, tn1);
                    tn.Nodes.Add(tn1);
               }
            }
        }

        #region 条件创建
        private void CreateDynConditionDisplay(bsDynCondition cond, int x, int y, int labwidth = 90, int textwidth = 150)
        {
            if (cond.compType=="textbox")
            {
                CreateTextDisplay(cond.condName,cond, x, y, labwidth, textwidth);
            }
            else if (cond.compType == "combox")
            {
                CreateCombobox(cond.condName,cond.compitems, cond, x, y, labwidth, textwidth);
            }
            //else if (NumRangeFields.Contains<string>(tn.Text))
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
        }
        private void CreateTextDisplay(string labText,object tag, int x, int y, int labwidth = 90, int textwidth = 150)
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
            tb.Tag = tag;

            this.gbConditon.Controls.Add(tb);
        }
        private void CreateCombobox(string labText, string items, object tag, int x, int y, int labwidth = 90, int comboxwidth = 150)
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
            cb.Tag = tag;

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
                
                
                string Conditions = GetWhereCondition();
                

                //list = EntityManager<土地现状数据>.GetListNoPaging<土地现状数据>(Conditions,"");
                //Conditions = Conditions.Replace("%", "%%%");
                //Conditions += MainForm.LoginUserRights;
                //string detailUrl="";
                //if (Conditions!="")
                //    detailUrl = MainForm.App_URI+ "lyRemoteServ/DoComplexQuery?sqlconf=" + Conditions;
                //else
                //    detailUrl = MainForm.App_URI + "lyRemoteServ/DoComplexQuery" ;
                //string ret = AsyncHttp.CommFun.GetRemoteJson(detailUrl);
                //list = JsonHelper.DeserializeJsonToList<企业范围>(ret);

                RefreshDgv(Conditions);

            
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show("请检查查询条件：" + ex.Message);
            }
        }

        private void RefreshDgv(string conditions)
        {
            List<vwLtdJcSj> list = MainForm.EM.GetListNoPaging<vwLtdJcSj>(conditions, "");

            if (list == null)
            {
                list = new List<vwLtdJcSj>();
            }
            this.dgvT2_11.AutoGenerateColumns = true;
            this.dgvT2_11.DataSource = list;
            int index = 1;
            this.dgvT2_11.Columns[index++].Visible = false;
            this.dgvT2_11.Columns[index++].Width = 90;
            this.dgvT2_11.Columns[index++].Visible = false;
            this.dgvT2_11.Columns[index++].Width = 50;
            this.dgvT2_11.Columns[index++].Width = 40;
            this.dgvT2_11.Columns[index++].Width = 100;
            this.dgvT2_11.Columns[index++].Width = 200;
            this.dgvT2_11.Columns[index++].Width = 60;
            this.dgvT2_11.Columns[index++].Width = 60;
            this.dgvT2_11.Columns[index++].Width = 60;
            this.dgvT2_11.Columns[index++].Width = 40;
            this.dgvT2_11.Columns[index++].Width = 200;
            this.dgvT2_11.Columns[index++].Width = 200;

            this.label1.Text = "符合条件的共计" + list.Count.ToString() + "条";
        }

        //private string GetItemCondition(bsDynCondition cond, string itemtext)
        //{
        //    string Conditions = "";
        //    string itemname = cond.condName;

        //    string[] sqls = cond.Sql.Split(new char[] { '|' });
        //    int sqlindex = 0;
        //    if (cond.compType == "textbox")
        //    {
        //        Conditions += " and " + cond.Sql.Replace("@@@@", itemtext);
        //    }
        //    else if (cond.compType == "combox")
        //    {
        //        foreach (string c in cond.compitems.Split(new char[] { ',' }))
        //        {
        //            if (c == itemtext)
        //                break;
        //            sqlindex++;
        //        }


        //        if (sqlindex + 1 > sqls.Length)
        //            sqlindex = sqls.Length - 1;//没有对应的就用最后一个


        //        if ("技术中心获批级别" == itemname || itemtext == "全部")
        //            Conditions += " and " + sqls[sqlindex];
        //        else if ("智能车间,清洁生产".Contains(itemname))
        //            Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(0, 4));
                
        //        else if ("地标性企业".Contains(itemname))
        //            Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(1, itemtext.Length - 3));

        //        else if ("营业额，税收，土地盘活计划".Contains(itemname))
        //            Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext.Substring(0, itemtext.Length - 3));

        //        else
        //            Conditions += " and " + sqls[sqlindex].Replace("@@@@", itemtext);


        //    }


        //    if (itemtext.Trim() == "")
        //        return "";



        //    //if ("地块编号,纳税人识别号,行业大类,经营范围,用地单位名称,租赁单位名称,红黄牌处罚情况,标准化等级,智能工厂,安全事故情况".Contains(itemname))
        //    //    Conditions += " and "+ sqls[sqlindex].Replace("@@@@",itemtext);

           

        //    //if ("上市情况" == itemname)
        //    //{ 
        //    //    if (itemtext == "全部")
        //    //    {
        //    //        Conditions += " and (DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";
        //    //        Conditions += " or DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";
        //    //        Conditions += " or DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";
        //    //        Conditions += ")";
        //    //    }
        //    //    if (itemtext== "台资拟上市")
        //    //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐台资 where 地块编号 is not null)";

        //    //    if (itemtext == "三板挂牌")
        //    //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐三板 where 地块编号 is not null)";

        //    //    if (itemtext == "主板后备")
        //    //        Conditions += " and DKBH in (" + " select 地块编号 from t同里镇开发区上市企业台帐主版后备 where 地块编号 is not null)";
        //    //}
          
        //    return Conditions;
        //}

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
                if (c.Text != "")
                {
                    if (c is TextBox)
                    {

                        Conditions +=TDObject.DAOBLL.RoleRelBll.GetItemCondition(c.Tag as bsDynCondition, c.Text);
                    }
                    else if (c is ComboBox)
                    {
                        if (c.Name != "年月")
                            Conditions += TDObject.DAOBLL.RoleRelBll.GetItemCondition(c.Tag as bsDynCondition, c.Text);
                        else
                        {
                            string ymcondition = TDObject.DAOBLL.ImportTBll.WhereSql("t企业基础数据", c.Text);
                            Conditions += " and (" + ymcondition + ")";
                        }
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
            }
            if (Conditions.Length > 5)
               {
                   Conditions = Conditions.Substring(4);
                // Conditions = Conditions.Substring(0, Conditions.Length - 5);
                Conditions = "单位 in (select 纳税人名称 from bsLtdInfo where" + Conditions + ")";
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
                        if (this.dgvT2_11.Rows[i].Cells[2].Value != null && this.dgvT2_11.Rows[i].Cells[2].Value.ToString().Trim() != "")
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
                        if (this.dgvT2_11.Rows[i].Cells[2].Value!=null && this.dgvT2_11.Rows[i].Cells[2].Value.ToString().Trim()!="")
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
                QyTech.SkinForm.qyFormUtil.ShowForm(obj);
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
            //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Console.WriteLine("button5_Click");
            if (Geos.Count > 0)
                LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, this.Geos);
            else
                MessageBox.Show("请首先定位企业，然后高亮显示！");
        }

        private void frmComplexQuery_FormClosing(object sender, FormClosingEventArgs e)
        {
           
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void dgvT2_11_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);

        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            foreach(TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
            }
            //if (e.Node.Text == treeView1.Nodes[0].Text)
            //{
            //    foreach (TreeNode tn in e.Node.Nodes)
            //    {
            //        tn.Checked = e.Node.Checked;
            //    }
            //}
        }




    }
}


