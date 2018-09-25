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
    public partial class FrmUserManaNew : QyTech.SkinForm.UICreate.frmListWithLeft
    {
        public FrmUserManaNew():base(MainForm.QyTech_EM, MainForm.QyTech_EM, MainForm.sqlConn_Base, "bsUser", "", "")
        {
            InitializeComponent();
            this.Title = "用户管理";
        }

        private void qyBtn_Search1_Click(object sender, EventArgs e)
        {

            if (txtLName.Text.Trim() != "")
            {

                RefreshDgv("LoginName like '%" + txtLName.Text.Trim() + "%'");
            }
            else
                RefreshDgv("");
        }

        private void FrmUserManaNew_Load(object sender, EventArgs e)
        {
            Init("EA4B62AA-472E-4B3F-B152-FCCF61908CF8",MainForm.LoginUser);
        }
    }
}
