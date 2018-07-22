using QyTech.Json;
using SunMvcExpress.Dao;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TDObject.BLL;

namespace TDObject.UI
{
    public class dgvCommDisplay
    {
        public static DataGridView InitDisp(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(dgv_AddNoColumn);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.Bisque;
            dgv.RowsDefaultCellStyle.BackColor = Color.Beige;
            return dgv;
        }

        private static void dgv_AddNoColumn(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }
    }
}
