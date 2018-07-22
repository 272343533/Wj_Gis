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
    public partial class FrmAdd4Qjsc : FlatForm
    {
       string addormodify = "add";

       t清洁生产历年 obj_;
       public FrmAdd4Qjsc(t清洁生产历年 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
               this.年度.Text = obj_.年度.ToString();
               this.备注.Text = obj_.备注.ToString();
               this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t清洁生产历年();
            }
        }
        private void FrmAdd4Qjsc_Load(object sender, EventArgs e)
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
                obj_.备注 = this.备注.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t清洁生产历年>(obj_);
                else
                    MainForm.EM.Modify<t清洁生产历年>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
