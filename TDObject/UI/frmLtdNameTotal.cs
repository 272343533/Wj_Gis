using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;

using ESRI.ArcGIS.Output;

using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Geodatabase;

using TDObject.MapControl;

using SunMvcExpress.Dao;

using TDObject.IdentifyTool;
using System.Windows.Forms.DataVisualization.Charting;

namespace TDObject.UI
{
    public partial class frmLtdNameTotal : QyTech.SkinForm.qyFormWithTitle
    {
        IEnvelope _ext;


        int id;
        string dkbh;
        string ltdname;

        List<t企业基础数据> Objs;//倒序，0标识最新的数据。
        List<LtdPhoto> photos;
        int CurrPhotoNo;

        public frmLtdNameTotal(IEnvelope ext)//AxMapControl axmap)
        {
            InitializeComponent();
            //_axmap = axmap;
            _ext = ext;
        }


        private void RefreshDgv(string ltname)
        {
            List<bsLtdInfo> objs;
            if (ltname=="")
                objs= BLL.CommSetting.EM.GetListNoPaging<bsLtdInfo>("租赁企业否=0", "纳税人名称");
            else
                objs = BLL.CommSetting.EM.GetListNoPaging<bsLtdInfo>("租赁企业否=0 and 纳税人名称 like '%"+ltname+"%'", "纳税人名称");
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = objs;

        }
        private void frmLtdNameTotal_Load(object sender, EventArgs e)
        {
            try
            {
                this.Title = "单企业统计";
                dataGridView1.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                RefreshDgv("");
                //企业照片点位置,红牌警告点位置,黄牌警告点位置,安全检查点位置,行政区,管理区,房屋建筑,企业范围,道路注记,河流注记,道路,河流");//D_Spatial.SDE.

                //if (this.axMapControl2.LayerCount > 1)
                //    this.axMapControl2.ClearLayers();
                string displayLayerName = GlobalVariables.LayerName2FullName["行政区"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["管理区"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["房屋建筑"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["企业范围"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["道路注记"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["道路"];
                displayLayerName += "," + GlobalVariables.LayerName2FullName["河流"];

                if (this.axMapControl1.LayerCount == 0)
                {
                    for (int i = GlobalVariables.axMapControl.LayerCount - 1; i > 0; i--)
                    {
                        if (displayLayerName.Contains(GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i).Name))

                            this.axMapControl1.AddLayer(GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i));
                    }
                }

                LayerControl.SetVisibleStatus(this.axMapControl1, GlobalVariables.LayerName2FullName["企业范围"], true);
                LayerControl.SetVisibleStatus(this.axMapControl1, GlobalVariables.LayerName2FullName["房屋建筑"], true);

                this.axMapControl1.Extent = _ext;

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
          
        }

        private void frmLtdNameTotal_Shown(object sender, EventArgs e)
        {
            this.chkXs.ForeColor = Color.Blue;
            this.chkSs.ForeColor = Color.Green;
            this.chkNh.ForeColor = Color.Red;

            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.axMapControl1.Extent = _axmap.Extent;

            FrmLtdZlqyxxNew obj = new FrmLtdZlqyxxNew(dkbh);
            obj.Show();
        }

        private void axMapControl1_OnExtentUpdated(object sender, IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            try
            {
                for (int i = 0; i < this.axMapControl1.LayerCount; i++)
                {
                    ILayer player = GlobalVariables.GetOverviewLayer(this.axMapControl1.Map, i);
                    IFeatureLayer pflayer = player as IFeatureLayer;
                    GlobalVariables.UpdataLabel(this.axMapControl1, pflayer);

                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            try
            {
                DataGridView dgv = sender as DataGridView;
                SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);

                e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            label8.Text = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            try
            {
                if (dataGridView1.CurrentCell == null)
                    return;
                if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value == null)
                {
                    MessageBox.Show("该企业没有地块编号数据，请补充基础数据！");
                    return;
                }
                dkbh = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[2].Value.ToString();
                ltdname = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value.ToString();
            
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dataGridView1.CurrentCell.RowIndex >= 0)
                {
                    if (dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[1].Value != null)
                    {
                         pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbh);

                        if (pGeo.Count > 0)
                        {
                            FindGeos.Add(pGeo[0]);
                        }

                        ExDisplayLtdFeature(FindGeos);

                        LayerControl.ChangeMapExtent(this.axMapControl1, pGeo[0].Extent);
                    }
                }

                //刷新数据
                企业范围 ltdobj = MainForm.EM.GetByPk<企业范围>("DKBH", dkbh);
                this.textBox1.Text = ltdobj.ZDMJ.ToString();
                this.textBox2.Text = ltdobj.JZMJ.ToString();
                this.textBox6.Text = ltdobj.FZMJ_.ToString();


                int RowIndex = dataGridView1.CurrentCell.RowIndex;
                if (RowIndex >= 0)
                {
                    Objs = MainForm.EM.GetListNoPaging<t企业基础数据>("单位='"+ltdname+"'", "年度+'-'+月份 desc ");
                    if (Objs.Count > 0)
                    {
                        this.textBox3.Text = Objs[0].销售.ToString();
                        this.textBox4.Text = Objs[0].税收.ToString();
                        this.textBox5.Text = Objs[0].用能.ToString();
                    }
                    //图形
                    DisplayChart();
                }



                List<vwLtdJcSj> rentltdobjs=MainForm.EM.GetListNoPaging<vwLtdJcSj>("地块编号='"+dkbh+"'","");
                if (rentltdobjs.Count > 0)
                    btnRent.Enabled = true;
                else
                    btnRent.Enabled = false;

                //照片部分
                photos = MainForm.EM.GetListNoPaging<LtdPhoto>("SSQYMC='" + ltdname + "'", "OBJECTID desc");
                CurrPhotoNo = 0;
                if (photos.Count > 0)
                {
                    CurrPhotoNo = 1;
                    DispImg();
                }
                else
                {
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\noimage.jpg");
                }
                textBox7.Text = CurrPhotoNo.ToString() + "/" + photos.Count.ToString();
                //if (photos.Count > 0)
                //{
                //    pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + photos[0].PICTURE).GetResponse().GetResponseStream());
                //}
                //else
                //{
                //    pictureBox1.Image =Image.FromFile(Application.StartupPath+@"\noimage.jpg");
                //}

              
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

       
        private void btnFirst_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo != 1)
                {
                    CurrPhotoNo = 1;
                    DispImg();
                }
            }
        }

        private void btnPre_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo > 1)
                {
                    CurrPhotoNo -= 1;
                    DispImg();
                }
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo < photos.Count)
                {
                    CurrPhotoNo += 1;
                    DispImg();
                }
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo != photos.Count)
                {
                    CurrPhotoNo = photos.Count;
                    DispImg();
                }
            }
        }
        private void DispImg()
        {
            try
            {
                textBox7.Text = CurrPhotoNo.ToString() + "/" + photos.Count.ToString();

                string filename = photos[CurrPhotoNo - 1].PICTURE;

                pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + filename).GetResponse().GetResponseStream());
               
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到图片数据！");
            }
        }
        private void ExDisplayLtdFeature(List<IFeature> FindGeos)
        {
            try
            {
                FlashObjectsClass flashObjects=flashObjects = new FlashObjectsClass();
                flashObjects.MapControl = this.axMapControl1.Object as IMapControl2;
                flashObjects.Init();

                if (FindGeos.Count > 0)
                {
                    foreach (IFeature fea in FindGeos)
                        flashObjects.AddGeometry(fea.Shape);
                }

                flashObjects.FlashObjects(0);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }


        private void qyBtn_Search1_Click(object sender, EventArgs e)
        {
            RefreshDgv(this.txtLName.Text.Trim());
        }

        private void chkNh_CheckedChanged(object sender, EventArgs e)
        {
            DisplayChart();
        }

        private void DisplayChart()
        {
            int monthCount = Objs.Count > 12 ? 12 : Objs.Count;
            int FromIndex = monthCount > 12 ? Objs.Count - 12 : 0;
            chart1.Series[0].AxisLabel = "月份";
            //chart1.Series[0].ChartType = SeriesChartType.Column;
            //更改图形数据
            double sum = 0;
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            for (int i = FromIndex; i < monthCount; i++)
            {
                if (chkXs.Checked)
                    chart1.Series[0].Points.AddXY(Objs[i].月份, Objs[i].销售);
                else
                    chart1.Series[0].Points.AddXY(Objs[i].月份, 0);
                if (chkSs.Checked)
                    chart1.Series[1].Points.AddXY(Objs[i].月份, Objs[i].税收);
                else
                    chart1.Series[1].Points.AddXY(Objs[i].月份, 0);
                if (chkNh.Checked)
                    chart1.Series[2].Points.AddXY(Objs[i].月份, Objs[i].用能);
                else
                    chart1.Series[2].Points.AddXY(Objs[i].月份, 0);


                //chart1.Series[0].Points[i].LegendText = item.TypeDesp;
                //chart1.Series[0].Points[i].LegendText = item.TypeDesp;
                //chart1.Series[0].Points[i].LegendText = item.TypeDesp;
                chart1.Series[0].Points[i].LabelToolTip = Objs[i].月份;
                chart1.Series[0].Points[i].AxisLabel = Objs[i].月份;//.Substring(0,2);
                //chart1.Series[0].ax

            }

            chart1.Show();
        }
    }
}
