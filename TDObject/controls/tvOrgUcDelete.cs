using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SunMvcExpress.Dao;

using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Geodatabase;

using TDObject;
//using TDObject.IdentifyTool;
using TDObject.MapControl;
/*
using log4net;
using SfksDa;
*/

namespace SfksControls.Controls
{

    public partial class tvOrgUcDelete : UserControl
    {
        static log4net.ILog log = log4net.LogManager.GetLogger(" SfksControls.Controls tvOrgUcDelete");

        public delegate void delAfterSelect(object sender, TreeViewEventArgs e);

        public event delAfterSelect AfterSelect;
        AxMapControl pMapControl;
        public delegate void delDel(自由分区 org);

        public event delDel eventDel;
        public delegate void delSave(bsOrganize org);
        public event delSave eventSave;
        TreeView treev;//右键选择的项
        private bool IfFlash_ = false;

        public bool SetDelMenuDisp
        {
            set { 
                Delete.Visible = value;
                toolStripMenuItem1.Visible = value;
            }
        }

        public bool IfFlash
        {
            set { IfFlash_ = value; }
            get { return IfFlash_; }
        }
        //public DataGridView DgvTT { get { return this.dgvTT; } }

        //private Point Position = new Point(0, 0);
        private List<bsOrganize> _Ts;
        private List<自由分区> _Ts1;
        //private List<用地范围> _Ts2;
        private TreeNode currentSelectNode;

        private string NewName = "请修改";

        public tvOrgUcDelete()
        {
            InitializeComponent();
        }
        public TreeView tvorg
        {
            get { return this.tv; }

        }
        private void tv_DragEnter(object sender, DragEventArgs e)
        {
            //设置拖放类别(复制，移动等)
            e.Effect = DragDropEffects.Copy;
        }

        private void tv_ItemDrag(object sender, ItemDragEventArgs e)
        {
            try
            {
                TreeNode tn = (TreeNode)e.Item;
                //if (CanDragTreeNode(tn))
                {
                    //启动拖放操作，设置拖放类型为Copy
                    tv.DoDragDrop(e.Item, DragDropEffects.Copy);
                }
            }
            catch (Exception ex)
            {
                   log.Error("item drag:" + ex.Message);
            }
        }
        private void tv_DragDrop(object sender, DragEventArgs e)
        {

        }
        private bool CanDragTreeNode(TreeNode tn)
        {
            bool ret = false;

            try
            {
                if (tn != null && tn.Tag != null && tn.Tag is bsOrganize)
                {
                    ret = true;
                }
            }
            catch (Exception ex)
            {
                 log.Error("CanDragTreeNodeg:" + ex.Message);
            }

            return ret;
        }

        public void RefreshTree(List<bsOrganize> Ts)
        {
            _Ts = Ts;

            if (_Ts.Count != 0)
            {
                tv.Nodes.Clear();
               // AddRootTreeViewNodes();
            }
            // AddRootTreeViewNodes();
            tv.ExpandAll();

        }
        //public void RefreshTree(List<用地范围> Ts)
        //{
        //    _Ts2 = Ts;

        //    if (_Ts2.Count != 0)
        //    {
        //        tv.Nodes.Clear();
        //        AddRootTreeViewNodes_1();
        //    }
        //    // AddRootTreeViewNodes();
        //    tv.ExpandAll();

        //}
        public void RefreshTree(List<自由分区> Ts)
        {
            if (Ts == null)
                return;
            _Ts1 = Ts;

            if (_Ts1.Count != 0)
            {
                tv.Nodes.Clear();
                
                AddRootTreeViewNodes_();
            }
            // AddRootTreeViewNodes();
            tv.ExpandAll();
        }
        //public void RefreshTree()
        //{
        //    this.tv_AfterCheck(null,this);
        //}
        //public void AddRootTreeViewNodes()
        //{
        //    foreach (Organize t in _Ts)
        //    {
        //        if ((t != null) && (t.Pid == 0 || t.Pid == null))
        //        {
        //            TreeNode newNode = new TreeNode(t.Name);
        //            newNode.Name = t.Name;
        //            newNode.Tag = t;

        //            tv.Nodes.Add(newNode);


        //            AddChildTreeViewNodes(newNode);
        //        }

        //    }
        //}
        public void AddRootTreeViewNodes_()
        {
            foreach (自由分区 t in _Ts1)
            {
                if ((t != null))
                {
                    TreeNode newNode = new TreeNode(t.createName);
                    newNode.Name = t.createName;
                    newNode.Tag = t;

                    tv.Nodes.Add(newNode);


                }

            }
        }
        public void AddRootTreeViewNodes_1()
        {
            TreeNode newNode = new TreeNode("企业列表");
            newNode.Name = "企业列表";
            newNode.Tag = null;
            tv.Nodes.Add(newNode);

        //    AddChildTreeViewNodes_(newNode);


        }
        //private void AddChildTreeViewNodes_(TreeNode parentTreeViewNode)
        //{
        //    foreach (用地范围 t in _Ts2)
        //    {
        //        if ((t != null))
        //        {
        //            TreeNode newNode = new TreeNode(t.DWMC);
        //            newNode.Name = t.DWMC;
        //            newNode.Tag = t;
        //            parentTreeViewNode.Nodes.Add(newNode);
        //            // AddChildTreeViewNodes_(newNode);

        //        }

