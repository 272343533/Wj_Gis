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
    public partial class frmLtdInfoModi : FlatForm
    {

     

        List<z企业变化信息表> objs;


        public frmLtdInfoModi()
        {
            InitializeComponent();
        }

        private void frmLtdInfoModi_Load(object sender, EventArgs e)
        {
            try
            {
                dgv1.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                comboBox1.SelectedIndex = 0;

                //string fName = System.Windows.Forms.Application.StartupPath + @"\DemoExcel\D、企业变化信息表.xlsx";
                //string strCon = "provider=Microsoft.Ace.OleDb.12.0;data source=" + fName + ";extended properties='excel 12.0;HDR=YES;IMEX=1'";//关键是红色区域
                //OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                //Con.Open();
                //System.Data.DataTable dt = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                //string tableName = dt.Rows[0][2].ToString().Trim();
                //Con.Close();

                //string strSql = "select * from [" + tableName + "]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                //OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                //OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                //DataSet ds = new DataSet();//新建数据集
                //da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                ////指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
                //dataGridView1.AutoGenerateColumns = true;
                //dataGridView1.Columns.Clear();
                //dataGridView1.DataSource = ds.Tables[0];
                dgv1.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
                dgv1.AutoGenerateColumns = false;
                dgv1.AllowUserToAddRows = false;


                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<z企业变化信息表> uis = dgv1.DataSource as List<z企业变化信息表>;

                z企业变化信息表 obj;// = uis[e.RowIndex];
                if (dgv1.Rows[e.RowIndex].Cells[1].Value != null)
                {
                    obj = uis[e.RowIndex];
                    string ret = MainForm.EM.Modify<z企业变化信息表>(obj);
                    if (ret == "")
                        MessageBox.Show("修改成功！");
                    else
                        MessageBox.Show(ret);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.Text != "")
                    objs = MainForm.EM.GetListNoPaging<z企业变化信息表>("IsUpdMap='" + comboBox1.Text + "'", "OBJECTID");
                else
                    objs = MainForm.EM.GetListNoPaging<z企业变化信息表>("", "OBJECTID");
                dgv1.DataSource = objs;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                z企业变化信息表 obj = new z企业变化信息表();
                obj.IsUpdMap = "未更新";
                MainForm.EM.Add<z企业变化信息表>(obj);

                button1_Click(null, null);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        


        private void frmLtdInfoModi_MouseDown(object sender, MouseEventArgs e)
        {
            FormSkin.MouseMoveForm(this.Handle);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

        }
    }
}
