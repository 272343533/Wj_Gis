using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QyTech.SkinForm;

using TDObject.MapControl;
using SunMvcExpress.Dao;


namespace TDObject.UI
{
    public partial class frmLtdProbem3 : qyFormWithTitle
    {
        public frmLtdProbem3()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="id">对应地块的编码</param>
        public frmLtdProbem3(GlobalVariables.SelectFeatureValue flag, string dkbm)
        {
            InitializeComponent();

            if (flag == GlobalVariables.SelectFeatureValue.AnQuanJianCha)
            {
                //找到改地块的所有有问题的企业
                List<t安全事故情况> objs = MainForm.EM.GetListNoPaging<t安全事故情况>("公司名称 in  (select 纳税人名称 from bsLtdInfo where 地块编号='" + dkbm + "')", "");

                if (objs.Count > 0)
                {
                    int index = 0;
                    foreach (t安全事故情况 obj in objs)
                    {
                        index++;
                        txtProblem.Text += "\r\n" + index.ToString() + "   " + obj.公司名称 + ":" + obj.事故类型;
                    }
                }
                else
                {
                    txtProblem.Text = "没有找到相关数据，可能名称不匹配，请联系管理员核实数据！";
                }

            }
        }
        private void frmLtdProbem3_Load(object sender, EventArgs e)
        {

        }
    }
}
