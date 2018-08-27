using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace QyTech.SkinForm.UICreate
{
    public class UICreate
    {
        public static void CreateTextDisplay( GroupBox gbContainer,string labText, string FName,object FValue, int x, int y, int labwidth = 90, int textwidth = 150)
        {
            Label l = new Label();
            l.Name = "lbl_" + FName;
            l.Text = labText;
            l.Location = new System.Drawing.Point(x, y);//(300,...)
            l.Width = labwidth;
            l.TextAlign = ContentAlignment.MiddleRight;
            gbContainer.Controls.Add(l);

            TextBox tb = new TextBox();
            tb.Location = new System.Drawing.Point(x + 100, y);
            tb.Width = textwidth;
            tb.Name = FName;
            tb.Text = FValue.ToString();
            gbContainer.Controls.Add(tb);
        }
        public static void CreateCombobox(GroupBox gbContainer, string labText, string FName, string items, object FValue, int x, int y, int labwidth = 90, int comboxwidth = 150)
        {
            Label l = new Label();
            l.Text = labText;
            l.Location = new System.Drawing.Point(x, y);
            l.Width = labwidth;
            l.TextAlign = ContentAlignment.MiddleRight;
            gbContainer.Controls.Add(l);

            ComboBox cb = new ComboBox();
            cb.Location = new System.Drawing.Point(x + 100, y);
            cb.Width = comboxwidth;
            cb.Name = FName;
            int index = 0;
            if (items.Trim() != "")
            {
                string[] sitems = items.Split(new char[] { ',' });
                cb.Items.Clear();
                cb.Items.Add("");
                foreach (string s in sitems)
                {
                    cb.Items.Add(s);
                }
                for (int i = 0; i < cb.Items.Count; i++)
                    if (cb.Items[i].ToString() == FValue.ToString())
                    { index = i; break; }

            }

            cb.SelectedIndex = index;
            gbContainer.Controls.Add(cb);
        }
    }
}
