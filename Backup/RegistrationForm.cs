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
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_Load(Object sender,EventArgs e)
        {
            label11.Visible = false;
            label12.Visible = false;
            label13.Visible = false;
        
        
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn".ToString()]);
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            SqlCommand cmd1 = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into User_table(username,password,FingerPassword,Address,Phno) values('" + textBox1.Text + "','" + textBox2.Text + "','" + b + "','" + textBox4.Text + "','" + textBox5.Text + "')";
            cmd.ExecuteNonQuery();
            // generating account no
            SqlCommand cmd2 = new SqlCommand();
            cmd2.CommandText = "sp_GenerateRandomNumber";
            cmd2.Connection=cn;
            cmd2.CommandType = CommandType.StoredProcedure;
            SqlParameter sp = new SqlParameter();
            sp.ParameterName = "@RndNumber";
            sp.DbType = DbType.String;
            sp.Size = 100;
            sp.Direction = ParameterDirection.Output;
            cmd2.Parameters.Add(sp);
            cmd2.ExecuteNonQuery();
            string accno = cmd2.Parameters["@RndNumber"].Value.ToString();


            //end generating account no
            
            //inserting the initial amount

            SqlCommand cmd3 = new SqlCommand();
            cmd3.CommandType = CommandType.Text;
            cmd3.Connection = cn;
            //////if (comboBox1.SelectedItem.ToString() == "saving")
            //////    cmd3.CommandText = "insert into User_transaction_table values('" + accno + "','" + textBox8.Text + "','debit','" + DateTime.Today.ToShortDateString() + "',0,'" + textBox8.Text + "','d')";
            //////else
            //////cmd3.CommandText = "insert into User_transaction_table values('" + accno + "','" + textBox8.Text + "','credit','" + DateTime.Today.ToShortDateString() + "',0,'"+textBox8.Text+"','d')";
            //////cmd3.ExecuteNonQuery();
            ////////end inserting the initial amount
            //////cmd1.CommandText = "insert into User_credentials_table(password,FingerPassword,username,BankName,BranchName,TransType,AccountNo) values('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + accno + "') ";
            //////cmd1.Connection = cn;
            //////int result = cmd1.ExecuteNonQuery();

            if (comboBox1.SelectedItem.ToString() == "saving")
                cmd3.CommandText = "insert into User_transaction_table values('" + accno + "','" + textBox8.Text + "','debit','" + DateTime.Today.ToShortDateString() + "',0,'" + textBox8.Text + "','d')";
            else
                cmd3.CommandText = "insert into User_transaction_table values('" + accno + "','" + textBox8.Text + "','credit','" + DateTime.Today.ToShortDateString() + "',0,'" + textBox8.Text + "','d')";
            
            cmd3.ExecuteNonQuery();
            //end inserting the initial amount
            cmd1.CommandText = "insert into User_credentials_table(password,FingerPassword,username,BankName,BranchName,TransType,AccountNo) values('" + textBox2.Text + "',@imagepath,'" + textBox1.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + accno + "') ";
            cmd1.Connection = cn;
            cmd1.Parameters.Add("@imagepath", SqlDbType.Image);
            cmd1.Parameters["@imagepath"].Value = b;
            int result = cmd1.ExecuteNonQuery();
            if (result > 0)
            {

                label11.Visible = true;
                label12.Text = accno;
            }
            else
                label13.Visible = true;


        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }
        byte[] b;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                b = new byte[2000];
                Image i = Image.FromFile(openFileDialog1.FileName);

                textBox3.Text = openFileDialog1.FileName;
                FileStream f = new FileStream(openFileDialog1.FileName,FileMode.Open,FileAccess.Read,FileShare.Read);

                f.Read(b,0,2000);


            }
        }

           }
}
