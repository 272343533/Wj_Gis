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
    public partial class FrmAdd32Ssqy : QyTech.SkinForm.qyForm
    {
        string addormodify = "add";

        t同里镇开发区上市企业台帐三板 obj_;
        public FrmAdd32Ssqy(t同里镇开发区上市企业台帐三板 obj = null)
        {
            InitializeComponent();

            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;


                try
                {
                    this.序号.Text = obj_.序号.ToString();
                    this.企业名称.Text = obj_.企业名称;
                    this.年度.Text = obj_.年度==null?"":obj_.年度.ToString();
                    this.统一社会信用代码.Text = obj_.统一社会信用代码;
                    this.股票名称.Text = obj_.股票名称;
                    this.挂牌代码.Text = obj_.挂牌代码;
                    this.董事长.Text = obj_.董事长;
                    this.签约券商.Text = obj_.签约券商;
                    this.挂牌时间.Text = obj_.挂牌时间;
                    this.备注.Text = obj_.备注;
                    this.地块编号.Text = obj_.地块编号;
                }
                catch { }
            }
            else
            {
                obj_ = new t同里镇开发区上市企业台帐三板();
            }
        }
        private void FrmAdd32Ssqy_Load(object sender, EventArgs e)
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
                string ret = "";
                obj_.序号 = Convert.ToInt32(this.序号.Text);
                obj_.企业名称 = this.企业名称.Text;
                obj_.年度 = Convert.ToInt32(this.年度.Text);
                obj_.统一社会信用代码 = this.统一社会信用代码.Text;
                obj_.股票名称 = this.股票名称.Text;
                obj_.挂牌代码 = this.挂牌代码.Text;
                obj_.董事长 = this.董事长.Text;
                obj_.签约券商 = this.签约券商.Text;
                obj_.挂牌时间 = this.挂牌时间.Text;
                obj_.备注 = this.备注.Text;
                obj_.地块编号 = this.地块编号.Text;

                if (addormodify == "add")
                    ret = MainForm.EM.Add<t同里镇开发区上市企业台帐三板>(obj_);
                else
                    ret = MainForm.EM.Modify<t同里镇开发区上市企业台帐三板>(obj_);
                if (ret == "")
                    MessageBox.Show("保存成功");
                else
                    MessageBox.Show("保存失败,请检查数据的正确性！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败");
            }

        }

    }
}
