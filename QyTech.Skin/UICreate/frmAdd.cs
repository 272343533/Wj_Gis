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
using QyTech.Auth.Dao;

using System.Reflection;

using QyTech.Core.BLL;

namespace QyTech.SkinForm.UICreate
{
    public partial class frmAdd : qyForm
    {
        string addormodify = "add";
        List<QyTech.Auth.Dao.bsFunField> funfields;
        bsFunConf bsFc;
        object obj_;
        string objtype_;


        public static EntityManager QyTech_EM = new EntityManager(new QyTech.Auth.Dao.QyTech_AuthEntities());

        public frmAdd(string objtype, object obj = null)
        {
            InitializeComponent();
            objtype_ = objtype;
            //bsFc=MainForm.QyTech_EM.getbyp
            if (obj != null)
            {
                addormodify = "modify";
                obj_ = obj;

            }
            else
            {
                Assembly ass = Assembly.LoadFrom(@"SunMvcExpress.Dao.dll");
                Type type = ass.GetType("SunMvcExpress.Dao." + objtype_);
                obj_ = Activator.CreateInstance(type);
            }
            InitFrom();
        }
        private void frmAdd_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;

            this.btnClose.Image = qyResources.GetImage(ImageSource.exit_16);
            this.btnSave.Image = qyResources.GetImage(ImageSource.save_16);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void InitFrom()
        {
            lblTitle.Text = objtype_;


            funfields = QyTech_EM.GetListNoPaging<bsFunField>("TName='企业范围' and VisibleInForm=1", "NoInForm");



            int num = -1;
            int LocationX, LocationY;
            int colCount = (int)Math.Ceiling(funfields.Count/13.0);

            foreach (bsFunField ff in funfields)
            {
                if (ff.VisibleInForm != false && ff.FEditType!=null && "select,text".Contains(ff.FEditType))
                {
                    num++;
                    LocationX = num % colCount * 250;
                    LocationY = 10 + num / colCount * 45;

                    string cname = ff.FDesp;


                    string Fvalue = QyTechReflection.GetObjectPropertyValue(obj_, ff.FName);

                    if (ff.FEditType == "select")//combox
                    {
                        UICreate.CreateCombobox(gbContainer, ff.FDesp, ff.FName, ff.FEditValueEx, Fvalue, LocationX, LocationY);
                    }
                    else if (ff.FEditType == "text")
                    {
                        //text
                        UICreate.CreateTextDisplay(gbContainer, ff.FDesp, ff.FName, Fvalue, LocationX, LocationY);
                    }

                }

            }

            this.Height = 90 + num / colCount * 45;
            this.Width += 250 * (colCount - 1);

            this.lblTitle.Location = new Point(this.Width / 2 - System.Text.Encoding.Default.GetBytes(this.lblTitle.Text).Length*10/2, lblTitle.Location.Y);

            this.btnSave.Location = new Point(this.Width / 2 -this.btnSave.Width- 100, btnSave.Location.Y);
            this.btnClose.Location = new Point(this.Width / 2 + 100, btnClose.Location.Y);
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                foreach (bsFunField ff in funfields)
                {

                    if (ff.VisibleInForm != false && "select,text".Contains(ff.FEditType))
                    {
                        try
                        {
                            if(gbContainer.Controls[ff.FName].Text=="")
                                continue;

                            var property = obj_.GetType().GetProperty(ff.FName);
                            if (ff.OType == "string")
                                property.SetValue(obj_, gbContainer.Controls[ff.FName].Text);
                            else if (ff.OType=="decimal")
                                property.SetValue(obj_, Convert.ToDecimal(gbContainer.Controls[ff.FName].Text));
                            else if (ff.OType=="datetime")
                                property.SetValue(obj_, Convert.ToDecimal(gbContainer.Controls[ff.FName].Text));
                            else if (ff.OType=="int")
                                property.SetValue(obj_, Convert.ToInt32(gbContainer.Controls[ff.FName].Text));
                            //property.SetValue(obj_, (decimal)Convert.ChangeType(gbContainer.Controls[ff.FName].Text, property.PropertyType), null);

                        }
                        catch (Exception ex) { log.Error(ff.FName + ":" + ex.Message); }
                    }

                }
                Type t = obj_.GetType();

                string detailUrl = "";// MainForm.App_URI + "lyRemoteServ/UpdGisObj?TType=" + TType + "&json=" + json;

                string ret = AsyncHttp.CommFun.GetRemoteJson(detailUrl);

                if (ret == "")
                {
                    MessageBox.Show("保存成功！");
                }
                else
                {
                    MessageBox.Show("保存失败!(" + ret + ")");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

     
    }
}
