using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net; 



namespace BatchTranBdCoords
{

    public class Pnt
    {
        public decimal x;
        public decimal y;
    }
    public class BaiDuApiMapFromTo
    {
        public int status;
        public Pnt[] result;
    }
    public class BaiduMapLongLatiJson
    {
        public int error;
        public string x;
        public string y;
        public decimal Longtitude;
        public decimal Latitude;
    }
    public partial class Form1 : Form
    {
        string fName = "";
        bool isFileHaveName;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = "c:\\";//注意这里写路径时要用c:\\而不是c:\
            openFileDialog.Filter = "文本文件|*.txt|所有文件|*.*";
            openFileDialog.RestoreDirectory = true;
            openFileDialog.FilterIndex = 1;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
              
                fName = openFileDialog.FileName;
                this.textBox1.Text = fName;

                this.textBox2.Text = "";

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int LineCount = 0;
             string ls="" ;
            StreamReader sR = new StreamReader(fName, Encoding.Default);
            ls = sR.ReadLine();
            while (ls!= null)
            {
                LineCount++;
                ls = sR.ReadLine();
           }
            sR.Close();

            progressBar1.Minimum = 0;
            progressBar1.Maximum = LineCount;



            string newName = fName + "JW.txt";
            if (File.Exists(newName))
            {
                try
                {
                    File.Delete(newName);
                }
                catch { MessageBox.Show("目标文件已存在，不能删除"); }
            }
            StreamWriter sW = new StreamWriter(newName,true,Encoding.Default);

            // 同样也可以指定编码方式 
            //StreamReader sR2 = new StreamReader(@"c:\temp\a.txt", Encoding.UTF8);
           // FileStream fS = new FileStream(@"C:\temp\a.txt", FileMode.Open, FileAccess.Read, FileShare.None); 

            // 读一行 
            sR = new StreamReader(fName, Encoding.Default);
            LineCount = 0;
            string nextLine = sR.ReadLine();
            while (nextLine != null)
            {
                string[] lines = nextLine.Split(new char[] { ',' });
                //转换
                BaiDuApiMapFromTo bd092IIobj = GetMapCorrJson(6, 5, Convert.ToDouble(lines[2]), Convert.ToDouble(lines[3]));
               
              
                if (bd092IIobj != null)
                {
                   lines[2] = bd092IIobj.result[0].x.ToString();
                   lines[3] = bd092IIobj.result[0].y.ToString();
                }
               
                //写文件
                string newLine = lines[0];
                newLine += lines[1] + ",";
                newLine += lines[2] + ",";
                newLine += lines[3] + ",";
                newLine += lines[4] + ",";

                sW.WriteLine(newLine);
                progressBar1.Value = LineCount++;
                nextLine = sR.ReadLine();
            }
            sW.Close();
            sR.Close();
        }

        public BaiDuApiMapFromTo GetMapCorrJson(int mapfrom, int mapto, double lng, double lat)
        {
            try
            {
                //string json = GetHttp("http://api.map.baidu.com/geoconv/v1/?coords=" + lng.ToString() + ",%20" + lat.ToString() + "&from=" + mapfrom + "&to=" + mapto + "&ak=zogQhcGTaQUNycXl5OrdXq9Z");
                string json = GetHttp("http://api.map.baidu.com/geoconv/v1/?coords=" + lng.ToString() + ",%20" + lat.ToString() + "&from=" + mapfrom + "&to=" + mapto + "&ak=zogQhcGTaQUNycXl5OrdXq9Z");
                BaiDuApiMapFromTo obj = Json2T<BaiDuApiMapFromTo>(json);
                return obj;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public static string GetHttp(string url)
        {
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);

            httpWebRequest.ContentType = "application/json";
            httpWebRequest.Method = "GET";
            httpWebRequest.Timeout = 20000;

            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            StreamReader streamReader = new StreamReader(httpWebResponse.GetResponseStream());
            string responseContent = streamReader.ReadToEnd();

            httpWebResponse.Close();
            streamReader.Close();

            return responseContent;
        }


        public static T Json2T<T>(string json)
        {
            //var ser = new DataContractJsonSerializer(typeof(SearchNews));
            T obj = Activator.CreateInstance<T>();

            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(json)))
            {
                System.Runtime.Serialization.Json.DataContractJsonSerializer serializer = new System.Runtime.Serialization.Json.DataContractJsonSerializer(obj.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
