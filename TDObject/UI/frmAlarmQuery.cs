using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SunMvcExpress.Dao;

namespace TDObject.UI
{
    public partial class frmAlarmQuery : QyTech.SkinForm.qyForm
    {

        private string YdLtdOrRentLtd="YdLtd";

        private int LtdId_=-1;

        private int CurrRentRegularId;
        private int CurrYdRegularId;

        private int[] RowIndex = new int[2];

        List<LtdRegular> yddw = new List<LtdRegular>();
        List<LtdRegular> Zldw = new List<LtdRegular>();



        public frmAlarmQuery(int id)
        {
            InitializeComponent();

            LtdId_ = id;
        }

        List<LtdPhoto> photos;
        int CurrPhotoNo = 0;
        private void frmAlarmQuery_Load(object sender, EventArgs e)
        {

            try
            {
                dataGridView1.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;
                dataGridView2.AlternatingRowsDefaultCellStyle = QyTech.SkinForm.Controls.qyDgv.DgvDefaultAlterCellStyle;;

                RowIndex[0] = -1;
                RowIndex[1] = -1;
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        private void RefreshForm()
        {
            try
            {
                企业范围 ltdobj = BLL.CommSetting.EM.GetByPk<企业范围>("OBJECTID", LtdId_);

                label1.Text = ltdobj.YDQYMC + "  " + label1.Text;

                dataGridView1.AllowUserToAddRows = false;
                dataGridView2.AllowUserToAddRows = false;

                photos = BLL.CommSetting.EM.GetListNoPaging<LtdPhoto>("SSDKBM='" + ltdobj.DKBH + "' and PhotoType=2", "PICTURE");
                if (photos.Count > 0)
                {
                    CurrPhotoNo = 1;
                }
                textBox1.Text = "0/" + photos.Count.ToString();



                List<LtdRegular> ltds = BLL.CommSetting.EM.GetListNoPaging<LtdRegular>("SSDKBM='" + ltdobj.DKBH + "'", "");
                yddw.Clear();
                Zldw.Clear();

                foreach (LtdRegular obj in ltds)
                {
                    if (!obj.IsRentLtd.Value)
                    {
                        yddw.Add(obj);
                    }
                    else
                    {
                        Zldw.Add(obj);
                    }
                }

                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = yddw;

                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.DataSource = Zldw;
                label2.Text = "租赁企业安全信息(数量:" + Zldw.Count.ToString() + ")";
            }
            catch { }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    RowIndex[1] = e.RowIndex;
                    CurrRentRegularId = Convert.ToInt32(dataGridView2.Rows[e.RowIndex].Cells[10].Value);
                    string nsrsbh = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    if (e.ColumnIndex == 9)
                    {
                        if (nsrsbh != "")
                        {
                            z租赁企业信息表 zlobj = MainForm.EM.GetBySql<z租赁企业信息表>("NSRSBH='" + nsrsbh + "'");
                            if (zlobj != null)
                            {
                                frmAlarmLtdQuery obj = new frmAlarmLtdQuery(true, zlobj.OBJECTID);
                                obj.Show();
                            }
                            else
                            {
                                MessageBox.Show("该企业代码(纳税人识别号)倒不倒对应的企业，需核实数据");
                            }
                        }
                        else
                        {
                            MessageBox.Show("企业编码或纳税人识别号没有输入，不能进一步操作，请保证数据的完整性！");
                        }
                    }
                    //DGV下拉框的取值
                    //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }

      

        private bool pbrEnd = false;
        private void PbrStart()
        {
            //System.Threading.Thread thrpbr = new System.Threading.Thread(new System.Threading.ThreadStart(PbrStart));
            //thrpbr.Start();
            //pbrEnd = true;
            pbrEnd = false;
            this.progressBar1.Visible = true;
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = 100;
            this.progressBar1.Value = this.progressBar1.Minimum;
            while (!pbrEnd)
            {
                this.progressBar1.Value += 5;
                if (this.progressBar1.Value==this.progressBar1.Maximum)
                {
                    this.progressBar1.Value=this.progressBar1.Maximum-1;
                }
                this.progressBar1.Refresh();
                System.Threading.Thread.Sleep(100);
            }
            this.progressBar1.Visible = false;

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.progressBar1.Value == this.progressBar1.Maximum)
            {
                this.progressBar1.Value = this.progressBar1.Maximum - 1;
            }
            this.progressBar1.Value += 1;
        }
        private void frmAlarmQuery_Shown(object sender, EventArgs e)
        {
            //button4_Click(null, null);
            if (photos.Count > 0)
                DispImg();
        }
      
        private void button4_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo !=1)
                {
                    CurrPhotoNo = 1;
                    DispImg();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo > 1)
                {
                    CurrPhotoNo -= 1;
                    DispImg();
                }
            }
        }
  
