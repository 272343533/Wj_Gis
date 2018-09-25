using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using System.Dynamic;
using System.Text;
using log4net;

using TDObject.BLL;
using ESRI.ArcGIS.Geodatabase;
using TDObject.MapControl;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using QyTech.Json;
using System.Threading;

using SunMvcExpress.Dao;
using TDObject.UI;
using ESRI.ArcGIS.SystemUI;
using TDObject.DrawLayer;
using ESRI.ArcGIS.Controls;
using QyTech.Core.BLL;
using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.GISClient;

using QyTech.ArcGis;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Xml.Linq;
using System.Runtime.Remoting.Messaging;

using System.Net;
using WTGeoWeb.BLL;
using TDObject.IdentifyTool;
using System.Data.Objects.DataClasses;


using ESRI.ArcGIS.Output;

using System.Drawing.Printing;

using QyTech.SkinForm;
using QyTech.SkinForm.Controls;
using ESRI.ArcGIS.DataSourcesFile;
using QyTech.Auth.Dao;


[assembly: log4net.Config.XmlConfigurator(ConfigFile = "log4net.config", Watch = true)]
namespace TDObject
{


    public sealed partial class MainForm : Form
    {

        log4net.ILog log = log4net.LogManager.GetLogger("MainForm");
        public static bsUser LoginUser = null;
        public static string LoginUserRights = "";
        public static bool LoadFinished = false;

        public static int m_LoginStatus = 1;//1:登录界面 2：登录成功 3：登录取消
        public static IWorkspace Workspace;
        public static TabControl _TabControl;
        private int OverlyLayerFlag = 1;

        private string localmapName = Application.StartupPath + @"\" + "WjMapLocal.mxd";
        private static string localMdbName = Application.StartupPath + @"\WjMapLocal.mdb";
        private static string localMdbName_csgh = Application.StartupPath + @"\WjMapLocal_Csgh.mdb";
        private static string localMdbName_fwjz = Application.StartupPath + @"\WjMapLocal_Fwjz.mdb";
        private static string localMdbName_wt = Application.StartupPath + @"\Wt0170825.mdb";

        arcGisMap gismap = new arcGisMap();



        List<Dictionary<string, List<string>>> OverLayStyles;//样式1,2,3,4


        ClassCotrolLayerShow cls = new ClassCotrolLayerShow();

        private int loadType = 5;

        public static string QyTechAuth_URI = "http://122.114.190.250:8080/wjkfq_gis/";
        public static string App_URI = "http://122.114.190.250:8080/wjkfq_gis/";

        TDObject.BLL.UIBLL.bllTypeFilter blluifilter; //= new TDObject.BLL.UIBLL.bllTypeFilter();


        frmLtdInfoPop newpop;

        /// <summary>
        /// 进度条
        /// </summary>
        private frmProgress loadingProgress = null;
        private delegate bool IncreaseHandle(int nValue);
        private IncreaseHandle myIncrease = null;
        private static object stepForProbar = 2;

        /// <summary>
        /// 统计规则
        /// </summary>
        Dictionary<string, List<LayTotalConf>> layconf = new Dictionary<string, List<LayTotalConf>>();




        private List<vwLtdJcSj> _ltdobjs;

        private List<vwLtdJcSj> _ltdobjs1;


        public static EntityManager EM = new EntityManager(new SunMvcExpress.Dao.wj_GisDbEntities());
        public static EntityManager QyTech_EM = new EntityManager(new QyTech.Auth.Dao.QyTech_AuthEntities());
        private static string strSqlConn = "server =122.114.190.250,2433; uid = sa; pwd = Qy_ltd414; database = wj_GisDb";
        public static System.Data.SqlClient.SqlConnection sqlConn = new System.Data.SqlClient.SqlConnection(strSqlConn);
        public static System.Data.SqlClient.SqlConnection sqlConn_Base = new System.Data.SqlClient.SqlConnection(strSqlConn.Replace("wj_GisDb", "QyTech_Auth"));


        FlashObjectsClass flashObjects = new FlashObjectsClass();

        private int SelectDgv = 11;


        public static List<XElement> pFeatureLayerlist = new List<XElement>();
        public delegate void AddHandler();


        public static bool LayerToFileStatus = false;

        public static string LtdNameQuery;



        Dictionary<string, ILayer> LoadedLayers = new Dictionary<string, ILayer>();//所有层枚举对象
        List<IFeature> FindGeos = new List<IFeature>();//查找到的要素
        List<IGeometry> Geos = new List<IGeometry>();//找到返回要素的集合几何对象

        IEnvelope newdisp = (IEnvelope)new Envelope();//查找到的要素的矩形范围



        private int GetOverlyLayers()
        {
            int OverlyLayerFlag = 1; //1: 土地现状、2：土地规划、4：城市规划、8：批次 采用位处理
            //if (rbDjTD.Checked)
            //    OverlyLayerFlag += 2;
            //if (rbDjCS.Checked)
            //    OverlyLayerFlag += 4;
            //if (rbDjPc.Checked)
            //    OverlyLayerFlag +=8;

            return OverlyLayerFlag;

        }