        //    }
        //}
        private void AddChildTreeViewNodes(TreeNode parentTreeViewNode)
        {

            foreach (bsOrganize t in _Ts)
            {

                if (t.PId == ((bsOrganize)(parentTreeViewNode.Tag)).bsO_Id)
                {
                    TreeNode newNode = new TreeNode(t.Name);
                    newNode.Name = t.Name;
                    newNode.Tag = t;

                    parentTreeViewNode.Nodes.Add(newNode);
                    AddChildTreeViewNodes(newNode);
                }
            }
        }
        private void tv_AfterCheck(object sender, TreeViewEventArgs e)
        {
            TreeNode tn = e.Node;
            foreach (TreeNode tnch in tn.Nodes)
            {
                tnch.Checked = tn.Checked;
            }
            this.currentSelectNode = e.Node;

            this.AfterSelect(sender, e);
        }

        private void tv_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //e.Node.Checked = true;
            this.currentSelectNode = e.Node;

            //this.AfterSelect(sender, e);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            pMapControl = GlobalVariables.axMapControl;
            
            自由分区 org = currentSelectNode.Tag as 自由分区;
            if (org.OBJECTID == 0 && org.createName != NewName)
                return;

            if (currentSelectNode.Tag != null)
            {
                this.eventDel(org);
            }

            pMapControl.Refresh();
            
        }

        //private void toolStripMenuItem2_Click(object sender, EventArgs e)
        //{
        //    //from data
        //    自由分区 org = currentSelectNode.Tag as 自由分区;


        //    if (currentSelectNode.Tag != null)
        //    {
        //        this.eventDel(currentSelectNode.Tag as Organize);
        //    }


        //}
        public void RemoveCurrentNode()
        {
            currentSelectNode.Remove();
        }




        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            foreach (TreeNode tn in tv.Nodes)
            {
                SaveTree(tn);
            }

        }

        private void SaveTree(TreeNode ptn)
        {
            if (ptn.Checked && ptn.Tag != null)
            {
                bsOrganize org = (ptn.Tag as bsOrganize);
                if (ptn.Text != org.Name)
                {
                    org.Name = ptn.Text;
                }
                this.eventSave(org);
            }

            foreach (TreeNode tn in ptn.Nodes)
            {
                if (tn.Checked && tn.Tag != null)
                {
                    bsOrganize org = (tn.Tag as bsOrganize);
                    if (tn.Text != org.Name)
                    {
                        org.Name = tn.Text;
                    }
                    this.eventSave(org);
                }

                SaveTree(tn);

            }
        }

        private void tv_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            bsOrganize org = e.Node.Tag as bsOrganize;
            if (org.PId == null && org.Name != NewName)
                e.CancelEdit = true;
        }

        private void tv_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (tv.Nodes[0] == e.Node) return;
            if (IfFlash_)
            {
                pMapControl = GlobalVariables.axMapControl;
                string Name = string.Empty;
                IGeometry pGeo = null;
                try
                {

                    Name = tv.Nodes[0].Nodes[e.Node.Index].Name;

                }
                catch
                {

                }
                if (Name != null)
                {
                    pGeo = getFeatureByName(Name);

                }
                else
                {
                    return;
                }
                if (pGeo != null)
                {
                    pMapControl.FlashShape(pGeo);
                }
                //IFeatureIdentifyObj identifyObjDefault = layerResult.IdentifiedFeatureObjList[featureIndex];
                //pFeatureIdentifyObj = pIDArray.get_Element(i) as pFeatureIdentifyObj;
                //pIdentifyObj = pFeatureIdentifyObj as IIdentifyObj;
                //pIdentifyObj.Flash(pMap.ActiveView.ScreenDisplay);

            }

        }
        private IGeometry getFeatureByName(string Name)
        {
            IGeometry pGeo = null;
            IFeatureLayer pFeatureLayer = null;
            IFeatureClass pFeatureClass = null;
            IFeature pFeature = null;

            for (int i = 0; i < pMapControl.LayerCount; i++)
            {

                if (pMapControl.get_Layer(i).Name == GlobalVariables.LayerName2FullName ["镇界"])
                {
                    pFeatureLayer = (IFeatureLayer)pMapControl.get_Layer(i);
                    break;
                }
                //if (pMapControl.get_Layer(i).Name == "arcgis.DBO.用地范围")
                //{
                //    pFeatureLayer = (IFeatureLayer)pMapControl.get_Layer(i);
                //    break;
                //}

            }
            if (pFeatureLayer != null)
            {
                pFeatureClass = pFeatureLayer.FeatureClass;
                int debug = pFeatureClass.FeatureCount(null);
                for (int i = 0; i < pFeatureClass.FeatureCount(null); i++)
                {


                    IFeatureCursor pFeatureCursor = pFeatureClass.Search(null, false);
                    pFeature = pFeatureCursor.NextFeature();
                    while (pFeature != null)
                    {
                        if (pFeature.get_Value(2).ToString().Contains(Name))
                        {
                            pGeo = pFeature.Shape;
                            return pGeo;
                        }
                        else
                        {
                            pFeature = pFeatureCursor.NextFeature();
                        }

                    }

                }
            }
            else
            {
                return null;
            }

            return pGeo;
        }

        private void tv_MouseUp(object sender, MouseEventArgs e)
        {

            treev = sender as TreeView;
           // System.Drawing.Point point = treev.PointToClient(e.Location);
            TreeViewHitTestInfo info = treev.HitTest(e.X, e.Y);
            TreeNode node = info.Node;//获得 右键点击的节点




            if (node != null && MouseButtons.Right == e.Button)
            {
                treev.SelectedNode = node;//关键的一句话，右键点击菜单的时候，会选中右键点击的项
               
            } 
        }
    }
}
