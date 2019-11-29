using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QyTech.SkinForm;
using SunMvcExpress.Dao;
using QyTech.ExcelOper;

using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data;

using QyTech.Auth.Dao;

namespace TDObject.UI
{
    public partial class frmExcelImport : qyFormWithTitle
    {

        Dictionary<string, string> dic_ExcelColumn2FieldName = new Dictionary<string, string>();
        List<bsFName2ExcelColMap> FName2ExcelCols;

        string strDir = "";
        string fileName = "";
        string sheetName = "";
        string tableName = "";
        string bsT_Id = "";

        QyExcelHelper exExcelHelper = new QyExcelHelper("local");

        OleDbConnection oledbConn = null;
        SqlConnection sqlConn = null;
        string strSqlConn = "server =122.112.245.147; uid = sa; pwd = Qy_ltd414; database = wj_GisDb";
        DataSet ds = new DataSet();//新建数据集
        DataTable dtSheet;
        DataTable dtImported;
        List<string> ExcelCols = new List<string>();
        QyTech.SkinForm.UICreate.frmFName2ExcelCol obj;
        Dictionary<string, string> dicFname2ExcelCol;//字段与excel映射关系

        Dictionary<string, string> OrgRoleTableRights = new Dictionary<string, string>();

        string importtype = "";

