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
    public partial class frmAlarmEdit : FlatForm
    {
        private string AddorEdit="Add";

        private int LtdProblemId;
        private int LtdId;
        private bool IsRent;
        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="OBJECTID">ltdproblem 主键</param>
        public frmAlarmEdit(string AddOrEdit,int OBJECTID,bool isRent)
        {
            InitializeComponent();

            AddorEdit = AddOrEdit;
            if (AddorEdit.ToLower() == "add")
            {
                LtdId = OBJECTID;
                IsRent = isRent;
            }
            else
                LtdProblemId = OBJECTID;
        }

       
        private void frmAlarmEdit_Load(object sender, EventArgs e)
        {
            this.comboBox1.SelectedIndex = 1;
            this.comboBox2.SelectedIndex = 1;

            if (LtdProblemId != 0)
            {
                LtdProblem dbobj = MainForm.EM.GetBySql<LtdProblem>("OBJECTID=" + LtdProblemId);

                if (dbobj != null)
                {
                    this.textBox2.Text = dbobj.SSDKBM;
                    this.textBox4.Text = dbobj.SSQYBM;
                    
                    this.textBox1.Text = dbobj.CCDM;
                    this.comboBox1.SelectedIndex = dbobj.CCLX == "黄牌" ? 0 : 1;
                    this.dateTimePicker1.Value = dbobj.CCRQ.Value==null?DateTime.Today:Convert.ToDateTime(dbobj.CCRQ.Value);
                    this.comboBox2.Text = dbobj.CCNR;

                    this.textBox5.Text = dbobj.CXDM;
                    this.dateTimePicker2.Value = dbobj.CXRQ.Value == null ? DateTime.Today : Convert.ToDateTime(dbobj.CXRQ.Value);
                    this.textBox6.Text = dbobj.SCDM;
                    this.dateTimePicker3.Value = dbobj.SCRQ.Value == null ? DateTime.Today : Convert.ToDateTime(dbobj.SCRQ.Value);
                 }
            }
            else
            {
                if (!IsRent)
                {
                    企业范围 dbobj = MainForm.EM.GetBySql<企业范围>("OBJECTID=" + LtdId);

                    if (dbobj != null)
                    {
                        this.textBox2.Text = dbobj.DKBH;
                        this.textBox4.Text = dbobj.NSRSBH;
                    }
                }
                else
                {

                    z租赁企业信息表 dbobj = MainForm.EM.GetBySql<z租赁企业信息表>("OBJECTID=" + LtdId);

                    if (dbobj != null)
                    {
                        this.textBox2.Text = dbobj.DKBH;
                        this.textBox4.Text = dbobj.NSRSBH;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //obj_.序号 = Convert.ToInt32(this.序号.Text);
                //obj_.企业名称 = this.企业名称.Text;
                //obj_.车间名称 = this.车间名称.Text;
                //obj_.获评年份 = Convert.ToInt32(this.获评年份.Text);
                //obj_.区镇 = this.区镇.Text;

                //obj_.地块编号 = this.地块编号.Text;

                //if (addormodify == "add")
                //    MainForm.EM.Add<t智能车间>(obj_);
                //else
                //    MainForm.EM.Modify<t智能车间>(obj_);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
