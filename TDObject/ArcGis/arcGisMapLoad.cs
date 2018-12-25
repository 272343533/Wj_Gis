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

using System.Xml.Linq;



namespace QyTech.ArcGis
{
    public struct arcGisLoadStruct
    {
        public IWorkspace Workspace;
        public AxMapControl MapContorl;
        public IFeatureWorkspace FeatureWorkspace;
    }

    public delegate XElement delegateLoadLayer(string obj);
    public delegate List<XElement> delegateLoadLayerWithSP(string ws,string layname);  



  
    public class arcGisMap
    {
        log4net.ILog log = log4net.LogManager.GetLogger("MainForm");


        public void SaveDocument(AxMapControl axMapControl1,string filename)
        {
            try
            {
                //判断pMapDocument是否为空，  
                //获取pMapDocument对象  
                IMxdContents pMxdC;
                pMxdC = axMapControl1.Map as IMxdContents;
                IMapDocument pMapDocument = new MapDocumentClass();
                //获取保存路径  
                pMapDocument.New(filename);
                //  
                pMapDocument.ReplaceContents(pMxdC);
                //保存地图文档  
                pMapDocument.Save(true, true);
                MessageBox.Show("地图文档保存成功!");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  
      
        public IWorkspace GetSdeWorkSpace()
        {
            Conection c = new Conection();
            string SqlCon = string.Empty;
            try
            {
                SqlCon = c.GetConnectionString("sdeServer");
            }
            catch
            {
                log.Error("地图加载错误，请与程序供应商联系，检查服务器连接设置!");
            }
            if (SqlCon == string.Empty)
            {
                log.Error("地图加载错误，请与程序供应商联系，检查服务器连接!");
            }

            string[] strs = SqlCon.Split(new char[] { '=', ';' });

            log.Info("600:");
            //开始连接sde数据库
            IWorkspace Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
            log.Info("700:");
            return Workspace;
          
        }

       //public void LoadMap(object obj)
       //{
       //    arcGisLoadStruct agls=(arcGisLoadStruct)obj;
       //    AxMapControl mapc1 = agls.MapContorl;
       //    IWorkspace WorkSpace=agls.Workspace;
       //    IFeatureWorkspace featureWorkspace = agls.FeatureWorkspace;
       //    log.Info("500:");
       //    string s = "sde.行政区";
      
       //    //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
       //   // GlobalVariables.addLayer = addLayerToMap(WorkSpace,featureWorkspace, "sde.行政区");

       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //     log.Info("1020:" + s);
       //    try
       //    {
       //        //GlobalVariables.axMapControl.ClearLayers();
       //        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //        log.Info("1040:" + s);
       //        IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //        log.Info("1050:" + s);
       //        IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //        log.Info("1060:" + s);
       //        IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //        string LastFeatureName = String.Empty;
       //        log.Info("1080:" + s);

       //        while (m_FeatureClass != null)
       //        {
       //            log.Info("1090:" + m_FeatureClass.AliasName);

       //            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //            LastFeatureName += m_FeatureClass.AliasName;
       //            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //            m_FeatureLayer.FeatureClass = m_FeatureClass;
       //            m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //            m_FeatureLayer.Selectable = false;

       //            log.Info("1100:" + m_FeatureClass.AliasName);
       //            GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //            log.Info("1200:" + m_FeatureClass.AliasName);
       //            //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //            GlobalVariables.SymbolLayer(m_FeatureLayer);

       //            log.Info("1500:" + m_FeatureClass.AliasName);
       //            m_FeatureClass = enumFeatureClass.Next();
       //        }

       //        log.Info("1600:");
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("程序报错，请重新加载或启动。(" + ex.Message + ")");
       //        return ;

       //    }


       //    log.Info("2400:");
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    //控制显示
       //    mapc1.Extent = mapc1.FullExtent;


       //    TDObject.MainForm.LoadFinished = true;

       //    mapc1.Refresh();

       //    return;

       //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="WorkSpace"></param>
        /// <param name="featureWorkspace"></param>
        /// <param name="s">要素集</param>
        /// <returns></returns>
       //public bool addLayerToMap(IWorkspace WorkSpace,IFeatureWorkspace featureWorkspace, string s)
       //{
       //    //sde 工作空间，编辑模式用
       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals( s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>( s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //     log.Info("1020:" + s);
       //        try
       //        {
       //            //GlobalVariables.axMapControl.ClearLayers();
       //            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //            log.Info("1040:" + s);
       //            IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //            log.Info("1050:" + s);
       //            IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //            log.Info("1060:" + s);
       //            IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //            string LastFeatureName = String.Empty;
       //            log.Info("1080:" + s);

       //            while (m_FeatureClass != null)
       //            {
       //                log.Info("1090:" + m_FeatureClass.AliasName);

       //                //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //                LastFeatureName += m_FeatureClass.AliasName;
       //                IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //                m_FeatureLayer.FeatureClass = m_FeatureClass;
       //                m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //                m_FeatureLayer.Selectable = false;

       //                log.Info("1100:" + m_FeatureClass.AliasName);
       //                GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //                log.Info("1200:" + m_FeatureClass.AliasName);
       //                //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //                GlobalVariables.SymbolLayer(m_FeatureLayer);

       //                log.Info("1500:" + m_FeatureClass.AliasName);
       //                m_FeatureClass = enumFeatureClass.Next();
       //            }

       //            log.Info("1600:");
       //        }
       //        catch (Exception ex)
       //        {
       //            MessageBox.Show("程序报错，请重新加载或启动。(" + ex.Message + ")");
       //            return false;

       //        }

         
       //    log.Info("2400:");
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    return true;
       //}

       //public bool addLayerToAxMapControl(IFeatureWorkspace featureWorkspace, string[] FeatureDatasetStr, string LayerName)
       //{
       //    log.Info("1000");

         
       //    foreach (string s in FeatureDatasetStr)
       //    {
       //        log.Info("1010:" + s);

       //        //sde 工作空间，编辑模式用
       //        if (GlobalVariables.sdeWorkspace != null)
       //        {
       //            if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //            {
       //                KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, MainForm.Workspace as IWorkspaceEdit);
       //                GlobalVariables.sdeWorkspace.Add(item);
       //            }
       //        }
       //        log.Info("1020:" + s);
       //        try
       //        {
       //            //GlobalVariables.axMapControl.ClearLayers();
       //            IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //            log.Info("1040:" + s);
       //            IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //            log.Info("1050:" + s);
       //            IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //            log.Info("1060:" + s);
       //            IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //            string LastFeatureName = String.Empty;
       //            log.Info("1080:" + s);

       //            while (m_FeatureClass != null)
       //            {
       //                log.Info("1090:" + m_FeatureClass.AliasName);

       //                //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //                LastFeatureName += m_FeatureClass.AliasName;
       //                IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //                m_FeatureLayer.FeatureClass = m_FeatureClass;
       //                m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //                m_FeatureLayer.Selectable = false;

       //                log.Info("1100:" + m_FeatureClass.AliasName);
       //                GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //                log.Info("1200:" + m_FeatureClass.AliasName);
       //                //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //                GlobalVariables.SymbolLayer(m_FeatureLayer);

       //                log.Info("1500:" + m_FeatureClass.AliasName);
       //                m_FeatureClass = enumFeatureClass.Next();
       //            }

       //            log.Info("1600:");
       //        }
       //        catch (Exception ex)
       //        {
       //            MessageBox.Show("程序报错，请重新加载或启动。(" + ex.Message + ")");
       //            return false;

       //        }


       //    }
       //    log.Info("2400:");
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    return true;
       //}

       //public string LoadMapLayer(object obj)
       //{

       //    List<IFeatureLayer> layers = new List<IFeatureLayer>();

       //    IWorkspace WorkSpace = null;
       //    IPropertySet pPropSet = new PropertySetClass();

       //    IFeatureWorkspace featureWorkspace;
          
       //    Conection c = new Conection();
       //    string SqlCon = string.Empty;
       //    try
       //    {
       //        SqlCon = c.GetConnectionString("sdeServer");
       //    }
       //    catch
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接设置!");
       //    }
       //    if (SqlCon == string.Empty)
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接!");
       //    }

       //    string[] strs = SqlCon.Split(new char[] { '=', ';' });

       //    log.Info("600:");
       //    //开始连接sde数据库
       //    //IWorkspace Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
       //    ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
       //     //使用sde的工作空间工厂
       //    IWorkspaceFactory pSdeFact = new SdeWorkspaceFactoryClass();
       //    pPropSet.SetProperty("SERVER", strs[1]);
       //    pPropSet.SetProperty("INSTANCE", strs[3]);//实例化端口
       //    pPropSet.SetProperty("USER", strs[5]);//SDE 用户名
       //    pPropSet.SetProperty("password", strs[7]);//密码
       //    pPropSet.SetProperty("DATABASE", strs[9]);
       //    pPropSet.SetProperty("version", strs[11]);//连接版本

       //    try
       //    {
       //        WorkSpace = pSdeFact.Open(pPropSet, 0);
       //    }
       //    catch (Exception ex)
       //    {
       //         log.Error(ex.Message);
       //         MessageBox.Show("SDE链接失败！请检查sde服务是否开启及连接配置是否正确", "信息提示");

       //    }
       //    log.Info("500:");
       //    string s = "sde.行政区";

       //    featureWorkspace = WorkSpace as IFeatureWorkspace;
       //    //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
       //    // GlobalVariables.addLayer = addLayerToMap(WorkSpace,featureWorkspace, "sde.行政区");

       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //    log.Info("1020:" + s);
       //    try
       //    {
       //        //GlobalVariables.axMapControl.ClearLayers();
       //        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //        log.Info("1040:" + s);
       //        IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //        log.Info("1050:" + s);
       //        IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //        log.Info("1060:" + s);
       //        IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //        string LastFeatureName = String.Empty;
       //        log.Info("1080:" + s);

       //        while (m_FeatureClass != null)
       //        {
       //            log.Info("1090:" + m_FeatureClass.AliasName);

       //            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //            LastFeatureName += m_FeatureClass.AliasName;
       //            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //            m_FeatureLayer.FeatureClass = m_FeatureClass;
       //            m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //            m_FeatureLayer.Selectable = false;

       //            log.Info("1100:" + m_FeatureClass.AliasName);
       //            GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //            layers.Add(m_FeatureLayer);
       //            log.Info("1200:" + m_FeatureClass.AliasName);
       //            //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //           // GlobalVariables.SymbolLayer(m_FeatureLayer);


       //            log.Info("1500:" + m_FeatureClass.AliasName);
       //            m_FeatureClass = enumFeatureClass.Next();
       //        }

       //        log.Info("1600:");
       //    }
       //    catch (Exception ex)
       //    {
       //       return "程序报错，请重新加载或启动。(" + ex.Message + ")";

       //    }


       //    log.Info("2400:");
       //    string json = JsonHelper.SerializeObject<IFeatureLayer>(layers);
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    return json;

       //}

       //public void LoadMapLayerToMap(object obj)
       //{

       //    AxMapControl map = new AxMapControl();// obj as AxMapControl;
       //    List<IFeatureLayer> layers = new List<IFeatureLayer>();

       //    IWorkspace WorkSpace = null;
       //    IPropertySet pPropSet = new PropertySetClass();

       //    IFeatureWorkspace featureWorkspace;

       //    Conection c = new Conection();
       //    string SqlCon = string.Empty;
       //    try
       //    {
       //        SqlCon = c.GetConnectionString("sdeServer");
       //    }
       //    catch
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接设置!");
       //    }
       //    if (SqlCon == string.Empty)
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接!");
       //    }

       //    string[] strs = SqlCon.Split(new char[] { '=', ';' });

       //    log.Info("600:");
       //    //开始连接sde数据库
       //    //IWorkspace Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
       //    ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
       //    //使用sde的工作空间工厂
       //    IWorkspaceFactory pSdeFact = new SdeWorkspaceFactoryClass();
       //    pPropSet.SetProperty("SERVER", strs[1]);
       //    pPropSet.SetProperty("INSTANCE", strs[3]);//实例化端口
       //    pPropSet.SetProperty("USER", strs[5]);//SDE 用户名
       //    pPropSet.SetProperty("password", strs[7]);//密码
       //    pPropSet.SetProperty("DATABASE", strs[9]);
       //    pPropSet.SetProperty("version", strs[11]);//连接版本

       //    try
       //    {
       //        WorkSpace = pSdeFact.Open(pPropSet, 0);
       //    }
       //    catch (Exception ex)
       //    {
       //         log.Error(ex.Message);
       //         MessageBox.Show("SDE链接失败！请检查sde服务是否开启及连接配置是否正确", "信息提示");

       //    }
       //    log.Info("500:");
       //    string s = "sde.行政区";

       //    featureWorkspace = WorkSpace as IFeatureWorkspace;
       //    //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
       //    // GlobalVariables.addLayer = addLayerToMap(WorkSpace,featureWorkspace, "sde.行政区");

       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //    log.Info("1020:" + s);
       //    try
       //    {
       //        //GlobalVariables.axMapControl.ClearLayers();
       //        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //        log.Info("1040:" + s);
       //        IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //        log.Info("1050:" + s);
       //        IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //        log.Info("1060:" + s);
       //        IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //        string LastFeatureName = String.Empty;
       //        log.Info("1080:" + s);

       //        while (m_FeatureClass != null)
       //        {
       //            log.Info("1090:" + m_FeatureClass.AliasName);

       //            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //            LastFeatureName += m_FeatureClass.AliasName;
       //            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //            m_FeatureLayer.FeatureClass = m_FeatureClass;
       //            m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //            m_FeatureLayer.Selectable = false;

       //            log.Info("1100:" + m_FeatureClass.AliasName);
       //            //GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //            map.AddLayer(m_FeatureLayer);
       //            layers.Add(m_FeatureLayer);
       //            log.Info("1200:" + m_FeatureClass.AliasName);
       //            //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //           // GlobalVariables.SymbolLayer(m_FeatureLayer);


       //            log.Info("1500:" + m_FeatureClass.AliasName);
       //            m_FeatureClass = enumFeatureClass.Next();
       //        }

       //        log.Info("1600:");
       //    }
       //    catch (Exception ex)
       //    {
       //         log.Error(ex.Message);
       //         return;// "程序报错，请重新加载或启动。(" + ex.Message + ")";

       //    }


       //    log.Info("2400:");
       //    string json = JsonHelper.SerializeObject<IFeatureLayer>(layers);
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    return;// json;

       //}

       //public string LoadMapLayerForTimer(string layername)
       //{

       //    List<IFeatureLayer> layers = new List<IFeatureLayer>();

       //    IWorkspace WorkSpace = null;
       //    IPropertySet pPropSet = new PropertySetClass();

       //    IFeatureWorkspace featureWorkspace;

       //    Conection c = new Conection();
       //    string SqlCon = string.Empty;
       //    try
       //    {
       //        SqlCon = c.GetConnectionString("sdeServer");
       //    }
       //    catch
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接设置!");
       //    }
       //    if (SqlCon == string.Empty)
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接!");
       //    }

       //    string[] strs = SqlCon.Split(new char[] { '=', ';' });

       //    log.Info("600:");
       //    //开始连接sde数据库
       //    //IWorkspace Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
       //    ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
       //    //使用sde的工作空间工厂
       //    IWorkspaceFactory pSdeFact = new SdeWorkspaceFactoryClass();
       //    pPropSet.SetProperty("SERVER", strs[1]);
       //    pPropSet.SetProperty("INSTANCE", strs[3]);//实例化端口
       //    pPropSet.SetProperty("USER", strs[5]);//SDE 用户名
       //    pPropSet.SetProperty("password", strs[7]);//密码
       //    pPropSet.SetProperty("DATABASE", strs[9]);
       //    pPropSet.SetProperty("version", strs[11]);//连接版本

       //    try
       //    {
       //        WorkSpace = pSdeFact.Open(pPropSet, 0);
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("SDE链接失败！请检查sde服务是否开启及连接配置是否正确", "信息提示");

       //    }
       //    log.Info("500:");
       //    string s = layername;

       //    featureWorkspace = WorkSpace as IFeatureWorkspace;
       //    //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
       //    // GlobalVariables.addLayer = addLayerToMap(WorkSpace,featureWorkspace, "sde.行政区");

       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //    log.Info("1020:" + s);
       //    try
       //    {
       //        //GlobalVariables.axMapControl.ClearLayers();
       //        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //        log.Info("1040:" + s);
       //        IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //        log.Info("1050:" + s);
       //        IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //        log.Info("1060:" + s);
       //        IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //        string LastFeatureName = String.Empty;
       //        log.Info("1080:" + s);

       //        while (m_FeatureClass != null)
       //        {
       //            log.Info("1090:" + m_FeatureClass.AliasName);

       //            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //            LastFeatureName += m_FeatureClass.AliasName;
       //            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //            m_FeatureLayer.FeatureClass = m_FeatureClass;
       //            m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //            m_FeatureLayer.Selectable = false;

       //            log.Info("1100:" + m_FeatureClass.AliasName);
       //            GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
       //            layers.Add(m_FeatureLayer);
       //            log.Info("1200:" + m_FeatureClass.AliasName);
       //            //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //            GlobalVariables.SymbolLayer(m_FeatureLayer);


       //            log.Info("1500:" + m_FeatureClass.AliasName);
       //            m_FeatureClass = enumFeatureClass.Next();
       //        }

       //        log.Info("1600:");
       //    }
       //    catch (Exception ex)
       //    {
       //        return "程序报错，请重新加载或启动。(" + ex.Message + ")";

       //    }


       //    log.Info("2400:");
       //    string json = JsonHelper.SerializeObject<IFeatureLayer>(layers);
       //    GlobalVariables.axMapControl.ActiveView.Refresh();
       //    log.Info("2500:");

       //    return json;

       //}

       //public XElement LoadMapLayer1(string obj)
       //{

       //    List<IFeatureLayer> layers = new List<IFeatureLayer>();
       //    XElement el = null;
       //    IWorkspace WorkSpace = null;
       //    //IPropertySet pPropSet = JsonHelper.DeserializeJsonToObject<IPropertySet>(obj);
       //    //object obj1= esriSerializerHelper.esriDeserializer(obj.ToString());

       //    IXMLSerializer xmlSerializer = new XMLSerializerClass();
       //    xmlSerializer.LoadFromString(obj, null, null);

       //    //IPropertySet pPropSet = (IPropertySet)esriSerializerHelper.esriDeserializer(obj.ToString());
       //    IPropertySet pPropSet = (IPropertySet)xmlSerializer.LoadFromString(obj, null, null);
       //    IFeatureWorkspace featureWorkspace;

       //    Conection c = new Conection();
       //    string SqlCon = string.Empty;
       //    try
       //    {
       //        SqlCon = c.GetConnectionString("sdeServer");
       //    }
       //    catch
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接设置!");
       //    }
       //    if (SqlCon == string.Empty)
       //    {
       //        log.Error("地图加载错误，请与程序供应商联系，检查服务器连接!");
       //    }

       //    string[] strs = SqlCon.Split(new char[] { '=', ';' });

       //    log.Info("600:");
       //    //开始连接sde数据库
       //    //IWorkspace Workspace = MapLoad.OpenSDEWorkspace(strs[1], strs[3], strs[5], strs[7], strs[9], strs[11]);
       //    ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
       //    //使用sde的工作空间工厂
       //    IWorkspaceFactory pSdeFact = new SdeWorkspaceFactoryClass();
       //    pPropSet.SetProperty("SERVER", strs[1]);
       //    pPropSet.SetProperty("INSTANCE", strs[3]);//实例化端口
       //    pPropSet.SetProperty("USER", strs[5]);//SDE 用户名
       //    pPropSet.SetProperty("password", strs[7]);//密码
       //    pPropSet.SetProperty("DATABASE", strs[9]);
       //    pPropSet.SetProperty("version", strs[11]);//连接版本

       //    try
       //    {
       //        WorkSpace = pSdeFact.Open(pPropSet, 0);
       //    }
       //    catch (Exception ex)
       //    {
       //        MessageBox.Show("SDE链接失败！请检查sde服务是否开启及连接配置是否正确", "信息提示");

       //    }
       //    log.Info("500:");
       //    string s = "sde.行政区";

       //    featureWorkspace = WorkSpace as IFeatureWorkspace;
       //    //GlobalVariables.addLayer = MapLoad.addLayerToAxMapControl(strs, new string[] { "sde.行政区", "sde.工业管理区", "sde.土地现状数据", "sde.自由分区" }, "");
       //    // GlobalVariables.addLayer = addLayerToMap(WorkSpace,featureWorkspace, "sde.行政区");

       //    if (GlobalVariables.sdeWorkspace != null)
       //    {
       //        if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
       //        {
       //            KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, WorkSpace as IWorkspaceEdit);
       //            GlobalVariables.sdeWorkspace.Add(item);
       //        }
       //    }
       //    log.Info("1020:" + s);
       //    try
       //    {
       //        //GlobalVariables.axMapControl.ClearLayers();
       //        IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
       //        log.Info("1040:" + s);
       //        IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
       //        log.Info("1050:" + s);
       //        IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
       //        log.Info("1060:" + s);

       //        IFeatureClass m_FeatureClass = enumFeatureClass.Next();
       //      //  IRecordSet2 pRecordSet = esriSerializerHelper.ConvertToRecordset(m_FeatureClass);
       //        XElement pXElement = esriSerializerHelper.StoreAsXml(m_FeatureClass);
       //        el = new XElement("FeatureClass", new XAttribute("name", m_FeatureClass.AliasName),
       //                                 pXElement);
              
       //     //   string layerstr = esriSerializerHelper.StoreToFile(pRecordSet);
       //        string LastFeatureName = String.Empty;
       //        log.Info("1080:" + s);

       //        while (m_FeatureClass != null)
       //        {
       //            log.Info("1090:" + m_FeatureClass.AliasName);

       //            //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
       //            LastFeatureName += m_FeatureClass.AliasName;
       //            IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
       //            m_FeatureLayer.FeatureClass = m_FeatureClass;
       //            m_FeatureLayer.Name = m_FeatureClass.AliasName;
       //            m_FeatureLayer.Selectable = false;

       //            log.Info("1100:" + m_FeatureClass.AliasName);
       //            //GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
                  


       //            layers.Add(m_FeatureLayer);
       //            log.Info("1200:" + m_FeatureClass.AliasName);
       //            //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
       //            //GlobalVariables.SymbolLayer(m_FeatureLayer);


       //            log.Info("1500:" + m_FeatureClass.AliasName);
       //            m_FeatureClass = enumFeatureClass.Next();
       //        }

       //        log.Info("1600:");
       //    }
       //    catch (Exception ex)
       //    {
       //        return null;// "程序报错，请重新加载或启动。(" + ex.Message + ")";

       //    }


       //    log.Info("2400:");

       //  //  string json = JsonHelper.SerializeObject<IFeatureLayer>(layers);

       //    return el;

       //}


       public List<XElement> LoadMapLayer1WithWorkspace(string workspace,string layername)
       {

           List<IFeatureLayer> layers = new List<IFeatureLayer>();
           List<XElement> list = new List<XElement>();
           XElement el = null;
            //IPropertySet pPropSet = JsonHelper.DeserializeJsonToObject<IPropertySet>(obj);
           //object obj1= esriSerializerHelper.esriDeserializer(obj.ToString());

           IWorkspace WorkSpace = (IWorkspace)esriSerializerHelper.DeSerialsAEObject(workspace, "sde");
         
        
           IFeatureWorkspace featureWorkspace;

           log.Info("500:");
           string s = layername;
         //  foreach (string s in layername)
         //  {
               featureWorkspace = WorkSpace as IFeatureWorkspace;
              
               log.Info("1020:" + s);
               try
               {
                   //GlobalVariables.axMapControl.ClearLayers();
                   IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
                   log.Info("1040:" + s);
                   IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
                   log.Info("1050:" + s);
                   IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
                   log.Info("1060:" + s);

                   IFeatureClass m_FeatureClass = enumFeatureClass.Next();
                   //  IRecordSet2 pRecordSet = esriSerializerHelper.ConvertToRecordset(m_FeatureClass);

                   while (m_FeatureClass != null)
                   {
                       esriSerializerHelper.StoreToFile(m_FeatureClass, "D:\\Temp\\" + m_FeatureClass.AliasName+ ".xml");
                       XElement pXElement = esriSerializerHelper.StoreAsXml(m_FeatureClass);
                       el = new XElement("FeatureClass", new XAttribute("name", m_FeatureClass.AliasName),
                                          pXElement);
                       list.Add(el);
                       m_FeatureClass = enumFeatureClass.Next();
                   }


               }
               catch (Exception ex)
               {
                   log.Error(ex);
               }
      //     }
           //string s = layername;// "sde.行政区";

         
           return list;

       }

       public void AddLayerToMapControl(AxMapControl amc,  IFeatureLayer features)
       {

            features.Selectable = false;

            amc.AddLayer(features, amc.LayerCount);   //加载到map窗口

               


       }

       public void AddLayerToMapControl(AxMapControl amc, IWorkspace WorkSpace, IFeatureClass features)
       {

           IFeatureWorkspace featureWorkspace;
           featureWorkspace = WorkSpace as IFeatureWorkspace;

           string s = features.AliasName;
           //GlobalVariables.axMapControl.ClearLayers();
           IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(features.AliasName);
           IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
           IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
           IFeatureClass m_FeatureClass = enumFeatureClass.Next();
           string LastFeatureName = String.Empty;
         
           while (m_FeatureClass != null)
           {
               log.Info("1090:" + m_FeatureClass.AliasName);

               //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
               LastFeatureName += m_FeatureClass.AliasName;
               IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
               m_FeatureLayer.FeatureClass = m_FeatureClass;
               m_FeatureLayer.Name = m_FeatureClass.AliasName;
               m_FeatureLayer.Selectable = false;

               amc.AddLayer(m_FeatureLayer,amc.LayerCount);   //加载到map窗口
            
               m_FeatureClass = enumFeatureClass.Next();
           }


       }



    }
}
