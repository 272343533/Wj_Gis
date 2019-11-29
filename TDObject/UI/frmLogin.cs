using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using QyTech.Auth.Dao;
using QyTech.Core;
using QyTech.Core.BLL;
using System.Net.Http;

using Newtonsoft.Json;
using System.Threading;
using QyTech.Json;
using System.IO;

namespace TDObject
{
    public partial class frmLogin : Form
    {

        BinaryWriter bw;
        BinaryReader br;
        string filename = "mydata";
        string passwordkey = "abcdefghigklmnopqrstuvwxyz0123456789ABCDEFGHIJKLMNOPQRST";

        string strpwd = "";

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

            string username = this.tbUserName.Text.Trim(); ;
            //strpwd = this.tbPassword.Text.Trim(); 
            //string detailUrl = MainForm.App_URI + "home/loginbyjson?username=" + username + "&password=" + strpwd;

            //string ret = "";// AsyncHttp.CommFun.GetRemoteJson(detailUrl);


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
            //                   string url = MainForm.App_URI + "lyRemoteServ/UdpUserData?userinfo=" + strui;
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

            bsUser luser = MainForm.QyTech_EM.GetBySql<bsUser>("LoginName='"+username+ "' and LoginPwd='"+ strpwd+"'");
          
            if (luser != null)
            {
                try
                {
                    luser.LoginDt = DateTime.Now;
                    MainForm.QyTech_EM.Modify<bsUser>(luser);
                }
                catch {}
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

                //保存账号
               try
                {
                    bw = new BinaryWriter(new FileStream(filename,FileMode.OpenOrCreate));
                    string content = username + "@@@@" + strpwd;
                    content = String.Format("{0, -50}", content);
                    byte[] bytes = System.Text.Encoding.Default.GetBytes(content);
                    StringBuilder ps = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        int c = bytes[i] ^ passwordkey[i];
                        ps.Append(c + " ");
                    }

                    bw.Write(ps.ToString());
                    bw.Close();

                }
                catch (IOException ex)
                {
                   
                }

            }
            else
             {
                MessageBox.Show("用户名或密码不正确", "提示", MessageBoxButtons.OK);
             }

        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            panel1.Parent = pictureBox1;

            try
            {
                br = new BinaryReader(new FileStream(filename,FileMode.Open));
                try
                {
                    string passwd = br.ReadString();
                    string[] ps = passwd.Split(' ');
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < ps.Length - 1; i++)
                    {
                        sb.Append((char)(passwordkey[i] ^ int.Parse(ps[i]))); //异或解密， 转换成char
                    }
                    passwd = sb.ToString();

                    string[] strs = passwd.Split(new string[] { "@@@@" }, 2, StringSplitOptions.RemoveEmptyEntries);
                    this.tbUserName.Text = strs[0];

                    this.tbPassword.Text = strs[1].Trim();
                    strpwd = this.tbPassword.Text;
                    br.Close();
                }
                catch { br.Close(); }
            }
            catch (IOException ex)
            {
                return;
            }
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            strpwd = QyTech.Security.IMD5.Encrypt(this.tbPassword.Text.Trim());

        }
    }
}
