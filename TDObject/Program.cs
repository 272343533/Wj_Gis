using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS;
using System.Configuration;

namespace TDObject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!RuntimeManager.Bind(ProductCode.Engine))
            {
                if (!RuntimeManager.Bind(ProductCode.Desktop))
                {
                    MessageBox.Show("Unable to bind to ArcGIS runtime. Application will be shut down.");
                    return;
                }
            }
            //初始化日志文件 
            string state = ConfigurationManager.AppSettings["IsWriteLog"];
            //判断是否开启日志记录
            if (state == "1")
            {
                var path = AppDomain.CurrentDomain.SetupInformation.ApplicationBase +
                           ConfigurationManager.AppSettings["log4net"];
                var fi = new System.IO.FileInfo(path);
                log4net.Config.XmlConfigurator.Configure(fi);
            }


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}