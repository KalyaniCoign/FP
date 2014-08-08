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
    public partial class Mainform : Form
    {
        public Mainform()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select *from User_credentials_table where password='" + textBox1.Text + "' and AccountNo='"+txtAccno.Text+"' ";
            cmd.Connection = cn;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                StaticClass.pwd = sdr[2].ToString();
                StaticClass.name = sdr[3].ToString();
                //MessageBox.Show(sdr[2].ToString());

                // MessageBox.Show("successful login ");

                UserHome uh = new UserHome();
                uh.Show();
                this.Hide();
            }


            else
            {
                //MessageBox.Show("invalid login");
                InvalidLoginForm inf = new InvalidLoginForm();
                inf.Show();
                this.Hide();

            }
            cn.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
            this.Hide();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegistrationForm rf = new RegistrationForm();
            rf.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from User_credentials_table ";
            //cmd.Parameters.Add("@imagepath", SqlDbType.Image);
           
            //cmd.Parameters["@imagepath"].Value = i;
            cmd.Connection = cn;
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
             int status=0;
          while(sdr.Read())
            {
                //mycode
                byte[] b2 = new byte[2000];
                b2 = (byte[])sdr[1];
                int index=0;
                status = 0;
                while (index < 2000)
                {
                    if (b[index] != b2[index])
                    {
                        status = 1;
                        break;      
                    }
                    index++;
                }
                ////MemoryStream ms1 = new MemoryStream(b2,0,2000,false);
                ////Image i1 = Image.FromStream(ms1);
                //MemoryStream ms2=new MemoryStream(b);
                //BufferedStream bs = new BufferedStream(ms2);
                //Image i2 = Image.FromStream();
                if (status==0)
                {
                    StaticClass.pwd = sdr[2].ToString();
                    StaticClass.name = sdr[3].ToString();
                    //MessageBox.Show(sdr[2].ToString());

                    MessageBox.Show("successful login ");

                    UserHome uh = new UserHome();
                    uh.Show();
                    this.Hide();
                    break;

                }
                
                //cn.Close();
                //end my code


                ////StaticClass.pwd = sdr[2].ToString();
                ////StaticClass.name = sdr[1].ToString();
                //////MessageBox.Show(sdr[2].ToString());

                ////// MessageBox.Show("successful login ");

                ////UserHome uh = new UserHome();
                ////uh.Show();
                ////this.Hide();
            }

            if(status==1)
                {
                    //MessageBox.Show("invalid login");
                    InvalidLoginForm inf = new InvalidLoginForm();
                    inf.Show();
                    this.Hide();
                   
                }
            //else
            //{
            //    //MessageBox.Show("invalid login");
            //    InvalidLoginForm inf = new InvalidLoginForm();
            //    inf.Show();
            //    this.Hide();

            //}
            cn.Close();
        }
        byte[] b;
        Image i;
        private void button3_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                b = new byte[2000];
                i= Image.FromFile(openFileDialog1.FileName);

               
                FileStream f = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read, FileShare.Read);

                f.Read(b, 0, 2000);


            }
        }

       
          }
}
