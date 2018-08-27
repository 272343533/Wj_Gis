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

namespace TDObject.UI
{
    public partial class FrmAdd9Qyjstz : QyTech.SkinForm.qyForm
    {
        string addormodify = "add";

        t企业技术中心台账 obj_;
        public FrmAdd9Qyjstz(t企业技术中心台账 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
                this.级别.Text = obj_.级别.ToString();
                this.获评时间.Text = obj_.获评时间.ToString();
                this.镇区.Text = obj_.镇区.ToString();
                this.备注.Text = obj_.备注.ToString();
                 this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t企业技术中心台账();
            }
        }
        private void FrmAdd9Qyjstz_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                obj_.序号 = Convert.ToInt32(this.序号.Text);
                obj_.企业名称 = this.企业名称.Text;
                obj_.级别 = this.级别.Text;
                obj_.获评时间 = this.获评时间.Text;
                obj_.镇区 = this.镇区.Text;
                obj_.备注 = this.备注.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t企业技术中心台账>(obj_);
                else
                    MainForm.EM.Modify<t企业技术中心台账>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
