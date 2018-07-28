using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;

namespace TDObject
{
      
    public static class FormSkin
    {
         [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;

        public static void MouseMoveForm(IntPtr handle)
        {
            ReleaseCapture();
            SendMessage(handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public static  DataGridViewCellStyle DgvDefaultAlterCellStyle{
            get{
                return new DataGridViewCellStyle { BackColor =Color.FromArgb(255, 255, 224, 192)};
                }
        }

        public static Color FormBackColor
        {
            get { return SystemColors.GradientInactiveCaption; }
        }

        public static void FormInitSetting(Form frmobj)
        {
            frmobj.BackColor = SystemColors.GradientInactiveCaption;
            frmobj.StartPosition = FormStartPosition.CenterScreen;
        }

        public static void ShowForm(Form frm)
        {
            FlatFormWithTop pfrm = new FlatFormWithTop(frm);
            pfrm.Show();
        }

        public static void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);

            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);


        }
    }
}
