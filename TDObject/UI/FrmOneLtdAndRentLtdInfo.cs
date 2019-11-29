using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Dynamic;
using System.Text;
using log4net;


using SunMvcExpress.Dao;
using TDObject.UI;
using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;

using QyTech.ArcGis;

using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;

using System.Net;
using WTGeoWeb.BLL;
using TDObject.IdentifyTool;
using System.Data.Objects.DataClasses;


using ESRI.ArcGIS.Output;

using System.Drawing.Printing;
using TDObject;

namespace TDObject.UI
{
    public partial class FrmOneLtdAndRentLtdInfo : QyTech.SkinForm.qyFormWithTitle
    {
        private string dkbh;
        List<LtdPhoto> photos;
        int CurrPhotoNo = 0;
    

        /// <summary>
        /// 用于从列表中或鼠标单击中根据地块来显示信息
        /// </summary>
        /// <param name="dkbm"></param>
        public FrmOneLtdAndRentLtdInfo(string dkbm)
        {
            InitializeComponent();
            dkbh = dkbm;
            this.Title = "企业信息";
        }

        /// <summary>
        /// 用于在企业基础信息处调用单独显示照片
        /// </summary>
        /// <param name="Id"></param>
        public FrmOneLtdAndRentLtdInfo(List<LtdPhoto> photoes)
        {
            InitializeComponent();

            photos = photoes;
            dkbh = "";// photos[0].SSDKBM;
            this.Height = this.Height - 270;
            this.Title = "用地照片信息";
            this.dgvT2_12.Visible = false;
        }

        private void FrmOneLtdAndRentLtdInfo_Load(object sender, EventArgs e)
        {
            try
            {
                if (dkbh != "")
                {
                    dgvT2_11.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle; ;
                    dgvT2_11.Columns.Clear();
                    dgvT2_12.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle; ;
                    dgvT2_12.Columns.Clear();
                    //this.Size =new Size(SystemInformation.WorkingArea.Width,400);
                    List<QyTech.Auth.Dao.bsFunField> CurrFunFields;
                    string sqlOrderby = "序号";
                    string sqlwhere = " 单位 in (select 纳税人名称 from bsltdinfo where 地块编号 = '" + dkbh + "' and 租赁企业否=0)";
                    System.Data.DataTable CurrDt = QyTech.SQLDA.SqlUtil.RefreshDbTable(dgvT2_11, MainForm.sqlConn, "t企业基础数据", sqlwhere, sqlOrderby, out CurrFunFields);


                    sqlwhere = " 单位 in (select 纳税人名称 from bsltdinfo where 地块编号 ='" + dkbh + "' and 租赁企业否=1)";
                    QyTech.SQLDA.SqlUtil.RefreshDbTable(dgvT2_12, MainForm.sqlConn, "t企业基础数据", sqlwhere, sqlOrderby, out CurrFunFields);

                    //List<z租赁企业信息表> zlobjs = MainForm.EM.GetListNoPaging<z租赁企业信息表>("DKBH='" + dkbh + "'", "");

                    //dgvT2_12.AutoGenerateColumns = false;
                    //dgvT2_12.DataSource = zlobjs;
                    photos = BLL.CommSetting.EM.GetListNoPaging<LtdPhoto>("SSDKBM='" + dkbh + "' and PhotoType=1", "PICTURE");

                }

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
         }
        private void FrmOneLtdAndRentLtdInfo_Shown(object sender, EventArgs e)
        {
            CurrPhotoNo = 0;
            if (photos.Count > 0)
            {
                CurrPhotoNo = 1;
                DispImg();
            }
            else
            {
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\noimage.jpg");
                this.label1.Text = "无照片信息";
            }
            textBox1.Text = CurrPhotoNo.ToString() + "/" + photos.Count.ToString();

        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvT2_12_MouseMove(object sender, MouseEventArgs e)
        {
            //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }


        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo != 1)
                {
                    CurrPhotoNo = 1;
                    DispImg();
                }
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo > 1)
                {
                    CurrPhotoNo -= 1;
                    DispImg();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo < photos.Count)
                {
                    CurrPhotoNo += 1;
                    DispImg();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo != photos.Count)
                {
                    CurrPhotoNo = photos.Count;
                    DispImg();
                }
            }
        }
        private void DispImg()
        {
            try
            {
                textBox1.Text = CurrPhotoNo.ToString() + "/" + photos.Count.ToString();

                string filename = photos[CurrPhotoNo - 1].PICTURE;

                //timer1.Interval = 200;
                //timer1.Start();
                pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.112.245.147:8080/Wjkfq_gis/Uploads/" + filename).GetResponse().GetResponseStream());
                //timer1.Stop();

                richTextBox1.Text = "      " + photos[CurrPhotoNo - 1].SSQYMC + "\r\n\r\n    " + photos[CurrPhotoNo - 1].PicMemo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到图片，可能已被删除！");
                pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\noimage.jpg");
            }
        }

       
    }
}