        public MainForm()
        {

            InitializeComponent();
            Init();
            Control.CheckForIllegalCrossThreadCalls = false;

        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Init()
        {
            try
            {
                //程序许可
                IAoInitialize m_AoInitialize = new AoInitializeClass();
                esriLicenseStatus pLicesestatus = (esriLicenseStatus)m_AoInitialize.IsProductCodeAvailable(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
                if (pLicesestatus == esriLicenseStatus.esriLicenseAvailable)
                {
                    if (pLicesestatus != esriLicenseStatus.esriLicenseCheckedOut)
                    {
                        pLicesestatus = (esriLicenseStatus)m_AoInitialize.Initialize(esriLicenseProductCode.esriLicenseProductCodeAdvanced);
                    }
                    else
                    {
                        System.Windows.Forms.MessageBox.Show("程序初始化失败");
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("没有程序运行许可");
                }

                GlobalVariables.axMapControl = this.axMapControl1;
                GlobalVariables.axMapControlEagle = this.axMapControl2;
                //this.axTOCControl1.Refresh();



                //设置可选图层事件
                GlobalVariables.Select.Changed += new GlobalVariables.Select.ChangedEventHandler(SelectControl.SetSelectableLayer);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }



        public IAGSServerObjectName GetMapServer(string pHostOrUrl, string pServiceName, bool pIsLAN)
        {

            //设置连接属性
            IPropertySet pPropertySet = new PropertySetClass();

            if (pIsLAN)
                pPropertySet.SetProperty("machine", pHostOrUrl);//machine可以是机器名或者IP，连接方式为LAN。
            else
                pPropertySet.SetProperty("url", pHostOrUrl);//如果url连接的需要设置用户名和密码，那么要设置用户名和密码属性。

            //如果使用url连接，那么一定要在浏览器可以访问才行。


            //打开连接

            IAGSServerConnectionFactory pFactory = new AGSServerConnectionFactory();

            IAGSServerConnection pConnection = pFactory.Open(pPropertySet, 0);

            //Get the image server.
            IAGSEnumServerObjectName pServerObjectNames = pConnection.ServerObjectNames;
            pServerObjectNames.Reset();
            IAGSServerObjectName ServerObjectName = pServerObjectNames.Next();
            while (ServerObjectName != null)
            {
                if ((ServerObjectName.Name.ToLower() == pServiceName.ToLower()) &&
                    (ServerObjectName.Type == "MapServer"))
                {

                    break;
                }
                ServerObjectName = pServerObjectNames.Next();
            }

            //返回对象
            return ServerObjectName;

        }
        private void LoadMap(int loadtype)
        {
            try
            {
                List<string> layers = new List<string>();

                layers.Clear();
                layers.Add("红牌警告点位置");
                layers.Add("黄牌警告点位置");
                layers.Add("企业照片点位置");
                layers.Add("安全检查点位置");
                LoadLocalMap(localMdbName_fwjz, layers);


                layers.Clear();
                layers.Add("行政区");
                layers.Add("管理区");
                //layers.Add("房屋建筑");
                layers.Add("企业范围");

                layers.Add("道路"); layers.Add("道路注记");
                layers.Add("河流"); layers.Add("河流注记");

                LoadLocalMap(localMdbName, layers);

                layers.Clear();
                layers.Add("城市规划"); layers.Add("城市规划注记注记2");
                LoadLocalMap(localMdbName_csgh, layers);

                layers.Clear();
                layers.Add("房屋建筑");
                LoadLocalMap(localMdbName_fwjz, layers);


                GlobalVariables.addLayer = true;

                for (int i = 0; i < axMapControl1.LayerCount; i++)
                {
                    LoadedLayers.Add(axMapControl1.get_Layer(i).Name, axMapControl1.get_Layer(i));
                }
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }

        private void LoadLocalMap(string dbname, List<string> layers)
        {
            try
            {

                IWorkspaceFactory pFactory = new AccessWorkspaceFactoryClass();
                //IWorkspace pWorkspace = pFactory.OpenFromFile(Application.StartupPath + @"\WtLocal.mdb", 0);
                IWorkspace pWorkspace = pFactory.OpenFromFile(dbname, 0);
                IFeatureWorkspace pFeatWorkspace = pWorkspace as IFeatureWorkspace;

                foreach (string layername in layers)
                {
                    try
                    {
                        IFeatureClass m_FeatureClass = pFeatWorkspace.OpenFeatureClass(layername);

                        //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
                        IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                        m_FeatureLayer.FeatureClass = m_FeatureClass;
                        m_FeatureLayer.Name = m_FeatureClass.AliasName;
                        m_FeatureLayer.Selectable = false;

                        GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口

                        GlobalVariables.SymbolLayer(m_FeatureLayer);
                    }
                    catch (Exception ex)
                    {
                        log.Error("LoadMap_loadtype is 5_" + layername + ex.Message + ex.StackTrace);
                    }
                }


                //try
                //{
                //    IMapServerRESTLayer pRestLayer = new MapServerRESTLayerClass();
                //    pRestLayer.Connect("http://122.114.190.250:6080/arcgis/rest/services/WTMap/WtPublish1/MapServer");
                //    this.axMapControl1.AddLayer(pRestLayer as ILayer);
                //    //return;

                //    //IAGSServerObjectName pServerObjectName = GetMapServer("http://122.114.190.250:6080/arcgis/rest/services", "WTMap/WtPublish1", false);
                //    //IName pName = (IName)pServerObjectName;
                //    //IAGSServerObject pServerObject = (IAGSServerObject)pName.Open();
                //    //IMapServer pMapServer = (IMapServer)pServerObject;
                //    //ESRI.ArcGIS.Carto.IMapServerLayer pMapServerLayer = new ESRI.ArcGIS.Carto.MapServerLayerClass();
                //    //pMapServerLayer.ServerConnect(pServerObjectName, pMapServer.DefaultMapName);
                //    //axMapControl1.AddLayer(pMapServerLayer as ILayer);
                //    GlobalVariables.addLayer = true;
                //}
                //catch (Exception ex)
                //{
                //    MessageBox.Show(ex.Message);
                //}
                //return;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show("LoadMap_l：" + ex.Message);
            }
        }

        private void RefreshMapWithRegion(string XZCDM, string XZZDM)
        {
            try
            {
                cls.ControlLayerShow(GlobalVariables.axMapControl, XZCDM, XZZDM);
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void LayerCallBack(IAsyncResult arResult)
        {
            try
            {
                Thread.Sleep(5000);
                delegateLoadLayerWithSP handler = (delegateLoadLayerWithSP)((AsyncResult)arResult).AsyncDelegate;

                List<XElement> result = (List<XElement>)handler.EndInvoke(arResult);//当是true时，就将结果返回显示

                //myList.OnItemAddEventHandler += new AddHandler(Addlayer);

                //myList.Add(result);
                pFeatureLayerlist.AddRange(result);
                if (pFeatureLayerlist.Count > 10)
                    LayerToFileStatus = true;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }

        }
        //对错误进行处理
        void Window_Error(object sender, HtmlElementErrorEventArgs e)
        {
            // 自己的处理代码             
            e.Handled = true;
        }

        public SortedList<string, bool> dicLayerDisp = new SortedList<string, bool>();

        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                this.WindowState = FormWindowState.Minimized;

                this.dgvCSGH.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvFW.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvQycc.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvQyxx.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvT2_11.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvT2_12.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvT2_21.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                this.dgvT2_31.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;

                _TabControl = this.tabControl1;

                SetBottomViewDisp(false);
                SetProperViewDisp(false);
                //this.skinEngine1.SkinFile = Application.StartupPath + @"\MP10.ssk";
                //webBrowser1.DocumentCompleted += new WebBrowserDocumentCompletedEventHandler(web_DocumentCompleted);
                List<bsArcLayer> layers = MainForm.EM.GetListNoPaging<bsArcLayer>("IsValid=1", "DislNo");
                foreach (bsArcLayer l in layers)
                {
                    GlobalVariables.dbLayers.Add(l.Name, l);
                }



                //dicLayerDisp.Add("红牌警告点位置", false);
                //dicLayerDisp.Add("黄牌警告点位置", false);
                //dicLayerDisp.Add("企业照片点位置", false);
                //dicLayerDisp.Add("安全检查点位置", false);

                arcGisMap gismap = new arcGisMap();
                log.Info("0:");

                Thread thrlogin = new Thread(new ThreadStart(LoginValid));
                thrlogin.Start();


                log.Info("100:");

                LayControl layc = new LayControl();
                // this.layconf = layc.GetLayerTotalConf();


                LoadMap(loadType);
                LoadFinished = true; //用于登录界面的loading

                while (m_LoginStatus == 1)
                {
                    Thread.Sleep(1000);
                }


                //确定各图层位置
                ChangeLayerPos("企业照片点位置,红牌警告点位置,黄牌警告点位置,安全检查点位置,行政区,管理区,房屋建筑,企业范围,城市规划注记注记2,城市规划,道路注记,河流注记,道路,河流");//D_Spatial.SDE.
                                                                                                                   //确定可见性
                LayerControl.SetVisibleLayer(GlobalVariables.axMapControl, "", "管理区,行政区,房屋建筑,企业范围,道路,河流,道路注记,河流注记");

                if (m_LoginStatus == 2)
                {
                    this.ShowInTaskbar = true;

                    ////////string url = MainForm.App_URI + "lyRemoteServ/GetAllOrgData?userid=" + MainForm.LoginUser.bsU_Id;
                    ////////string ret = AsyncHttp.CommFun.GetRemoteJson(url);
                    ////////List<bsOrganize> org = JsonHelper.DeserializeJsonToList<bsOrganize>(ret);
                    //tvOrgUc1.RefreshTree(org);

                    this.Text += " (" + LoginUser.UserName + "，您好:)";

                    // cls.ControlZYFQShow(GlobalVariables.axMapControl, "");


                    //RefreshMapDisplay();//刷新地图和鹰眼图

                    RefreshRights();
                    //RefreshRightsMap();
                }

                RefreshEagleView();

                this.dgvT2_11.AutoGenerateColumns = false;
                this.dgvT2_12.AutoGenerateColumns = false;
                this.dgvT2_21.AutoGenerateColumns = false;
                this.dgvT2_31.AutoGenerateColumns = false;

                dataGridViewTextBoxColumn18.Visible = true;
                dataGridViewTextBoxColumn19.Visible = true;


                treeView1.Nodes[0].Checked = true;
                foreach (TreeNode tn in treeView1.Nodes[0].Nodes)
                {
                    tn.Checked = true;
                    foreach (TreeNode tn1 in tn.Nodes)
                    {
                        tn1.Checked = true;
                    }
                }
                treeView1.Nodes[0].ExpandAll();
                treeView2.Nodes[0].ExpandAll();

                AddFXFBXSMenuItem();


                //this.axTOCControl1.SetBuddyControl(GlobalVariables.axMapControl);

            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                // MessageBox.Show(ex.Message);
            }
        }

        private void AddFXFBXSMenuItem()
        {
            blluifilter = new TDObject.BLL.UIBLL.bllTypeFilter(this.axMapControl1);

            foreach (string key in blluifilter.menus.Keys)
            {
                ToolStripMenuItem tsmi = new ToolStripMenuItem(key);
                string[] items = blluifilter.menus[key].compitems.Split(new char[] { ',' });
                foreach (string item in items)
                {
                    if (item != "全部")
                    {
                        ToolStripMenuItem subtsmi = new ToolStripMenuItem(item);
                        subtsmi.Tag = blluifilter.menus[key];
                        subtsmi.Click += new System.EventHandler(FilterHighLightDisplay);
                        subtsmi.MouseDown += new MouseEventHandler(FilterHighLightUnDisplay);
                        tsmi.DropDownItems.Add(subtsmi);
                    }
                }
                //string[] substrs = blluifilter.menus[key].Split(new char[] { ',' });
                //foreach (string substrs1 in substrs)
                //{
                //    string[] subs= substrs1.Split(new char[] { '|' });
                //    ToolStripMenuItem subtsmi = new ToolStripMenuItem(subs[0]);
                //    subtsmi.Tag = key;
                //    subtsmi.Click += new System.EventHandler(FilterHighLightDisplay);
                //    tsmi.DropDownItems.Add(subtsmi);
                //}
                分项分布显示ToolStripMenuItem.DropDownItems.Add(tsmi);
            }
        }

        private void FilterHighLightUnDisplay(object sender, MouseEventArgs e)
        {
            flashObjects.ClearDisplay();
        }
        private void FilterHighLightDisplay(object sender, EventArgs e)
        {
            try
            {
                //axMapControl1.Refresh();//.PartialRefresh(esriViewDrawPhase.esriViewForeground, null, null);
                //flashObjects.ClearDisplay();

                //subtsmi.Tag = blluifilter.menus[key];
                ToolStripMenuItem tsmi = sender as ToolStripMenuItem;
                string clicktext = tsmi.Text;
                bsDynCondition dc = tsmi.Tag as bsDynCondition;
                //int index = 1;
                //string value = "";

                //blluifilter.GetIndexAndCondtinoValue(ptext, clicktext, out index, out value);
                //blluifilter.RefreshData(index, value);

                string cond = TDObject.DAOBLL.RoleRelBll.Get企业范围WhereCondition(dc, tsmi.Text);

                //blluifilter.RefreshData(cond);
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");

                List<企业范围> objs = MainForm.EM.GetListNoPaging<企业范围>(cond, "");
                string dkbhs = "";

                foreach (企业范围 obj in objs)
                {
                    if (obj.DKBH != null && obj.DKBH != "")
                    {
                        dkbhs += "," + obj.DKBH;
                    }
                }
                IEnvelope newdisp = (IEnvelope)new Envelope();//用于定位
                List<IGeometry> Geos = new List<IGeometry>();
                List<IFeature> FindGeos = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbhs.Substring(1), ",", ref newdisp, ref Geos);


                if (Geos.Count > 0)
                {
                    Console.WriteLine(Geos.Count.ToString());
                    if (this.flashObjects == null)
                        this.flashObjects = new FlashObjectsClass();
                    flashObjects.MapControl = axMapControl1.Object as IMapControl2;
                    flashObjects.Init();

                    if (Geos.Count > 0)
                    {
                        foreach (IGeometry geo in Geos)
                            flashObjects.AddGeometry(geo);
                    }

                    flashObjects.FlashObjects(0);
                }
                //LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        //private void RefreshMapDisplay()
        //{
        //    try
        //    {
        //        IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
        //        IActiveView pAv = pGra as IActiveView;

        //        // 刷新鹰眼
        //        pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
        //        GlobalVariables.axMapControl.Extent = GlobalVariables.axMapControl.FullExtent;
        //        GlobalVariables.axMapControlEagle.Extent = GlobalVariables.axMapControl.FullExtent;
        //        //this.axTOCControl1.Refresh();
        //        this.axMapControl2.Refresh();
        //        GlobalVariables.axMapControlEagle.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //}

        //private void RefreshRightsMap(string layname="")
        //{
        //    return;
        //    try
        //    {
        //        //权限地图的刷新
        //        ILayer pLayer = axMapControl1.get_Layer(1);
        //        IFeatureLayerDefinition pFlDefinition;

        //        Dictionary<string, string> LayerForOrgField = new Dictionary<string, string>();

        //        LayerForOrgField.Add("村界", "行政村代码");
        //        LayerForOrgField.Add("道路线", "所属村代码");
        //        LayerForOrgField.Add("道路中线", "所属村代码");

        //        LayerForOrgField.Add("土地现状数据", "所属行政村代码");
        //        LayerForOrgField.Add("工业管理区", "所属行政村代码");
        //        LayerForOrgField.Add("历年批次", "所属行政村代码");
        //        LayerForOrgField.Add("房屋", "所属行政村代码");
        //        LayerForOrgField.Add("城市规划", "所属行政村代码");

        //        LayerForOrgField.Add("供地", "所属行政村代码");
        //        LayerForOrgField.Add("国有权属", "所属行政村代码");
        //        LayerForOrgField.Add("可建设区", "所属行政村代码");
        //        LayerForOrgField.Add("企业范围", "所属行政村代码");
        //        LayerForOrgField.Add("土地利用现状", "所属行政村代码");


        //        if (LoginUser.bsO_RightsCode != "全部村镇")
        //        {
        //            if (layname == "")
        //            {
        //                foreach (string layername in LayerForOrgField.Keys)
        //                {
        //                    pLayer = LayerControl.getGeoLayer(this.axMapControl1, layername);
        //                    if (pLayer != null)
        //                    {
        //                        pFlDefinition = pLayer as IFeatureLayerDefinition;
        //                        string filter = "'" + LoginUser.bsO_RightsCode.Replace(",", "','") + "'";
        //                        pFlDefinition.DefinitionExpression = LayerForOrgField[layername] + " in (" + filter + ")";
        //                    }
        //                }
        //                ILayer layobj = LayerControl.getGeoLayer(this.axMapControl1, "镇界");
        //                if (layobj != null)
        //                {
        //                    layobj.Visible = false;
        //                }
        //            }
        //            else
        //            {
        //                foreach (string layername in LayerForOrgField.Keys)
        //                {
        //                    if (layername != layname)
        //                        continue;

        //                    pLayer = LayerControl.getGeoLayer(this.axMapControl1, layername);
        //                    pLayer = axMapControl1.get_Layer(10);
        //                    pFlDefinition = pLayer as IFeatureLayerDefinition;
        //                    string filter = "'" + LoginUser.bsO_RightsCode.Replace(",", "','") + "'";
        //                    pFlDefinition.DefinitionExpression = LayerForOrgField[layername] + " in (" + filter + ")";
        //                }

        //                ILayer layobj = LayerControl.getGeoLayer(this.axMapControl1, "镇界");
        //                if (layobj != null)
        //                {
        //                    layobj.Visible = false;
        //                }

        //            }
        //        }



        //        GlobalVariables.axMapControl.Refresh();
        //    }
        //    catch (Exception ex)
        //    {
        //        log.Error(ex.Message);
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="laynameswithcomma">图层名顺序从上到下</param>
        private void ChangeLayerPos(string laynameswithcomma)
        {
            int position = 0;
            string[] layenames = laynameswithcomma.Split(new char[] { ',', ' ', '.', ';' });

            Dictionary<string, int> name2pos = new Dictionary<string, int>();
            foreach (string layname in layenames)
            {
                name2pos.Add(layname, position++);
            }
            LayerControl.ChangePos(GlobalVariables.axMapControl, name2pos);
        }


        private void LoginValid()
        {
            if (LoginUser == null)
            {
                frmLogin frmlogin = new frmLogin();
                frmlogin.ShowDialog();
            }
        }


        /// <summary>
        /// 地图加载方法--待修改
        /// </summary>
        private void RemoteSdeMap_Load()
        {
            log.Info("500:");

            if (!GlobalVariables.addLayer)
            {
                Conection c = new Conection();
                string SqlCon = string.Empty;
                try
                {
                    SqlCon = c.GetConnectionString("sdeServer");
                }
                catch
                {
                    MessageBox.Show("请检查sde连接字符串设置!");
                }
                if (SqlCon == string.Empty) return;
                string[] strs = SqlCon.Split(new char[] { '=', ';' });
                //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.土地现状数据", "sde.城市规划", "sde.土地规划", "sde.历年批次", "sde.工业管理区", "sde.行政区", "sde.自由分区" }, "");

                log.Info("600:");
                //开始连接sde数据库
                Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
                if (Workspace == null)
                    return;
                log.Info("700:");
                //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
                GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区", "sde.城市规划", "sde.土地规划", "sde.历年批次" }, "");

            }
        }

        private void Map_RemoteLoadLayer(string LayName, string datasetName)
        {
            log.Info("500:");

            if (!GlobalVariables.addLayer)
            {
                Conection c = new Conection();
                string SqlCon = string.Empty;
                try
                {
                    SqlCon = c.GetConnectionString("sdeServer");
                }
                catch
                {
                    MessageBox.Show("请检查sde连接字符串设置!");
                }
                if (SqlCon == string.Empty) return;
                string[] strs = SqlCon.Split(new char[] { '=', ';' });
                //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.土地现状数据", "sde.城市规划", "sde.土地规划", "sde.历年批次", "sde.工业管理区", "sde.行政区", "sde.自由分区" }, "");

                log.Info("600:");
                //开始连接sde数据库
                Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
                if (Workspace == null)
                    return;
                //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
                MapLoad.addOneLayerToAxMapControl(datasetName, LayName);
            }
        }




        private void axMapControl1_OnExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnExtentUpdatedEvent e)
        {
            try
            {
                #region 刷新鹰眼
                //创建鹰眼中线框
                IEnvelope pEnv = (IEnvelope)e.newEnvelope;
                IRectangleElement pRectangleEle = new RectangleElementClass();
                IElement pEle = pRectangleEle as IElement;
                pEle.Geometry = pEnv;

                //设置线框的边线对象，包括颜色和线宽
                IRgbColor pColor = new RgbColorClass();
                pColor.Red = 255;
                pColor.Green = 0;
                pColor.Blue = 0;
                pColor.Transparency = 255;
                // 产生一个线符号对象 
                ILineSymbol pOutline = new SimpleLineSymbolClass();
                pOutline.Width = 2;
                pOutline.Color = pColor;

                // 设置颜色属性 
                pColor.Red = 255;
                pColor.Green = 0;
                pColor.Blue = 0;
                pColor.Transparency = 0;

                // 设置线框填充符号的属性 
                ISimpleFillSymbol pFillSymbol = new SimpleFillSymbolClass();
                pFillSymbol.Color = pColor;
                pFillSymbol.Outline = pOutline;
                // ISimpleFillSymbol
                pFillSymbol.Style = esriSimpleFillStyle.esriSFSNull;
                IFillShapeElement pFillShapeEle = pEle as IFillShapeElement;
                pFillShapeEle.Symbol = pFillSymbol;

                // 得到鹰眼视图中的图形元素容器
                IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
                IActiveView pAv = pGra as IActiveView;
                // 在绘制前，清除 axMapControl2 中的任何图形元素 
                pGra.DeleteAllElements();
                // 鹰眼视图中添加线框
                pGra.AddElement((IElement)pFillShapeEle, 0);
                // 刷新鹰眼
                pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);

                #endregion


                #region 更新注记
                //  axMapControl2.Extent = axMapControl2.FullExtent;、
                if (GlobalVariables.addLayer)
                {
                    try
                    {
                        for (int i = 0; i < GlobalVariables.axMapControl.LayerCount; i++)
                        {
                            ILayer player = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i);
                            IFeatureLayer pflayer = player as IFeatureLayer;
                            GlobalVariables.UpdataLabel(GlobalVariables.axMapControl, pflayer);

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                #endregion

                #region 定位后的高亮显示

                #endregion

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void axMapControl1_OnFullExtentUpdated(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnFullExtentUpdatedEvent e)
        {
            try
            {
                RefreshEagleView();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void RefreshEagleView()
        {
            //获取鹰眼图层
            try
            {
                //if (this.axMapControl2.LayerCount > 1)
                //    this.axMapControl2.ClearLayers();
                if (axMapControl2.LayerCount == 0)
                {
                    string displayLayerName = GlobalVariables.LayerName2FullName["行政区"];
                    displayLayerName += "," + GlobalVariables.LayerName2FullName["管理区"];
                    //displayLayerName += "," + GlobalVariables.LayerName2FullName["企业范围"];
                    displayLayerName += "," + GlobalVariables.LayerName2FullName["道路"];
                    displayLayerName += "," + GlobalVariables.LayerName2FullName["河流"];


                    string[] layers = displayLayerName.Split(new char[] { ',' });


                    IWorkspaceFactory pFactory = new AccessWorkspaceFactoryClass();


                    //IWorkspace pWorkspace = pFactory.OpenFromFile(Application.StartupPath + @"\WtLocal.mdb", 0);
                    IWorkspace pWorkspace = pFactory.OpenFromFile(localMdbName, 0);

                    IFeatureWorkspace pFeatWorkspace = pWorkspace as IFeatureWorkspace;

                    foreach (string layername in layers)
                    {
                        try
                        {
                            IFeatureClass m_FeatureClass = pFeatWorkspace.OpenFeatureClass(layername);

                            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
                            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                            m_FeatureLayer.FeatureClass = m_FeatureClass;
                            m_FeatureLayer.Name = m_FeatureClass.AliasName;
                            m_FeatureLayer.Selectable = false;

                            this.axMapControl2.AddLayer(m_FeatureLayer, axMapControl2.LayerCount);   //加载到map窗口

                            GlobalVariables.SymbolLayer(axMapControl2, m_FeatureLayer);
                        }
                        catch (Exception ex)
                        {
                            log.Error("LoadMap_loadtype is 5_" + layername + ex.Message + ex.StackTrace);
                        }

                    }
                    LayerControl.SetVisibleLayer(this.axMapControl2, "", "管理区,行政区,道路,河流");

                    //if (this.axMapControl2.LayerCount == 0 && GlobalVariables.axMapControl.LayerCount==13)
                    //{
                    //    for (int i = GlobalVariables.axMapControl.LayerCount - 1; i > 0; i--)
                    //    {
                    //        if (displayLayerName.Contains(GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i).Name))

                    //            this.axMapControl2.AddLayer(GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i));
                    //    }
                    //}
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            // 设置 MapControl 显示范围至数据的全局范围
            this.axMapControl2.Extent = GlobalVariables.axMapControl.FullExtent;

            // 刷新鹰眼控件地图
            this.axMapControl2.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

        }

        private void axMapControl2_OnMouseDown(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseDownEvent e)
        {
            //属性查询
            try
            {
                this.axMapControl2.AutoMouseWheel = false;
                if (this.axMapControl2.Map.LayerCount != 0)
                {

                    // 按下鼠标左键移动矩形框 
                    if (e.button == 1)
                    {
                        IPoint pPoint = new PointClass();
                        pPoint.PutCoords(e.mapX, e.mapY);
                        IEnvelope pEnvelope = GlobalVariables.axMapControl.Extent;
                        pEnvelope.CenterAt(pPoint);
                        GlobalVariables.axMapControl.Extent = pEnvelope;
                        GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    }
                    // 按下鼠标右键绘制矩形框 
                    else if (e.button == 2)
                    {
                        IEnvelope pEnvelop = this.axMapControl2.TrackRectangle();
                        GlobalVariables.axMapControl.Extent = pEnvelop;
                        GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
                    }

                }
                //this.axMapControl2.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void axMapControl2_OnMouseMove(object sender, ESRI.ArcGIS.Controls.IMapControlEvents2_OnMouseMoveEvent e)
        {
            // 如果不是左键按下就直接返回 
            try
            {
                if (e.button != 1) return;
                IPoint pPoint = new PointClass();
                pPoint.PutCoords(e.mapX, e.mapY);
                GlobalVariables.axMapControl.CenterAt(pPoint);
                GlobalVariables.axMapControl.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void axMapControl1_OnMouseUp(object sender, IMapControlEvents2_OnMouseUpEvent e)
        {
            //判断是否在属性查询状态
            if (GlobalVariables.Select.SType != GlobalVariables.SelectType.enull && GlobalVariables.Select.SOperFun == GlobalVariables.SelectFunGroup.QueryLayerInfo)
            {

                identifyDialog.OnMouseUp(e.mapX, e.mapY);
            }
        }

        /// <summary>
        /// 获取点击处的点对象，设置了半径区间寻找
        /// </summary>
        /// <param name="pPoint"></param>
        /// <param name="pFeatureLayer"></param>
        /// <param name="pRadius"></param>
        /// <returns></returns>
        public List<IFeature> GetPointSelect(IPoint pPoint, IFeatureLayer pFeatureLayer, double pRadius)
        {

            List<IFeature> pSelelctFeatureList = new List<IFeature>();

            ISpatialFilter pSpatialFilter = new SpatialFilterClass();
            IFeatureCursor pFeatureCursor;
            if (pPoint != null && pFeatureLayer != null)
            {
                ITopologicalOperator pTopologicalOperator = pPoint as ITopologicalOperator;
                IGeometry pGeometry = pTopologicalOperator.Buffer(pRadius);//建立缓冲区

                pSpatialFilter.Geometry = pGeometry;
                pSpatialFilter.SpatialRel = esriSpatialRelEnum.esriSpatialRelEnvelopeIntersects;//求交
                pFeatureCursor = pFeatureLayer.FeatureClass.Search(pSpatialFilter, false);//空间查询
                IFeature pFeature = pFeatureCursor.NextFeature();
                while (pFeature != null)
                {
                    pSelelctFeatureList.Add(pFeature);
                    pFeature = pFeatureCursor.NextFeature();
                }
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pFeatureCursor);//释放缓存
                System.Runtime.InteropServices.Marshal.ReleaseComObject(pSpatialFilter);//释放缓存
            }
            return pSelelctFeatureList;
        }

        private void axMapControl1_OnMouseDown(object sender, IMapControlEvents2_OnMouseDownEvent e)
        {
            try
            {


                #region noted by zhwsun on 2018-08-27 不在使用查处，直接导入数据库，显示即可
                //if (GlobalVariables.Select.SType != GlobalVariables.SelectType.enull && GlobalVariables.Select.SOperFun == GlobalVariables.SelectFunGroup.QueryQyCc)
                //{
                //    if (GlobalVariables.Select.SType == GlobalVariables.SelectType.SingleSelect)
                //    {
                //        if (e.button == 2)
                //        {
                //            GlobalVariables.Select.Exit();
                //            return;
                //        }
                //        //单击选择
                //        //featureSelect方法
                //        featureSelect pfeaobj = new featureSelect();

                //        pfeaobj.featureSelects(e);

                //        string LayerName = string.Empty;
                //        string Fields = string.Empty;
                //        string Result = string.Empty;

                //         Fields = SelectControl.DealFeatureSelect();
                //        if (Fields.Length < 1)
                //        {
                //            MessageBox.Show("没有选中对象，要使图层可见并选中对象，请重新选择！");
                //            return;
                //        }
                //        if (Fields.Length > 0)
                //        {
                //            if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.QiYeFangWei)
                //            {
                //                frmAlarmQuery obj = new frmAlarmQuery(Convert.ToInt32(Fields.Substring(0, Fields.Length - 1)));
                //                QyTech.SkinForm.qyFormUtil.ShowForm(obj);
                //            }
                //        }
                //    }
                //}

                //else
                #endregion

                if (GlobalVariables.Select.SType != GlobalVariables.SelectType.enull && GlobalVariables.Select.SOperFun == GlobalVariables.SelectFunGroup.QueryMarkerInfo)
                {

                    IPoint point = new PointClass();
                    point.PutCoords(e.mapX, e.mapY);
                    IFeatureLayer fealayer;
                    List<IFeature> feas;
                    //fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围") as IFeatureLayer;
                    //照片信息
                    if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.QiYeZhaoPianXinxi)
                    {
                        fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业照片点位置") as IFeatureLayer;
                    }
                    else if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.AnQuanJianCha)
                    {
                        fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "安全检查点位置") as IFeatureLayer;
                    }
                    else if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.HuangPai)
                    {
                        fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "黄牌警告点位置") as IFeatureLayer;
                    }
                    else //if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.HongPai)
                    {
                        fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "红牌警告点位置") as IFeatureLayer;
                    }

                    //是否应该修改为在企业范围中查找，这样应该更合适，好找一些 zhwsun on 2018-08-28
                    feas = GetPointSelect(point, fealayer, 50);

                    if (feas.Count > 0)
                    {
                        object id = feas[0].get_Value(2);//0：Id，2:地块编码
                        if (id != null && id.ToString() != "")
                        {
                            if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.QiYeZhaoPianXinxi)
                            {
                                FrmOneLtdAndRentLtdInfo obj = new FrmOneLtdAndRentLtdInfo(id.ToString());
                                obj.ShowDialog();
                            }
                            else if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.AnQuanJianCha)
                            {
                                string txtproblem = GetLtdproblem(GlobalVariables.SelectFeatureValue.AnQuanJianCha, id.ToString());
                                GlobalVariables.CreateTextElment(axMapControl1, e.mapX, e.mapY, txtproblem);
                                //frmLtdProbem3 obj = new frmLtdProbem3(GlobalVariables.SelectFeatureValue.AnQuanJianCha, id.ToString());
                                //obj.ShowDialog();
                            }
                            //计划对图层进行过滤，然后按样式显示即可，因此就不用再点了
                            //else if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.AnQuanJianCha)
                            //{
                            //    //fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "安全检查点位置 ") as IFeatureLayer;
                            //}
                            //else if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.HuangPai)
                            //{
                            //    //fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "黄牌警告点位置 ") as IFeatureLayer;
                            //}
                            //else //if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.HongPai)
                            //{
                            //    //fealayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "红牌警告点位置 ") as IFeatureLayer;
                            //}

                        }
                    }
                    else
                    {
                        MessageBox.Show("没有选中对象，要使图层可见并选中对象，请重新选择！");
                        return;
                    }

                    return;
                    #region temp no use
                    //if (GlobalVariables.Select.SType == GlobalVariables.SelectType.SingleSelect)
                    //{
                    //    if (e.button == 2)
                    //    {
                    //        GlobalVariables.Select.Exit();
                    //        return;
                    //    }
                    //    //单击选择
                    //    //featureSelect方法
                    //    featureSelect pfeaobj = new featureSelect();
                    //    pfeaobj.featureSelects(e);

                    //    string LayerName = string.Empty;
                    //    string Fields = string.Empty;
                    //    string Result = string.Empty;

                    //    Fields = SelectControl.DealFeatureSelect();
                    //    if (Fields.Length < 5)
                    //    {
                    //        MessageBox.Show("没有选中对象，要使图层可见并选中对象，请重新选择！");
                    //        return;
                    //    }
                    //    if (Fields.Length > 0)
                    //    {
                    //        if (GlobalVariables.Select.SValue == GlobalVariables.SelectFeatureValue.QiYeZhaoPianXinxi)
                    //        {
                    //            string dkbm = "";
                    //            if (dkbm != null && dkbm != "")
                    //            {
                    //                FrmOneLtdAndRentLtdInfo obj = new FrmOneLtdAndRentLtdInfo(dkbm);
                    //                qyFormUtil.ShowForm(obj);
                    //            }
                    //        }
                    //    }
                    //}
                    #endregion
                }
                else if (GlobalVariables.Select.SType != GlobalVariables.SelectType.enull && GlobalVariables.Select.SOperFun == GlobalVariables.SelectFunGroup.QueryLayerInfo)
                {
                    //查询房屋，企业，城市规划
                    identifyDialog.OnMouseDown(e.button, e.mapX, e.mapY);
                }

                //更新标注和注记信息
                try
                {
                    for (int i = 0; i < GlobalVariables.axMapControl.LayerCount; i++)
                    {
                        ILayer player = GlobalVariables.GetOverviewLayer(GlobalVariables.axMapControl.Map, i);
                        IFeatureLayer pflayer = player as IFeatureLayer;

                        GlobalVariables.UpdataLabel(GlobalVariables.axMapControl, pflayer);
                    }
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }




















        private void 图层控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    FrmLayerSet obj = new FrmLayerSet();
            //    qyFormUtil.ShowForm(obj);
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}
        }


        private bool LabelLayer(ILayer pLayer, Font pFontDisp, Color pColor, string bstrExpression, bool m_bViewLabel)
        {
            //return true;
            //bool VARIANT_FALSE;
            //if (pLayer == null)
            //{
            //    return false;
            //}
            //if (bstrExpression == "")
            //{
            //}
            //IFeatureLayer pFeatureLayer;
            //IGeoFeatureLayer pGeoFeatureLayer;
            //pFeatureLayer = (IFeatureLayer)pLayer;
            //pGeoFeatureLayer = (IGeoFeatureLayer)pFeatureLayer;

            //ITrackCancel pTrackCancel = new CancelTrackerClass();//(CLSID_CancelTracker);	
            //IActiveView pView = this.axMapControl1.ActiveView;
            //IScreenDisplay pScreenDisplay = pView.ScreenDisplay;
            //IDisplay pDisplay = (IDisplay)pScreenDisplay;

            //if (m_bViewLabel == false)
            //{
            //    pGeoFeatureLayer.DisplayAnnotation = false;
            //    pView.Refresh();
            //    return true;
            //}

            //else
            //{
            //    pGeoFeatureLayer.DisplayAnnotation = true;
            //}

            ////IAnnotateLayerProperties pALP = new LabelEngineLayerPropertiesClass();// IAnnotateLayerProperties();//(CLSID_LabelEngineLayerProperties);
            ////pALP.. = esriLabelWhichFeatures.)pGeoFeatureLayer;//..f.putref_FeatureLayer(pGeoFeatureLayer);
            //IEnvelope pEnv = this.axMapControl1.ActiveView.Extent;//.m_ctrlMap.GetExtent();
            //pALP.Extent = pEnv;
            //ILabelEngineLayerProperties pLELP;
            //pLELP = pALP;

            //ITextSymbol pTextSymbol;
            //pLELP.Symbol = pTextSymbol;
            ////if (pColor!=null)
            ////{	
            ////IRgbColorPtr pRgbColor(CLSID_RgbColor);
            ////pRgbColor=pColor;
            ////pTextSymbol->put_Color(pColor);
            ////}

            ////if (pFontDisp!=NULL)
            ////{
            ////pTextSymbol->put_Font(pFontDisp);
            ////}

            //pLELP.Expression = bstrExpression;
            //IAnnotateLayerPropertiesCollection pCol;
            //pCol = pGeoFeatureLayer.AnnotationProperties;
            //pCol.Clear();
            //pCol.Add(pALP);

            //pGeoFeatureLayer.Draw((esriDrawPhase)esriDPAnnotation, pDisplay, pTrackCancel);

            //pView.Refresh();
            return true;

        }




        private void btnRefreshMap_Click(object sender, EventArgs e)
        {
            //dgvFW.Columns[1].Width;
            try
            {
                if (this.cboLayerName.Text != "")
                {
                    IGeoFeatureLayer pLayer = LayerControl.getGeoLayer(this.axMapControl1, this.cboLayerName.Text);
                    if (pLayer is IFeatureLayer)//如果第一个图层时矢量图层
                    {
                        ILayerEffects pLayerEffects = pLayer as ILayerEffects;
                        pLayerEffects.Transparency = Convert.ToInt16(cboTransp.Text.Trim());//设置ILayerEffects接口的Transparency属性使该矢量图层的透明度属性为65.

                        this.axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewAll, pLayer, null);
                    }
                    else
                        this.axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewAll, null, null);
                }
                else
                    this.axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewAll, null, null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void chkXZDisp_CheckedChanged(object sender, EventArgs e)
        {
            LoadLayerToLayerQueryButton();
            ChangeLayerSymbol();
        }


        private void LoadLayerToLayerQueryButton()
        {
            //toolStripButton3.Enabled = chkXZDisp.Checked;
            //toolStripButton6.Enabled = this.chkFWDisp.Checked;
            //toolStripButton1.Enabled = this.rbDjPc.Checked;
            //toolStripButton4.Enabled = this.rbDjTD.Checked;
            //toolStripButton5.Enabled = this.rbDjCS.Checked;
            //toolStripButton7.Enabled = this.chkQyfw.Checked;
            //toolStripButton8.Enabled = this.chkJbntbhq.Checked;
            //toolStripButton9.Enabled = this.chkGyqssj.Checked;
            //toolStripButton10.Enabled = this.chkKjsq.Checked;
            //toolStripButton11.Enabled = this.chkGdsj.Checked;
            //toolStripButton12.Enabled = this.chkTdlyxz.Checked;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (GlobalVariables.axMapControl.get_Layer(GlobalVariables.axMapControl.LayerCount - 1).Name != "影像")
            //    {
            //        if (LoginUser.bsO_Righrs == "全部村镇")
            //            LoadImageLayer("影像", "wd/wt");// "WTMap/WTService");
            //        else if (LoginUser.bsO_Righrs == "宅基村")
            //            LoadImageLayer("影像", "wd/cun320507100202");
            //        else if (LoginUser.bsO_Righrs == "何家角村")
            //            LoadImageLayer("影像", "wd/cun320507100201");
            //        else if (LoginUser.bsO_Righrs == "迎湖村")
            //            LoadImageLayer("影像", "wd/cun320507100203");
            //        else if (LoginUser.bsO_Righrs == "新埂村")
            //            LoadImageLayer("影像", "wd/cun320507100200");
            //        else if (LoginUser.bsO_Righrs == "项路村")
            //            LoadImageLayer("影像", "wd/cun320507100204");
            //        else if (LoginUser.bsO_Righrs == "华阳村")
            //            LoadImageLayer("影像", "wd/cun320507100208");
            //        else if (LoginUser.bsO_Righrs == "四旺村")
            //            LoadImageLayer("影像", "wd/cun320507100207");
            //        else if (LoginUser.bsO_Righrs == "建成区")
            //            LoadImageLayer("影像", "wd/cun320507100001");


            //        //LoadImageLayer("影像", "WTMap/SLService");

            //    }

            //    chkImage.Checked = !chkImage.Checked;
            //    if (chkImage.Checked)
            //    {
            //        this.button7.BackgroundImage = TDObject.Properties.Resources.ditu;
            //    }
            //    else
            //    {
            //        this.button7.BackgroundImage = TDObject.Properties.Resources.weixing;
            //    }
            //}
            //catch (Exception ex)
            //{
            //    log.Error(ex.Message);
            //}

        }

        private void LoadImageLayer(string layName, string serviceName)
        {
            try
            {
                IAGSServerConnectionFactory connectionFactory = new AGSServerConnectionFactory();
                IPropertySet propertySet = new PropertySet();
                IAGSServerConnection connection;
                string con = string.Empty;
                try
                {
                    con = new Conection().GetConnectionString("arcgisServer");

                }
                catch
                {
                    MessageBox.Show("请检查arcgisServer连接字符串设置!");
                }
                if (con == string.Empty) return;
                string[] strs = con.Split(new char[] { ';' });
                propertySet.SetProperty("url", strs[0]);

                try
                {
                    connection = connectionFactory.Open(propertySet, 0);
                    // Get "MapService" MapServer object
                }
                catch (Exception ex)
                {
                    //this.button7.BackgroundImage = TDObject.Properties.Resources.weixing;
                    MessageBox.Show("在与服务器通信中发生错误！(" + ex.Message + ")");
                    return;
                }
                IAGSEnumServerObjectName serverObjectNames;
                IAGSServerObjectName serverObjectName;
                serverObjectNames = connection.ServerObjectNames;
                while ((serverObjectName = serverObjectNames.Next()) != null)
                {

                    if (serverObjectName.Name.Equals(serviceName) && serverObjectName.Type.Equals("MapServer"))
                        break;

                }

                if (serverObjectName == null)
                {

                    //this.button7.BackgroundImage = TDObject.Properties.Resources.weixing;
                    MessageBox.Show("在与服务器通信中发生错误！");
                    return;
                }
                IName name = serverObjectName as IName;
                IMapServer mapServer = name.Open() as IMapServer;

                // Create MapServerLayer using AGS data source
                ESRI.ArcGIS.Carto.IMapServerLayer layer = new MapServerLayer() as IMapServerLayer;
                layer.ServerConnect(serverObjectName, mapServer.DefaultMapName);
                ILayer lay = layer as ILayer;
                lay.Name = layName;
                GlobalVariables.axMapControl.AddLayer(lay, GlobalVariables.axMapControl.LayerCount);
                LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, serviceName, true);
                GlobalVariables.axMapControl.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }

        /// <summary>
        /// 2017-11-01 取消取消历年批次的叠加
        /// </summary>
        private void ChangeLayerSymbol()
        {
            //Dictionary<string, bool> overlyNames = new Dictionary<string, bool>();//叠加图层显示标志

            ////overlyNames.Add("历年批次", rbDjPc.Checked);
            ////overlyNames.Add("城市规划", rbDjCS.Checked);
            ////overlyNames.Add("土地规划", rbDjTD.Checked);
            ////overlyNames.Add("土地现状数据", chkXZDisp.Checked);
            //overlyNames.Add("影像", chkImage.Checked);



            //int OverLayCount = 0;
            ////string LastDispLayName = GlobalVariables.LayerName2FullName["历年批次"];
            //string LastDispLayName = GlobalVariables.LayerName2FullName["城市规划"];



            //foreach (string layname in overlyNames.Keys)
            //{
            //    if (overlyNames[layname])
            //    {
            //        LastDispLayName = layname;
            //        OverLayCount++;
            //    }
            //}

            //GlobalVariables.LayTextSymbolStyleName.Clear();
            ////GlobalVariables.LayTextSymbolStyleName.Add("历年批次", "默认标注");
            //GlobalVariables.LayTextSymbolStyleName.Add("城市规划", "默认标注");
            //GlobalVariables.LayTextSymbolStyleName.Add("土地规划", "默认标注");
            //GlobalVariables.LayTextSymbolStyleName.Add("土地现状数据", "默认标注");
            //GlobalVariables.LayTextSymbolStyleName.Add("相城区道路中心镇及湖泊注记", "土地规划(新)");
            //GlobalVariables.LayTextSymbolStyleName.Add("基本农田保护区", "国土数据(权属性质)");
            //GlobalVariables.LayTextSymbolStyleName.Add("供地", "国土数据(权属性质)");
            //GlobalVariables.LayTextSymbolStyleName.Add("国有权属", "国土数据(权属性质)");
            //GlobalVariables.LayTextSymbolStyleName.Add("可建设区", "国土数据(权属性质)");
            //GlobalVariables.LayTextSymbolStyleName.Add("企业范围", "国土数据(权属性质)");
            //GlobalVariables.LayTextSymbolStyleName.Add("土地利用现状", "土地利用现状");

            //foreach (string layname in overlyNames.Keys)
            //{
            //    if (layname != "影像")
            //    {
            //        if (OverLayCount == 1)
            //        {
            //            GlobalVariables.LayTextSymbolStyleName[OverLayStyles[0][layname][0]] = "默认标注";
            //        }
            //        else
            //        {
            //            if (layname == LastDispLayName)
            //            {
            //                GlobalVariables.LayTextSymbolStyleName[OverLayStyles[0][layname][0]] = "默认标注";
            //            }
            //            else if (OverLayCount == 2)
            //            {
            //                GlobalVariables.LayTextSymbolStyleName[OverLayStyles[0][layname][0]] = "小号标注";
            //            }
            //        }
            //    }
            //}

            //foreach (string layname in overlyNames.Keys)
            //{
            //    if (layname != "影像")
            //    {
            //        if (OverLayCount == 1)
            //        {
            //            LayerControl.CreateOverLaySymbol(GlobalVariables.axMapControl, OverLayStyles[0][layname][0], OverLayStyles[0][layname][1], OverLayStyles[0][layname][2], OverLayStyles[0][layname][3]);
            //        }
            //        else
            //        {
            //            if (layname == LastDispLayName)
            //            {
            //                LayerControl.CreateOverLaySymbol(GlobalVariables.axMapControl, OverLayStyles[3][layname][0], OverLayStyles[3][layname][1], OverLayStyles[3][layname][2], OverLayStyles[3][layname][3]);
            //            }
            //            else if (OverLayCount == 2)
            //            {
            //                LayerControl.CreateOverLaySymbol(GlobalVariables.axMapControl, OverLayStyles[1][layname][0], OverLayStyles[1][layname][1], OverLayStyles[1][layname][2], OverLayStyles[1][layname][3]);
            //            }
            //            else if (OverLayCount >= 3)
            //            {
            //                LayerControl.CreateOverLaySymbol(GlobalVariables.axMapControl, OverLayStyles[2][layname][0], OverLayStyles[2][layname][1], OverLayStyles[2][layname][2], OverLayStyles[2][layname][3]);
            //            }
            //        }
            //    }
            //    LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, layname, overlyNames[layname]);
            //}

            //GlobalVariables.axMapControlEagle.Refresh();
            //GlobalVariables.axMapControl.Refresh();
            ////this.axTOCControl1.SetBuddyControl(GlobalVariables.axMapControl);


        }

        private void axMapControl1_OnMouseMove(object sender, IMapControlEvents2_OnMouseMoveEvent e)
        {
            try
            {
                //statusBarXY.Text = string.Format("{0}, {1}  {2}", e.mapX.ToString("#######.##"), e.mapY.ToString("#######.##"), axMapControl1.MapUnits.ToString().Substring(4));
                if (GlobalVariables.Select.SType != GlobalVariables.SelectType.enull && GlobalVariables.Select.SOperFun == GlobalVariables.SelectFunGroup.QueryLayerInfo)
                {
                    identifyDialog.OnMouseMove(e.mapX, e.mapY);

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void chkDLDisp_CheckedChanged(object sender, EventArgs e)
        {
            //LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, GlobalVariables.LayerName2FullName["道路线"], chkDLDisp.Checked);
            //LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, GlobalVariables.LayerName2FullName["道路中线"], chkDLDisp.Checked);
            //LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, GlobalVariables.LayerName2FullName["桥"], chkDLDisp.Checked);
            //GlobalVariables.axMapControl.Refresh();
        }

        private void chkFWDisp_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                LayerControl.SetVisibleStatus(GlobalVariables.axMapControl, GlobalVariables.LayerName2FullName["房屋"], true);
                GlobalVariables.axMapControl.Refresh();

                LoadLayerToLayerQueryButton();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void MainForm_Shown(object sender, EventArgs e)
        {
            try
            {
                if (MainForm.m_LoginStatus == 3)
                { this.Close(); }
                this.WindowState = FormWindowState.Maximized ;

                foreach (string layanme in cboLayerFact.Items)
                {
                    IGeoFeatureLayer pLayer = LayerControl.getGeoLayer(this.axMapControl1, layanme);
                    if (pLayer is IFeatureLayer)//如果第一个图层时矢量图层
                    {
                        ILayerEffects pLayerEffects = pLayer as ILayerEffects;
                        pLayerEffects.Transparency = Convert.ToInt16(cboTransp.Text.Trim());//设置ILayerEffects接口的Transparency属性使该矢量图层的透明度属性为65.
                    }
                }
                this.axMapControl1.Refresh();
            }
            catch (Exception ex) { log.Error(ex.Message); }
        }



        private void 用户管理ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                FrmUserManaNew obj = new FrmUserManaNew();
                obj.Show();

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        private void 密码修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmChangePwd obj = new frmChangePwd();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void RefreshRights()
        {
            //绘制自由分区ToolStripMenuItem.Visible = false;
            //图形处理ToolStripMenuItem.Visible = false;
            Maptrans.Visible = false;
            图层控制ToolStripMenuItem.Visible = false;

            testToolStripMenuItem.Visible = true;


            btnSaveFW.Visible = false;
            try
            {
                if (LoginUser.bsR_Name == "管理员")
                {
                    excel数据导入ToolStripMenuItem.Visible = true;
                    用户管理ToolStripMenuItem2.Visible = true;
                    图形处理ToolStripMenuItem.Visible = true;
                    分项维护ToolStripMenuItem1.Visible = true;


                    if ("统计站,委领导,System,吴江经济技术开发区".Contains(LoginUser.bsO_Name))
                    {
                        基础数据导入ToolStripMenuItem.Visible = true;
                        testToolStripMenuItem.Visible = true;//企业统计
                    }

                }
                else
                {
                    excel数据导入ToolStripMenuItem.Visible = false;
                    用户管理ToolStripMenuItem2.Visible = false;
                    图形处理ToolStripMenuItem.Visible = false;
                    分项维护ToolStripMenuItem1.Visible = false;

                    btnSaveFW.Visible = false;
                    btnSaveQyfw.Visible = false;
                }
            }
            catch (Exception ex)
            {
                log.Error("RefreshRights:" + ex.Message);
            }
        }

        private void chkImage_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ChangeLayerSymbol();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (loadType == 5)
            {
                //关闭连接
            }
        }


        private void StartProgress()
        {
            stepForProbar = 2;
            Thread thdSub = new Thread(new ThreadStart(DispProgressBar));//ThreadFun));
            thdSub.Start();
            // this.Enabled = false;
        }
        public void StopProgress()
        {
            //lock (stepForProbar)
            //{
            //     stepForProbar = -1;
            //}
            if (loadingProgress != null)
                loadingProgress.m_Terminated = true;
        }

        private void DispProgressBar()
        {
            loadingProgress = new frmProgress();
            myIncrease = new IncreaseHandle(loadingProgress.Increase);
            if ((int)stepForProbar != -1)
                loadingProgress.ShowDialog();
            loadingProgress = null;
            myIncrease = null;
        }
        private void ThreadFun()
        {
            MethodInvoker mi = new MethodInvoker(DispProgressBar);
            this.BeginInvoke(mi);
            Thread.Sleep(1000);//Sleep a while to show window

            bool blnIncreased = false;
            object objReturn = null;
            do
            {
                Thread.Sleep(500);
                objReturn = this.Invoke(this.myIncrease, new object[] { (int)stepForProbar });
                blnIncreased = (bool)objReturn;
                Application.DoEvents();
            }
            while (blnIncreased);
        }

        private void SetCursorForSelect()
        {
            //this.Cursor = Cursors.Arrow;
            //ESRI.ArcGIS.SystemUI.ICommand pCommand; 
            //pCommand = new ESRI.ArcGIS.Controls.ControlsSelectFeaturesToolClass(); 
            //pCommand.OnCreate(this.axMapControl1.Object); 
            //axMapControl1.CurrentTool = pCommand as ESRI.ArcGIS.SystemUI.ITool;
            //pCommand.OnClick();

            this.axToolbarControl1.CurrentTool = null;
            this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;

        }

        private void axToolbarControl1_OnItemClick(object sender, IToolbarControlEvents_OnItemClickEvent e)
        {
            //如果不是放到，缩小，漫游，则清除之前的操作
            // if (e.index > 5)
            //{
            GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.eNull;//清除之前的操作
            //}
        }

        private void 属性ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SetProperViewDisp(!panel1.Visible);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void SetProperViewDisp(bool dispflag)
        {
            属性ToolStripMenuItem.Checked = dispflag;
            panel1.Visible = dispflag;
        }


        /// 属性查询初始化窗体创建带查询图层 -- 入口方法
        /// <summary>
        /// </summary>
        /// <param name="layerName"></param>
        private void ShowIdentifyDialog(string layerName)
        {
            if (panel1.Visible)
                panel1.Width = 330;
            ArrayList list = new ArrayList();
            list.Add(dgvQyxx);
            list.Add(dgvFW);
            list.Add(dgvCSGH);


            //新建属性查询对象
            identifyDialog = IdentifyDialog.CreateInstance(axMapControl1, list);
            identifyDialog.Owner = this;
            identifyDialog.Show();
            //  identifyDialog.Hide();
            identifyDialog.SetLayerFilterIndex(layerName);


        }

        private IdentifyDialog identifyDialog { get; set; }






        private void SaveLayerData(string TType, DataGridView dgv)
        {
            Dictionary<string, string> value = new Dictionary<string, string>();
            int row = dgv.Rows.Count;//得到总行数    
            if (row <= 0)
                return;
            for (int i = 0; i < row; i++)//得到总行数并在之内循环    
            {
                value.Add(dgv.Rows[i].Cells[0].Value.ToString(), dgv.Rows[i].Cells[1].Value.ToString());
            }
            if (DatabaseAccess.updateLayerInfoToDB(TType, value) == 0)
            {
                MessageBox.Show("修改保存成功！", "信息提示");
            }
            else
            {
                MessageBox.Show("修改保存失败！", "信息提示");
            }
        }



        private void btnSaveFW_Click(object sender, EventArgs e)
        {
            SaveLayerData("房屋建筑", dgvFW);
        }


        //private void toolStripButton6_Click(object sender, EventArgs e)
        //{
        //    SetProperViewDisp(true);

        //    GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.FW;
        //    GlobalVariables.Select.SType = GlobalVariables.SelectType.PolygonSelect;
        //    GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.QueryLayerInfo;
        //    ShowIdentifyDialog("房屋");

        //    this.axToolbarControl1.CurrentTool = null;
        //    this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
        //}


        private void RefreshCheckedStatus(string layname,bool visible)
        {
            int layindex = -1;
            for (int i = 0; i < treeView2.Nodes[0].Nodes.Count; i++)
            {
                if (treeView2.Nodes[0].Nodes[i].Text == layname)
                {
                    //visible = treeView2.Nodes[0].Nodes[i].Checked;

                    treeView2.Nodes[0].Nodes[i].Checked = visible;
                    layindex = i;
                    break;
                }
            }
        }

        private void CancelMapClickHandler()
        {
            GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.enull;
            GlobalVariables.Select.SType = GlobalVariables.SelectType.enull;
            GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.eNull;

        }
        private void LayerAttrQueryStart(string Layername,bool visible)
        {
            try
            {
                //SetProperViewDisp(true); //吴江左侧不显示，注释掉
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.enull;
                GlobalVariables.Select.SType = GlobalVariables.SelectType.enull;
                GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.eNull;
                //获取显示状态

                if (Layername == "城市规划")
                {
                    RefreshCheckedStatus(Layername, visible);
                    LayerControl.SetVisibleStatus(axMapControl1, Layername, visible);
                }
                else if (visible)
                {
                    RefreshCheckedStatus(Layername, visible);
                    LayerControl.SetVisibleStatus(axMapControl1, Layername, true);
                }



                if (!visible)// && Layername == "城市规划")
                    return;


                GlobalVariables.Select.SType = GlobalVariables.SelectType.PolygonSelect;
                GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.QueryLayerInfo;
                if (Layername == "房屋建筑")
                    GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.FangWu;
                else if (Layername == "企业范围")
                    GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.QiYeFangWei;
                else if (Layername == "城市规划")
                    GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.ChengShiGuiHua;

                ShowIdentifyDialog(Layername);

                this.axToolbarControl1.CurrentTool = null;
                this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
            }
            catch (Exception ex)
            {
                log.Error(this.Name + ":" + ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void 综合查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmComplexQuery obj = new frmComplexQuery();
            qyFormUtil.ShowForm(obj);
        }


        private void 按企业名称查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLtdQymcQuery frmobj = new frmLtdQymcQuery();
            frmobj.ShowDialog();

            BottomPageVisible(1);
            string strQyfw = "纳税人名称 like '%" + LtdNameQuery + "%'" + LoginUserRights;
            string strLtdBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=0 and " + strQyfw + ")";


            string strZlBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=1 and " + strQyfw + ")";
            LtdQyxxQuery(strLtdBase, strZlBase);


            //LtdQyxxQuery(strLtdBase, "ZLQYMC_ like '%" + LtdNameQuery + "%'" + LoginUserRights);

        }

        private void LtdQyxxQuery(string qyfilter, string zlfilter)
        {
            _ltdobjs = TDObject.BLL.CommSetting.EM.GetListNoPaging<vwLtdJcSj>(qyfilter, "序号");
            TDObject.UI.UIDgvColumnsSetting.RefreshLtdImportInfo(dgvT2_11, _ltdobjs, "vwLtdJcSj", 1);

            _ltdobjs1 = TDObject.BLL.CommSetting.EM.GetListNoPaging<vwLtdJcSj>(zlfilter, "序号");
            TDObject.UI.UIDgvColumnsSetting.RefreshLtdImportInfo(dgvT2_12, _ltdobjs1, "vwLtdJcSj", 1);
        }

        //企业信息查询
        //private void toolStripButton7_Click(object sender, EventArgs e)
        //{
        //    SetProperViewDisp(true);
        //    GlobalVariables.Select.SType = GlobalVariables.SelectType.PolygonSelect;
        //    GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.XZ;
        //    GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.QueryLayerInfo;
        //    ShowIdentifyDialog("企业范围");

        //    this.axToolbarControl1.CurrentTool = null;
        //    this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;
        //}

        private void BottomPageVisible(int index)
        {
            SetBottomViewDisp(true);

            this.tabControl2.ItemSize = new Size(10, 1);
            if (index == 1)
            {
                this.tabPage6.Parent = this.tabControl2;
                this.tabPage7.Parent = null;
                this.tabPage8.Parent = null;
                //this.tabPage15.Parent = null;

            }
            else if (index == 2)
            {
                this.tabPage6.Parent = null;
                this.tabPage7.Parent = this.tabControl2;
                this.tabPage8.Parent = null;
                //this.tabPage15.Parent = null;
            }
            else if (index == 3)
            {
                this.tabPage6.Parent = null;
                this.tabPage7.Parent = null;
                this.tabPage8.Parent = this.tabControl2;
                //this.tabPage15.Parent = null;
            }
            else
            {
                this.tabPage6.Parent = null;
                this.tabPage7.Parent = null;
                this.tabPage8.Parent = null;
                //this.tabPage15.Parent = this.tabControl2;

            }
        }

        private void 华阳村ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BottomPageVisible(1);


                ToolStripMenuItem tsmi = ((ToolStripMenuItem)sender);
                LtdNameQuery = tsmi.Tag.ToString();
                string strQyfw = "所属管理区 like '%" + LtdNameQuery + "%'";
                string strLtdBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=0 and " + strQyfw + ")";


                //string strQyfw = "纳税人名称 like '%" + LtdNameQuery + "%'" + LoginUserRights;
                string strZlBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=1 and " + strQyfw + ")";
                LtdQyxxQuery(strLtdBase, strZlBase);


                //LtdQyxxQuery(strLtdBase, "SSGLQDM like '%" + LtdNameQuery + "%'");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 按产业类型查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                BottomPageVisible(1);

                ToolStripMenuItem tsmi = ((ToolStripMenuItem)sender);
                LtdNameQuery = tsmi.Text;//.Substring(0, 3);

                string strQyfw = "主行业 like '%" + LtdNameQuery + "%'" + MainForm.LoginUserRights;
                //string strLtdBase = "单位 in (select ydqymc from 企业范围 where " + strQyfw + ")";
                string strLtdBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=0) and " + strQyfw + "";
                string strZlBase = "单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=1) and " + strQyfw + "";
                LtdQyxxQuery(strLtdBase, strZlBase);
                //LtdQyxxQuery("所属行政村代码='" + MainForm.LoginUser.bsO_RightsCode + "' and 用地单位名称 like '%" + LtdNameQuery + "%'", "所属行政村代码='" + MainForm.LoginUser.bsO_RightsCode + "' and  租赁企业名称 like '%" + LtdNameQuery + "%'");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }








        private void ChangeToPositioin(string LayerName)
        {
            string DKBH;




            try
            {
                string dkbhs = "";
                for (int i = 0; i < dgvT2_11.Rows.Count; i++)
                {
                    object val = dgvT2_11.Rows[i].Cells[0].Value;
                    if (val != null && Convert.ToBoolean(val) == true)
                    {
                        DKBH = dgvT2_11.Rows[i].Cells[2].Value.ToString();
                        //pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);
                        if (DKBH != null && DKBH.Trim() != "")
                        {
                            if (!dkbhs.Contains(DKBH))
                                dkbhs += "," + DKBH;
                        }


                    }
                }
                FindGeos = LayerControl.getIGeoByFields(LoadedLayers["企业范围"], "DKBH", dkbhs, ",", ref newdisp, ref Geos);

                if (Geos.Count == 0)
                    MessageBox.Show("没有找到定位企业，请与管理员联系核实数据！");
                else
                    LayerControl.ChangeMapExtent(GlobalVariables.axMapControl, newdisp);
            }
            catch (Exception ex)
            {
                MessageBox.Show("系统资源可能不足，请尽量不要全部选择！");
            }

            if (FindGeos.Count == 0)
                MessageBox.Show("请先选择用地企业！");
            else
                LayerControl.ChangeMapExtent(this.axMapControl1, newdisp);
        }



        public void ChangeToPositioin(string LayerName, string lstdkbms)
        {
            string DKBH;


            List<IFeature> FindGeos = new List<IFeature>();

            List<IFeature> pGeo = new List<IFeature>();
            IEnvelope newdisp = (IEnvelope)new Envelope();

            string[] dkbms = lstdkbms.Split(new char[] { ',' });
            foreach (string dkbm in dkbms)
            {
                pGeo = LayerControl.getIGeoByFields(LoadedLayers["企业范围"], "DKBH", dkbm);

                if (pGeo.Count > 0)
                {
                    newdisp.Union(pGeo[0].Extent);
                }
            }
            LayerControl.ChangeMapExtent(this.axMapControl1, newdisp);
        }

        private void btnPosition1_Click(object sender, EventArgs e)
        {
            try
            {
                ChangeToPositioin("企业范围");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 企业查询信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                //SetBottomViewDisp(this.splitContainer3.Panel2.Height==0?true:false)
                SetBottomViewDisp(!panel6.Visible);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        private void SetBottomViewDisp(bool dispflag)
        {
            企业查询信息ToolStripMenuItem.Checked = dispflag;
            this.panel6.Visible = dispflag;
            //if (dispflag)
            //    this.splitContainer3.Panel2.Height = 200;
            //else
            //    this.splitContainer3.Panel2.Height = 0;
        }

        private void 当前窗体范围打印图件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmMapPreprint obj = new frmMapPreprint(this.axMapControl1);
                obj.ShowDialog();

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        // <summary>
        /// 按纸张打印地图 //by yl landgis@126.com 2008.6.18
        /// </summary>
        /// <param name="pActiveView"></param>
        /// <param name="pscale"></param>
        private void PrintAuto(IActiveView pActiveView)
        {
            //IPaper pPaper = new Paper();
            //IPrinter pPrinter = new EmfPrinterClass();

            //System.Drawing.Printing.PrintDocument sysPrintDocumentDocument = new System.Drawing.Printing.PrintDocument();

            //pPaper.PrinterName = sysPrintDocumentDocument.PrinterSettings.PrinterName;
            //pPrinter.Paper = pPaper;

            //int Resolution = pPrinter.Resolution;

            //double w, h;
            //IEnvelope PEnvelope = pActiveView.Extent;
            //w = PEnvelope.Width;
            //h = PEnvelope.Height;
            //double pw, ph;//纸张
            //pPrinter.QueryPaperSize(out pw, out ph);
            //tagRECT userRECT = pActiveView.ExportFrame;

            //userRECT.left = (int)(pPrinter.PrintableBounds.XMin * Resolution);
            //userRECT.top = (int)(pPrinter.PrintableBounds.YMin * Resolution);

            //if ((w / h) > (pw / ph))//以宽度来调整高度
            //{

            //    userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Width * Resolution);
            //    userRECT.bottom = userRECT.top + (int)((pPrinter.PrintableBounds.Width * Resolution) * h / w);
            //}
            //else
            //{
            //    userRECT.bottom = userRECT.top + (int)(pPrinter.PrintableBounds.Height * Resolution);
            //    userRECT.right = userRECT.left + (int)(pPrinter.PrintableBounds.Height * Resolution * w / h);

            //}

            //IEnvelope pDriverBounds = new EnvelopeClass();
            //pDriverBounds.PutCoords(userRECT.left, userRECT.top, userRECT.right, userRECT.bottom);

            //ITrackCancel pCancel = new CancelTrackerClass();
            //int hdc = pPrinter.StartPrinting(pDriverBounds, 0);

            //pActiveView.Output(hdc, pPrinter.Resolution,
            //ref userRECT, pActiveView.Extent, pCancel);

            //pPrinter.FinishPrinting();

        }


        private void btnExport1_Click(object sender, EventArgs e)
        {
            try
            {
                btnExport1.Text = "正在导出...";
                btnExport1.Enabled = false;
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Files|*.xls";
                if (chkYdqy.Checked)
                {
                    List<vwLtdJcSj> objs = new List<vwLtdJcSj>();
                    for (int i = 0; i < _ltdobjs.Count; i++)
                    {
                        object val = dgvT2_11.Rows[i].Cells[0].Value;
                        if (val != null && Convert.ToBoolean(val) == true)
                        {
                            objs.Add(_ltdobjs[i]);
                        }
                    }
                    if (objs.Count > 0)
                    {
                        if (DialogResult.OK == sfd.ShowDialog())
                        {
                            string modelName = sfd.FileName;// @"用地企业信息表";
                            QyTech.ExcelOper.QyExcelHelper excl = new QyTech.ExcelOper.QyExcelHelper("local");
                            //string p = "Id,bsO_Id,TotalDTType,FromDt,ddd,OrgName";
                            //导出的数据项
                            //string items = "用地单位名称,所属行政村名称,土地发证面积,实际占地面积,建筑占地面积,建筑面积,批准用途,实际用途,是否为租赁企业,企业性质,注册资本,法人代表,联系电话,土地座落,通讯地址,产业类型,能耗,产值,税收,租金,行业类型,经济类型,资产类型,抵押情况,企业代码";
                            string items = "地块编号,年度,月份,单位代码,单位,市区,区域,经营现状,是否工业,等级,住所,经营范围,注册时间,企业类型,法人代表,注册资金,主行业,行业细分,规模,规上";
                            if ("统计站,委领导,System,吴江经济技术开发区".Contains(LoginUser.bsO_Name))
                            {
                                items = "地块编号,年度,月份,单位代码,单位,市区,区域,经营现状,是否工业,等级,住所,经营范围,注册时间,企业类型,法人代表,注册资金,主行业,行业细分,规模,规上,企业数,参保人数,就业人数,国税,地税,销售,占地,其中持证,用能,用电,排放,研发经费支出,平均职工人数,固定资产折旧,生产税净额,营业盈余,职工工资总额,税收,增加值,亩均税收";
                            }
                            string saveToPath = excl.ExportListToExcl<vwLtdJcSj>(objs, modelName, items, "yyyy-MM-dd", true, 2, 2, "local");

                            MessageBox.Show("用地企业文件导出完毕！", "提示", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请首选选择要导出的数据！", "提示", MessageBoxButtons.OK);
                        return;
                    }

                }
                if (chkZlqy.Checked)
                {

                    List<vwLtdJcSj> objs = new List<vwLtdJcSj>();
                    for (int i = 0; i < _ltdobjs1.Count; i++)
                    {
                        object val = dgvT2_12.Rows[i].Cells[0].Value;
                        if (val != null && Convert.ToBoolean(val) == true)
                        {
                            objs.Add(_ltdobjs1[i]);
                        }
                    }

                    if (objs.Count > 0)
                    {
                        if (DialogResult.OK == sfd.ShowDialog())
                        {
                            string modelName = sfd.FileName;//@"z租赁企业信息表";
                            QyTech.ExcelOper.QyExcelHelper excl = new QyTech.ExcelOper.QyExcelHelper("local");
                            //string items = "租赁企业名称,所属行政村名称,用地企业名称,企业性质,注册资本,法人代表,联系电话,土地座落,通讯地址,产业类型,能耗,产值,税收,租金,行业类型,经济类型,资产类型,抵押情况,企业代码";
                            string items = "地块编号,年度,月份,单位代码,单位,市区,区域,经营现状,是否工业,等级,住所,经营范围,注册时间,企业类型,法人代表,注册资金,主行业,行业细分,规模,规上";
                            if ("统计站,委领导,System,吴江经济技术开发区".Contains(LoginUser.bsO_Name))
                            {
                                items = "地块编号,年度,月份,单位代码,单位,市区,区域,经营现状,是否工业,等级,住所,经营范围,注册时间,企业类型,法人代表,注册资金,主行业,行业细分,规模,规上,企业数,参保人数,就业人数,国税,地税,销售,占地,其中持证,用能,用电,排放,研发经费支出,平均职工人数,固定资产折旧,生产税净额,营业盈余,职工工资总额,税收,增加值,亩均税收";
                            }
                            string saveToPath = excl.ExportListToExcl<vwLtdJcSj>(objs, modelName, items, "yyyy-MM-dd", true, 2, 2, "local");
                            MessageBox.Show("租赁企业文件导出完毕！", "提示", MessageBoxButtons.OK);
                        }
                    }
                    else
                    {
                        MessageBox.Show("请首选选择要导出的数据！", "提示", MessageBoxButtons.OK);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
            finally
            {
                btnExport1.Text = "导出表";
                btnExport1.Enabled = true;

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Text = "导出中...";
            //ExportWTQYXXB(_Wtqyxxbobjs);
            button1.Text = "导出";
        }




        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                TDObject.BLL.Printer.MapPrint.PrintView(this.axMapControl1.ActiveView);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                TDObject.BLL.Printer.MapPrint.PrintView(this.axMapControl1.ActiveView);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                SaveLayerData("企业范围", dgvQyxx);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }




        private void button10_Click(object sender, EventArgs e)
        {

            string DKBH;
            try
            {
                if (Geos.Count == 0)
                {
                    string dkbhs = "";
                    for (int i = 0; i < dgvT2_11.Rows.Count; i++)
                    {
                        object val = dgvT2_11.Rows[i].Cells[0].Value;
                        if (val != null && Convert.ToBoolean(val) == true)
                        {
                            DKBH = dgvT2_11.Rows[i].Cells[2].Value.ToString();
                            //pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);
                            if (DKBH != null && DKBH.Trim() != "")
                            {
                                if (!dkbhs.Contains(DKBH))
                                    dkbhs += "," + DKBH;
                            }
                        }
                    }
                    FindGeos = LayerControl.getIGeoByFields(LoadedLayers["企业范围"], "DKBH", dkbhs, ",", ref newdisp, ref Geos);

                }
                if (Geos.Count > 0)
                    LayerControl.ExDisplayLtdFeature(GlobalVariables.axMapControl, Geos);
                else
                    MessageBox.Show("请首先选择定位企业，然后高亮显示！");

            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void button10_MouseDown(object sender, MouseEventArgs e)
        {
            //如果单击速度太快，则此处执行较长，可能还没完成就触发下一个操作了，所以还是两个按钮
            //ChangeToPositioin("企业范围");
        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="layname"></param>
        ///// <param name="dkbm">逗号分隔的字符串</param>
        //public void HighLightObjs(string layname, string lstdkbm)
        //{
        //    ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, layname);
        //    List<IFeature> FindGeos = new List<IFeature>();
        //    List<IFeature> pGeo = new List<IFeature>();
        //    string[] dkbms = lstdkbm.Split(new char[] { ',' });

        //    foreach (string dkbh in dkbms)
        //    {

        //        pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", dkbh);

        //        if (pGeo.Count > 0)
        //        {
        //            FindGeos.Add(pGeo[0]);
        //        }
        //    }
        //    ExDisplayLtdFeature(FindGeos);
        //}


        private void ExDisplayLtdFeature(List<IFeature> FindGeos)
        {
            //if (flashObjects == null)
            //{
            //    flashObjects = new FlashObjectsClass();
            //}
            flashObjects.MapControl = this.axMapControl1.Object as IMapControl2;
            flashObjects.Init();

            if (FindGeos.Count > 0)
            {
                foreach (IFeature fea in FindGeos)
                    flashObjects.AddGeometry(fea.Shape);
            }

            flashObjects.FlashObjects(0);
        }


        private void dgvT2_11_Click(object sender, EventArgs e)
        {
            //this.axMapControl1.r
            //axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
            //this.axMapControl1_OnMouseDown(null, null);
            SelectDgv = 11;
            string DKBH;
            try
            {
                if (dgvT2_11.CurrentCell == null)
                    return;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_11.CurrentCell.RowIndex >= 0)
                {
                    if (dgvT2_11.Rows[dgvT2_11.CurrentCell.RowIndex].Cells[1].Value != null)
                    {
                        DKBH = dgvT2_11.Rows[dgvT2_11.CurrentCell.RowIndex].Cells[2].Value.ToString();
                        pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                        if (pGeo.Count > 0)
                        {
                            FindGeos.Add(pGeo[0]);
                            ExDisplayLtdFeature(FindGeos);
                        }


                        //处理租赁信息部分
                        this._ltdobjs1 = EM.GetListNoPaging<vwLtdJcSj>("地块编号='" + DKBH + "' and 单位 in (select 纳税人名称 from bsltdinfo where 租赁企业否=1)", "");
                        TDObject.UI.UIDgvColumnsSetting.RefreshLtdImportInfo(dgvT2_12, _ltdobjs1, "vwLtdJcSj", 1);

                        //bool findflag = false;
                        //for (int i = 0; i < dgvT2_12.RowCount; i++)
                        //{
                        //    dgvT2_12.Rows[i].Selected = false;
                        //    if (dgvT2_12.Rows[i].Cells[1].Value != null)
                        //    {
                        //        if (dgvT2_12.Rows[i].Cells[1].Value.ToString() == DKBH)
                        //        {
                        //            dgvT2_12.Rows[i].Selected = true;
                        //            //这是主要的地方。这行后，CurrentRow就是第三行了。
                        //            if (!findflag)
                        //            {
                        //                dgvT2_12.CurrentCell = dgvT2_12.Rows[i].Cells[1];
                        //                findflag = true;
                        //            }//break;
                        //        }
                        //    }
                        //}
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            //this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);



        }





        private void dgvT2_11_DoubleClick(object sender, EventArgs e)
        {
            string DKBH;
            try
            {
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_11.CurrentCell.RowIndex >= 0)
                {

                    DKBH = dgvT2_11.Rows[dgvT2_11.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                    if (pGeo.Count > 0)
                    {
                        LayerControl.ChangeMapExtent(this.axMapControl1, pGeo[0].Extent);

                        int SH = Screen.PrimaryScreen.Bounds.Height;
                        int SW = Screen.PrimaryScreen.Bounds.Width;
                        int WH = this.ClientRectangle.Height;// 工作区域高度
                        int WW = this.ClientRectangle.Width;// 工作区域宽度
                        int leftPanel = scFillExtent.SplitterDistance;
                        int bottompanel = panel6.Height;
                        int x = (WW + leftPanel) / 2 + 50;
                        int y = (WH - bottompanel) / 2 - 50;

                        if (newpop != null)
                        {
                            newpop.Close();

                        }
                        newpop = new frmLtdInfoPop(DKBH, x, y);
                        //newpop.StartPosition = FormStartPosition.CenterScreen;
                        newpop.Show();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDgv != 12)//dgvT2_11.Focused)
                {
                    for (int i = 0; i < dgvT2_11.Rows.Count; i++)
                    {
                        dgvT2_11.Rows[i].Cells[0].Value = true;
                    }
                }
                else if (!dgvT2_12.Focused)
                {
                    for (int i = 0; i < dgvT2_12.Rows.Count; i++)
                    {
                        dgvT2_12.Rows[i].Cells[0].Value = true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                if (SelectDgv != 12)//dgvT2_11.Focused)
                {
                    for (int i = 0; i < dgvT2_11.Rows.Count; i++)
                    {
                        dgvT2_11.Rows[i].Cells[0].Value = null;
                    }
                }
                else if (!dgvT2_12.Focused)
                {
                    for (int i = 0; i < dgvT2_12.Rows.Count; i++)
                    {
                        dgvT2_12.Rows[i].Cells[0].Value = null;
                    }
                }
                this.axMapControl1.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        //单击显示
        private void dgvT2_31_Click(object sender, EventArgs e)
        {
            try
            {
                string DKBH;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "可建设区");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_31.CurrentCell.RowIndex >= 0)
                {

                    DKBH = dgvT2_31.Rows[dgvT2_31.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    pGeo = LayerControl.getIGeoByFields(pLayer, "地块编号", DKBH);

                    if (pGeo.Count > 0)
                    {
                        FindGeos.Add(pGeo[0]);
                    }

                    ExDisplayLtdFeature(FindGeos);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        //双击定位
        private void dgvT2_31_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string DKBH;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "可建设区");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_31.CurrentCell.RowIndex >= 0)
                {

                    DKBH = dgvT2_31.Rows[dgvT2_31.CurrentCell.RowIndex].Cells[0].Value.ToString();
                    pGeo = LayerControl.getIGeoByFields(pLayer, "地块编号", DKBH);

                    if (pGeo.Count > 0)
                    {
                        LayerControl.ChangeMapExtent(this.axMapControl1, pGeo[0].Extent);
                    }


                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void dgvT2_12_Click(object sender, EventArgs e)
        {
            SelectDgv = 12;
            string DKBH;
            try
            {
                if (dgvT2_12.CurrentCell == null)
                    return;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_12.CurrentCell.RowIndex >= 0)
                {
                    if (dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[2].Value != null)
                    {
                        DKBH = dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[2].Value.ToString();
                        pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                        if (pGeo.Count > 0)
                        {
                            FindGeos.Add(pGeo[0]);
                        }

                        ExDisplayLtdFeature(FindGeos);


                        for (int i = 0; i < dgvT2_11.RowCount; i++)
                        {
                            if (dgvT2_11.Rows[i].Cells[2].Value.ToString() == DKBH)
                            {
                                dgvT2_11.Rows[i].Selected = true;
                                //这是主要的地方。这行后，CurrentRow就是第三行了。  
                                dgvT2_11.CurrentCell = dgvT2_11.Rows[i].Cells[2];
                                break;
                            }
                        }


                    }
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }




        }

        private void cboLayerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cboLayerFact.SelectedIndex = cboLayerName.SelectedIndex;
        }






        private void dgvT2_21_Click(object sender, EventArgs e)
        {
            try
            {
                string DKBH;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_21.CurrentCell.RowIndex >= 0)
                {
                    List<tmpLtdXx> objs = EM.GetListNoPaging<tmpLtdXx>("YDQYMC= '" + dgvT2_21.Rows[dgvT2_21.CurrentCell.RowIndex].Cells[2].Value.ToString() + "'", "");
                    if (objs.Count > 0)
                    {
                        DKBH = objs[0].DKBH;
                        pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                        if (pGeo.Count > 0)
                        {
                            FindGeos.Add(pGeo[0]);
                        }

                        ExDisplayLtdFeature(FindGeos);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void dgvT2_21_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                string DKBH;
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_21.CurrentCell.RowIndex >= 0)
                {
                    List<tmpLtdXx> objs = EM.GetListNoPaging<tmpLtdXx>("YDQYMC= '" + dgvT2_21.Rows[dgvT2_21.CurrentCell.RowIndex].Cells[2].Value.ToString() + "'", "");
                    if (objs.Count > 0)
                    {
                        DKBH = objs[0].DKBH;
                        pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                        if (pGeo.Count > 0)
                        {
                            LayerControl.ChangeMapExtent(this.axMapControl1, pGeo[0].Extent);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private bool RefreshExQyxx = false;
        private void dgvQyxx_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            ///企业查处
            //int objid;
            //try
            //{
            //    if (dgvQyxx.Rows.Count == 1)
            //    {
            //        objid = Convert.ToInt32(dgvQyxx.Rows[0].Cells[1].Value);
            //        RefreshLtdCheckInfo(1, objid);
            //    }
            //    else if (dgvQyxx.Rows.Count==0)
            //        RefreshLtdCheckInfo(1, 0);
            // }
            //catch (Exception ex) { log.Error(ex.Message); }

            //租赁企业信息
            //try
            //{
            //    if (dgvQyxx.Rows.Count == 0)
            //    {
            //        RefreshExQyxx = false;
            //    }
            //    else if ((dgvQyxx.Rows.Count == 40 || dgvQyxx.Rows.Count == 2) && !RefreshExQyxx)
            //    {
            //        RefreshExQyxx = true;

            //        string dkbm = dgvQyxx.Rows[1].Cells[1].Value.ToString();
            //        企业范围 ltdinfo=MainForm.EM.GetByPk<企业范围>("DKBH",dkbm);

            //        //应该刷新数据
            //        //this.ucdgvQyxx1.RefreshData(ltdinfo);
            //        BottomPageVisible(4);
            //    }

            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("操作失败！" + ex.Message);
            //}
        }

        private void dgvT2_12_DoubleClick(object sender, EventArgs e)
        {
            string DKBH;
            try
            {
                ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
                List<IFeature> FindGeos = new List<IFeature>();
                List<IFeature> pGeo = new List<IFeature>();
                if (dgvT2_12.CurrentCell.RowIndex >= 0)
                {

                    DKBH = dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[2].Value.ToString();
                    pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", DKBH);

                    if (pGeo.Count > 0)
                    {
                        LayerControl.ChangeMapExtent(this.axMapControl1, pGeo[0].Extent);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }




        private void timer1_Tick(object sender, EventArgs e)
        {
            //if (!tmrEnabled)
            //    return;
            //if (webBrowser1.StatusText == "完成")
            //{
            //    timer1.Enabled = false;
            //    MessageBox.Show(webBrowser1.Document.GetElementById("idForQueryResult").GetAttribute("value"));

            //}

        }

        private void treeView2_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tn = (TreeNode)e.Node;
                string layername = tn.Text;

                LayerControl.SetVisibleStatus(this.axMapControl1, GlobalVariables.LayerName2FullName[tn.Text], tn.Checked);
                if (tn.Text == "城市规划")
                {
                    LayerControl.SetVisibleStatus(this.axMapControl1, GlobalVariables.LayerName2FullName["城市规划注记注记2"], tn.Checked);
                }

                //if (!tn.Checked)
                this.axMapControl1.ActiveView.Refresh();//.axMapControl.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void treeView1_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tnCur = (TreeNode)e.Node;

                foreach (TreeNode tn in tnCur.Nodes)
                {
                    if (tn.Checked != tnCur.Checked)
                        tn.Checked = tnCur.Checked;
                    foreach (TreeNode tn1 in tn.Nodes)
                    {
                        if (tn1.Checked != tnCur.Checked)
                            tn1.Checked = tn.Checked;
                    }
                }

                treeView1_AfterSelect(treeView1, e);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void 数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataImport obj = new frmDataImport();
            qyFormUtil.ShowForm(obj);
        }

        private void 数据导出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDataExport obj = new frmDataExport();
            qyFormUtil.ShowForm(obj);
        }

        private void btnLtnInfo_Move(object sender, EventArgs e)
        {
            try
            {
                ToolTip p = new ToolTip();
                p.ShowAlways = true;
                //p.SetToolTip(btnLtnInfo, "企业信息查询");
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void InfoEditView()
        {
            try
            {
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.enull;

                GlobalVariables.Select.SType = GlobalVariables.SelectType.enull;
                GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.eNull;

                //吴江开发区需要单独显示数据，所以这里要注释掉 zhwsun on 2018-08-28
                //if (!panel1.Visible)
                //{
                //    SetProperViewDisp(!panel1.Visible);
                //}
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 专题图输出1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Drawing.Printing.PrintDocument document = new System.Drawing.Printing.PrintDocument();

                ////initialize the currently printed page number
                //        m_CurrentPrintPage = 0;

                //        //check if a document is loaded into PageLayout	control
                //        if (axPageLayoutControl1.DocumentFilename == null) return;
                //        //set the name of the print preview document to the name of the mxd doc
                //        document.DocumentName = axPageLayoutControl1.DocumentFilename;

                //        //set the PrintPreviewDialog.Document property to the PrintDocument object selected by the user



                //frmMapPreprint obj = new frmMapPreprint(this.axMapControl1);
                //obj.Show();

                //PrintActiveViewParameterized(this.axMapControl1.ActiveView,3);
                TDObject.BLL.Printer.MapPrint.PrintPreView(new PrintPreviewDialog(), this.axMapControl1.ActiveView);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 按企业名统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLtdNameTotal obj = new frmLtdNameTotal(this.axMapControl1.Extent);
                //objfrmLtdNameTotal.axMapControl1.vi = this.axMapControl1.ActiveView;
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 按管理区统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FrmRegionTotal obj = new FrmRegionTotal();
                obj.ShowDialog();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 点击查询警告ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            try
            {
                GlobalVariables.Select.SType = GlobalVariables.SelectType.SingleSelect;
                GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.QueryQyCc;
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.AnQuanJianCha;
                SetCursorForSelect();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }



        private void 安全综合查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmComplexQuery obj = new frmComplexQuery();
                qyFormUtil.ShowForm(obj);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 新增企业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLtdInfoAdd obj = new frmLtdInfoAdd();
                qyFormUtil.ShowForm(obj);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 企业信息修改ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmLtdInfoModi obj = new frmLtdInfoModi();
                qyFormUtil.ShowForm(obj);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

       

        private string GetLtdproblem(GlobalVariables.SelectFeatureValue flag, string dkbm)
        {
            string ret = "";
            if (flag == GlobalVariables.SelectFeatureValue.AnQuanJianCha)
            {
                List<t安全事故情况> objs = MainForm.EM.GetListNoPaging<t安全事故情况>("公司名称 in  (select 纳税人名称 from bsLtdInfo where 地块编号='" + dkbm + "')", "");

                if (objs.Count > 0)
                {
                    int index = 0;
                    foreach (t安全事故情况 obj in objs)
                    {
                        index++;
                        ret += "\r\n" + index.ToString() + "   " + obj.公司名称 + ":" + obj.事故类型;
                    }
                }
                else
                {
                    ret = "没有找到相关数据，可能名称不匹配，请联系管理员核实数据！";
                }
            }
            return ret;
        }

        private void DicLayerDispPnt(string layername, string dkbhField,bool visible)
        {

            GlobalVariables.Select.SType = GlobalVariables.SelectType.SingleSelect;
            GlobalVariables.Select.SOperFun = GlobalVariables.SelectFunGroup.QueryMarkerInfo;
 
            //for (int i = 0; i < dicLayerDisp.Count; i++)
            //{
            //    string key = dicLayerDisp.Keys[i];
            //    if (key == layername)
            //    {
            //        dicLayerDisp[key] = visible;
            //        LayerControl.SetVisibleStatus(this.axMapControl1, layername, dicLayerDisp[layername]);
            //        //企业高亮，然后单击出现图形界面
            //        //LayerControl.SetVisibleStatus(this.axMapControl1, "企业范围", true, "DKBH in (select [SSDKBM]  FROM [wj_GisDb].[sde].[LtdPhoto])");

            //    }
            //}
            IMap pMap = axMapControl1.Map;
            IActiveView pActiveView = pMap as IActiveView;
            IGraphicsContainer pGraphicsContainer = (IGraphicsContainer)pActiveView;
            pGraphicsContainer.DeleteAllElements();
            //pActiveView.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);//刷新
            pActiveView.PartialRefresh(esriViewDrawPhase.esriViewAll, null, null);//刷新

            if (!visible)
            {
                LayerControl.SetVisibleStatus(this.axMapControl1, layername, visible);
                return;
            }

            //下面开始准备单击地图的操作
           
            if (layername == "企业照片点位置") //安全检查点位置 黄牌警告点位置 红牌警告点位置
            {
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.QiYeZhaoPianXinxi;
            }
            else if (layername == "安全检查点位置")
            {
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.AnQuanJianCha;
            }
            else if (layername == "黄牌警告点位置")
            {
                MessageBox.Show("需要提供基础数据！");
                return;
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.HuangPai;
            }
            else if (layername == "红牌警告点位置")
            {
                MessageBox.Show("需要提供基础数据！");
                return;
                GlobalVariables.Select.SValue = GlobalVariables.SelectFeatureValue.HongPai;
            }

            //this.axMapControl1.ActiveView.PartialRefresh(ESRI.ArcGIS.Carto.esriViewDrawPhase.esriViewAll, null, null);

            //////for (int i = 0; i < dicLayerDisp.Count; i++)
            //////{
            //////    string key = dicLayerDisp.Keys[i];
            //////    if (key == layername)
            //////    {
            //////        dicLayerDisp[key] = !dicLayerDisp[key];
            //////        LayerControl.SetVisibleStatus(this.axMapControl1, layername, dicLayerDisp[layername]);
            //////        //企业高亮，然后单击出现图形界面

            //////        //LayerControl.SetVisibleStatus(this.axMapControl1, "企业范围", true, "DKBH in (select [SSDKBM]  FROM [wj_GisDb].[sde].[LtdPhoto])");

            //////    }
            //////}
            //////if (dicLayerDisp[layername] == false)
            //////    return;
            ILayer pLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, "企业范围");
            List<IFeature> FindGeos = new List<IFeature>();
            List<IFeature> pGeo = new List<IFeature>();
            try
            {
                List<bsLtdInfo> disLtds = new List<bsLtdInfo>();
                if (layername == "企业照片点位置")
                {
                    disLtds = MainForm.EM.GetListNoPaging<bsLtdInfo>("纳税人名称 in (select SSQYMC from LtdPhoto)", "");
                }
                else if (layername == "安全检查点位置")
                {
                    disLtds = MainForm.EM.GetListNoPaging<bsLtdInfo>("纳税人名称 in (select 公司名称 from t安全事故情况)", "");
                }
                else if (layername == "红牌警告点位置")
                {
                    //disLtds = MainForm.EM.GetListNoPaging<bsLtdInfo>("纳税人名称 in (select 公司名称 from t安全事故情况)", "");
                }
                else if (layername == "黄牌警告点位置")
                {
                    //disLtds = MainForm.EM.GetListNoPaging<bsLtdInfo>("纳税人名称 in (select 公司名称 from t安全事故情况)", "");
                }
                if (disLtds == null || disLtds.Count == 0)
                {
                    MessageBox.Show("没有找到相关企业！");
                    return;
                }

                LayerControl.SetVisibleStatus(this.axMapControl1, layername, visible);
                ILayer apLayer = GlobalVariables.GetOverviewLayer(this.axMapControl1, layername);
                IFeatureLayer new_FeatureLayer = apLayer as IFeatureLayer;


                //DeleteAllFeatures(apLayer as IFeatureLayer, null);

                string sFilter = "";
                for (int i = 0; i < disLtds.Count; i++)
                {
                    if (disLtds[i].地块编号 != null && disLtds[i].地块编号.Trim() != "")
                    {
                        sFilter += "," + disLtds[i].地块编号.Trim();

                        //自己生成并画点 begin
                        //pGeo = LayerControl.getIGeoByFields(pLayer, "DKBH", disLtds[i].地块编号.Trim());

                        //if (pGeo.Count > 0)
                        //{
                        //    FindGeos.Add(pGeo[0]);

                        //    double x, y;
                        //    x = (pGeo[0].Extent.XMin + pGeo[0].Extent.XMax) / 2;
                        //    y = (pGeo[0].Extent.YMin + pGeo[0].Extent.YMax) / 2;
                        //    IPoint pt1 = new PointClass();
                        //    pt1.PutCoords(x, y);

                        //    CreateShpFromPoint(axMapControl1, layername, pt1, dkbhField, disLtds[i].地块编号.Trim());
                        //    //GlobalVariables.CreateTextElment(axMapControl1, x, y, GetLtdproblem(GlobalVariables.Select.SValue, disLtds[i].地块编号.Trim()));
                        //}
                        //自己生成并画点 end

                    }
                }
                ESRI.ArcGIS.Carto.IFeatureLayerDefinition pDef = (ESRI.ArcGIS.Carto.IFeatureLayerDefinition)new_FeatureLayer;
                pDef.DefinitionExpression = "DKBH in ('"+sFilter.Substring(1).Replace(",","','")+"')";
                axMapControl1.ActiveView.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到数据！");
            }
            //if (FindGeos.Count == 0)
            //    MessageBox.Show("没有找到对应的用地数据！");
            //else
            //    ExDisplayLtdFeature(FindGeos);

            LayerControl.SetVisibleStatus(this.axMapControl1, GlobalVariables.LayerName2FullName[layername], true);

            this.axToolbarControl1.CurrentTool = null;
            this.axMapControl1.MousePointer = ESRI.ArcGIS.Controls.esriControlsMousePointer.esriPointerArrow;


        }

        private void CreateShpFromPoint(AxMapControl axmc, string layername, IPoint point, string dkbmfield, string dkbm)
        {
            //string strPath = "E:\\Pointlayer2" as string;

            ////根据路径创建图层
            //IWorkspace pWorkspace = OpenWorkspace(strPath);
            //IFeatureClass pFeatureClass;
            //pFeatureClass = CreateFeatureClass(pWorkspace, esriGeometryType.esriGeometryPoint, "PPoint", 1);
            //IFeatureLayer pFLayer = new FeatureLayerClass();
            //pFLayer.FeatureClass = pFeatureClass;
            //pFLayer.Name = pFeatureClass.AliasName;

            ILayer iLayer = GlobalVariables.GetOverviewLayer(axmc, layername);
            IFeatureLayer fFLayer = iLayer as IFeatureLayer;
            ////开始编辑图层
            //IDataset pDataset = (IDataset)pFeatureClass;
            //IWorkspaceEdit pWorkspaceEdit = (IWorkspaceEdit)pDataset.Workspace;
            //pWorkspaceEdit.StartEditing(false);
            //pWorkspaceEdit.StartEditOperation();

            //需添加的两个点
            //IPoint pt1 = new PointClass();
            //pt1.PutCoords(100, 100);
            //IPoint pt2 = new PointClass();
            //pt2.PutCoords(200, 200);

            IFeature pFeature = fFLayer.FeatureClass.CreateFeature();
            //找到属性"Attribute"的字段序号
            //string strName = dkbmfield;
            int intIndex = pFeature.Fields.FindField(dkbmfield);


            //添加第一条数据记录
            //pFeature = pFLayer.FeatureClass.CreateFeature();
            pFeature.Shape = point as IGeometry;
            pFeature.set_Value(intIndex, dkbm);
            pFeature.Store();





            ////停止编辑
            //pWorkspaceEdit.StopEditOperation();
            //pWorkspaceEdit.StopEditing(true);

            //显示图层
            // ax.AddLayer(pFLayer, m_mapControl.Map.LayerCount);
            axmc.ActiveView.PartialRefresh(esriViewDrawPhase.esriViewGeography, null, null);

            //ISpatialReference pSpatialReference = axmc.ActiveView.FocusMap.SpatialReference;

            //string strShapeFolder = "C:/";
            //string strShapeFile = "test.shp";

            //string shapeFileFullName = strShapeFolder + strShapeFile;
            //IWorkspaceFactory pWorkspaceFactory = new ShapefileWorkspaceFactory();
            //IFeatureWorkspace pFeatureWorkspace = (IFeatureWorkspace)pWorkspaceFactory.OpenFromFile(strShapeFolder, 0);
            //IFeatureClass pFeatureClass;
            //if (File.Exists(shapeFileFullName))
            //{
            //    pFeatureClass = pFeatureWorkspace.OpenFeatureClass(strShapeFile);
            //    IDataset pDataset = (IDataset)pFeatureClass;
            //    pDataset.Delete();
            //}

            //IFields pFields = new FieldsClass();
            //IFieldsEdit pFieldsEdit = (IFieldsEdit)pFields;

            //IField pField = new FieldClass();
            //IFieldEdit pFieldEdit = (IFieldEdit)pField;

            //pFieldEdit.Name_2 = "SHAPE";
            //pFieldEdit.Type_2 = esriFieldType.esriFieldTypeGeometry;

            //IGeometryDefEdit pGeoDef = new GeometryDefClass();
            //IGeometryDefEdit pGeoDefEdit = (IGeometryDefEdit)pGeoDef;
            //pGeoDefEdit.GeometryType_2 = esriGeometryType.esriGeometryPoint;
            //pGeoDefEdit.SpatialReference_2 = pSpatialReference; //new UnknownCoordinateSystemClass();
            //pFieldEdit.GeometryDef_2 = pGeoDef;
            //pFieldsEdit.AddField(pField);

            //pField = new FieldClass();
            //pFieldEdit = (IFieldEdit)pField;
            //pFieldEdit.Name_2 = "ID";
            //pFieldEdit.Type_2 = esriFieldType.esriFieldTypeString;
            //pFieldsEdit.AddField(pField);

            //pField = new FieldClass();
            //pFieldEdit = (IFieldEdit)pField;
            //pFieldEdit.Name_2 = "Pixels";
            //pFieldEdit.Type_2 = esriFieldType.esriFieldTypeInteger;
            //pFieldsEdit.AddField(pField);

            //pFeatureClass = pFeatureWorkspace.CreateFeatureClass(strShapeFile, pFields, null, null, esriFeatureType.esriFTSimple, "SHAPE", "");
            //IPoint pPoint = new PointClass();
            //pPoint.X = 113.0;
            //pPoint.Y = 23.0;
            //IFeature pFeature = pFeatureClass.CreateFeature();
            //pFeature.Shape = pPoint;
            //pFeature.set_Value(pFeature.Fields.FindField("ID"), "D-1");
            //pFeature.set_Value(pFeature.Fields.FindField("Pixels"), 1);
            //pFeature.Store();

            //IFeatureLayer pFeaturelayer = new FeatureLayerClass();
            //pFeaturelayer.FeatureClass = pFeatureClass;
            //pFeaturelayer.Name = "layer";

            //axmc.AddLayer(pFeaturelayer);

        }
        private void DeleteAllFeatures(IFeatureLayer pLayer, IQueryFilter queryFilter)
        {
            ITable pTable = pLayer.FeatureClass as ITable;
            pTable.DeleteSearchedRows(queryFilter);
        }
        private void getCenterPnt(Polygon ploygon, out double x, out double y)
        {
            double xs = 0, ys = 0;
            xs = 0; ys = 0;
            for (int i = 0; i < ploygon.PointCount; i++)
            {
                xs += ploygon.Point[i].X;
                ys += ploygon.Point[i].Y;

            }
            x = xs / ploygon.PointCount;
            y = ys / ploygon.PointCount;

        }

        private void button11_Click(object sender, EventArgs e)
        {
            try
            {
                int ltdobjid = Convert.ToInt32(dgvQyxx.Rows[0].Cells[1].Value);
                frmAlarmQuery obj = new frmAlarmQuery(ltdobjid);
                qyFormUtil.ShowForm(obj);
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                //int ltdobjid = Convert.ToInt32(dgvQyxx.Rows[0].Cells[1].Value);
                //FrmLtdZlqyxxNew obj = new FrmLtdZlqyxxNew(ltdobjid);
                //obj.Show();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                TreeNode tnCur = (TreeNode)e.Node;

                string strNodeCode = "";
                string strXZqCode = "";
                if (tnCur.Checked)
                {
                    strXZqCode = treeView1.Nodes[0].Tag.ToString();
                }

                foreach (TreeNode tn in treeView1.Nodes[0].Nodes)
                {
                    try
                    {
                        if (tn.Checked && tn.Tag != null)
                            strNodeCode += ",'" + tn.Tag.ToString() + "'";
                    }
                    catch { }
                    if (tn.Nodes.Count > 0)
                    {

                        foreach (TreeNode tn1 in tn.Nodes)
                        {
                            try
                            {
                                if (tn1.Checked && tn1.Tag != null)
                                    strNodeCode += ",'" + tn1.Tag.ToString() + "'";
                            }
                            catch { }
                        }
                    }
                }
                if (strNodeCode.Length > 0)
                {
                    strNodeCode = strNodeCode.Substring(1);
                }
                else
                {
                    strNodeCode = "''";
                }
                RefreshMapWithRegion("(" + strNodeCode + ")", "(" + strXZqCode + ")");

                //////控制显示

                GlobalVariables.axMapControl.Extent = GlobalVariables.axMapControl.FullExtent;
                IGraphicsContainer pGra = axMapControl2.Map as IGraphicsContainer;
                IActiveView pAv = pGra as IActiveView;

                //// 刷新鹰眼
                //pAv.PartialRefresh(esriViewDrawPhase.esriViewGraphics, null, null);
                //GlobalVariables.axMapControlEagle.Extent = GlobalVariables.axMapControlEagle.FullExtent;

                GlobalVariables.axMapControl.ActiveView.Refresh();
                //GlobalVariables.axMapControl.Refresh();
                //axMapControl2.Refresh();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 按行业类型统计ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTotalHY obj = new frmTotalHY();
                obj.Show();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }


        private void 统计筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTotalFilterNew obj = new frmTotalFilterNew();
                obj.Show();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 详细信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string dkbm = dgvT2_11.Rows[dgvT2_11.CurrentCell.RowIndex].Cells[2].Value.ToString();
                if (dkbm != null && dkbm != "")
                {
                    FrmOneLtdAndRentLtdInfo obj = new FrmOneLtdAndRentLtdInfo(dkbm);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void axToolbarControl1_OnMouseDown(object sender, IToolbarControlEvents_OnMouseDownEvent e)
        {

        }

        private void 分类筛选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                frmTypeFilterNew obj = new frmTypeFilterNew();
                obj.Show();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        /// <summary>
        /// 从租赁企业处
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                string dkbm = dgvT2_12.Rows[dgvT2_12.CurrentCell.RowIndex].Cells[2].Value.ToString();
                if (dkbm != null && dkbm != "")
                {
                    FrmOneLtdAndRentLtdInfo obj = new FrmOneLtdAndRentLtdInfo(dkbm);
                    obj.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

        private void 吴江区工业企业资源集约利用情况上报ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmUpReport1 obj = new FrmUpReport1();
            obj.ShowDialog();
        }

        private void 分项数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmTypeImport obj = new FrmTypeImport();
            qyFormUtil.ShowForm(obj);
        }

        public void ChangeMapExtent(IGeometry pGeo)
        {
            if (pGeo != null)
            {
                try
                {
                    this.axMapControl1.FullExtent = pGeo.Envelope;
                    this.axMapControl1.Refresh();

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message);
                }
            }
        }

        private void AddMardkerText(IFeature pFeature)
        {
            IGeometry geometry = pFeature.Shape;
            var x = (geometry.Envelope.XMin + geometry.Envelope.XMax) / 2;
            var y = (geometry.Envelope.YMin + geometry.Envelope.YMax) / 2;

            IPoint point = new PointClass();
            point.PutCoords(x, y);
            IGeometry pntgeometry = point as IGeometry;

            IRgbColor color = new RgbColor();
            color.Red = 0;
            color.Blue = 255;
            color.Green = 0;
            ITextSymbol txtSystem = new TextSymbolClass();
            txtSystem.Color = color;
            txtSystem.Size = 250;
            object symbol = txtSystem;
            this.axMapControl1.DrawText(geometry, "我们都有一个家", ref symbol);

            //object missing =Type.Missing ;
            //IActiveView pActiveView = axMapControl1.ActiveView  as IActiveView ;

            //  IElement pElement = GetPicture(pOpenFileDialog.FileName);
            // IPictureElement pPictureElement;
            //  if( pElement is IPictureElement ){
            //    pPictureElement = pElement as IPictureElement ;
            //    pPictureElement.MaintainAspectRatio =false;
            //    pPictureElement.SavePictureInDocument =true;
            //  }

            ////图片的大小和显示位置可以通过修改pEnv的坐标来自己决定
            //IEnvelope pEnv = new EnvelopeClass ();
            ////pEnv.PutCoords(....)
            //pEnv = axMapControl1.ActiveView.Extent  ;

            //  pElement.Geometry =pEnv as IGeometry ;
            //  axMapControl1.ActiveView.GraphicsContainer.AddElement(pElement,0);
            //  //axMapControl1.CtlRefresh(esriViewDrawPhase.esriViewBackground ,missing,missing);
        }

        private void AddSelfMarker(IFeature pFeature)
        {
            //    IElement pElement = null;
            //    IGeometry geometry = pFeature.Shape;
            //    switch (geometry.GeometryType)
            //    {
            //        case esriGeometryType.esriGeometryPolygon:
            //            var x = (geometry.Envelope.XMin + geometry.Envelope.XMax) / 2;
            //            var y = (geometry.Envelope.YMin + geometry.Envelope.YMax) / 2;

            //            axMapControl1.AddElement(pElement, 0);
            //            IFillShapeElement pPolygonElement = new PolygonElementClass();
            //            pPolygonElement.Symbol = pFillSymbol;// 面符号
            //            pElement = pPolygonElement as IElement;
            //            pElement.Geometry = geometry;
            //             break;
            //        case esriGeometryType.esriGeometryPolyline:
            //            ILineElement pLineElement = new LineElementClass();
            //            pLineElement.Symbol = pLineSymbol;// 线符号
            //            pElement = pLineElement as IElement;
            //            pElement.Geometry = geometry;
            //            break;
            //        case esriGeometryType.esriGeometryPoint:
            //            IMarkerElement pMarkerElement = new MarkerElementClass();
            //            pMarkerElement.Symbol = pMarkerSymbol;// 点符号
            //            pElement = pMarkerElement as IElement;
            //            pElement.Geometry = pFeature.Shape;
            //            break;
            //} 
            //axMapControl1.ActiveView.GraphicsContainer.AddElement(pElement, 0);// 添加 pElement
        }

        private void excel数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 基础数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcelImportYM obj = new frmExcelImportYM("月度");
            obj.ShowDialog();
        }

        private void 其它数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcelImportYM obj = new frmExcelImportYM("一般");
            obj.ShowDialog();
        }

        private void 基础信息维护ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmbsLtdInfo obj = new frmbsLtdInfo();
            obj.Show();
        }

        private void 年度数据导入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmExcelImportYM obj = new frmExcelImportYM("年度");
            obj.ShowDialog();
        }

        private void tsbLtd_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                ToolStripButton tsb = sender as ToolStripButton;
                 if ("企,房,城".Contains(tsb.Text))
                {
                    LayerAttrQueryStart(tsb.Tag.ToString(), tsb.Checked);
                }
                else if ("黄,红,检,照".Contains(tsb.Text))
                {

                    DicLayerDispPnt(tsb.Tag.ToString(), "DKBH",tsb.Checked);

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }

        }

        //清除其它操作
        private void tspControl(ToolStripButton tsb)
        {
            tsb.Checked = !tsb.Checked;
            //tsbLtd.Checked = tsbLtd.Checked ? false : false;
            //tsbFang.Checked = tsbLtd.Checked ? false : false;
            //tsbCheng.Checked = tsbLtd.Checked ? false : false;


            //tsbRed.Checked = tsbLtd.Checked ? false : false;
            //tsbYellow.Checked = tsbLtd.Checked ? false : false;
            //tsbCheck.Checked = tsbLtd.Checked ? false : false;
            //tsbPhoto.Checked = tsbLtd.Checked ? false : false;
        }

        private void tsbFang_Click(object sender, EventArgs e)
        {
            ToolStripButton tsb = sender as ToolStripButton;
            tspControl(tsb);

        }
    }


    public class keyvalue
    {
        public keyvalue(string k, string v)
        {
            key = k;
            value = v;
        }
        public string key { get; set; }
        public string value { get; set; }
    }

       
}