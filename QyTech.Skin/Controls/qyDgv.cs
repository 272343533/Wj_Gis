using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Drawing;


namespace QyTech.SkinForm.Controls
{
    /// <summary>
    /// 仅用来显示数据，不能编辑
    /// </summary>
    public class qyDgv : DataGridView
    {
        #region 初始化
        public qyDgv()
        {
         

            //EditMode = DataGridViewEditMode.EditOnEnter;
            //EnableHeadersVisualStyles = false;
            //RowHeadersVisible = false; //第一列前面的短空白
            //SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            //ReadOnly = true;

            //////DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            //////columnHeaderStyle.BackColor = Color.Lavender;
            ////////FromArgb(196, 225, 255);
            ////////Color.Lavender;//薰衣草的淡紫色
            //////columnHeaderStyle.Font = new Font("宋体", 12);
            //////columnHeaderStyle.ForeColor = Color.Black;
            //////columnHeaderStyle.SelectionBackColor = Color.White;
            //////columnHeaderStyle.SelectionForeColor = Color.Black;
            //////ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            ////////AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;//填满DataGridView

            //AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;

            BackgroundColor = Color.White;
           // CellBorderStyle = DataGridViewCellBorderStyle.Raised;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;


            AlternatingRowsDefaultCellStyle = new DataGridViewCellStyle { BackColor = Color.FromArgb(255, 255, 224, 192) };
            RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_RowPostPaint);

        }

