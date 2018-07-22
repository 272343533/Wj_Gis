using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SunMvcExpress.Dao;
using QyTech.Core;
using QyTech.Core.BLL;
using QyTech.Core.BLL;
using QyTech.Json;

namespace TDObject.UI
{
    public partial class frmUserMana : FlatForm
    {


        Guid currentUiid;
        List<bsUser> users = new List<bsUser>();

        private int CurrRowIndex=-1;

        private bool IsTreeNodeRefresh = false;

        public frmUserMana()
        {
            InitializeComponent();
        }

        private void frmUserMana_Load(object sender, EventArgs e)
        {
            //this.dgvEmp.DataError += delegate(dgvEmp, DataGridViewDataErrorEventArgs e) { };
           // this.dgvEmp.Columns[5].DataPropertyName = "bsR_Name";
            treeOrg.Nodes[0].ExpandAll();
            this.treeOrg.SelectedNode = treeOrg.Nodes[0];

          //  RefreshUserInfoDgv(treeOrg.Nodes[0].Text);

            
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
          
            //dgvEmp.AllowUserToAddRows = !dgvEmp.AllowUserToAddRows;
            try
            {
                if (treeOrg.SelectedNode == treeOrg.Nodes[0])
                {
                    MessageBox.Show("请选择具体部门！");
                    return;
                }
                bsUser ui = new bsUser();
                ui.bsU_Id =Guid.NewGuid();
                ui.bsO_Name = treeOrg.SelectedNode.Text;
                ui.Name = "新增用户";
                 ui.LoginName = "";
                ui.bsO_Righrs = "吴江经济技术开发区";
                ui.Pwd ="123456";
                ui.bsR_Name ="浏览人员";

                string strui = JsonHelper.SerializeObject<bsUser>(ui, null);
                string url = MainForm.URI + "lyRemoteServ/AddUserData?userinfo=" + strui;
                string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                if (ret != "")
                    MessageBox.Show(ret);
                else
                    RefreshUserInfoDgv(this.treeOrg.SelectedNode.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }
        }

        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            try
            {
                List<bsUser> uis = dgvEmp.DataSource as List<bsUser>;

                foreach (bsUser ui in uis)
                {
                    if (ui.LoginName == null || ui.Name == null || ui.LoginName.Trim() == "" || ui.Name.Trim() == "")
                    {
                        MessageBox.Show("用户的登录名和姓名不能为空，请检查！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                    }


                    string url = MainForm.URI + "lyRemoteServ/GetOneUserData?id=" + ui.bsU_Id.ToString();
                    string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                    bsUser dbobj = JsonHelper.DeserializeJsonToObject<bsUser>(ret);
                    //bsUser dbobj = EntityManager<bsUser>.GetByPk<bsUser>("bsU_Id",ui.bsU_Id);

                    dbobj.bsR_Name = ui.bsR_Name;
                    dbobj.LoginName = ui.LoginName;
                    dbobj.Name = ui.Name;
                    dbobj.bsO_Righrs = ui.bsO_Righrs;
                    if (dbobj.bsO_Id == null)
                    {
                        dbobj.bsO_Id = Guid.Parse("8E0CEA4C-1F0E-4E8B-AB16-960FF9570C8B");
                        dbobj.bsO_Name = "望亭镇";
                    }
                    //if (dbobj.bsO_Id

                    string strui = JsonHelper.SerializeObject<bsUser>(dbobj, null);
                    url = MainForm.URI + "lyRemoteServ/UdpUserData?userinfo=" + strui;
                    ret = AsyncHttp.CommFun.GetRemoteJson(url);
                    if (ret != "")
                        MessageBox.Show(ret);
                   // EntityManager<bsUser>.Modify(dbobj);
                }
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, System.EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("确定要删除吗？", "提示", MessageBoxButtons.YesNo))
            {
                try
                {
                    //String ret =EntityManager<bsUser>.Delete<bsUser>("bsU_Id",currentUiid);
                    string url = MainForm.URI + "lyRemoteServ/DelUserData?id=" + currentUiid.ToString();
                    string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                   
                    if (ret=="")
                        MessageBox.Show("删除成功！");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("删除失败！" + ex.Message);
                }
                RefreshUserInfoDgv(this.treeOrg.SelectedNode.Text);
            }
        }

        private void RefreshUserInfoDgv(string bsO_Name)
        {
            try
            {
                //string url = MainForm.URI + "lyRemoteServ/GetAllUserInfoData";
                //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                //users = JsonHelper.DeserializeJsonToList<bsUser>(ret);
               if (bsO_Name==this.treeOrg.Nodes[0].Text)
                   users = MainForm.EM.GetListNoPaging<bsUser>("", "bsR_Name,LoginName");
               else
                   users = MainForm.EM.GetListNoPaging<bsUser>("bsO_Name='"+bsO_Name+"'", "bsR_Name,LoginName");
                List<bsUser> tmps = new List<bsUser>();
                foreach (bsUser bsu in users)
                {
                    if (bsu.LoginName != "admin")
                    {
                        tmps.Add(bsu);
                    }
                }
                BindingList<bsUser> bs_objs = new BindingList<bsUser>(tmps);
                this.dgvEmp.AutoGenerateColumns = false;

                dgvEmp.DataSource = tmps;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }

        }


        private string SaveEmp(Guid bsU_Id, string name, string loginname, string operrights, string orgrights)
        {
            if (loginname == null || name == null || loginname.Trim() == "" || name.Trim() == "")
            {
                return "用户的登录名和姓名不能为空，请检查！";
            }

            try
            {
                string url = MainForm.URI + "lyRemoteServ/GetOneUserData?id=" + bsU_Id.ToString();
                string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                bsUser dbobj = JsonHelper.DeserializeJsonToObject<bsUser>(ret);
                //bsUser dbobj = EntityManager<bsUser>.GetByPk<bsUser>("bsU_Id",ui.bsU_Id);

                dbobj.bsR_Name = operrights;
                dbobj.LoginName = loginname;
                dbobj.Name = name;
                dbobj.bsO_Righrs = orgrights;
                if (dbobj.bsO_Id == null)
                {
                    dbobj.bsO_Id = Guid.Parse("8E0CEA4C-1F0E-4E8B-AB16-960FF9570C8B");
                    dbobj.bsO_Name = "吴江经济开发区";
                }
                //if (dbobj.bsO_Id



                string strui = JsonHelper.SerializeObject<bsUser>(dbobj, null);
                url = MainForm.URI + "lyRemoteServ/UdpUserData?userinfo=" + strui;
                ret = AsyncHttp.CommFun.GetRemoteJson(url);
                return "保存成功！";
            }
            catch (Exception ex)
            {
                return "保存失败,请检查数据正确性，并保证网络正常。!(" + ex.Message + ")";
            }
        }

        private void dgvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CurrRowIndex=e.RowIndex;
            currentUiid = Guid.Parse(dgvEmp.Rows[e.RowIndex].Cells[1].Value.ToString());

            if (e.ColumnIndex ==0)
            {
              
                    string name=dgvEmp.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string loginname=dgvEmp.Rows[e.RowIndex].Cells[4].Value.ToString();
                    string operrights=dgvEmp.Rows[e.RowIndex].Cells[5].Value.ToString();
                    string orgrights=dgvEmp.Rows[e.RowIndex].Cells[6].Value.ToString();

                    string ret=SaveEmp(currentUiid,name, loginname, operrights, orgrights);

                    if (ret != "")
                        MessageBox.Show(ret);
               
            }
            //else
            //{
            //    IsTreeNodeRefresh = true;
            //    this.comboBox1.Text = this.dgvEmp.Rows[e.RowIndex].Cells[4].Value.ToString();
            //    string strrights = this.dgvEmp.Rows[e.RowIndex].Cells[5].Value.ToString();
            //    foreach (TreeNode tn in treeView1.Nodes)
            //    {
            //        RefreshTreeRights(tn, strrights);
            //    }

            //    IsTreeNodeRefresh = false;
              
            //}
        }

        private void RefreshTreeRights(TreeNode tn,string rights)
        {
           
                tn.Checked = false;
                if (rights.Contains(tn.Text))
                {
                    tn.Checked = true;
                }
                foreach (TreeNode sub in tn.Nodes)
                {
                    RefreshTreeRights(sub, rights);
                }
            
        }
        private void RefreshTreeRights(TreeNode tn, bool checkflag)
        {

            tn.Checked = checkflag;
            foreach (TreeNode sub in tn.Nodes)
            {
                RefreshTreeRights(sub, checkflag);
            }
        }
        private void RefreshTreeRightsReverse(TreeNode tn)
        {

            tn.Checked = !tn.Checked;
            foreach (TreeNode sub in tn.Nodes)
            {
                RefreshTreeRightsReverse(sub);
            }
        }
        private void dgvEmp_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);

            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

 
        }

 
        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (!IsTreeNodeRefresh)
                return;
            foreach (TreeNode tn in e.Node.Nodes)
            {
                tn.Checked = e.Node.Checked;
            }
        }

    

    

     

        private void dgvEmp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dgvEmp_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }

        private void treeOrg_AfterSelect(object sender, TreeViewEventArgs e)
        {
            RefreshUserInfoDgv(this.treeOrg.SelectedNode.Text);
        }
    }
}
