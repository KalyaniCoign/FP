using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ATM_on_Finger__Password_processing
{
    public partial class ExitHome : Form
    {
        public ExitHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Mainform mf = new Mainform();
            mf.Show();
            this.Hide();
        }
    }
}
