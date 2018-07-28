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

namespace TDObject.UI
{
    public partial class frmLtdNameTotal : FlatForm
    {
        IEnvelope _ext;


        int id;
        string dkbh;
        string ltdname;
        public frmLtdNameTotal(IEnvelope ext)//AxMapControl axmap)
        {
            InitializeComponent();
            //_axmap = axmap;
            _ext = ext;
         }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void frmLtdNameTotal_Load(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;

                List<企业范围> objs = BLL.CommSetting.EM.GetListNoPaging<企业范围>("", "YDQYMC");
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = objs;

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
            this.checkBox1.ForeColor = Color.Blue;
            this.checkBox2.ForeColor = Color.Yellow;
            this.checkBox3.ForeColor = Color.Red;

          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.axMapControl1.Extent = _axmap.Extent;

            FrmLtdZlqyxx obj = new FrmLtdZlqyxx(dkbh);
            FormSkin.ShowForm(obj);
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
                this.textBox3.Text = ltdobj.CZ_;
                this.textBox4.Text = ltdobj.SS_;
                this.textBox5.Text = ltdobj.NH_;


                List<z租赁企业信息表> rentltdobjs=MainForm.EM.GetListNoPaging<z租赁企业信息表>("DKBH='"+dkbh+"'","");
                if (rentltdobjs.Count > 0)
                    btnRent.Enabled = true;
                else
                    btnRent.Enabled = false;

                //照片部分
                List<LtdPhoto> photos = MainForm.EM.GetListNoPaging<LtdPhoto>("SSQYMC='" + ltdname + "'", "OBJECTID desc");
                if (photos.Count > 0)
                {
                    pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + photos[0].PICTURE).GetResponse().GetResponseStream());
                }

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void ExDisplayLtdFeature(List<IFeature> FindGeos)
        {
            try
            {
                FlashObjectsClass flashObjects;
                flashObjects = new FlashObjectsClass();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            MessageBox.Show("需要补充各月的相关数据");
        }

    }
}
