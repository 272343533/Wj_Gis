using QyTech.Json;
using SunMvcExpress.Dao;
using QyTech.Core.BLL;
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
    public partial class FrmLayerSet : Form
    {
        public FrmLayerSet()
        {
            InitializeComponent();
        }

        private void FrmLayerSet_Load(object sender, EventArgs e)
        {
            dataGridView1.AlternatingRowsDefaultCellStyle = FormSkin.DgvDefaultAlterCellStyle;
         
            List<blLayer> objs = TDObject.BLL.CommSetting.EM.GetListNoPaging<blLayer>("", " DispNo");

            this.dataGridView1 = dgvCommDisplay.InitDisp(dataGridView1);
            this.dataGridView1.DataSource = objs;

            bsUser luser = MainForm.LoginUser;
            GetGridView_layer(luser.LayerSet);
        }

        private void GetGridView_layer(string SetLayer)
        {
            string[] Str = SetLayer.Split(',');
            int count = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < Str.Count(); i++)
            {

                for (int j = 0; j < count; j++)
                {
                    dataGridView1.EndEdit();
                    DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["Column3"];
                    if (Str[i] == dataGridView1.Rows[i].Cells[2].Value.ToString().Trim())     //查找被选择的数据行 
                    {
                        checkCell.Value = true;
                    }
                }

            }

        }
        /// <summary>
        /// 退出按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            string LayerSet_new="";
            int count = Convert.ToInt32(dataGridView1.Rows.Count.ToString());
            for (int i = 0; i < count; i++)
            {
                //如果DataGridView是可编辑的，将数据提交，否则处于编辑状态的行无法取到 
                dataGridView1.EndEdit();
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)dataGridView1.Rows[i].Cells["Column3"];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)     //查找被选择的数据行 
                {
                    LayerSet_new = LayerSet_new + dataGridView1.Rows[i].Cells[2].Value.ToString().Trim()+',';
                }
            }

            LayerSet_new = LayerSet_new.Substring(0, LayerSet_new.Length - 1);

            if (MainForm.LoginUser.LayerSet == LayerSet_new)
            {
                MessageBox.Show("您尚未更改要加载的图层！");
                return;
            }
            else
            {
                MainForm.LoginUser.LayerSet = LayerSet_new;
                using (var db = new wj_GisDbEntities())
                {
                    var info = db.bsUser  .SingleOrDefault(cc => cc.bsU_Id  == MainForm .LoginUser .bsU_Id );
                    info.LayerSet  = LayerSet_new ;
                    db.SaveChanges();
                    MessageBox.Show("要加载的图层已经修改！");
                    return ;
                }
            }
            
        }
    }
}
