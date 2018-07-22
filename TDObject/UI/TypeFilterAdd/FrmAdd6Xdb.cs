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
    public partial class FrmAdd6Xdb : FlatForm
    {
       string addormodify = "add";

       t新地标计划企业名单 obj_;
       public FrmAdd6Xdb(t新地标计划企业名单 obj = null)
       {
           InitializeComponent();

           if (obj != null)
           {
               addormodify = "modify";
               obj_ = obj;

               this.序号.Text = obj_.序号.ToString();
               this.单位.Text = obj_.单位;
               this.年度.Text = obj_.年度.ToString();
               this.区域.Text = obj_.区域.ToString();
               this.行业.Text = obj_.行业.ToString();
               this.细分.Text = obj_.细分.ToString();
               this.销售.Text = obj_.销售.ToString();
               this.目标.Text = obj_.目标.ToString();
               this.地块编号.Text = obj_.地块编号;
           }
           else
           {
               obj_ = new t新地标计划企业名单();
           }
       }
        private void FrmAdd6Xdb_Load(object sender, EventArgs e)
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
                obj_.单位 = this.单位.Text;
                obj_.年度 = Convert.ToInt32(this.年度.Text);
                obj_.区域 = this.区域.Text;
                obj_.行业 = this.行业.Text;
                obj_.细分 = this.细分.Text;
                obj_.销售 = Convert.ToDouble(this.销售.Text);
                obj_.目标 = this.目标.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t新地标计划企业名单>(obj_);
                else
                    MainForm.EM.Modify<t新地标计划企业名单>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
