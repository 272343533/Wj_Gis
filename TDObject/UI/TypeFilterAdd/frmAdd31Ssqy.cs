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
    public partial class frmAdd31Ssqy : FlatForm
    {
        string addormodify = "add";

        t同里镇开发区上市企业台帐台资 obj_;
        public frmAdd31Ssqy(t同里镇开发区上市企业台帐台资 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
               this.年度.Text = obj_.年度.ToString();
               this.联系人.Text = obj_.联系人;
               this.职务.Text = obj_.职务;
               this.联系电话.Text = obj_.联系电话;
               this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t同里镇开发区上市企业台帐台资();
            }
        }
        private void frmAdd31Ssqy_Load(object sender, EventArgs e)
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
                obj_.年度 = Convert.ToInt32(this.年度.Text);
                obj_.联系人 = this.联系人.Text;
                obj_.职务 = this.职务.Text;
                obj_.联系电话 = this.联系电话.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t同里镇开发区上市企业台帐台资>(obj_);
                else
                    MainForm.EM.Modify<t同里镇开发区上市企业台帐台资>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
