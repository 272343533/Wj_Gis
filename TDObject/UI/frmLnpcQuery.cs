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
    public partial class frmLnpcQuery : Form
    {
        public frmLnpcQuery()
        {
            InitializeComponent();
        }

        List<string> years = new List<string>();

        private void frmLnpcQuery_Load(object sender, EventArgs e)
        {
            years.Add("");
            for (int i = 0; i <DateTime.Now.Year-1980; i++)
            {
                years.Add((DateTime.Now.Year - i).ToString()+"年");
            }
            DataGridViewComboBoxColumn dgvc = (DataGridViewComboBoxColumn)this.dgvLnpc.Columns[3];
            dgvc.DataSource = years;



            List<历年批次> dbobjs = MainForm.EM.GetListNoPaging<历年批次>(MainForm.LoginUserRights, "");


            BindingList<历年批次> bs_objs = new BindingList<历年批次>(dbobjs);
            this.dgvLnpc.AutoGenerateColumns = false;
            this.dgvLnpc.AllowUserToAddRows = false;

            dgvLnpc.DataSource = bs_objs;
           
        }

        private void btnRowSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvLnpc.CurrentCell != null)
                {

                    List<历年批次> uis = new List<历年批次>((BindingList<历年批次>)this.dgvLnpc.DataSource);
                    历年批次 ui = uis[dgvLnpc.CurrentRow.Index];
                    
                   
                        string ret = MainForm.EM.Modify<历年批次>(ui);

                        if (ret != "")
                            MessageBox.Show(ret);
                    else
                        MessageBox.Show("保存成功！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }

        private void btnTableSave_Click(object sender, EventArgs e)
        {
            try
            {
                string ret = "",res="";
                List<历年批次> uis = new List<历年批次>((BindingList<历年批次>)this.dgvLnpc.DataSource);

                foreach (历年批次 ui in uis)
                {
                    ret = MainForm.EM.Modify<历年批次>(ui) ;
                    if (ret != "")
                        res += ret + ",";
                }
                if (res != "")
                    MessageBox.Show(res.Substring(0, res.Length - 1));
                else
                MessageBox.Show("保存成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存失败！" + ex.Message);
            }
        }


    }
}
