using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace ATM_on_Finger__Password_processing
{
    public partial class ChangePasswordform : Form
    {
        public ChangePasswordform()
        {
            InitializeComponent();
        }

        private void ChangePasswordform_Load(object sender, EventArgs e)
        {

            label5.Visible = false;
            //label6.Visible = false;
        }



        private void button2_Click(object sender, EventArgs e)
        {
            //ExitHome eh = new ExitHome();
            eh.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SubUserHomepage sh = new SubUserHomepage();
            sh.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;
            cmd.CommandText = "select *from User_table where password='"+textBox2.Text+"' ";
            
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                int userid = Convert.ToInt32(sdr[0].ToString());

                cmd.CommandText = "update User_table set password='" + textBox3.Text + "'where userid="+userid+" ";
                cmd.Connection = cn;
                if (Convert.ToBoolean(cn.State) == true)
                    cn.Close();
                cn.Open();
                int result = cmd.ExecuteNonQuery();
               // SqlDataReader sdr1;
                //sdr1 = cmd.ExecuteReader();
                if (result>0)

                {

                    label5.Visible = true;
                    //label6.Visible = true;
                    label5.Text = "password changed successfully ";
                   // label6.Text = sdr1[2].ToString();
                }
            }

            cn.Close();


        }
    }
}
