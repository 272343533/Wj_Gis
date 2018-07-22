using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using QyTech.Core.BLL;
using SunMvcExpress.Dao;

using TDObject.MapControl;

using ESRI.ArcGIS.Carto;


namespace TDObject.UI
{
    public partial class frmLtdQyxx : FlatForm
    {

        private MainForm _parent;
        private int _QueryType;
        private string _dkbm = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="QueryType">1:非空间查询 2：空间查询</param>
        public frmLtdQyxx(int QueryType,MainForm parent,string dkbm="")
        {
            _parent = parent;
            _QueryType = QueryType;
            _dkbm = dkbm;

            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "查询中...";
            this.Refresh();
            //if (_QueryType != 1)
            //{
            //    this.panel1.Visible = false;
            //    this.textBox1.Text = _dkbm;
            //}
            RefreshMainInfoDgv();
            button1.Text = "查询";
        }

        private void frmLtdQyxx_Load(object sender, EventArgs e)
        {
            dgvQyxxWithZl.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
            

            if (_QueryType != 1)
            {
                this.panel1.Visible = false;
                this.textBox1.Text = _dkbm;
                RefreshMainInfoDgv();
            }
            //RefreshMainInfoDgv();
        }
        private void RefreshMainInfoDgv()
        {
            try
            {

                List<tmpLtdXx> dbobjs;
                if (_QueryType==1)
                    dbobjs = MainForm.EM.GetListNoPaging<tmpLtdXx>("YDQYMC like '%" + this.textBox1.Text.Trim() + "%'" + MainForm.LoginUserRights, "Id");
                else
                    dbobjs = MainForm.EM.GetListNoPaging<tmpLtdXx>("DKBH = '" + this.textBox1.Text.Trim() + "'" + MainForm.LoginUserRights, "");


                BindingList<tmpLtdXx> bs_objs = new BindingList<tmpLtdXx>(dbobjs);
                this.dgvQyxxWithZl.AutoGenerateColumns = false;
                this.dgvQyxxWithZl.AllowUserToAddRows = false;

                dgvQyxxWithZl.DataSource = bs_objs;
            }
            catch (Exception ex)
            {
                MessageBox.Show("操作失败！" + ex.Message);
            }

        }

        //单击高亮
        private void dgvQyxxWithZl_Click(object sender, EventArgs e)
        {
            if (dgvQyxxWithZl.CurrentCell != null)
            {
                string id = dgvQyxxWithZl.Rows[dgvQyxxWithZl.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string dkbm = dgvQyxxWithZl.Rows[dgvQyxxWithZl.CurrentCell.RowIndex].Cells[1].Value.ToString();

                _parent.HighLightObjs("企业范围", dkbm);
            }
            else
            {
                MessageBox.Show("请首先选中企业！");
            }
        }

   
        //双击定位
        private void dgvQyxxWithZl_DoubleClick(object sender, EventArgs e)
        {
            if (dgvQyxxWithZl.CurrentRow != null)
            {
                string id = dgvQyxxWithZl.Rows[dgvQyxxWithZl.CurrentCell.RowIndex].Cells[0].Value.ToString();
                string dkbm = dgvQyxxWithZl.Rows[dgvQyxxWithZl.CurrentCell.RowIndex].Cells[1].Value.ToString();

                _parent.ChangeToPositioin("企业范围", dkbm);
            }
            else
            {
                MessageBox.Show("请首先选中企业！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //获取当前企业，然后进行查处
            //然后传入数据进行查处
        //    if (dgvQyxxWithZl.CurrentRow != null)
        //    {
        //        List<tmpLtdXx> objs = new List<tmpLtdXx>((BindingList<tmpLtdXx>)this.dgvQyxxWithZl.DataSource);

        //        tmpLtdXx obj = objs[dgvQyxxWithZl.CurrentRow.Index];
        //        frmLtdCcclEdit frmobj = new frmLtdCcclEdit(obj);
        //        frmobj.Show();
        //    }
        //    else
        //    {
        //        MessageBox.Show("请首先选中企业！");
        //    }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