        public frmExcelImport()
        {
            InitializeComponent();
        }
        public frmExcelImport(string ImportType)
        {
            InitializeComponent();
            importtype = ImportType;
            this.Title = "Excel数据导入";
        }
        private void frmExcelImport_Load(object sender, EventArgs e)
        {
            try
            {
                qyBtnFile.Image = QyTech.SkinForm.qyResources.Excel_16;
                //qyBtnSearch.Image = qyResources.search_16;
                //qyBtn_Map.Image = qyResources.position_16;

                //,,t开发区2000万企业,t市局表格,t闲置土地盘活计划表,
                OrgRoleTableRights.Add("委领导", "");
                OrgRoleTableRights.Add("服务业发展科", "t新地标计划企业名单,t智能车间,t吴江区智能制造示范试点企业名单,t同里镇开发区上市企业台帐三板,t同里镇开发区上市企业台帐台资,t同里镇开发区上市企业台帐主版后备,t清洁生产历年,t企业技术中心台账");
                OrgRoleTableRights.Add("统计站", "t经发局表格,t企业基础数据,,t工业固定资产,t规上企业名单");
                OrgRoleTableRights.Add("经济运行科", "");
                OrgRoleTableRights.Add("企业管理科", "");
                OrgRoleTableRights.Add("科技局", "t高企,t工程技术研究中心,");
                OrgRoleTableRights.Add("安全生产科", "t安全事故情况,t标准化级别,t立案处罚情况");


                List<bsTable> ts;
                if ("System,委领导,吴江经济技术开发区".Contains(MainForm.LoginUser.bsO_Name))
                {
                    ts = MainForm.QyTech_EM.GetListNoPaging<bsTable>("TName like 't%' and TName  in ( select TName from bsTableImportType where ImportType='"+importtype+"'", "Desp");
                }
                else
                {
                    ts = MainForm.QyTech_EM.GetListNoPaging<bsTable>("TName like 't%' and TName in   d TName in ( select TName from bsTableImportType where ImportType='" + importtype + "' and bsOName='"+ MainForm.LoginUser.bsO_Name+"'", "Desp"); 
                    //ts = MainForm.QyTech_EM.GetListNoPaging<bsTable>("TName like 't%' and TName not in ('t企业基础数据','t市局表格') and TName in ('" + OrgRoleTableRights[MainForm.LoginUser.bsO_Name].Replace(",", "','") + "')", "Desp");
                }
                if (ts.Count == 0)
                {
                    MessageBox.Show("用户所在部门没有需要导入的数据，如需补充请联系管理员！");
                }
                else
                {
                    qyDgv_Table.AutoGenerateColumns = false;
                    qyDgv_Table.DataSource = ts;


                    sqlConn = new SqlConnection(strSqlConn);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void qyBtnFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                if (strDir == "")
                    openFileDialog.InitialDirectory = System.Windows.Forms.Application.StartupPath + @"\";//注意这里写路径时要用c:\\而不是c:\
                else
                    openFileDialog.InitialDirectory = strDir;
                openFileDialog.Filter = "excel文件|*.xls;*.xlsx|所有文件|*.*";
                openFileDialog.RestoreDirectory = true;
                openFileDialog.FilterIndex = 1;
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    fileName = openFileDialog.FileName;
                    strDir = fileName.Substring(0, fileName.LastIndexOf(@"\"));
                    this.textBox1.Text = fileName;

                    GetAllSheet(fileName);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
       
        private void GetAllSheet(string excelfile)
        {
            try
            {
                string strCon = "provider=Microsoft.Ace.OleDb.12.0;data source=" + excelfile + ";extended properties='excel 12.0;HDR=YES;IMEX=1'";//关键是红色区域
                oledbConn = new OleDbConnection(strCon);//建立连接
                oledbConn.Open();
                DataTable dt = oledbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
                comboBox1.Items.Clear();
                foreach(DataRow dr in dt.Rows)
                {
                    if (dr[2].ToString().Substring(dr[2].ToString().Length-1)=="$")
                        comboBox1.Items.Add(dr[2].ToString().Substring(0,dr[2].ToString().Length-1));
                }
                if (dt.Rows.Count > 0)
                    comboBox1.SelectedIndex = 0;
               sheetName = comboBox1.Text;

                oledbConn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void RefreshFromExcel(string excelfile,string sheetName)
        {
            try
            {
                string strSql = "select * from [" + sheetName + "]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
                OleDbCommand Cmd = new OleDbCommand(strSql, oledbConn);//建立要执行的命令
                OleDbDataAdapter da = new OleDbDataAdapter(Cmd);//建立数据适配器
                ds.Tables.Clear();
                da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
                dtSheet = ds.Tables[0];
                dgvExcel.Columns.Clear();
                dgvExcel.DataSource = dtSheet;


                //记录excel列名称
                ExcelCols.Clear();
                foreach (DataColumn dc in dtSheet.Columns)
                {
                    ExcelCols.Add(dc.ColumnName);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);//捕捉异常
            }
        }

        private void qyBtnSearch_Click(object sender, EventArgs e)
        {
            if (fileName != "")
            {
                RefreshFromExcel(fileName, sheetName + "$");
                tabControl2.TabPages[0].Text = "Excel数据 (" + dtSheet.Rows.Count.ToString() + "条)";
            }
        }

        private void qyBtn_Map_Click(object sender, EventArgs e)
        {
            if (ExcelCols == null || ExcelCols.Count == 0)
            {
                MessageBox.Show("请1先选择excel文件,2选择对应的sheet，3并显示数据!");
                return;
            }
            if (tableName == "")
                MessageBox.Show("请选择导入数据对应的表！");

            if (ExcelCols[1] == "F2"|| ExcelCols[2] == "F3") { 
                if (DialogResult.No==MessageBox.Show("请确保excel表格数据的正确性，第一行为表格头，第二行开始为数据！\r\n是否继续进行？","询问",MessageBoxButtons.YesNo))
                {
                    return;
                }
            }
            obj = new QyTech.SkinForm.UICreate.frmFName2ExcelCol("wj_GisDb", tableName, ExcelCols);
            obj.AfterFName2ExcelColMapping += new QyTech.SkinForm.UICreate.frmFName2ExcelCol.FName2ExcelColMappingHandle(Obj_AfterFName2ExcelColMapping);
            obj.ShowDialog();
        }

        private void Obj_AfterFName2ExcelColMapping(Dictionary<string, string> fName2excelCol)
        {
            dicFname2ExcelCol = fName2excelCol;
        }

        private void qyBtnImport_Click(object sender, EventArgs e)
        {
            try
            {
                QyExcelHelper exHlper = new QyExcelHelper("Local");

                string ExcelNotNullCols = "";
                if (dicFname2ExcelCol == null)
                {
                    dicFname2ExcelCol = new Dictionary<string, string>();
                    foreach (bsFName2ExcelColMap m in FName2ExcelCols)
                    {
                        dicFname2ExcelCol.Add(m.FName, m.ExcelCName);
                        if (m.ColNotNull!=null && m.ColNotNull.Value)
                        {
                            ExcelNotNullCols += "," + m.FName;
                        }
                    }
                }

                //判断非空列是否给了映射，没有给的话不能继续执行
                string[] notnullcol = ExcelNotNullCols.Split(new char[] { ',' });
                for (int i = 0; i < notnullcol.Length; i++)
                {
                    if (dicFname2ExcelCol[notnullcol[i]].Trim() == "")
                    {
                        MessageBox.Show(notnullcol[i] + "不能为空!必须有映射列！");
                        return;
                    }
                }

                //开始导入数据
                exHlper.CopiedEvent += new QyExcelHelper.delegateCopyHandler(ExHlper_CopiedEvent);
                DataTable dtUnImported = exHlper.TransferDataWithSql(dtSheet, strSqlConn, tableName, dicFname2ExcelCol, chkDel.Checked, ExcelNotNullCols);
                RefreshDbTable(sqlConn);

                dgvUnImported.Columns.Clear();
                dgvUnImported.DataSource = dtUnImported;
                tabControl2.TabPages[2].Text = "未导入数据  (" + dtUnImported.Rows.Count.ToString() + "条)";
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
       
        private void ExHlper_CopiedEvent(long copycount, long Total)
        {
            if (copycount == Total)
                pbrExcelImport.Visible = false;
            else 
            {
                pbrExcelImport.Visible = true;
                pbrExcelImport.Maximum = (int)Total;
                pbrExcelImport.Minimum = 0;
            }
            pbrExcelImport.Value = (int)copycount;// * 100 / Total);
            //pbrExcelImport.PercentValue= (int)(copycount * 100 / Total);
        }

        private DataTable GetDataTable(SqlConnection sqlconn)
        {
            string strSql = "select * from [" + tableName + "]";//表名的写法也应注意不同，对应的excel表为sheet1，在这里要在其后加美元符号$，并用中括号
            SqlCommand Cmd = new SqlCommand(strSql, sqlconn);//建立要执行的命令
            SqlDataAdapter da = new SqlDataAdapter(Cmd);//建立数据适配器
            ds.Tables.Clear();
            da.Fill(ds);//把数据适配器中的数据读到数据集中的一个表中（此处表名为shyman，可以任取表名）
                        //指定datagridview1的数据源为数据集ds的第一张表（也就是shyman表），也可以写ds.Table["shyman"]
            dtImported = ds.Tables[0];
            return dtImported;
        }

       

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sheetName = comboBox1.Text;
        }

        private void qyBtnQueryDb_Click(object sender, EventArgs e)
        {
            RefreshDbTable(sqlConn);
        }
        private void RefreshDbTable(SqlConnection sqlconn)
        {
            dtImported = GetDataTable(sqlConn);
            dgvImported.Columns.Clear();
            dgvImported.DataSource = dtImported;

            QyTech.SQLDA.SqlUtil.ResetDgvHeader(dgvImported, MainForm.QyTech_EM, "bsT_Id='" + bsT_Id + "'", "NoInList");
            //List<bsFunField> bffs = MainForm.QyTech_EM.GetListNoPaging<bsFunField>("bsT_Id='" + bsT_Id + "'", "FNo");
            //dgvImported.Columns[0].Visible = false;
            //for (int i =1; i < bffs.Count; i++)
            //{
            //    try
            //    {
            //        dgvImported.Columns[i].Visible = bffs[i].VisibleInList==null?true:(bool)bffs[i].VisibleInList;
            //        dgvImported.Columns[i].HeaderText = bffs[i].FDesp;
            //        dgvImported.Columns[i].Width = (int)bffs[i].FWidthInList;
            //    }
            //    catch { }
            //}
            tabControl2.TabPages[1].Text = "全部已导入数据  (" + dtImported.Rows.Count.ToString() + "条)";

            tabControl2.SelectedIndex = 1;
        }

        private void qyDgv_Table_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bsT_Id = qyDgv_Table.Rows[e.RowIndex].Cells[0].Value.ToString();
                tableName = qyDgv_Table.Rows[e.RowIndex].Cells[1].Value.ToString();
                FName2ExcelCols = MainForm.QyTech_EM.GetListNoPaging<bsFName2ExcelColMap>("TName='" + tableName + "'", "FNo");

                RefreshDbTable(sqlConn);
            }
            catch { }
        }

        private void frmExcelImport_Shown(object sender, EventArgs e)
        {
            qyDgv_Table.CurrentCell = qyDgv_Table.Rows[0].Cells[2];
            qyDgv_Table_CellClick(qyDgv_Table, new DataGridViewCellEventArgs(2, 0));

        }
    }
}
