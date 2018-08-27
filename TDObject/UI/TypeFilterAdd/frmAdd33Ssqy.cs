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
using System.Reflection;

namespace TDObject.UI
{
    public partial class frmAdd33Ssqy : QyTech.SkinForm.qyForm
    {
        string addormodify = "add";

        t同里镇开发区上市企业台帐主版后备 obj_;
        public frmAdd33Ssqy(t同里镇开发区上市企业台帐主版后备 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;

                this.序号.Text = obj_.序号.ToString();
                this.企业名称.Text = obj_.企业名称;
                this.年度.Text = obj_.年度.ToString();
                this.董事长.Text = obj_.董事长.ToString();
                this.电话.Text = obj_.电话.ToString();
                this.董秘.Text = obj_.董秘.ToString();
                this.董秘电话.Text = obj_.董秘电话.ToString();
                this.签约时间.Text = obj_.签约时间.ToString();
                this.签约券商.Text = obj_.签约券商.ToString();
                this.年底进度.Text = obj_.年底进度.ToString();
                this.进入程序.Text = obj_.进入程序.ToString();
                this.完成股改.Text = obj_.完成股改.ToString();
                this.进入辅导.Text = obj_.进入辅导.ToString();
                this.报证监会.Text = obj_.报证监会.ToString();
                this.三板挂牌.Text = obj_.三板挂牌.ToString();
                this.成功上市.Text = obj_.成功上市.ToString();
                this.签约券商.Text = obj_.签约券商.ToString();
                this.签约券商.Text = obj_.签约券商.ToString();

                this.地块编号.Text = obj_.地块编号;
            }
            else
            {
                obj_ = new t同里镇开发区上市企业台帐主版后备();
            }
        }
        private void frmAdd33Ssqy_Load(object sender, EventArgs e)
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
                obj_.董事长 = this.董事长.Text;
                obj_.电话 = this.电话.Text;
                obj_.董秘 = this.董秘.Text;
                obj_.董秘电话 = this.董秘电话.Text;
                obj_.签约时间 = this.签约时间.Text;
                obj_.签约券商 = this.签约券商.Text;
                obj_.年底进度 = this.年底进度.Text;
                obj_.进入程序 = Convert.ToInt32(this.进入程序.Text);
                obj_.完成股改 = Convert.ToInt32(this.完成股改.Text);
                obj_.进入辅导 = Convert.ToInt32(this.进入辅导.Text);
                obj_.报证监会 = Convert.ToInt32(this.报证监会.Text);
                obj_.三板挂牌 = Convert.ToInt32(this.三板挂牌.Text);
                obj_.成功上市 = Convert.ToInt32(this.成功上市.Text);
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    MainForm.EM.Add<t同里镇开发区上市企业台帐主版后备>(obj_);
                else
                    MainForm.EM.Modify<t同里镇开发区上市企业台帐主版后备>(obj_);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

    }
}
