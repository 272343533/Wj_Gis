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
using ESRI.ArcGIS.DataSourcesGDB;
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
    public partial class FrmOneLtdAndRentLtdInfo : QyTech.SkinForm.qyForm
    {
        private string dkbh;

        List<LtdPhoto> photos;
        int CurrPhotoNo = 0;
    


        public FrmOneLtdAndRentLtdInfo(string dkbm)
        {
            InitializeComponent();
            dkbh = dkbm;
        }

        private void FrmOneLtdAndRentLtdInfo_Load(object sender, EventArgs e)
        {
            try
            {
                dgvT2_11.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                dgvT2_12.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                //this.Size =new Size(SystemInformation.WorkingArea.Width,400);
                List<企业范围> objs = MainForm.EM.GetListNoPaging<企业范围>("DKBH='" + dkbh + "'", "");

                dgvT2_11.AutoGenerateColumns = false;
                dgvT2_11.DataSource = objs;

                List<z租赁企业信息表> zlobjs = MainForm.EM.GetListNoPaging<z租赁企业信息表>("DKBH='" + dkbh + "'", "");

                dgvT2_12.AutoGenerateColumns = false;
                dgvT2_12.DataSource = zlobjs;


                photos = BLL.CommSetting.EM.GetListNoPaging<LtdPhoto>("SSDKBM='" + dkbh + "' and PhotoType=1", "PICTURE");
                if (photos.Count > 0)
                {
                    CurrPhotoNo = 1;
                }
                textBox1.Text = "0/" + photos.Count.ToString();

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
         }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvT2_12_MouseMove(object sender, MouseEventArgs e)
        {
            QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
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
                pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + filename).GetResponse().GetResponseStream());
                //timer1.Stop();

                richTextBox1.Text = "      " + photos[CurrPhotoNo - 1].SSQYMC + "\r\n\r\n    " + photos[CurrPhotoNo - 1].PicMemo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到图片数据！");
            }
        }

        private void FrmOneLtdAndRentLtdInfo_Shown(object sender, EventArgs e)
        {
            if (photos.Count > 0)
                DispImg();
        }
    }
}
