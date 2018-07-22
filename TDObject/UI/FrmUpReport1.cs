using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDObject.UI
{
    public partial class FrmUpReport1 : FlatForm
    {
        public FrmUpReport1()
        {
            InitializeComponent();
        }

        private void FrmUpReport1_Load(object sender, EventArgs e)
        {
            webBrowser1.Navigate("file:///" + Environment.CurrentDirectory + "/Html/UpReport1Web.html");
           // webBrowser1.Navigate("http://122.114.38.213:8080/WjKfq_gis/UpReport1Web.html");
            //webBrowser1.Url =new Uri("http://122.114.38.213:8080/WjKfq_gis/UpReport1Web.html");
            //webBrowser1.Navigate("file:///" + Environment.CurrentDirectory + "/Html/吴江区工业企业资源集约利用情况表.mht");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }

}
