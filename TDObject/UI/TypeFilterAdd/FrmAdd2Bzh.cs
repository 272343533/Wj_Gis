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
    public partial class FrmAdd2Bzh : FlatForm
    {
        string addormodify = "add";

        t标准化级别 obj_;
        public FrmAdd2Bzh(t标准化级别 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;



                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
                this.年份.Text = obj_.年份.ToString();
                this.是否公告.Text = obj_.是否公告.ToString();
                this.标准化级别.Text = obj_.标准化级别.ToString();
                this.地块编号.Text = obj_.地块编号.ToString();
            }
            else
            {
                obj_ = new t标准化级别();
            }
        }
        private void FrmAdd2Bzh_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterScreen;
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
                obj_.年份 = this.年份.Text;
                obj_.是否公告 = this.是否公告.Text;
                obj_.标准化级别 = this.标准化级别.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t标准化级别>(obj_);
                else
                    MainForm.EM.Modify<t标准化级别>(obj_);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
