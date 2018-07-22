using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ESRI.ArcGIS.esriSystem;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.Display;
using ESRI.ArcGIS.Controls;
using ESRI.ArcGIS.ADF;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.DataSourcesGDB;
using System.Windows.Forms;
using log4net;

namespace TDObject.MapControl
{
    public static class MapLoad
    {

        static log4net.ILog log = log4net.LogManager.GetLogger("MapLoad");

        /// <summary>
        /// 地图加载方法
        /// </summary>
        /// <param name="SqlConStr">Sde连接数组 ex:"IP", "port:5151", "sa", "1", "arcgis", "dbo.default"</param>
        /// <param name="FeatureDatasetStr">数据集名称</param>
        /// <param name="LayerName">图层名称（未用）</param>
        /// 所有添加的数据集会在GlobalVariables.sdeWorkspace统一管理
        public static bool addLayerToAxMapControl(string[] SqlConStr, string[] FeatureDatasetStr, string LayerName)
        {
            log.Info("1000");
          
            //开始连接sde数据库
            IWorkspace Workspace;
            GlobalVariables.axMapControl.ClearLayers();//(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
          //  GlobalVariables.axMapControl1.ClearLayers();
            ///结束连接sde数据库并开始处理
            // Workspace = OpenSDEWorkspace("123.56.128.32", "port:5151", "sa", "1", "arcgis", "dbo.default");
            //Workspace = OpenSDEWorkspace("idea-pc", "port:5151", "sde", "sde", "arcgis", "dbo.default");

            Workspace = OpenSDEWorkspace(SqlConStr[1], SqlConStr[3], SqlConStr[5], SqlConStr[7], SqlConStr[9], SqlConStr[11]);
            if (Workspace == null)
                return false;
            
            foreach (string s in FeatureDatasetStr)
            {
                log.Info("1010:"+s);
          
                //sde 工作空间，编辑模式用
                if (GlobalVariables.sdeWorkspace != null)
                {
                    if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
                    {
                        KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, Workspace as IWorkspaceEdit);
                        GlobalVariables.sdeWorkspace.Add(item);
                    }
                }
                log.Info("1020:" + s);
                try
                {
                    //GlobalVariables.axMapControl.ClearLayers();
                    IFeatureWorkspace featureWorkspace;
                    featureWorkspace = Workspace as IFeatureWorkspace;//传递给Feature 工作空间
                    log.Info("1030:" + s);
                    IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);
                    log.Info("1040:" + s);
                    IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;
                    log.Info("1050:" + s);
                    IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;
                    log.Info("1060:" + s);
                    IFeatureClass m_FeatureClass = enumFeatureClass.Next();
                    string LastFeatureName = String.Empty;
                    log.Info("1080:" + s);
            
                    while (m_FeatureClass != null)
                    {
                        log.Info("1090:" + m_FeatureClass.AliasName);
          
                        //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
                        LastFeatureName += m_FeatureClass.AliasName;
                        IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                        m_FeatureLayer.FeatureClass = m_FeatureClass;
                        m_FeatureLayer.Name = m_FeatureClass.AliasName;
                        m_FeatureLayer.Selectable = false;
                        
                        log.Info("1100:" + m_FeatureClass.AliasName);
                        GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
                        log.Info("1200:" + m_FeatureClass.AliasName);
                        //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
                        GlobalVariables.SymbolLayer(m_FeatureLayer);
                       
                        //m_FeatureLayer.Visible = false;
                           
                        log.Info("1500:" + m_FeatureClass.AliasName);
          
                          m_FeatureClass = enumFeatureClass.Next();
                    }

                    log.Info("1600:" );
                }
                catch (Exception ex)
                {

                    log.Error(ex.Message);
                    return false;

                }
                
            }
            log.Info("2400:");
            GlobalVariables.axMapControl.ActiveView.Refresh();
            log.Info("2500:" );
          
