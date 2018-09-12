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
    public partial class frmLtdInfoPop : QyTech.SkinForm.qyForm
    {
        string dkbh_;
        int x=1000, y=50;
        public frmLtdInfoPop(string dkbh,int X,int Y)
        {
            InitializeComponent();
            dkbh_ = dkbh;
            x = X;
            y = Y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmLtdInfoPop_Deactivate(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void frmLtdInfoPop_Load(object sender, EventArgs e)
        {
            try
            {
                this.Location = new Point(x, y);
                企业范围 ltdobj = BLL.CommSetting.EM.GetBySql<企业范围>("DKBH='" + dkbh_ + "'");

                List<vwLtdJcSj> zlobjs = BLL.CommSetting.EM.GetListNoPaging<vwLtdJcSj>("地块编号='" + dkbh_ + "'", "");

                label1.Text = "用地企业名称：" + ltdobj.YDQYMC;
                label2.Text = "租赁企业情况：租赁企业数量   " + zlobjs.Count.ToString() + "家";

                label8.Text = ltdobj.ZDMJ.ToString() + label8.Text;
                label9.Text = ltdobj.JZZDMJ.ToString() + label8.Text;
                label10.Text = ltdobj.JZMJ.ToString() + label8.Text;
                //label11.Text = ltdobj.ZDMJ.ToString() + label8.Text;

                //加载图片
                //先查看是否有该用地企业是否有图片，有则显示
                List<LtdPhoto> ltds = MainForm.EM.GetListNoPaging<LtdPhoto>("SSQYMC='"+ ltdobj.YDQYMC+"'", "OBJECTID desc");
                if (ltds.Count > 0)
                {
                    string filename = ltds[0].PICTURE;
                    pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + filename).GetResponse().GetResponseStream());
                    splitContainer1.SplitterDistance = 120;
                    
                }
                else
                {
                    splitContainer1.SplitterDistance = 0;
                    this.Width -= 120;
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
    }
}
