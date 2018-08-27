using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

using SunMvcExpress.Dao;
using QyTech.ExcelOper;
using System.Reflection;



namespace TDObject.UI
{
    public partial class frmDataImport : QyTech.SkinForm.qyForm
    {
        public frmDataImport()
        {
            InitializeComponent();
        }

        List<市局表格> objs;
        List<开发区表格> objs2;
        List<经发局表格> objs1;

        Dictionary<string, string> dic_ExcelColumn2FieldName = new Dictionary<string, string>();
        List<QyTech.Auth.Dao.bsFName2ExcelColMap> efMs;

        QyExcelHelper exExcelHelper = new QyExcelHelper("local");

        DataSet ds = new DataSet();//新建数据集

        List<string> ExcelCols = new List<string>();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath + @"\";//注意这里写路径时要用c:\\而不是c:\
                openFileDialog.Filter = "excel文件|*.xls|excel文件|*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string strPath = openFileDialog.FileName;
                    this.textBox1.Text = strPath;

                    RefreshFromExcel(strPath);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshFromExcel(string excelfile)
        {
            try
            {
                string strCon = "provider=Microsoft.Ace.OleDb.12.0;data source=" + excelfile + ";extended properties='excel 12.0;HDR=YES;IMEX=1'";//关键是红色区域
                OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                Con.Open();
                System.Data.DataTable dt = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,  new object[] { null, null, null, "TABLE" });
                string tableName = dt.Rows[0][2].ToString().Trim();
                Con.Close();

                string strSql = "select * from [" + tableName + "]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                ds.Tables.Clear();
                da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
                dgvExcel.Columns.Clear();
                if (tabControl2.SelectedIndex == 0)
                {
                    dgvExcel.DataSource = ds.Tables[0];
           
                }
                else if (tabControl2.SelectedIndex == 1)
                {
                    dgvExcel.DataSource = ds.Tables[0];
                }
                else
                {
                    dgvExcel.DataSource = ds.Tables[0];
           
                }
                dt = ds.Tables[0];
                //记录excel列名称
                ExcelCols.Clear();
                foreach(DataColumn dc in dt.Columns)
                {
                    ExcelCols.Add(dc.ColumnName);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void RefreshPgb(int val, int maxvalue)
        {
            if (val == 1)
            {
                this.progressBar1.Visible = true;
                this.progressBar1.Maximum = maxvalue;
            }
            else if (val == maxvalue)
                this.progressBar1.Visible = false;
            else
                this.progressBar1.Value = val;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int BatchCount = 100;
            List<市局表格> objs_sjbg = new List<市局表格>();

            try
            {
                object val;
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 0 || cboYear.Text == "" || this.textBox1.Text.Trim() == "")
                    {
                        MessageBox.Show("数据源、数据格式和年度必须输入才能导入！");
                    }
                    else
                    {
                        efMs = MainForm.QyTech_EM.GetListNoPaging<QyTech.Auth.Dao.bsFName2ExcelColMap>("TableName='" + cboType.Text + "'", "ExcelCNo");
                        dic_ExcelColumn2FieldName.Clear();
                        foreach (QyTech.Auth.Dao.bsFName2ExcelColMap m in efMs)
                        {
                            dic_ExcelColumn2FieldName.Add(m.ExcelCName, m.FName);
                        }


                        if (DialogResult.OK == MessageBox.Show("是否确认导入数据库?", "询问", MessageBoxButtons.OKCancel))
                        {

                            System.Data.DataTable dt = ds.Tables[0];
                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                if (cboType.Text == "市局表格")
                                {
                                    市局表格 sjobj = new 市局表格();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度,月份".Contains(dt.Columns[c].ColumnName))
                                                val = Convert.ToInt32(dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val = dt.Rows[r][dt.Columns[c].ColumnName];


                                            PropertyInfo p;
                                            try
                                            {
                                                //按名称

                                                p = sjobj.GetType().GetProperty(dic_ExcelColumn2FieldName[dt.Columns[c].ColumnName]);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                            //try
                                            //{
                                            //    //没有直接按照字段名，列可能是字段名
                                            //    p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                            //    p.SetValue(sjobj, val, null);

                                            //}
                                            //catch (Exception ex1)
                                            //{ //没有的话按照列的位置
                                            //    //p = sjobj.GetType().GetProperty(efMs[c].FName);
                                            //}
                                            //}
                                        }
                                        catch (Exception ex) { log.Error(ex.Message); }
                                    }
                                    objs_sjbg.Add(sjobj);
                                    if (objs_sjbg.Count==BatchCount || r==dt.Rows.Count-1)
                                    {
                                        MainForm.EM.Add<市局表格>(objs_sjbg);
                                        objs_sjbg.Clear();
                                        //MainForm.EM.Add<市局表格>(sjobj);
                                    }
                                    RefreshPgb(r + 1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "经发局表格")
                                {
                                    经发局表格 sjobj = new 经发局表格();
                                    sjobj.ND = Convert.ToInt32(cboYear.Text);
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("年度".Contains(dt.Columns[c].ColumnName))
                                            {
                                                val = Convert.ToInt32(dt.Rows[r][dt.Columns[c].ColumnName]);
                                            }
                                            else
                                            {
                                                val = dt.Rows[r][dt.Columns[c].ColumnName];
                                            }
                                            PropertyInfo p;

                                            //没有直接按照字段名，列可能是字段名
                                            try
                                            {
                                                p = sjobj.GetType().GetProperty(dic_ExcelColumn2FieldName[dt.Columns[c].ColumnName]);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { log.Error(ex.Message); }
                                    }
                                    MainForm.EM.Add<经发局表格>(sjobj);
                                    RefreshPgb(r + 1, dt.Rows.Count);
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("excel中必须有正确数据才可以！");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDataImport_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSj.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgvJfj.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgvExcel.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                this.cboNd.SelectedIndex = 0;

                this.dgvSj.AllowUserToAddRows = false;
               this.dgvJfj.AllowUserToAddRows = false;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    objs = MainForm.EM.GetListNoPaging<市局表格>("ND='" + cboNd.Text.Substring(0, 4) + "'", "XH");
                    dgvSj.AutoGenerateColumns = false;
                    dgvSj.DataSource = objs;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    objs1 = MainForm.EM.GetListNoPaging<经发局表格>("ND=" + cboNd.Text.Substring(0, 4), "");
                    //List<经发局表格> objs1 = MainForm.EM.GetListNoPaging<经发局表格>("", "");
                    dgvJfj.AutoGenerateColumns = false;
                    dgvJfj.DataSource = objs1;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    List<市局表格> uis = dgvSj.DataSource as List<市局表格>;

                    市局表格 obj = uis[e.RowIndex];
                    string ret = MainForm.EM.Modify<市局表格>(obj);
                    if (ret == "")
                        MessageBox.Show("保存成功！");
                    else
                        MessageBox.Show(ret);
                    MessageBox.Show("表格修改需要明确哪些列可以改，哪些列不能修改，防止误修改！");
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvKfqnd_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    List<开发区表格> uis = dgvSj.DataSource as List<开发区表格>;

                    开发区表格 obj = uis[e.RowIndex];
                    string ret = MainForm.EM.Modify<开发区表格>(obj);
                    if (ret == "")
                        MessageBox.Show("保存成功！");
                    else
                        MessageBox.Show(ret);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvJfj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 0)
                {
                    List<经发局表格> uis = dgvSj.DataSource as List<经发局表格>;

                    经发局表格 obj = uis[e.RowIndex];
                    string ret = MainForm.EM.Modify<经发局表格>(obj);
                    if (ret == "")
                        MessageBox.Show("保存成功！");
                    else
                        MessageBox.Show(ret);
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

    
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl2_MouseMove(object sender, MouseEventArgs e)
        {
            QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void dgvExcel_MouseMove(object sender, MouseEventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                RefreshFromExcel(this.textBox1.Text);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void qyBtn1_Click(object sender, EventArgs e)
        {
            if (ExcelCols==null ||ExcelCols.Count==0)
            {
                MessageBox.Show("请先选择excel文件!");
                return;
            }
            QyTech.SkinForm.UICreate.frmFName2ExcelCol obj = new QyTech.SkinForm.UICreate.frmFName2ExcelCol("wj_GisDb","经发局表格", ExcelCols);
            obj.Show();
        }
    }
}
