using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDObject.UI
{
    public partial class frmUserMana_GlqRights : Form
    {
        public frmUserMana_GlqRights()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //if (CurrRowIndex == -1)
            //{
            //    MessageBox.Show("请先指定用户");
            //    return;
            //}
            //string rights = GetCheckedOrgRights(treeView1.Nodes[0]);

            //this.dgvEmp.Rows[CurrRowIndex].Cells[4].Value = this.comboBox1.Text;
            //this.dgvEmp.Rows[CurrRowIndex].Cells[5].Value = rights;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshTreeRights(treeView1.Nodes[0], true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RefreshTreeRightsReverse(treeView1.Nodes[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RefreshTreeRights(treeView1.Nodes[0], false);

        }

        private void RefreshTreeRights(TreeNode tn, string rights)
        {

            tn.Checked = false;
            if (rights.Contains(tn.Text))
            {
                tn.Checked = true;
            }
            foreach (TreeNode sub in tn.Nodes)
            {
                RefreshTreeRights(sub, rights);
            }

        }
        private void RefreshTreeRights(TreeNode tn, bool checkflag)
        {

            tn.Checked = checkflag;
            foreach (TreeNode sub in tn.Nodes)
            {
                RefreshTreeRights(sub, checkflag);
            }
        }
        private void RefreshTreeRightsReverse(TreeNode tn)
        {

            tn.Checked = !tn.Checked;
            foreach (TreeNode sub in tn.Nodes)
            {
                RefreshTreeRightsReverse(sub);
            }
        }
        private string GetCheckedOrgRights(TreeNode tn)
        {
            string rights = "";
            string subrights = "";
            if (tn.Checked)
            {
                rights += "," + tn.Text;
            }

            foreach (TreeNode sub in tn.Nodes)
            {
                subrights = GetCheckedOrgRights(sub);
                if (subrights != "")
                {
                    rights += "," + subrights;
                }
            }

            if (rights.Length > 0)
            {
                rights = rights.Substring(1);
            }

            return rights;
        }

    }
}
