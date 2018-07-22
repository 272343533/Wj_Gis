using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using QyTech.Core;
using QyTech.Core.BLL;
using SunMvcExpress.Dao;

namespace TDObject.UI
{
    public partial class frmLtdQymcQuery : Form
    {
       public frmLtdQymcQuery()
        {
            InitializeComponent();
        }
        //List<企业范围> _ltdobjs;
        private void button1_Click(object sender, EventArgs e)
        {
            MainForm.LtdNameQuery =this.textBox1.Text.Trim();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //public List<企业范围> Ltds
        //{
        //    get { return _ltdobjs; }
        //}


    }
}
