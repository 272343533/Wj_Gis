using QyTech.Json;
using SunMvcExpress.Dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDObject.BLL;
using WTGeoWeb.BLL;

namespace TDObject.UI
{
    public partial class frmLtdTotalInfo : Form
    {

        public frmLtdTotalInfo(List<TotalLtdInfo> objs)
        {
            InitializeComponent();

            this.dgv11 = dgvCommDisplay.InitDisp(dgv11);

            dgv11.DataSource = objs;
        }


        private void dgv11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv11.Columns[e.ColumnIndex].Name == "clnDetail")
            {
                // string  e.RowIndex
                //占击按钮操作
                string ItemName = dgv11.Rows[e.RowIndex].Cells["clnRegionCode"].Value.ToString();
                
                //string Result = Conection.GetPostStringRetStr("http://122.114.38.213/Td_Gis/LtdInfo/QueryLtdInfo", "ltdName=" + ItemName);
                //土地现状数据 obj = TDObject.BLL.CommSetting.EM.GetBySql<土地现状数据>("地块编码='"+ ItemName+"'");

                string DetailUrl = MainForm.URI + "/lyRemoteServ/GetLtdInfo?dkbm=" + ItemName;
                string json = AsyncHttp.CommFun.GetRemoteJson(DetailUrl);
                土地现状数据 obj = JsonHelper.DeserializeFormtJsonToObject<土地现状数据>(json);

                frmLtdInfo frmobj = new frmLtdInfo(obj);
                frmobj.ShowDialog();
              
            }
        }

        private void frmLtdTotalInfo_Load(object sender, EventArgs e)
        {

        }

    }
}
