using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Net;
using System.IO;
namespace TDObject.BLL
{
    /// <summary>
    /// 连接管理
    /// </summary>
    public class Conection
    {
        static log4net.ILog log = log4net.LogManager.GetLogger("TDObject.BLL Conection");

        private string connectionString = string.Empty;
        /// <summary>
        /// 获取app.config里的数据库连接串。
        /// </summary>
        /// <param name="configName"></param>
        /// <returns></returns>
        public string GetConnectionString(string configName)
        {
            connectionString = ConfigurationManager.ConnectionStrings[configName].ConnectionString.ToString();
            return connectionString;
        }
        public static string GetPostStringRetStr(string url, string data)
        {
            try
            {
                byte[] postBytes = Encoding.GetEncoding("utf-8").GetBytes(data);
                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(url);
                myRequest.Method = "POST";
                myRequest.ContentType = "application/x-www-form-urlencoded";
                myRequest.ContentLength = postBytes.Length;
                myRequest.Proxy = null;
                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(postBytes, 0, postBytes.Length);
                newStream.Close();
                // Get response
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                using (StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.GetEncoding("utf-8")))
                {
                    string content = reader.ReadToEnd();
                    return content;
                }
            }
            catch (System.Exception ex)
            {
                log.Error("GetPostString post通讯出错" + ex.Message);
                return null;//ex.Message;
            }
        }
    }
}