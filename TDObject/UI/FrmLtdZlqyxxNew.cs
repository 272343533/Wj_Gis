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
using QyTech.Json;
using QyTech.Core.BLL;
using System.Data.SqlClient;

namespace TDObject.UI
{
    public partial class FrmLtdZlqyxxNew : QyTech.SkinForm.UICreate.frmList
    {
        List<vwLtdJcSj> listDbObjs;

        public FrmLtdZlqyxxNew(string dkbh):base(MainForm.QyTech_EM,MainForm.EM,MainForm.sqlConn, "t企业基础数据", "单位 in (select 纳税人名称 from bsLtdInfo where 地块编号='" + dkbh + "' and 租赁企业否=1)", "")
        {
            InitializeComponent();

            this.Title = "租赁企业管理";
        }

        private void qyBtn_Search1_Click(object sender, EventArgs e)
        {
            if (txtLName.Text.Trim() != "")
            {

                RefreshDgv("单位 like '%" + txtLName.Text.Trim() + "%'");
            }
            else
                RefreshDgv("");
        }

        private void FrmLtdZlqyxxNew_Load(object sender, EventArgs e)
        {
            //Init("F60E570C-D52B-40CA-9722-85F4D05A4CEA", MainForm.LoginUser);
            Init("B8DD9678-3489-4CFD-AF50-7CA1A701E10C", MainForm.LoginUser);

            VisibleBtnAdd = false;
            VisibleBtnDelete = false;

        }
    }
}
