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
using QyTech.Core.BLL;

namespace TDObject.UI
{
    public partial class FrmLtdZlqyxx : QyTech.SkinForm.qyForm
    {
        private 企业范围 LtdXx;
        public MainForm parentform;

        string DKBH;
        public FrmLtdZlqyxx(int objid)
        {
             InitializeComponent();

             LtdXx = MainForm.EM.GetByPk<企业范围>("OBJECTID", objid);

             DKBH = LtdXx.DKBH;
        }
        public FrmLtdZlqyxx(string dkbh)
        {
            InitializeComponent();

            DKBH = dkbh;
        }
        //private void button3_Click(object sender, EventArgs e)
        //{

        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    //保存租赁企业修改信息
        //    try
        //    {
        //        List<z租赁企业信息表> uis = new List<z租赁企业信息表>((BindingList<z租赁企业信息表>)this.dgvT2_12.DataSource);

        //        foreach (z租赁企业信息表 ui in uis)
        //        {
                    
        //            //string url = MainForm.App_URI + "lyRemoteServ/GetOneZlqyxxData?id=" + ui.OBJECTID.ToString();
        //            //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
        //            //z租赁企业信息表 dbobj = JsonHelper.DeserializeJsonToObject<z租赁企业信息表>(ret);
        //            z租赁企业信息表 dbobj = MainForm.EM.GetByPk<z租赁企业信息表>("OBJECTID", ui.OBJECTID);
                  
        //            //dbobj.产业类型 = ui.产业类型;
        //            //dbobj.产值 = ui.产值;
        //            //dbobj.抵押情况 = ui.抵押情况;
        //            //dbobj.地块编码 = ui.地块编码;
        //            //dbobj.地块附属建筑面积 = ui.地块附属建筑面积;
        //            //dbobj.地块附属建筑占地面积 = ui.地块附属建筑占地面积;
        //            //dbobj. 租赁企业名称= ui.租赁企业名称;
        //            //dbobj.租用面积 = ui.租用面积;
        //            //dbobj.用地企业名称 = ui.用地企业名称;
        //            //dbobj. 土地座落= ui.土地座落;
        //            //dbobj.土地证号 = ui.土地证号;
        //            //dbobj. 土地使用者名称= ui.土地使用者名称;
        //            //dbobj.土地发证面积 = ui.土地发证面积;
        //            //dbobj.实际占地面积 = ui.实际占地面积;


        //            string ret = MainForm.EM.Modify<z租赁企业信息表>(dbobj);

        //            //string strui = JsonHelper.SerializeObject<z租赁企业信息表>(dbobj, null);
        //            //url = MainForm.App_URI + "lyRemoteServ/UdpZlqyxxbData?info=" + strui;
        //            //ret = AsyncHttp.CommFun.GetRemoteJson(url);
        //            if (ret != "")
        //                MessageBox.Show(ret);
        //            // EntityManager<bsUser>.Modify(dbobj);
        //        }
        //        MessageBox.Show("保存成功！");
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("保存失败！" + ex.Message);
        //    }
        //}

        private void FrmLtdZlqyxx_Load(object sender, EventArgs e)
        {
            try
            {
                dgvT2_12.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                RefreshMainInfoDgv();
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshMainInfoDgv()
        {
            try
            {

                //string url = MainForm.App_URI + "lyRemoteServ/GetAllUserInfoData";
                //string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                //List<z租赁企业信息表> dbobjs = JsonHelper.DeserializeJsonToList<z租赁企业信息表>(ret);

                //users = EntityManager<bsUser>.GetListNoPaging<bsUser>("", "bsR_Name,LoginName");
                List<vwLtdJcSj> dbobjs = MainForm.EM.GetListNoPaging<vwLtdJcSj>("地块编号='" + DKBH + "'", "");
               
                BindingList<vwLtdJcSj> bs_objs = new BindingList<vwLtdJcSj>(dbobjs);
                this.dgvT2_12.AutoGenerateColumns = false;

                dgvT2_12.DataSource = bs_objs;

                label1.Text += bs_objs.Count.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int objid = (int)(dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[0].Value);
                string ltdname = dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
            //FrmLtdCccl obj = new FrmLtdCccl(2,objid);
            //obj.ShowDialog();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FrmLtdZlqyxx_MouseMove(object sender, MouseEventArgs e)
        {
            //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

    }
}
