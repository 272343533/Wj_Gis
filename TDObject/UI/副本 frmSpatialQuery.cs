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
namespace TDObject.UI
{
    public partial class frmSpatialQuery : Form
    {
        private string ExtCodes = "";
        private string LayerName= "";
        private string LayerObjCode = "";
        private string ExtBuidingCodes = "";
        private string ExtBatchCodes = "";


        private string TotalItemStr = string.Empty;
        private List<tmpTotalItem> itemlist = new List<tmpTotalItem>();

        int bitOverlyFlag;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layerName">对应哪个层的查询</param>
        /// <param name="layerObjCode">要素对象</param>
        /// <param name="TotalItemStr">统计数据</param>
        /// <param name="ExtBuidingCodes">扩展的代码：房屋建筑列表</param>
        /// <param name="ExtBatchCodes">扩展的代码：批次地块代码列表</param>
        public frmSpatialQuery(string layerName,string layerObjCode,string totalItemStr,int OverlyFlag)
        {
            InitializeComponent();
             DgvInit();

            LayerName = layerName;
            LayerObjCode = layerObjCode;
            TotalItemStr = totalItemStr;

            bitOverlyFlag = OverlyFlag;

       }
        public frmSpatialQuery(string layerName, string layerObjCode, List<tmpTotalItem> TotalItem, string extBuidingCodes, string extBatchCodes,int OverlyFlag=1 )
        {
            InitializeComponent();
            DgvInit();

            itemlist = TotalItem;

            LayerName = layerName;
            LayerObjCode = layerObjCode;
            ExtBuidingCodes = extBuidingCodes;
            ExtBatchCodes = extBatchCodes;
            bitOverlyFlag = OverlyFlag;
        }
        private void DgvInit()
        {
            this.dgv11.AutoGenerateColumns = false;
            this.dgv12.AutoGenerateColumns = false;
            this.dgv21.AutoGenerateColumns = false;
            this.dgv22.AutoGenerateColumns = false;
            this.dgv31.AutoGenerateColumns = false;
            this.dgv32.AutoGenerateColumns = false;

            this.dgv11.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv12.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv21.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv22.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv31.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgv32.SelectionMode = DataGridViewSelectionMode.FullRowSelect;


            this.dgv11.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv12.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv21.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv22.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv31.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);
            this.dgv32.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_AddNoColumn);


            dgv11.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv11.RowsDefaultCellStyle.BackColor = Color.Beige;
            dgv12.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv12.RowsDefaultCellStyle.BackColor = Color.Beige;
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
          
            List<tmpTotalItem> objs = new List<tmpTotalItem>();

            if (TotalItemStr != string.Empty && TotalItemStr != null)
            {
                itemlist = JsonHelper.DeserializeJsonToList<tmpTotalItem>(TotalItemStr);

            }
            else
            {
               //把itemlist处理完整
            }
            if (itemlist.Count == 0)
            {
                MessageBox.Show("未查询到信息！", "信息提示");
                this.Close();
            }
            Dictionary<string, List<tmpTotalItem>> totalData = new Dictionary<string, List<tmpTotalItem>>();
            totalData.Add("土地现状1", new List<tmpTotalItem>());
            totalData.Add("土地现状2", new List<tmpTotalItem>());
            totalData.Add("土地规划", new List<tmpTotalItem>());
            totalData.Add("城市规划", new List<tmpTotalItem>());
            totalData.Add("历年批次", new List<tmpTotalItem>());
            totalData.Add("批次明细", new List<tmpTotalItem>());

            string strNoBuildingArea = "工业,经营性住宅,行政事业用地,商业用地,拆迁安置区";
            foreach (tmpTotalItem obj in itemlist)
            {
                if ((obj.TotalType == "土地现状"))
                {
                    if (strNoBuildingArea.Contains(obj.ItemName))
                    {
                        totalData["土地现状1"].Add(obj);
                    }
                    else
                        totalData["土地现状2"].Add(obj);
                }
                else
                {
                    totalData[obj.TotalType].Add(obj);
                }
            }

            //获取建筑面积数据 加入到totalData["土地现状1"];
            if (ExtBuidingCodes != null && !ExtBuidingCodes.Equals(""))
            {
                string Result = Conection.GetPostStringRetStr("http://122.114.38.213/Td_Gis/QueryTotal/QueryTotalItemIntersect", "Ids=" + ExtBuidingCodes);
                List<tmpTotalItem> buildsobjs = JsonHelper.DeserializeJsonToList<tmpTotalItem>(Result);
                for (int i = 0; i < buildsobjs.Count; i++)
                {
                    tmpTotalItem obj = buildsobjs[i];
                    if (i < buildsobjs.Count - 2)
                    {
                        totalData["土地现状1"][i].BuildingArea = obj.BuildingArea;
                        totalData["土地现状1"][i].BuildingFloorArea = obj.BuildingFloorArea;
                    }
                    else
                    {
                        totalData["土地现状2"].Add(buildsobjs[i]);
                    }
                }
            }
            
            this.dgv11.DataSource = totalData["土地现状1"];
            this.dgv12.DataSource = totalData["土地现状2"];
            this.dgv21.DataSource = totalData["土地规划"];
            this.dgv22.DataSource = totalData["城市规划"];
            this.dgv31.DataSource = totalData["历年批次"];
            this.dgv32.DataSource = totalData["批次明细"];


            //获取建筑面积数据
           
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
            string TotalTypeName="";
            string Codes="";
            if (dgv11.Columns[e.ColumnIndex].Name == "clnDetail")
            {
                // string  e.RowIndex
                //占击按钮操作
                string ItemName = dgv11.Rows[e.RowIndex].Cells["clnItemName"].Value.ToString();
                
                string Result ="";
                if ("镇界,村界".Contains(LayerName))
                    Result=Conection.GetPostStringRetStr("http://122.114.38.213/Td_Gis/LtdInfo/QueryLtdTotalInfo", "TotalTypeName=" + ItemName + "&Codes=" + LayerObjCode + "&CodeType=1");
                else
                    Result=Conection.GetPostStringRetStr("http://122.114.38.213/Td_Gis/LtdInfo/QueryLtdTotalInfo", "TotalTypeName=" + ItemName + "&Codes=" + ExtBuidingCodes + "&CodeType=2");
                List<tmpLtdTotalArea> objs= JsonHelper.DeserializeJsonToList<tmpLtdTotalArea>(Result);

                frmLtdTotalInfo frmobj = new frmLtdTotalInfo(objs);
                frmobj.ShowDialog();
               
            }
        }
       
    }
}
