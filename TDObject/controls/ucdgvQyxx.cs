using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SunMvcExpress.Dao;



namespace TDObject.controls
{
    public partial class ucdgvQyxx : UserControl
    {

        List<z租赁企业信息表> _zlinfos;
        企业范围 _ltdinfo;

        private bool RefreshExQyxx = false;
        private bool StartEditFlag = false;

     
        public ucdgvQyxx()
        {
            InitializeComponent();
        }

        public void RefreshData(企业范围 ltdinfo)
        {

            RefreshExQyxx = false;
            StartEditFlag = false;
            _ltdinfo = ltdinfo;
         
            _zlinfos = MainForm.EM.GetListNoPaging<z租赁企业信息表>("地块编码='" + _ltdinfo.地块编码 + "'", "");
            BindingList<z租赁企业信息表> bs_objs = new BindingList<z租赁企业信息表>(_zlinfos);
            this.dgvZlQy.AutoGenerateColumns = false;
            dgvZlQy.DataSource = bs_objs;
            dgvZlQy.AllowUserToAddRows = true;


            List<LtdProblem> ltdproblems = MainForm.EM.GetListNoPaging<LtdProblem>("地块编码='" + ltdinfo.地块编码 + "'", "");
            BindingList<LtdProblem> bs_objs1 = new BindingList<LtdProblem>(ltdproblems);
            this.dgvQyccQuery.AutoGenerateColumns = false;
            dgvQyccQuery.DataSource = bs_objs1;



        }

        private void dgvQyxx_Load(object sender, EventArgs e)
        {
            if (dgvZlQy.Columns.Count == 0)
            {
                this.dgvZlQy.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15,
            this.dataGridViewTextBoxColumn20,
            this.Column16,
            this.dataGridViewTextBoxColumn22,
            this.dataGridViewTextBoxColumn23,
            this.Column18,
            this.Column19,
            this.Column20,
            this.Column21,
            this.Column22,
            this.dataGridViewTextBoxColumn29,
            this.Column23,
            this.Column24,
            this.Column25,
            this.Column26,
            this.Column27,
            this.Column28,
            this.Column29,
            this.Column30,
            this.Column31,
            this.Column32});
            }
        }

        private void btnZlqyxxSave_Click(object sender, EventArgs e)
        {
            string ret, res = "";
            try
            {
                foreach (租赁企业信息表 ui in _zlinfos)
                {
                    if (ui.OBJECTID != 0)
                    {
                        ret = MainForm.EM.Modify<租赁企业信息表>(ui);
                        if (ret != "")
                            res += ret + ",";
                    }
                    else
                    {
                        ret = MainForm.EM.Add<租赁企业信息表>(ui);
                        if (ret != "")
                            res += ret + ",";

                    }

                }
                if (res != "")
                    MessageBox.Show("保存出现问题！" + res);
                else
                    MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.dgvZlQy.CurrentCell != null)
            {
                租赁企业信息表 ui = _zlinfos[dgvZlQy.CurrentRow.Index];
                string ret = MainForm.EM.DeleteById<租赁企业信息表>("OBJECTID", ui.OBJECTID);
                if (ret!="")
                {
                    MessageBox.Show("删除失败!"+ret);
                }
                else
                {
                   _zlinfos = MainForm.EM.GetListNoPaging<租赁企业信息表>("地块编码='" + _ltdinfo.地块编码 + "'", "");
                    BindingList<租赁企业信息表> bs_objs = new BindingList<租赁企业信息表>(_zlinfos);
                    dgvZlQy.DataSource = bs_objs;

                    MessageBox.Show("删除成功");
                }
            }
        }
     
        private void dgvQyxx_DataSourceChanged(object sender, EventArgs e)
        {
           
        }
        private void dgvZlQy_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //每次增加都会触发
            if (StartEditFlag && dgvZlQy.Rows.Count>1)
            {
                string dkbm = _ltdinfo.地块编码;
                if (dgvZlQy.CurrentCell != null)
                {
                    dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[3].Value = _ltdinfo.地块编码;
                   // dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[4].Value = _ltdinfo.;
                    dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[5].Value = _ltdinfo.所属行政村名称;
                    dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[6].Value = _ltdinfo.所属行政村代码;
                    dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[8].Value = _ltdinfo.所属行政镇名称;
                    dgvZlQy.Rows[dgvZlQy.CurrentCell.RowIndex].Cells[7].Value = _ltdinfo.所属行政镇代码;


                }
            }
        }

        private void dgvZlQy_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            StartEditFlag = true;
        }
    }

       
}