            return true;
        }

        public static bool addLayerToAxMapControl(string[] FeatureDatasetStr, string LayerName)
        {
            log.Info("1000");

            //开始连接sde数据库
            IFeatureWorkspace featureWorkspace;
            featureWorkspace = MainForm.Workspace as IFeatureWorkspace;//传递给Feature 工作空间
                   
            foreach (string s in FeatureDatasetStr)
            {
                log.Info("1010:" + s);

                //sde 工作空间，编辑模式用
                if (GlobalVariables.sdeWorkspace != null)
                {
                    if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
                    {
                        KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, MainForm.Workspace as IWorkspaceEdit);
                        GlobalVariables.sdeWorkspace.Add(item);
                    }
                }
                log.Info("1020:" + s);
                try
                {
                    //GlobalVariables.axMapControl.ClearLayers();
                    IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);

                    IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;

                    IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;

                    IFeatureClass m_FeatureClass = enumFeatureClass.Next();
                    string LastFeatureName = String.Empty;


                    while (m_FeatureClass != null)
                    {
                       //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
                        LastFeatureName += m_FeatureClass.AliasName;
                        IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                        m_FeatureLayer.FeatureClass = m_FeatureClass;
                        m_FeatureLayer.Name = m_FeatureClass.AliasName;
                        m_FeatureLayer.Selectable = false;

                        GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
                        //if (m_FeatureLayer.Name.Contains("房屋") || m_FeatureLayer.Name.Contains("规划") || m_FeatureLayer.Name.Contains("历史"))
                        GlobalVariables.SymbolLayer(m_FeatureLayer);

                        m_FeatureClass = enumFeatureClass.Next();
                    }

                    log.Info("1600:");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("程序报错，请重新加载或启动。("+ex.Message+")");
                    return false;

                }

            }
            log.Info("2400:");
            GlobalVariables.axMapControl.ActiveView.Refresh();
            log.Info("2500:");

            return true;
        }


        public static bool addOneLayerToAxMapControl(string FeatureDatasetStr, string LayerName)
        {
            log.Info("1000");

            //开始连接sde数据库
            IFeatureWorkspace featureWorkspace;
            featureWorkspace = MainForm.Workspace as IFeatureWorkspace;//传递给Feature 工作空间

            string s = FeatureDatasetStr;

       
            //sde 工作空间，编辑模式用
            if (GlobalVariables.sdeWorkspace != null)
            {
                if (GlobalVariables.sdeWorkspace.FindIndex(t => t.Key.Equals(s)) == -1)
                {
                    KeyValuePair<string, IWorkspaceEdit> item = new KeyValuePair<string, IWorkspaceEdit>(s, MainForm.Workspace as IWorkspaceEdit);
                    GlobalVariables.sdeWorkspace.Add(item);
                }
            }
            try
            {
                IFeatureDataset featureDataset = featureWorkspace.OpenFeatureDataset(s);

                IFeatureClassContainer featureClassContainer = (IFeatureClassContainer)featureDataset;

                IEnumFeatureClass enumFeatureClass = featureClassContainer.Classes;

                IFeatureClass m_FeatureClass = enumFeatureClass.Next();
                string LastFeatureName = String.Empty;


                while (m_FeatureClass != null)
                {
                    //判断是否已添加（或判断过下面的if且不成立）过当前图层 不知道为什么有时候会出现重复加载
                    LastFeatureName += m_FeatureClass.AliasName;
                    IFeatureLayer m_FeatureLayer = new FeatureLayerClass();
                    m_FeatureLayer.FeatureClass = m_FeatureClass;
                    m_FeatureLayer.Name = LayerName;
                    m_FeatureLayer.Selectable = false;

                    GlobalVariables.axMapControl.AddLayer(m_FeatureLayer, GlobalVariables.axMapControl.LayerCount);   //加载到map窗口
                    
                    GlobalVariables.SymbolLayer(m_FeatureLayer);

                    m_FeatureClass = enumFeatureClass.Next();
                }

                log.Info("1600:");
            }
            catch (Exception ex)
            {
                MessageBox.Show("程序报错，请重新加载或启动。(" + ex.Message + ")");
                return false;
            }

            GlobalVariables.axMapControl.ActiveView.Refresh();

            return true;
        }

        /// <summary>
        /// 连接sde数据库的方法
        /// </summary>
        /// <param name="Server"></param>
        /// <param name="Instance"></param>
        /// <param name="User"></param>
        /// <param name="Password"></param>
        /// <param name="Database"></param>
        /// <param name="version"></param>
        /// <returns>返回工作空间</returns>
        public static IWorkspace OpenSDEWorkspace(string Server, string Instance, string User, string Password, string Database, string version)
        {

            ESRI.ArcGIS.RuntimeManager.Bind(ESRI.ArcGIS.ProductCode.EngineOrDesktop);
            IWorkspace ws = null;
            IPropertySet pPropSet = new PropertySetClass();
            //使用sde的工作空间工厂
            IWorkspaceFactory pSdeFact = new SdeWorkspaceFactoryClass();
            
            pPropSet.SetProperty("SERVER", Server);
            pPropSet.SetProperty("INSTANCE", Instance);//实例化端口
            pPropSet.SetProperty("DATABASE", Database);
            pPropSet.SetProperty("USER", User);//SDE 用户名
            pPropSet.SetProperty("password", Password);//密码
            pPropSet.SetProperty("version", version);//连接版本
            try
            {
                ws = pSdeFact.Open(pPropSet, 0);

            }
            catch (Exception ex)
            {

                log.Error(ex.Message);
                MessageBox.Show("服务器链接失败！请检查服务是否开启。", "信息提示");

            }
            return ws;
        }

    
    }
}
