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
    public partial class FrmAdd8Xztd : FlatForm
    {
        string addormodify = "add";

        t闲置土地盘活计划表 obj_;
        public FrmAdd8Xztd(t闲置土地盘活计划表 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
               this.年度.Text = obj_.年度.ToString();
               this.地块位置.Text = obj_.地块位置.ToString();
               this.土地面积.Text = obj_.土地面积.ToString();
               this.回购情况.Text = obj_.回购情况.ToString();
               this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t闲置土地盘活计划表();
            }
        }
        private void FrmAdd8Xztd_Load(object sender, EventArgs e)
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
                obj_.地块位置 = this.地块位置.Text;
                obj_.土地面积 = Convert.ToDouble(this.土地面积.Text);
                obj_.回购情况 = this.回购情况.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t闲置土地盘活计划表>(obj_);
                else
                    MainForm.EM.Modify<t闲置土地盘活计划表>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
