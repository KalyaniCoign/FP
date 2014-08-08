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
    public partial class UserHome : Form
    {
        public UserHome()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            StaticClass.acctype = "current";
            SubUserHomepage su = new SubUserHomepage();
            su.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            StaticClass.acctype = "saving";
            SubUserHomepage su1 = new SubUserHomepage();
            su1.Show();
            this.Hide();
        }

        private void UserHome_Load(object sender, EventArgs e)
        {
            label2.Text = StaticClass.name;
        }
    }
}