        private void button2_Click_1(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo < photos.Count)
                {
                    CurrPhotoNo += 1;
                    DispImg();
                }
              }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (photos.Count > 0)
            {
                if (CurrPhotoNo != photos.Count)
                {
                    CurrPhotoNo = photos.Count ;
                    DispImg();
                }
            }
        }
        private void DispImg()
        {
            try
            {
                textBox1.Text = CurrPhotoNo.ToString() + "/" + photos.Count.ToString();

                string filename = photos[CurrPhotoNo-1].PICTURE;

                //timer1.Interval = 200;
                //timer1.Start();
                pictureBox1.Image = Image.FromStream(System.Net.WebRequest.Create("http://122.114.190.250:8080/Wjkfq_gis/Uploads/" + filename).GetResponse().GetResponseStream());
                //timer1.Stop();

                 richTextBox1.Text = "      " + photos[CurrPhotoNo - 1].SSQYMC + "\r\n\r\n    " + photos[CurrPhotoNo - 1].PicMemo;
            }
            catch (Exception ex)
            {
                MessageBox.Show("没有找到图片数据！");
            }
        }
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                YdLtdOrRentLtd = "YdLtd";
                if (dataGridView1.SelectedRows.Count > 0)
                    RowIndex[0] = dataGridView1.SelectedRows[0].Index;
                else
                    RowIndex[0] = -1;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0)
            {
                CurrYdRegularId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value);
                RowIndex[0] = e.RowIndex;
           
                if (e.ColumnIndex == 9)
                //DataGridViewColumn column = dataGridView1.Columns[e.ColumnIndex];
                //if (column is DataGridViewButtonColumn)
                {
                    //这里可以编写你需要的任意关于按钮事件的操作~
                    //MessageBox.Show("按钮被点击");
                    //frmAlarmLtdQuery obj = new frmAlarmLtdQuery(false,Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[10].Value));
                    frmAlarmLtdQuery obj = new frmAlarmLtdQuery(false, LtdId_);
                    obj.Show();
                }
                //DGV下拉框的取值
                //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value.ToString());
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
                FrmAddLtdRegular obj = new FrmAddLtdRegular(null);
                obj.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                List<LtdRegular> uis;

                LtdRegular obj;// = uis[e.RowIndex];
                if (YdLtdOrRentLtd.ToLower() == "ydltd")
                {
                    if (RowIndex[0] == -1)
                    {
                        MessageBox.Show("请先单击选择数据！");
                        return;
                    }
                    uis = this.dataGridView1.DataSource as List<LtdRegular>;
                    if (this.dataGridView1.Rows[RowIndex[0]].Cells[10].Value != null)
                    {
                        obj = uis[RowIndex[0]];
                        FrmAddLtdRegular frmobj = new FrmAddLtdRegular(obj);
                        frmobj.ShowDialog();
                    }
                }
                else
                {
                    if (RowIndex[1] == -1)
                    {
                        MessageBox.Show("请先单击选择数据！");
                        return;
                    }
                    uis = this.dataGridView2.DataSource as List<LtdRegular>;
                    if (this.dataGridView2.Rows[RowIndex[1]].Cells[10].Value != null)
                    {
                        obj = uis[RowIndex[1]];
                        FrmAddLtdRegular frmobj = new FrmAddLtdRegular(obj);
                        frmobj.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                string ret = "";
                List<LtdRegular> uis;

                LtdRegular obj;// = uis[e.RowIndex];
                if (YdLtdOrRentLtd.ToLower() == "ydltd")
                {
                    if (RowIndex[0] == -1)
                    {
                        MessageBox.Show("请先单击选择数据！");
                        return;
                    }
                    uis = this.dataGridView1.DataSource as List<LtdRegular>;
                    obj = uis[RowIndex[0]];
                    ret = MainForm.EM.DeleteById<LtdRegular>("OBJECTID", obj.OBJECTID);

                }
                else
                {
                    if (RowIndex[1] == -1)
                    {
                        MessageBox.Show("请先单击选择数据！");
                        return;
                    }
                    uis = this.dataGridView2.DataSource as List<LtdRegular>;
                    obj = uis[RowIndex[1]];
                    ret = MainForm.EM.DeleteById<LtdRegular>("OBJECTID", obj.OBJECTID);
                }
                if (ret == "")
                    MessageBox.Show("删除成功！");
                else
                    MessageBox.Show("删除失败！(" + ret + ")");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            try
            {
                RefreshForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           // RowIndex[1] = e.RowIndex;
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            try
            {
                YdLtdOrRentLtd = "RentLtd";
                if (dataGridView2.SelectedRows.Count > 0)
                    RowIndex[1] = dataGridView2.SelectedRows[0].Index;
                else
                    RowIndex[1] = -1;
            }
            catch (Exception ex)
            {
                log.Error(ex.Message);
            }
     
        }

   

      

    }
}
