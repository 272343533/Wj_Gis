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
    public partial class FrmAdd7Zncj : FlatForm
    {
       string addormodify = "add";

       t智能车间 obj_;
       public FrmAdd7Zncj(t智能车间 obj = null)
       {
           InitializeComponent();

           if (obj != null)
           {
               addormodify = "modify";
               obj_ = obj;



               this.序号.Text = obj_.序号.ToString();
               this.企业名称.Text = obj_.企业名称;
               this.车间名称.Text = obj_.车间名称.ToString();
               this.获评年份.Text = obj_.获评年份.ToString();
               this.区镇.Text = obj_.区镇.ToString();
               this.地块编号.Text = obj_.地块编号;
           }
           else
           {
               obj_ = new t智能车间();
           }
       }
        private void FrmAdd7Zncj_Load(object sender, EventArgs e)
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
                obj_.车间名称 = this.车间名称.Text;
                obj_.获评年份 = Convert.ToInt32(this.获评年份.Text);
                obj_.区镇 = this.区镇.Text;

                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t智能车间>(obj_);
                else
                    MainForm.EM.Modify<t智能车间>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
