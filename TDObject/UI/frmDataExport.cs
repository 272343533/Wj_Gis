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

namespace TDObject.UI
{
    public partial class frmDataExport : QyTech.SkinForm.qyForm
    {
        public frmDataExport()
        {
            InitializeComponent();
        }

        List<t市局表格> objs;
        List<t经发局表格> objs2;
        QyExcelHelper exExcelHelper = new QyExcelHelper("local");


        private void frmDataImport_Load(object sender, EventArgs e)
        {
            try
            {
                dgvSj.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;
                dgvJfj.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                this.cboNd.SelectedIndex = 0;

                this.dgvSj.AllowUserToAddRows = false;
                this.dgvJfj.AllowUserToAddRows = false;

                exExcelHelper.eventNumChanged += new DelegateForExportNo(EventNoChanged);

             }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
          }
        private void EventNoChanged(int num,int max)
        {
            if (num == 1)
            {
                pgbExport.Visible = true;
                pgbExport.Maximum = max;
            }
            else if (max == num)
                pgbExport.Visible = false;
            else
                pgbExport.Value = num;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedIndex == 0)
                {
                    objs = MainForm.EM.GetListNoPaging<t市局表格>("ND='" + cboNd.Text.Substring(0, 4) + "'", "XH");
                    dgvSj.AutoGenerateColumns = false;
                    dgvSj.DataSource = objs;
                }
                else if (tabControl1.SelectedIndex == 1)
                {
                    objs2 = MainForm.EM.GetListNoPaging<t经发局表格>("ND=" + cboNd.Text.Substring(0, 4), "");
                    // List<开发区表格> objs2 = MainForm.EM.GetListNoPaging<开发区表格>("", "");
                    dgvJfj.AutoGenerateColumns = false;
                    dgvJfj.DataSource = objs2;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<t市局表格> uis = dgvSj.DataSource as List<t市局表格>;

                t市局表格 obj = uis[e.RowIndex];
                string ret = MainForm.EM.Modify<t市局表格>(obj);
                if (ret=="")
                    MessageBox.Show("保存成功！");
                else
                    MessageBox.Show(ret);
                MessageBox.Show("表格修改需要明确哪些列可以改，哪些列不能修改，防止误修改！");
            }
        }

    

        private void dgvJfj_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                List<t经发局表格> uis = dgvSj.DataSource as List<t经发局表格>;

                t经发局表格 obj = uis[e.RowIndex];
                string ret = MainForm.EM.Modify<t经发局表格>(obj);
                if (ret == "")
                    MessageBox.Show("保存成功！");
                else
                    MessageBox.Show(ret);
            }

         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button4.Text = "正在导出...";
            
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter="Excel Files|*.xls";
                if (DialogResult.OK == sfd.ShowDialog())
                {
                    string filename = sfd.FileName;
                    if (tabControl1.SelectedIndex == 0)
                    {

                        exExcelHelper.ExportListToExcl<t市局表格>(objs, filename, "XH,ND,YF,DWDM,DW,SQ,QY,ZS,JYFW,ZCSJ,ZHY,HYXF,GM,QYS,CBRS,GS,DS,XS,ZD,QZCZ,NH,YD,PF,YFJFZC,PJZGRS,GDZCZJ,SCSJE,YYYE,ZGGZZE,SS,ZZZ,MJSS", "yyyy-MM-dd");

                    }
                    else if (tabControl1.SelectedIndex == 1)
                    {
                        exExcelHelper.ExportListToExcl<t经发局表格>(objs2, filename, "XH,NSRSBH,NSRMC,HGDM,ZCLX,HYDL,HYDM,LJXSWHJ,SNTQ,ZJL,SS,SNTQ_1,JCKE,SNTQ_2", "yyyy-MM-dd");
                    }
                    
                    MessageBox.Show("数据导出完成！");
                }

             }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            button4.Text = "导出Excel";
        }

      
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tabControl2_MouseMove(object sender, MouseEventArgs e)
        {
            //QyTech.SkinForm.qyFormUtil.MouseMoveForm(this.Handle);
        }

        private void dgvExcel_MouseMove(object sender, MouseEventArgs e)
        {
            
        }
    }
}
