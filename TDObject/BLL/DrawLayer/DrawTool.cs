using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Geodatabase;
using System.Collections;

using TDObject.DrawLayer;

namespace TDObject.DrawLayer
{
    public partial class DrawTool : Form
    {
        public IWorkspaceEdit sdeWorkspace;
        public AxMapControl amc;
        DrawLayer drawLayer = new DrawLayer();
        public DrawTool()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            drawLayer.DrawLayers(sdeWorkspace, amc);
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String creatName = this.textBox1.Text;
            String creatTime = this.dateTimePicker1.Value.ToString();
            String creatUser = MainForm.LoginUser.LoginName;
            drawLayer.DrawLayerSave(creatName, creatTime, creatUser);
            
            this.Close();
        }

        private void DrawTool_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = DateTime.Now;
        }
    }
}
