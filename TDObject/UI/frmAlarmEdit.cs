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
    public partial class frmAlarmEdit : QyTech.SkinForm.qyForm
    {
         string addormodify = "add";

        LtdProblem obj_;
        public frmAlarmEdit(LtdProblem obj = null)
        {
            InitializeComponent();

            try
            {
                if (obj != null)
                {
                    addormodify = "modify";


                    this.textBox2.Text = obj_.SSDKBM;
                    this.textBox4.Text = obj_.SSQYBM;

                    this.textBox1.Text = obj_.CCDM;
                    this.comboBox1.SelectedIndex = obj_.CCLX == "黄牌" ? 0 : 1;
                    this.dateTimePicker1.Value = obj_.CCRQ.Value == null ? DateTime.Today : Convert.ToDateTime(obj_.CCRQ.Value);
                    this.comboBox2.Text = obj_.CCNR;

                    this.textBox5.Text = obj_.CXDM;
                    this.dateTimePicker2.Value = obj_.CXRQ.Value == null ? DateTime.Today : Convert.ToDateTime(obj_.CXRQ.Value);
                    this.textBox6.Text = obj_.SCDM;
                    this.dateTimePicker3.Value = obj_.SCRQ.Value == null ? DateTime.Today : Convert.ToDateTime(obj_.SCRQ.Value);
                }
                else
                {
                    obj_ = new LtdProblem();
                }
            }
            catch { }
        }


        private void frmAlarmEdit_Load(object sender, EventArgs e)
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
                    obj_.SSDKBM = this.textBox2.Text;
                    obj_.SSQYBM = this.textBox4.Text;

                    obj_.CCDM = this.textBox1.Text;
                    obj_.CCLX = this.comboBox1.Text;
                    obj_.CCRQ = this.dateTimePicker1.Value;
                    obj_.CCNR = this.comboBox2.Text;

                    obj_.CCDM = this.textBox5.Text;
                    if (obj_.CCDM != "")
                        obj_.CXRQ = this.dateTimePicker2.Value;
                    obj_.SCDM = this.textBox6.Text;
                    if (obj_.SCDM != "")
                        obj_.SCRQ = this.dateTimePicker3.Value;
                }
                else
                {
                    LtdProblem objdb = MainForm.EM.GetByPk<LtdProblem>("OBJECTID", obj_.OBJECTID);
                    obj_.SSDKBM = this.textBox2.Text;
                    obj_.SSQYBM = this.textBox4.Text;

                    obj_.CCDM = this.textBox1.Text;
                    obj_.CCLX = this.comboBox1.Text;
                    obj_.CCRQ = this.dateTimePicker1.Value;
                    obj_.CCNR = this.comboBox2.Text;

                    obj_.CCDM = this.textBox5.Text;
                    if (obj_.CCDM != "")
                        obj_.CXRQ = this.dateTimePicker2.Value;
                    obj_.SCDM = this.textBox6.Text;
                    if (obj_.SCDM != "")
                        obj_.SCRQ = this.dateTimePicker3.Value;

                    ret = MainForm.EM.Modify<LtdProblem>(objdb);
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

    }
}
