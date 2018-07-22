using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TDObject
{
    public partial class FlatForm : Form
    {
        protected log4net.ILog log = log4net.LogManager.GetLogger(" TDObject.BLL FlatForm");

        public FlatForm()
        {
            InitializeComponent();
            this.BackColor = SystemColors.GradientInactiveCaption;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ShowInTaskbar = true;
        }

        private void FlatForm_MouseMove(object sender, MouseEventArgs e)
        {
            FormSkin.MouseMoveForm(this.Handle);
        }

        private void FlatForm_Load(object sender, EventArgs e)
        {

        }

     
    }
}
