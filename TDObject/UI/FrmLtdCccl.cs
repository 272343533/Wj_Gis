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
using QyTech.Json;
using TDObject.controls;

namespace TDObject.UI
{
    public partial class FrmLtdCccl : Form
    {
        private 企业范围 LtdXx;
        private 租赁企业信息表 LtdZlXx;


        private int _ltdType = 0;//0:不使用 1：企业范围 2:租赁企业
        private int _ltd_objid; //租赁企业id，企业范围id

        //0:不使用 1：企业范围 2:租赁企业
        public FrmLtdCccl(int ltdType,int objectid)
        {
            InitializeComponent();

            _ltdType = ltdType;
            _ltd_objid = objectid;

            if (ltdType == 1)
            {
                LtdXx = MainForm.EM.GetByPk<企业范围>("OBJECTID", objectid);
            }
            else if (ltdType==2)
            {
                LtdZlXx = MainForm.EM.GetByPk<租赁企业信息表>("OBJECTID", objectid);
            }

            _ltdType = ltdType;
            _ltd_objid = objectid;
        }
        
       

        private void button1_Click(object sender, EventArgs e)
        {
             //保存租赁企业修改信息
            try
            {
                List<LtdProblem> uis = new List<LtdProblem>((BindingList<LtdProblem>)this.dgvT2_21.DataSource);

                //BindingList<LtdProblem> Blist = (BindingList<LtdProblem>)this.dgvT2_21.DataSource;


                //List<LtdProblem> list1 = new List<LtdProblem>(Blist);


                //List<LtdProblem> modelList = new List<LtdProblem>((BindingList<LtdProblem>)this.dgvT2_21.DataSource);

                foreach (LtdProblem obj in uis)
                {

                    //string url = MainForm.URI + "lyRemoteServ/GetOneZlqyxxData?id=" + obj.OBJECTID.ToString();
                    //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                    //LtdProblem dbobj = JsonHelper.DeserializeJsonToObject<LtdProblem>(ret);
                    //bsUser dbobj = EntityManager<bsUser>.GetByPk<bsUser>("bsU_Id",ui.bsU_Id);
                    LtdProblem dbobj = MainForm.EM.GetByPk<LtdProblem>("OBJECTID", obj.OBJECTID);
                 
                    dbobj.查处截止日期 = obj.查处截止日期;
                    dbobj.查处类型 = obj.查处类型;
                    dbobj.查处批注内容 = obj.查处批注内容;
                    dbobj.查处起始日期 = obj.查处起始日期;
                    dbobj.撤销日期 = obj.撤销日期;
                    dbobj.批注日期 = obj.批注日期;
                    dbobj.所在行政村 = obj.所在行政村;
                    dbobj.问题企业名称 = obj.问题企业名称;
                    dbobj.序号 = obj.序号;
                    dbobj.坐落 = obj.坐落;



                    //string strui = JsonHelper.SerializeObject<LtdProblem>(dbobj, null);
                    //url = MainForm.URI + "lyRemoteServ/UdpZlqyxxbData?info=" + strui;
                    //ret = AsyncHttp.CommFun.GetRemoteJson(url);

                    string ret = MainForm.EM.Modify<LtdProblem>(dbobj);

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

        private void button3_Click(object sender, EventArgs e)
        {

            try
            {
                LtdProblem obj = new LtdProblem();
                obj.序号 = "";
                obj.查处截止日期 = DateTime.Today.AddMonths(1);
                obj.查处类型 = "";
                obj.查处批注内容 = "";
                obj.查处起始日期 = DateTime.Today;
                obj.撤销日期 = null;
                obj.批注日期 = DateTime.Today;
                obj.所在行政村 = _ltdType == 1 ? LtdXx.所属行政村名称 : LtdZlXx.所属行政村名称;
                obj.问题企业名称 = _ltdType==1?LtdXx.用地单位名称:LtdZlXx.租赁企业名称;
                obj.坐落 = _ltdType == 1 ? LtdXx.土地座落 : LtdZlXx.土地座落;

                string ret = MainForm.EM.Add<LtdProblem>(obj);
              
                //string strui = JsonHelper.SerializeObject<LtdProblem>(obj, null);
                //string url = MainForm.URI + "lyRemoteServ/AddUserData?userinfo=" + strui;
                //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                if (ret != "")
                    MessageBox.Show(ret);
                else
                    RefreshMainInfoDgv();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }
        }

        private void FrmLtdCccl_Load(object sender, EventArgs e)
        {
            //CalendarColumn col = new CalendarColumn();
            //this.dgvT2_21.Columns.Add(col);
            ////this.dgvT2_21.RowCount = 5;
            //foreach (DataGridViewRow row in this.dgvT2_21.Rows)
            //{
            //    row.Cells[dgvT2_21.Columns.Count-1].Value = DateTime.Now;
            //}
            if (_ltdType == 0)
            {
                this.button1.Visible = false;
                this.button2.Visible = true;
                this.button3.Visible = false;
            }
            else
            {
                this.button1.Visible = true;
                this.button2.Visible = false;
                this.button3.Visible = true;
            }
            RefreshMainInfoDgv();
        }
        private void RefreshMainInfoDgv()
        {
            try
            {

                //string url = MainForm.URI + "lyRemoteServ/GetAllUserInfoData";
                //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                //List<租赁企业信息表> dbobjs = JsonHelper.DeserializeJsonToList<租赁企业信息表>(ret);

                List<LtdProblem> dbobjs;
                string queryrights = "";
                if (MainForm.LoginUser.bsO_RightsCode == "")
                    queryrights = "";
                else
                    queryrights = "   and 所在行政村 like '%" + MainForm.LoginUser.bsO_Righrs + "%'";

                if (_ltdType==0)
                {
                    dbobjs = MainForm.EM.GetListNoPaging<LtdProblem>("撤销日期 is null" + queryrights, "");
                }
                else
                {
                    dbobjs = MainForm.EM.GetListNoPaging<LtdProblem>("问题企业名称='" + (_ltdType == 1 ? LtdXx.用地单位名称 : LtdZlXx.租赁企业名称) + "'" + queryrights, "");
                }
                //users = EntityManager<bsUser>.GetListNoPaging<bsUser>("", "bsR_Name,LoginName");

                BindingList<LtdProblem> bs_objs = new BindingList<LtdProblem>(dbobjs);
                this.dgvT2_21.AutoGenerateColumns = false;

                dgvT2_21.DataSource = bs_objs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgvT2_21.CurrentCell.RowIndex >= 0)
            {
                int oid = Convert.ToInt32(dgvT2_21.Rows[dgvT2_21.CurrentCell.RowIndex].Cells[0].Value);

                LtdProblem dbobj = MainForm.EM.GetByPk<LtdProblem>("OBJECTID", oid);



                dbobj.撤销日期 = DateTime.Today;


                string ret = MainForm.EM.Modify<LtdProblem>(dbobj);

                if (ret != "")
                {
                    MessageBox.Show(ret);

                    dgvT2_21.Rows[dgvT2_21.CurrentCell.RowIndex].Cells[0].Value = DateTime.Today;
                }
                else
                {
                    MessageBox.Show("保存成功！");

                }
            }
            
        }

     
    }
}
