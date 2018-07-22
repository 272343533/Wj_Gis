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
using QyTech.Core.BLL;


namespace TDObject.UI
{
    public partial class frmLtdCcclEdit : Form
    {
        vwQyxx _vwQyxx;


        public frmLtdCcclEdit(vwQyxx obj)//string cun,string qyname,string zl)
        {
            InitializeComponent();
            _vwQyxx = obj;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtContent.Text.Trim() == "")
            {
                MessageBox.Show("请输入查处内容");
                return;
            }
            LtdProblem obj = new LtdProblem();
            obj.序号 = this.txtCcdm.Text;
            obj.所在行政村 = this.txtSzxzc.Text;
            obj.问题企业名称 = this.txtWtqumc.Text;
            obj.坐落 = this.txtZl.Text;
            obj.查处类型 = this.cbpCclx.Text;
            obj.地块编码 = this.txtdkbm.Text;
            obj.查处截止日期 = this.dtpEnd.Value.Date;
            obj.查处批注内容 = this.txtContent.Text;
            obj.查处起始日期 = this.dtpStart.Value.Date;
            obj.撤销日期 = null;// this.dtpCancel.Value;
            obj.批注日期 = this.dtpSign.Value.Date;
          
            string ret=MainForm.EM.Add<LtdProblem>(obj);
            if (ret != "")
            {
                MessageBox.Show("保存失败！("+ret+")","提示", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("保存成功", "提示", MessageBoxButtons.OK);
                this.Close();
            }
        }

        private void frmLtdCcclEdit_Load(object sender, EventArgs e)
        {
            this.txtSzxzc.Text = _vwQyxx.所属行政村名称;
            this.txtWtqumc.Text =  _vwQyxx.用地单位名称;
            this.txtZl.Text = _vwQyxx.土地座落;
            this.txtdkbm.Text=_vwQyxx.地块编码;
            this.cbpCclx.SelectedIndex =0;
        }
    }
}
