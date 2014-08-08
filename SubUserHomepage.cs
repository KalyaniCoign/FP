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
    public partial class SubUserHomepage : Form
    {
        public SubUserHomepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //code for withdrawal
            
            if (StaticClass.acctype == "current")
            {
                StaticClass.accmode = "credit";
                WithdrawalHome w = new WithdrawalHome();
                w.Show();
                this.Hide();
            }

            else
                if (StaticClass.acctype == "saving")
                {

                    StaticClass.accmode = "debit";
                    WithdrawalHome w1 = new WithdrawalHome();
                    w1.Show();
                    this.Hide();
               
                }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //code for deposit

            if (StaticClass.acctype == "current")
            {
                StaticClass.accmode = "credit";

                DepositHome d = new DepositHome();
                d.Show();
                this.Hide();
            }

            else
                if (StaticClass.acctype == "saving")
                {
                    StaticClass.accmode = "debit";
                    DepositHome d1 = new DepositHome();
                    d1.Show();
                    this.Hide();
                
               }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChangePasswordform ch = new ChangePasswordform();
            ch.Show();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            UserHome uh = new UserHome();
            uh.Show();
            this.Hide();
        }
    }
}
