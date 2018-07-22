using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using SunMvcExpress.Dao;

namespace TDObject.UI
{
    public partial class frmLtdInfoPop : FlatForm
    {
        string dkbh_;
        public frmLtdInfoPop(string dkbh)
        {
            InitializeComponent();
            dkbh_ = dkbh;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLtdInfoPop_Load(object sender, EventArgs e)
        {
            try
            {
                企业范围 ltdobj = BLL.CommSetting.EM.GetBySql<企业范围>("DKBH='" + dkbh_ + "'");

                List<z租赁企业信息表> zlobjs = BLL.CommSetting.EM.GetListNoPaging<z租赁企业信息表>("DKBH='" + dkbh_ + "'", "");

                label1.Text = "用地企业名称：" + ltdobj.YDQYMC;
                label2.Text = "租赁企业情况：租赁企业数量   " + zlobjs.Count.ToString() + "家";

                label8.Text = ltdobj.ZDMJ.ToString() + label8.Text;
                label9.Text = ltdobj.JZZDMJ.ToString() + label8.Text;
                label10.Text = ltdobj.JZMJ.ToString() + label8.Text;
                //label11.Text = ltdobj.ZDMJ.ToString() + label8.Text;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
