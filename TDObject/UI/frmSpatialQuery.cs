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
    public partial class frmSpatialQuery : Form
    {
        private string LayerName= "";
        private string LayerObjCode = "";
        private string LayerObjName = "";


        private IntersectTotalInfo totalinfo = new IntersectTotalInfo();
        private WTGeoWeb.BLLForAdmin.IntersectTotalInfo totalinfoForAdmin = new WTGeoWeb.BLLForAdmin.IntersectTotalInfo();


        public frmSpatialQuery(IntersectTotalInfo TotalInfo)
        {
            InitializeComponent();
            DgvInit();

            totalinfo = TotalInfo;

            LayerName = totalinfo.LayerName;
            LayerObjCode = totalinfo.ObjCode;
            LayerObjName = totalinfo.ObjName;
        }

        public frmSpatialQuery(WTGeoWeb.BLLForAdmin.IntersectTotalInfo TotalInfo)
        {
            InitializeComponent();
            DgvInit();

            totalinfoForAdmin = TotalInfo;

            LayerName = totalinfoForAdmin.LayerName;
            LayerObjCode = totalinfoForAdmin.ObjCode;
            LayerObjName = totalinfoForAdmin.ObjName;
        }
        private void DgvInit()
        {
            this.dgv11.AutoGenerateColumns = false;
             this.dgv21.AutoGenerateColumns = false;
            this.dgv22.AutoGenerateColumns = false;
            this.dgv31.AutoGenerateColumns = false;
            this.dgv32.AutoGenerateColumns = false;

            this.dgv11.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv21.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv22.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv31.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv32.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            this.dgv11.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv21.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv22.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv31.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv32.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);


            dgv11.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv11.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgv21.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv21.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgv22.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv22.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgv31.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv31.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgv32.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv32.RowsDefaultCellStyle.BackColor = Color.Beige;
          
        }




        private void frmSpatialQuery_Load(object sender, EventArgs e)
        {
            this.Text = LayerName + this.Text;
 
            if (totalinfo.ObjCode=="")
            {
                MessageBox.Show("未查询到信息！", "信息提示");
                this.Close();
            }

            if (totalinfoForAdmin == null||totalinfoForAdmin.LayerName==null)
            {
                Dictionary<string, List<TotalTypeInfo>> totalData = new Dictionary<string, List<TotalTypeInfo>>();
                List<TotalTypeInfo>[] ttis = new List<TotalTypeInfo>[4];
                List<TotalLtdInfo> pcs = new List<TotalLtdInfo>();

                for (int i = 0; i < 4; i++)
                {
                    ttis[i] = new List<TotalTypeInfo>();
                    foreach (TotalTypeInfo tti in totalinfo.totalLayers[i].totalTypes.Values)
                    {
                        ttis[i].Add(tti);
                        if (i == 3)
                        {
                            foreach (TotalLtdInfo ltdobj in totalinfo.totalLayers[i].totalTypes["历年批次"].totalLtds.Values)
                            {
                                pcs.Add(ltdobj);
                            }
                        }
                    }
                }
                totalData.Add("土地现状", ttis[0]);
                totalData.Add("土地规划", ttis[1]);
                totalData.Add("城市规划", ttis[2]);
                totalData.Add("历年批次", ttis[3]);
                //totalData.Add("批次明细", ttis[3]);


                this.dgv11.DataSource = totalData["土地现状"];
                this.dgv21.DataSource = totalData["土地规划"];
                this.dgv22.DataSource = totalData["城市规划"];
                this.dgv31.DataSource = totalData["历年批次"];

                //List<TotalLayerInfo> pcobjs = new List<TotalLayerInfo>();
                //totalinfo.totalLayers[3].ItemName = "历年批次";
                // pcobjs.Add(totalinfo.totalLayers[3]);
                //this.dgv31.DataSource = pcobjs;

                this.dgv32.DataSource = pcs;


                //获取建筑面积数据
            }
            else
            {
                Dictionary<string, List<WTGeoWeb.BLLForAdmin.TotalTypeInfo>> totalData = new Dictionary<string, List<WTGeoWeb.BLLForAdmin.TotalTypeInfo>>();
              
                totalData.Add("土地现状", totalinfoForAdmin.totalLayers[0].totalTypes);
                totalData.Add("土地规划", totalinfoForAdmin.totalLayers[1].totalTypes);
                totalData.Add("城市规划", totalinfoForAdmin.totalLayers[2].totalTypes);
               

                this.dgv11.DataSource = totalData["土地现状"];
                this.dgv21.DataSource = totalData["土地规划"];
                this.dgv22.DataSource = totalData["城市规划"];

                List<TotalTypeInfo> pctotals = new List<TotalTypeInfo>();
                TotalTypeInfo tti = new TotalTypeInfo();
                tti.RegionCount = totalinfoForAdmin.totalLayers[3].RegionCount;
                tti.ItemName = "历年批次";// totalinfoForAdmin.totalLayers[3].ItemName;
                tti.RegionArea = totalinfoForAdmin.totalLayers[3].RegionArea;
                pctotals.Add(tti);
                this.dgv31.DataSource = pctotals;

                List<TotalLtdInfo> tlis = new List<TotalLtdInfo>();
                foreach (WTGeoWeb.BLLForAdmin.TotalTypeInfo item in totalinfoForAdmin.totalLayers[3].totalTypes)
                {
                    TotalLtdInfo tli = new TotalLtdInfo();
                    tli.LtdName = item.ItemName;
                    tli.RegionArea = item.RegionArea;
                    tli.RegionCode = item.RegionCodes;
                    tlis.Add(tli);
                }
                this.dgv32.DataSource = tlis;
            
            }
        }


        private void dgv_AddNoColumn(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        private void dgv11_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // 村镇：TotalTypeName,bsOCodes
            // 地块： TotalTypeName,BuildingCodes
            if (dgv11.Columns[e.ColumnIndex].Name == "clnDetail")
            {
                // string  e.RowIndex
                //占击按钮操作
                string ItemName = dgv11.Rows[e.RowIndex].Cells["clnItemName"].Value.ToString();
                
                string Result ="";
                List<TotalLtdInfo> ltdinfos=new List<TotalLtdInfo>();
                List<vwLtdTotalInfo> dbobjs = new List<vwLtdTotalInfo>();
                if (LayerName == null)
                    return;
                if ("镇界,村界".Contains(LayerName))
                {
                    string regionCodes = totalinfoForAdmin.ObjCode;
                    Result = Conection.GetPostStringRetStr(MainForm.URI +"ShowView/GetTypeDetailsForPc", "regionCodes=" + regionCodes + "&typename=" + ItemName);
                    ltdinfos = JsonHelper.DeserializeJsonToList<TotalLtdInfo>(Result);
                    //foreach (vwLtdTotalInfo obj in dbobjs)
                    //{
                    //    TotalLtdInfo tli = new TotalLtdInfo();
                    //    tli.BuildingArea = (decimal)obj.jzmj;
                    //    tli.FloorArea = (decimal)obj.jzzdmj;

                    //    tli.LtdName = obj.qymc;
                    //    tli.LtdNo = obj.OBJECTID;
                    //    tli.RegionCode = "";
                    //    ltdinfos.Add(tli);
                    //}
                }
                else
                {
                    foreach (TotalLtdInfo tli in totalinfo.totalLayers[0].totalTypes[ItemName].totalLtds.Values)
                    {
                        ltdinfos.Add(tli);
                    }
                    //ltdinfos = totalinfo.totalLayers[0].totalTypes[ItemName].totalLtds;
                    //foreach(TotalTypeInfo tti in totalinfo.totalLayers[0].totalTypes.Values)
                    //{
                    //    if (tti.ItemName==ItemName)
                    //    {
                    //        ltdinfos = tti.totalLtds;
                    //    }
                    //}
                }

                frmLtdTotalInfo frmobj = new frmLtdTotalInfo(ltdinfos);
                frmobj.ShowDialog();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       
    }
}
