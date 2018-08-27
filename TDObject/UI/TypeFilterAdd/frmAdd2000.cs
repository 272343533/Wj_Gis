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
    public partial class frmAdd2000 : QyTech.SkinForm.qyForm
    {
        string addormodify = "add";

        t开发区2000万企业 obj_;
        public frmAdd2000(t开发区2000万企业 obj=null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
               this.纳税人名称.Text = obj_.纳税人名称;
               this.年度.Text = obj_.年度.ToString();
               this.累计销售额合计.Text = obj_.累计销售额合计.ToString();
               this.上年同期.Text = obj_.上年同期.ToString();
               this.增减率.Text = obj_.增减率.ToString();
               this.税收.Text = obj_.税收.ToString();
               this.税收上年同期.Text = obj_.税收上年同期.ToString();
               this.税收增减率.Text = obj_.税收增减率.ToString();
               this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t开发区2000万企业();
            }
        }
        private void frmAdd2000_Load(object sender, EventArgs e)
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
                obj_.纳税人名称 = this.纳税人名称.Text;
                obj_.年度 = Convert.ToInt32(this.年度.Text);
                obj_.累计销售额合计 = Convert.ToDouble(this.累计销售额合计.Text);
                obj_.上年同期 = Convert.ToDouble(this.上年同期.Text);
                obj_.增减率 = Convert.ToDouble(this.增减率.Text);
                obj_.税收 = Convert.ToDouble(this.税收.Text);
                obj_.税收上年同期 = Convert.ToDouble(this.税收上年同期.Text);
                obj_.税收增减率 = Convert.ToDouble(this.税收增减率.Text);
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t开发区2000万企业>(obj_);
                else
                    MainForm.EM.Modify<t开发区2000万企业>(obj_);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