        public static DataGridViewCellStyle DgvDefaultAlterCellStyle
        {
            get { return new DataGridViewCellStyle { BackColor = Color.FromArgb(255, 255, 224, 192) }; }

        }
        public new void CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            //鼠标移动到某行时更改背景色
            if (e.RowIndex >= 0)
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Lavender;
            }
        }

        public new void CellMouseLeave(object sender, DataGridViewCellEventArgs e)
        {
            //鼠标移开时还原背景色 
            if (e.RowIndex >= 0)
            {
                Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }


        public void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 10, e.RowBounds.Location.Y + 4);
        }
        #endregion
        public void addModifyButton(DataGridView dgv)
        {

            DataGridViewButtonColumn dgv_button_col_ViewEdit = new DataGridViewButtonColumn();      //修改/编辑

            // 设定列的名字
            dgv_button_col_ViewEdit.Name = "ViewEdit";
            //dgv_button_col_ViewEdit.DefaultCellStyle=

            // 在所有按钮上表示"查看/编辑"
            dgv_button_col_ViewEdit.UseColumnTextForButtonValue = true;
            dgv_button_col_ViewEdit.Text = "查看/编辑";
            dgv_button_col_ViewEdit.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_button_col_ViewEdit.FlatStyle = FlatStyle.Standard;
            dgv_button_col_ViewEdit.CellTemplate.Style.BackColor = Color.Lavender;
            //dgv_button_col_ViewEdit.DisplayIndex = 0;

            // 设置列标题
            dgv_button_col_ViewEdit.HeaderText = "";//“查看/编辑”

            // 向DataGridView追加
            dgv.Columns.Insert(dgv.ColumnCount, dgv_button_col_ViewEdit);       //添加“查看/编辑”列按钮

            //DataGridViewButtonColumn buttons = new DataGridViewButtonColumn();
            //{
            //    buttons.HeaderText = "Sales";
            //    buttons.Text = "Sales";
            //    buttons.UseColumnTextForButtonValue = true;
            //    buttons.AutoSizeMode =
            //        DataGridViewAutoSizeColumnMode.AllCells;
            //    buttons.FlatStyle = FlatStyle.Standard;
            //    buttons.CellTemplate.Style.BackColor = Color.Honeydew;
            //    buttons.DisplayIndex = 0;
            //}

            //DataGridView1.Columns.Add(buttons);

        }

        /// <summary>
        /// 追加删除列按钮，要弹出删除“窗体”
        /// </summary>
        /// <param name="dgv">要修改的DataGridView对象</param>
        public void addDGVDelButton(DataGridView dgv)
        {
            DataGridViewButtonColumn dgv_button_col_Del = new DataGridViewButtonColumn();           //删除

            //设定列的名字
            dgv_button_col_Del.Name = "Delete";

            //在所有按钮上表示"删除"
            dgv_button_col_Del.UseColumnTextForButtonValue = true;
            dgv_button_col_Del.Text = "删除";
            dgv_button_col_Del.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgv_button_col_Del.FlatStyle = FlatStyle.Standard;
            dgv_button_col_Del.CellTemplate.Style.BackColor = Color.Lavender;
            //dgv_button_col_Del.DisplayIndex = 1;

            //设置列标题
            dgv_button_col_Del.HeaderText = "";//“删除”

            //向DataGridView追加
            dgv.Columns.Insert(dgv.ColumnCount, dgv_button_col_Del);            //添加“删除”列按钮

        }

        /// <summary>
        /// 合并列表头
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void dataGV_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //    // 假定需要将表头行第7列单元格与其左单元格合并
        //    if (e.ColumnIndex == (column + 2) && e.RowIndex == -1)
        //    {
        //        Rectangle re = new Rectangle(e.CellBounds.Left - dataGV.Columns[e.ColumnIndex - 1].Width,
        //            e.CellBounds.Top, e.CellBounds.Width + dataGV.Columns[e.ColumnIndex - 1].Width,
        //            e.CellBounds.Height);
        //        e.Graphics.FillRectangle(Brushes.Lavender, re);//保持和前边的颜色一致

        //        Pen pen = new Pen(dataGV.BackgroundColor, 1);

        //        pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

        //        e.Graphics.DrawLine(pen, re.X, re.Y + re.Height - 1, re.X + re.Width, re.Y + re.Height - 1);//下线

        //        e.Graphics.DrawLine(pen, re.X + re.Width - 1, re.Y, re.X + re.Width - 1, re.Y + re.Height);//右线

        //        //SizeF strSize = e.Graphics.MeasureString(dataGV.Rows[0].Cells[1].Value.ToString()
        //        //    + e.Value.ToString(), dataGV.Font);
        //        SizeF strSize = e.Graphics.MeasureString("操作", dataGV.Font);

        //        //e.Graphics.DrawString(dataGV.Rows[0].Cells[1].Value.ToString() + e.Value.ToString(),
        //        //    dataGV.Font, Brushes.Black, re.X + (re.Width - strSize.Width) / 2,
        //        //    re.Y + (re.Height - strSize.Height) / 2);
        //        e.Graphics.DrawString("操作", dataGV.Font, Brushes.Black, re.X + (re.Width - strSize.Width) / 2,
        //            re.Y + (re.Height - strSize.Height) / 2);

        //        e.Handled = true;

        //    }
        //}

        /// <summary>
        /// CheckBox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private int count = 0;
        private new void CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex == -1)//如果单击列表头，全选．
            {

                if (count % 2 == 0)//(bool)dataGV.Rows[e.RowIndex].Cells[0].EditedFormattedValue == true
                {
                    count++;
                    for (int i = 0; i < RowCount; i++)
                    {
                        EndEdit();//结束编辑状态．
                        string re_value = Rows[i].Cells[0].EditedFormattedValue.ToString();
                        Rows[i].Cells[0].Value = "true";//如果为true则为选中,false未选中
                        Rows[i].Selected = true;//选中整行。

                    }
                }
                else
                {
                    count--;
                    for (int i = 0; i < RowCount; i++)
                    {
                        EndEdit();//结束编辑状态．
                        string re_value = Rows[i].Cells[0].EditedFormattedValue.ToString();
                        Rows[i].Cells[0].Value = "false";//如果为true则为选中,false未选中
                        Rows[i].Selected = false;//选中整行。

                    }
                }

            }
            else
            {
                for (int i = 0; i < Rows.Count; i++)
                {
                    ////不是当前选中的则checkBox全部设为false
                    //if (i != e.RowIndex || dataGV.CurrentCell.ColumnIndex != 0)
                    //{
                    //    DataGridViewCheckBoxCell cell = (DataGridViewCheckBoxCell)dataGV.Rows[i].Cells[0];
                    //    cell.Value = false;
                    //}
                    //else
                    //{
                    //是当前选中的，要设置为互斥的
                    if ((bool)Rows[e.RowIndex].Cells[0].EditedFormattedValue == true)
                    {
                        Rows[e.RowIndex].Cells[0].Value = false;
                    }
                    else
                    {
                        Rows[e.RowIndex].Cells[0].Value = true;
                    }
                    //}
                }
            }

        }



        /// <summary>
        /// DataGridView中的Button事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private new void CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Columns[e.ColumnIndex].Name == "ViewEdit")//跳转到“查看/编辑”窗体
            {
                //弹出对应的窗体事件
                //MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了");
                //int rows = int.Parse(e.RowIndex.ToString());                             //点击所在的行号
                //int columns = int.Parse(e.ColumnIndex.ToString());                       //点击所在的列号
                //MessageBox.Show(rows.ToString() + ";" + columns.ToString());
                //if(subForm.Visible == false)
                //{
                //    subForm.Show();
                //}

                //if (Application.OpenForms["Form11"] != null && Application.OpenForms["Form11"].Visible == true)
                //{
                //    subForm.Visible = false;
                //}else if (Application.OpenForms["Form11"] != null && Application.OpenForms["Form11"].Visible == false)
                //{
                //    subForm.Visible = true;
                //}
                //else
                //{
                //    subForm.Show();
                //}
                //helpform.control_Modify_Form(subForm1);
            }

            if (Columns[e.ColumnIndex].Name == "Delete")//跳转到“删除”窗体
            {
                //弹出对应的窗体事件
                //MessageBox.Show("行: " + e.RowIndex.ToString() + ", 列: " + e.ColumnIndex.ToString() + "; 被点击了");
                //helpform.control_Del_Form(subForm2);
            }
        }
        private void addEditColumn()
        {
            DataGridViewButtonColumn col = new DataGridViewButtonColumn();
            col.Name = "btnEdit";
            col.HeaderText = "操作";
            col.ReadOnly = false;
            //dgv.Columns[1].Frozen = false;
            Columns.Insert(0, col);                //插入 
            Columns[0].Frozen = false;                    //可以设置为冻结列
            Columns[0].Width = 80;
        }

        public void addCheckBox()
        {
            DataGridViewCheckBoxColumn col = new DataGridViewCheckBoxColumn();
            col.Name = "select";
            col.HeaderText = "全选";
            col.ReadOnly = false;
            //dgv.Columns[0].Frozen = false;                    //可以设置为冻结列
            //dgv.Columns[1].Frozen = false;
            Columns.Insert(0, col);                //插入 
            Columns[0].Width = 80;
            //dataGridView1.Columns.Insert(0, dataCheckBox);    //插入  
        }
    }
}