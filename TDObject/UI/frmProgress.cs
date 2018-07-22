using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SunMvcExpress.Dao;
using QyTech.Core;
using QyTech.Core.BLL;
using QyTech.Core.BLL;
using System.Threading;

namespace TDObject
{
    public partial class frmProgress : Form
    {

        public bool m_Terminated = false;
        public int m_step = 2;

        public frmProgress()
        {
            InitializeComponent();
        }
        public bool Increase(int nValue)
        {
          
                if (nValue > 0)
                {
                    if (pbrIng.Value + nValue < pbrIng.Maximum)
                    {
                        pbrIng.Value += nValue;
                    }
                    //else
                    //{
                    //    if (m_step<10)
                    //        m_step += m_step;
                    //    pbrIng.Value = pbrIng.Minimum;
                    //}
                    return true;

                }
                return false;
           
        }

        private void pbrIng_Click(object sender, EventArgs e)
        {
            //this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!m_Terminated)
                Increase(m_step);
            else
                this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
         
                this.label1.Text = "正在取消...";

                TDObject.MapControl.SelectControl.m_TerminatedAnalysis = true;
          
       }

     

    }
}
