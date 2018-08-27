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
    public partial class FrmAddLtdRegular : QyTech.SkinForm.qyForm
    {
        string addormodify = "add";

        LtdRegular obj_;
        public FrmAddLtdRegular(LtdRegular obj = null)
        {
            InitializeComponent();

            try
            {
                if (obj != null)
                {
                    addormodify = "modify";

                    obj_ = obj;
                    this.SSDKBM.Text = obj_.SSDKBM.ToString();
                    this.SSQYBM.Text = obj_.SSQYBM;
                    this.AQZD.Text = obj_.AQZD;
                    this.XFZD.Text = obj_.XFZD;
                    this.CWZD.Text = obj_.CWZD;
                    this.SBND.Text = obj_.SBND;
                    if (obj_.SBRQ != null)
                        this.SBRQ.Value = Convert.ToDateTime(obj_.SBRQ.Value);
                    this.AQZPDBM.Text = obj_.AQZPDBM;
                    this.DWMC.Text = obj_.DWMC;
                    if ((bool)obj_.IsRentLtd)
                        this.IsRentLtd_2.Checked = true;
                    else
                        IsRentLtd_1.Checked = true;
                    //this.IsRentLtd.Text = obj_.IsRentLtd;
                }
                else
                {
                    obj_ = new LtdRegular();
                }
            }
            catch { }
        }

      
        private void FrmAddLtdRegular_Load(object sender, EventArgs e)
        {
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
                if (addormodify == "add")
                {
                    obj_.SSDKBM = this.SSDKBM.Text;
                    obj_.SSQYBM = this.SSQYBM.Text;
                    obj_.AQZD = this.AQZD.Text;
                    obj_.XFZD = this.XFZD.Text;
                    obj_.CWZD = this.CWZD.Text;
                    obj_.SBND = this.SBND.Text;
                    obj_.SBRQ = Convert.ToDateTime(this.SBRQ.Text);
                    obj_.AQZPDBM = this.AQZPDBM.Text;
                    obj_.DWMC = this.DWMC.Text;
                    obj_.IsRentLtd = obj_.IsRentLtd;
                    ret = MainForm.EM.Add<LtdRegular>(obj_);
                }
                else
                {
                    LtdRegular objdb = MainForm.EM.GetByPk<LtdRegular>("OBJECTID", obj_.OBJECTID);
                    objdb.SSDKBM = this.SSDKBM.Text;
                    objdb.SSQYBM = this.SSQYBM.Text;
                    objdb.AQZD = this.AQZD.Text;
                    objdb.XFZD = this.XFZD.Text;
                    objdb.CWZD = this.CWZD.Text;
                    objdb.SBND = this.SBND.Text;
                    objdb.SBRQ = Convert.ToDateTime(this.SBRQ.Text);
                    objdb.AQZPDBM = this.AQZPDBM.Text;
                    objdb.DWMC = this.DWMC.Text;
                    objdb.IsRentLtd = obj_.IsRentLtd;
                    ret = MainForm.EM.Modify<LtdRegular>(objdb);
                }
                if (ret == "")
                    MessageBox.Show("保存成功！");
                else
                    MessageBox.Show("保存失败！(" + ret + ")");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void IsRentLtd_1_CheckedChanged(object sender, EventArgs e)
        {
             RadioButton rb =sender as RadioButton;
             if (rb.Text == "是")
                 obj_.IsRentLtd = true;
             else
                 obj_.IsRentLtd = false;
        }

    }
}
