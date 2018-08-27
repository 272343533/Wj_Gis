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
    public partial class FrmTypeImport : QyTech.SkinForm.qyForm
    {

        DataSet ds = new DataSet();//新建数据集
        Dictionary<string, string> dic_ExcelColumn2FieldName = new Dictionary<string, string>();
        //List<Excel2FieldMap> efMs;


        public FrmTypeImport()
        {
            InitializeComponent();
        }

        private void FrmTypeImport_Load(object sender, EventArgs e)
        {
            try
            {
                dgvExcel.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

               
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }

        }

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

        private void RefreshPgb(int val, int maxvalue)
        {
            if (val == maxvalue)
                this.progressBar1.Visible = false;
            else if (val == 1)
            {
                this.progressBar1.Visible = true;
                this.progressBar1.Maximum = maxvalue;
            }
            else
                this.progressBar1.Value = val;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int BatchCount = 100;
            try
            {
                if (ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count == 0 || this.textBox1.Text.Trim() == "")
                    {
                        MessageBox.Show("数据源必须啊包含数据，数据格式必须选择然后才能导入！");
                    }
                    else
                    {
                        if (DialogResult.OK == MessageBox.Show("是否确认导入数据库?", "询问", MessageBoxButtons.OKCancel))
                        {
                            object val;
                            PropertyInfo p;
                                           
                            System.Data.DataTable dt = ds.Tables[0];

                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                if (dt.Rows[r][dt.Columns[0].ColumnName].ToString() == "")
                                    continue;
                                if (cboType.Text == "标准化级别")
                                {
                                    t标准化级别 sjobj = new t标准化级别();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val = Convert.ToInt32(dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { log.Error(ex.Message); }
                                    }
                                    MainForm.EM.Add<t标准化级别>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "开发区2000万企业")
                                {
                                    t开发区2000万企业 sjobj = new t开发区2000万企业();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                           try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t开发区2000万企业>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "企业技术中心台账")
                                {
                                    t企业技术中心台账 sjobj = new t企业技术中心台账();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t企业技术中心台账>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "清洁生产历年")
                                {
                                    t清洁生产历年 sjobj = new t清洁生产历年();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                           if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t清洁生产历年>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "同里镇开发区上市企业台帐三板")
                                {
                                    t同里镇开发区上市企业台帐三板 sjobj = new t同里镇开发区上市企业台帐三板();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t同里镇开发区上市企业台帐三板>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "同里镇开发区上市企业台帐台资")
                                {
                                    t同里镇开发区上市企业台帐台资 sjobj = new t同里镇开发区上市企业台帐台资();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                              try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t同里镇开发区上市企业台帐台资>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "同里镇开发区上市企业台帐主版后备")
                                {
                                    t同里镇开发区上市企业台帐主版后备 sjobj = new t同里镇开发区上市企业台帐主版后备();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                              try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t同里镇开发区上市企业台帐主版后备>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "吴江区智能制造示范试点企业名单")
                                {
                                    t吴江区智能制造示范试点企业名单 sjobj = new t吴江区智能制造示范试点企业名单();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t吴江区智能制造示范试点企业名单>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }
                                else if (cboType.Text == "闲置土地盘活计划表")
                                {
                                    t闲置土地盘活计划表 sjobj = new t闲置土地盘活计划表();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t闲置土地盘活计划表>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }

                                else if (cboType.Text == "新地标计划企业名单")
                                {
                                    t新地标计划企业名单 sjobj = new t新地标计划企业名单();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                             if ("序号,年度".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                             try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t新地标计划企业名单>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
                                }

                                else if (cboType.Text == "智能车间")
                                {
                                    t智能车间 sjobj = new t智能车间();
                                    for (int c = 0; c < dt.Columns.Count; c++)
                                    {
                                        try
                                        {
                                            if ("序号,获评年份".Contains(dt.Columns[c].ColumnName))
                                                val=Convert.ToInt32( dt.Rows[r][dt.Columns[c].ColumnName]);
                                            else
                                                val= dt.Rows[r][dt.Columns[c].ColumnName];
                                            try
                                            {
                                                //按名称
                                                p = sjobj.GetType().GetProperty(dt.Columns[c].ColumnName);
                                                p.SetValue(sjobj, val, null);
                                            }
                                            catch (Exception ex)
                                            {
                                                log.Error(ex.Message);
                                            }
                                        }
                                        catch (Exception ex) { }
                                    }
                                    MainForm.EM.Add<t智能车间>(sjobj);
                                    RefreshPgb(r+1, dt.Rows.Count);
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


        private void RefreshFromExcel(string excelfile)
        {
            try
            {
                string strCon = "provider=Microsoft.Ace.OleDb.12.0;data source=" + excelfile + ";extended properties='excel 12.0;HDR=YES;IMEX=1'";//关键是红色区域
                OleDbConnection Con = new OleDbConnection(strCon);//建立连接
                Con.Open();
                System.Data.DataTable dt = Con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                string tableName = dt.Rows[0][2].ToString().Trim();
                Con.Close();

                string strSql = "select * from [" + tableName + "]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                OleDbCommand Cmd = new OleDbCommand(strSql, Con);//建立要执行的命令
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                ds.Tables.Clear();
                da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
                dgvExcel.Columns.Clear();
                dgvExcel.DataSource = ds.Tables[0];

                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
