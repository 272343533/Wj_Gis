using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SunMvcExpress.Dao;
using QyTech.Core;
using QyTech.Core.BLL;
using QyTech.Core.BLL;
using System.Net.Http;

using Newtonsoft.Json;
using System.Threading;
using QyTech.Json;

namespace TDObject
{
    public partial class frmLogin : Form
    {

        //LoginUser luser;

        //public LoginUser CurrentLoginUser { get { return luser; } }
        //private const string Uri = "http://122.114.38.213/arc_gis/countries?format=json";  
       

        public frmLogin()
        {
            InitializeComponent();
        }

       
        private void exButton2_Click(object sender, EventArgs e)
        {
            MainForm.m_LoginStatus = 3;
            this.Close();
        }

        private void exButton1_Click(object sender, EventArgs e)
        {
            string username = this.tbUserName.Text;
            string strpwd = this.tbPassword.Text.Trim();
            string detailUrl = MainForm.URI + "home/loginbyjson?username=" + username + "&password=" + strpwd;

            string ret = "";// AsyncHttp.CommFun.GetRemoteJson(detailUrl);


            //Uri uri = new Uri(detailUrl);
            //var client = new HttpClient();
            //client.GetAsync(detailUrl).ContinueWith(
            //   (requestTask) =>
            //   {
            //       HttpResponseMessage response = requestTask.Result;

            //       // 确认响应成功，否则抛出异常  
            //       response.EnsureSuccessStatusCode();

            //       // 异步读取响应为字符串  
            //       response.Content.ReadAsStringAsync().ContinueWith(
            //           (readTask) =>
            //           {
            //               ret = readTask.Result;
            //               bsUser luser = JsonHelper.DeserializeJsonToObject<bsUser>(ret); //JsonConvert.DeserializeObject<bsUser>(ret);


            //               // bsUser luser = QyTech.Core.BLL.EntityManagerUsingT.GetBySql<bsUser>("LoginName='"+this.tbUserName.Text+"' and Pwd='"+ this.tbPassword.Text.Trim()+"'");

            //               if (luser != null)
            //               {
                               
            //                   luser.LLoginDT = DateTime.Now;



            //                   string strui = JsonHelper.SerializeObject<bsUser>(luser, null);
            //                   string url = MainForm.URI + "lyRemoteServ/UdpUserData?userinfo=" + strui;
            //                   ret = AsyncHttp.CommFun.GetRemoteJson(url);

            //                   //EntityManager<bsUser>.Modify<bsUser>(luser);



            //                   MainForm.LoginUser = luser;
                             


            //                   this.DialogResult = DialogResult.OK;
            //                   MainForm.m_LoginStatus = 2;

            //               }
            //               else
            //               {
            //                   MessageBox.Show("用户名或密码不正确", "提示", MessageBoxButtons.OK);
            //               }
            //           });
            //   });

            bsUser luser = MainForm.EM.GetByPk<bsUser>("LoginName", username);
            try
            {
                luser.LLoginDT = DateTime.Now;
                MainForm.EM.Modify<bsUser>(luser);
            }
            catch { }
            if (luser != null)
            {
                MainForm.LoginUser = luser;
                this.DialogResult = DialogResult.OK;
                MainForm.m_LoginStatus = 2;

                this.pbrLoad.Minimum = 0;
                this.pbrLoad.Maximum = 10;
                this.lblLoad.Visible = true;
                this.pbrLoad.Visible = true;
                while (!MainForm.LoadFinished && this.pbrLoad.Value <= this.pbrLoad.Maximum)
                {
                    this.pbrLoad.Value = this.pbrLoad.Value >= this.pbrLoad.Maximum - 1 ? this.pbrLoad.Maximum - 1 : this.pbrLoad.Value + 1;
                    this.pbrLoad.Refresh();
                    this.lblLoad.Refresh();
                    System.Threading.Thread.Sleep(1000);
                }
                this.pbrLoad.Value = this.pbrLoad.Maximum;


            }
            else
             {
                MessageBox.Show("用户名或密码不正确", "提示", MessageBoxButtons.OK);
             }

        }
    }
}
