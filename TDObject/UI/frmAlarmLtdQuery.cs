using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

using SunMvcExpress.Dao;

namespace TDObject.UI
{
    public partial class frmAlarmLtdQuery : QyTech.SkinForm.qyForm
    {
        private int OBJECTID;
        private bool IsRent;


        string NSRSBH = "";

        private int LtdProblemId;


        private string AddorEdit = "Add";

        private int LtdId;


        private int RowIndex=-1;
        public frmAlarmLtdQuery(bool isRent,int objectid)
        {
            InitializeComponent();

            IsRent = isRent;
            OBJECTID = objectid;
            LtdId = objectid;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void frmAlarmLtdQuery_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//设置为整行被选中
               

                //企业编码SSQYBM按照纳税人识别号NSRSBH进行
                if (IsRent)
                {
                    z租赁企业信息表 dbobj = MainForm.EM.GetByPk<z租赁企业信息表>("OBJECTID", OBJECTID);
                    NSRSBH = dbobj.NSRSBH;
                }
                else
                {
                    企业范围 dbobj = MainForm.EM.GetByPk<企业范围>("OBJECTID", OBJECTID);
                    NSRSBH = dbobj.NSRSBH;
                
                }
             
                dataGridView1.AutoGenerateColumns = true;
                RefreshData();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void RefreshData()
        {
            List<LtdProblem> dbobjs = MainForm.EM.GetListNoPaging<LtdProblem>("SSQYBM='" + NSRSBH + "'", "CCRQ desc");
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = dbobjs;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                frmAlarmEdit obj = new frmAlarmEdit();
                obj.ShowDialog();
            
                //AddorEdit = "add";
                //RefreshInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }//frmAlarmEdit obj = new frmAlarmEdit("add", OBJECTID,IsRent);
            //obj.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBox.Show("确定要删除吗?", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                string ret=MainForm.EM.DeleteById<LtdProblem>("objectid", LtdProblemId);
                if (ret == "")
                {
                    MessageBox.Show("删除成功!");
                }
                else
                    MessageBox.Show(ret);
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                if (RowIndex == -1)
                {
                    MessageBox.Show("请先选择数据！");
                    return;
                }
                List<LtdProblem> uis = dataGridView1.DataSource as List<LtdProblem>;

                LtdProblem obj;// = uis[e.RowIndex];
                if (dataGridView1.Rows[RowIndex].Cells[1].Value != null)
                {
                    obj = uis[RowIndex];
                    frmAlarmEdit frmobj = new frmAlarmEdit(obj);
                    frmobj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex!=-1)
                LtdProblemId=Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

            LtdProblem ltdobj;

            if (this.textBox4.Text == "")
            {
                MessageBox.Show("企业编码为纳税人识别号，用于区分企业，必须输入！");
                return;
            }

            if (AddorEdit == "edit")
            {
                ltdobj = MainForm.EM.GetByPk<LtdProblem>("OBJECTID", LtdProblemId);
            }
            else
            {
                ltdobj = new LtdProblem();
            }
            ltdobj.SSQYBM = this.textBox4.Text;
            ltdobj.SSDKBM = this.textBox2.Text;
            ltdobj.CCNR = this.comboBox2.Text;
            ltdobj.CCLX = this.comboBox1.Text;
            ltdobj.CCRQ = this.dateTimePicker1.Value;
            ltdobj.CCDM = this.textBox1.Text;

            ltdobj.CXDM = this.textBox5.Text;
            ltdobj.CXRQ = this.dateTimePicker2.Value;

            ltdobj.SCDM = this.textBox6.Text;
            ltdobj.SCRQ = this.dateTimePicker3.Value;

            string ret = "";
            if (AddorEdit == "edit")
                ret=MainForm.EM.Modify<LtdProblem>(ltdobj);
            else
                ret=MainForm.EM.Add<LtdProblem>(ltdobj);


            if (ret == "")
            {
                MessageBox.Show("保存成功");
            }
            else
            {
                MessageBox.Show("保存失败");
            }
        }


        private void RefreshInput()
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
                    this.dateTimePicker1.Value = dbobj.CCRQ.Value == null ? DateTime.Today : Convert.ToDateTime(dbobj.CCRQ.Value);
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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            RowIndex = e.RowIndex;
        }
    }
}
