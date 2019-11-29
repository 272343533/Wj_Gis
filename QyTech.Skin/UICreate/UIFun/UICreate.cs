﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

using QyTech.Auth.Dao;

namespace QyTech.SkinForm.UICreate
{
    public class UICreate
    {

        public static void CreateFormEditPart(object obj, List<bsFunField> ffs, GroupBox gbParent, ref int gbwidth, ref int gbheight)
        {
            int InitLocationX = 0, InitLocationY = 5;//初始从相对于gbParnet的位置开始铺设

            int stepX = 260;//没列输入站的宽度
            int stepY = 40;//每行之间的像素距离
            int num = -1;//移动的控件数
            int colCount = 1;


            int lblWidth = 90;
            int betweenWidth = 5;
            int EditWidhth = 150;
            int ColumnWidth = lblWidth + betweenWidth + EditWidhth;

            int LocationX, LocationY;
            if (ffs == null)
                return;
            if (ffs.Count > 0)
            {


                colCount = (int)Math.Ceiling(ffs.Count / 13.0);//每列最多十三行，进行列扩充

                LocationX = InitLocationX;
                LocationY = InitLocationY;

                foreach (bsFunField ff in ffs)
                {
                    if (ff.FName == "ID")
                        continue;
                    if (ff.FEditType != null && "select,text,multext".Contains(ff.FEditType))
                    {
                        num++;
                        LocationX = InitLocationX + num % colCount * stepX;
                        LocationY = InitLocationY + num / colCount * stepY;
                        //LocationX +=  num % colCount * stepX;
                        //LocationY +=  num / colCount * stepY;

                        string cname = ff.FDesp;


                        string Fvalue = QyTechReflection.GetObjectPropertyValue(obj, ff.FName);

                        if (ff.FEditType == "select")//combox
                        {
                            UICreate.CreateCombobox(gbParent, ff.FDesp, ff.FName, ff.FEditValueEx, Fvalue, LocationX, LocationY);
                        }
                        else if (ff.FEditType == "text")
                        {
                            //text
                            UICreate.CreateTextDisplay(gbParent, ff.FDesp, ff.FName, Fvalue, LocationX, LocationY);
                        }
                        else if (ff.FEditType == "multext")
                        {
                            if (LocationX != InitLocationX)
                            {
                                LocationX = InitLocationX;
                                LocationY += stepY;
                            }
                            //text
                            UICreate.CreateMultiTextDisplay(gbParent, ff.FDesp, ff.FName, Fvalue, LocationX, LocationY, lblWidth, (int)ff.FWidthInForm);

                        }
                       

                    }

                }
            }
            gbheight = num / colCount * stepY;
            if (colCount>1)
                gbwidth = stepX * colCount;
            else
                gbwidth = stepX * colCount+100;

        }
        public static void CreateTextDisplay( GroupBox gbContainer,string labText, string FName,object FValue,int x, int y, object querytag = null, int labwidth = 90, int textwidth = 150)
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
            tb.Tag = querytag;
            gbContainer.Controls.Add(tb);
        }

        public static void CreateMultiTextDisplay(GroupBox gbContainer, string labText, string FName, object FValue, int x, int y, int labwidth = 90, int textwidth = 150)
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
            tb.Multiline = true;
            //tb.Height = 40;
            gbContainer.Controls.Add(tb);
        }
        public static ComboBox CreateCombobox(GroupBox gbContainer, string labText, string FName, string items, object FValue, int x, int y, object itemstag=null, int labwidth = 90, int comboxwidth = 150)
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
            cb.Tag = itemstag;
            int index = 0;
            if (items.Trim() != "")
            {
                string[] sitems = items.Split(new char[] { ',' ,';'});
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
            return cb;
        }
    }
}
