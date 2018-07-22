using QyTech.Json;
using SunMvcExpress.Dao;
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
using TDObject.BLL;

namespace TDObject.UI
{
    public partial class frmLtdInfo : Form
    {

        log4net.ILog log = log4net.LogManager.GetLogger("frmLtdInfo");

        public 土地现状数据 ltdObj;
        public frmLtdInfo(土地现状数据 obj)
        {
            InitializeComponent();

            ltdObj = obj;
        }

        private void frmLtdInfo_Load(object sender, EventArgs e)
        {
            try
            {
                //数据显示
                this.txtName.Text = ltdObj.企业名称;
                this.txtDkbm.Text = ltdObj.地块编码.ToString();
                this.txtDlmc.Text = ltdObj.地类名称;


                this.txtBuildingArea.Text =(ltdObj.地块附属建筑面积==null?"":Math.Round((decimal)ltdObj.地块附属建筑面积, 2).ToString()) + "      ㎡";
                this.txtFloorArea.Text = (ltdObj.地块附属建筑占地面积 == null ? "" : Math.Round((decimal)ltdObj.地块附属建筑占地面积, 2).ToString()) + "      ㎡";
                this.txtRegionArea.Text = (ltdObj.占地面积 == null ? "" : Math.Round((decimal)ltdObj.占地面积, 2).ToString()) + "      ㎡"; ;


                this.txtyqymc.Text = ltdObj.原企业名称 == null ? "" : ltdObj.原企业名称.ToString();
                this.txtYddwmc.Text = ltdObj.用地单位名称 == null ? "" : ltdObj.用地单位名称;

                this.TDZLQYMC.Text = ltdObj.土地租赁企业名称 == null ? "" : ltdObj.土地租赁企业名称.ToString();
                this.SSXZCMC.Text = ltdObj.所属行政村名称 == null ? "" : ltdObj.所属行政村名称.ToString();
                this.KFSMC.Text = ltdObj.开发商名称 == null ? "" : ltdObj.开发商名称;

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
            }
            

        }
    }
}
