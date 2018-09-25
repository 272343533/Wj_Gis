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
    public partial class FrmAdd5Znzz : QyTech.SkinForm.qyForm
    {
         string addormodify = "add";

         t吴江区智能制造示范试点企业名单 obj_;
         public FrmAdd5Znzz(t吴江区智能制造示范试点企业名单 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
                this.所属环节.Text = obj_.所属环节.ToString();
                this.区镇.Text = obj_.区镇.ToString();
                this.类型.Text = obj_.类型.ToString();
             
               this.地块编号.Text = obj_.年份;
            }
            else
            {
                obj_ = new t吴江区智能制造示范试点企业名单();
            }
        }
        private void FrmAdd5Znzz_Load(object sender, EventArgs e)
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
                obj_.所属环节 = this.所属环节.Text;
                obj_.区镇 = this.区镇.Text;
                obj_.类型 = this.类型.Text;
                obj_.年份 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t吴江区智能制造示范试点企业名单>(obj_);
                else
                    MainForm.EM.Modify<t吴江区智能制造示范试点企业名单>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
