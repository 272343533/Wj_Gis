using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QyTech.Json;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;


namespace TDObject.UI
{
    public partial class frmChangePwd : FlatForm
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string DetailUrl = MainForm.URI + "/lyRemoteServ/GetOneUserData?id=" + MainForm.LoginUser.bsU_Id.ToString();
                string json = AsyncHttp.CommFun.GetRemoteJson(DetailUrl);
                bsUser userobj = JsonHelper.DeserializeFormtJsonToObject<bsUser>(json); // TDObject.BLL.CommSetting.EM.GetByPk<bsUser>("bsU_Id", MainForm.LoginUser.bsU_Id);

                //if (da.Md5(tbPassold.Text) != MainForm.LoginUser.Pwd)
                if (tbPassold.Text != MainForm.LoginUser.Pwd)
                {
                    MessageBox.Show("原密码不正确");
                }
                else
                {
                    if (tbPass.Text == tbPass2.Text)
                    {
                        userobj.Pwd = tbPass.Text.Trim();

                        string strui = JsonHelper.SerializeObject<bsUser>(userobj, null);
                        DetailUrl = MainForm.URI + "lyRemoteServ/UdpUserData?userinfo=" + strui;
                        string ret = AsyncHttp.CommFun.GetRemoteJson(DetailUrl);

                        if (ret != "")
                            MessageBox.Show(ret);
                        else
                        {
                            MessageBox.Show("更新成功");
                            MainForm.LoginUser = userobj;
                        }
                    }
                    else
                    {
                        MessageBox.Show("新密码两次不一致");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChangePwd_MouseMove(object sender, MouseEventArgs e)
        {
            FormSkin.MouseMoveForm(this.Handle);
        }
    }
}
