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

namespace ATM_on_Finger__Password_processing
{
    public partial class DepositHome : Form
    {
        public DepositHome()
        {
            InitializeComponent();
        }

        private void DepositHome_Load(object sender, EventArgs e)
        {
            //label6.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label3.Visible = false;
            label7.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            label5.Visible = false;
            label8.Visible = false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StaticClass.accno = txtAccNo.Text;
            txtAccNo.Enabled = false;
            button3.Visible = false;

            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.CommandText = "select top 1 AmountAvailable,TransMode from User_transaction_table where AccountNo='" + StaticClass.accno + "' order by transactionid  desc";
            SqlDataReader sdr;
            sdr = cmd.ExecuteReader();
            if (sdr.Read())
            {
                StaticClass.bal = sdr[0].ToString();
                StaticClass.accmode = sdr[1].ToString();

                label7.Text = StaticClass.bal;
                label3.Visible = true;
                label4.Visible = true;
                // label2.Visible = true;
               // label6.Visible = true;
                label7.Visible = true;
                label8.Visible = true;
                label3.Visible = true;
                label7.Visible = true;
                label4.Visible = true;
                textBox3.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                label5.Visible = true;
                label8.Visible = true;

            }

            else
            {
                MessageBox.Show("please enter correct Account No");

                //label2.Text = "please enter correct Account No";
                //label2.Visible = true;
            }

        }

        //    if (StaticClass.acctype == "current" && StaticClass.accmode == "credit")
        //    {


        //        SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
        //        cn.Open();
        //        SqlCommand cmd = new SqlCommand();
        //        cmd.CommandType = CommandType.Text;
        //        cmd.Connection = cn;

        //        cmd.CommandText = "select *from User_credentials_table where password='" + StaticClass.pwd.ToString() + "' and TransType='current' ";
        //        SqlDataReader sdr;
        //        sdr = cmd.ExecuteReader();
        //        if (sdr.Read())
        //        {

        //            StaticClass.accno = sdr[2].ToString();
        //            cmd.CommandText = "select *from User_transaction_table where AccountNo='" + StaticClass.accno.ToString() + "' and TransMode='credit' ";
        //            cmd.Connection = cn;
        //            if (Convert.ToBoolean(cn.State) == true)
        //                cn.Close();
        //            cn.Open();
        //            SqlDataReader sdr1;
        //            sdr1 = cmd.ExecuteReader();
        //            if (sdr1.Read())
        //            {
        //                StaticClass.bal = sdr1[1].ToString();

        //                label6.Visible = true;
        //                label7.Visible = true;
        //               // label8.Visible = true;
        //                label6.Text = StaticClass.accno.ToString();
        //                label7.Text = StaticClass.bal.ToString();
                        
        //            }

        //        }
        //        cn.Close();

        //    }

        //    else
        //        if (StaticClass.acctype == "saving" && StaticClass.accmode == "debit")
        //        {


        //            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
        //            cn.Open();
        //            SqlCommand cmd = new SqlCommand();
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Connection = cn;
        //            cmd.CommandText = "select *from User_credentials_table where password='" + StaticClass.pwd.ToString() + "' and TransType='saving' ";
        //            SqlDataReader sdr;
        //            sdr = cmd.ExecuteReader();
        //            if (sdr.Read())
        //            {

        //                StaticClass.accno = sdr[2].ToString();
        //                cmd.CommandText = "select *from User_transaction_table where AccountNo='" + StaticClass.accno.ToString() + "'  and TransMode='debit' ";
        //                if (Convert.ToBoolean(cn.State) == true)
        //                    cn.Close();
        //                cn.Open();
        //                cmd.Connection = cn;
        //                SqlDataReader sdr1;

        //                sdr1 = cmd.ExecuteReader();
        //                if (sdr1.Read())
        //                {
        //                    StaticClass.bal = sdr1[1].ToString();
        //                    label6.Visible = true;
        //                    label7.Visible = true;
        //                    label8.Visible = true;
        //                    label6.Text = StaticClass.accno.ToString();
        //                    label7.Text = StaticClass.bal.ToString();
        //                    //StaticClass.bal = Convert.ToString (Convert.ToInt32(StaticClass.bal) - Convert.ToInt32(textBox2.ToString()));
        //                    //StaticClass.bal -= Convert.ToInt32(textBox2.ToString());
                            
        //                }

        //            }

        //            cn.Close();
        //        }
            


        //}

        private void button2_Click(object sender, EventArgs e)
        {
            ExitHome eh = new ExitHome();
            eh.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (StaticClass.acctype == "current" && StaticClass.accmode == "credit")
            {

                SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
                cn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.Connection = cn;

                
                
                int result;
                // string text2 = textBox2.Text;
                result = Convert.ToInt32(StaticClass.bal) + Convert.ToInt32(textBox3.Text);
                cmd.CommandText = "insert into User_transaction_table(AccountNo,AmountAvailable,TransMode,TransDate,TransAmount,CurrentAmount,TransDid) values('" + StaticClass.accno + "','" + result + "','" + StaticClass.accmode + "','" + DateTime.Today.ToShortDateString() + "','" + textBox3.Text + "','" + StaticClass.bal + "','d')";
  
                
               // cmd.CommandText = "update User_transaction_table set BalanceAmount='" + StaticClass.bal + "' where AccountNo='" +StaticClass.accno +"' ";

                int res1 = cmd.ExecuteNonQuery();

                StaticClass.bal = result.ToString();
                if (res1 > 0)
                {
                    // StaticClass.bal-=Convert.ToInt32(textBox2.ToString());
                    label8.Visible = true;
                    label7.Text = StaticClass.bal;
                    label8.Text = StaticClass.bal.ToString();
                }
                else 
                {
                    label8.Text = "please verify your account no";
                }
            }
            else
                if (StaticClass.acctype == "saving" && StaticClass.accmode == "debit")
                {
                    SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
                    cn.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = cn;



                    int result;
                    // string text2 = textBox2.Text;
                    result = Convert.ToInt32(StaticClass.bal) + Convert.ToInt32(textBox3.Text);
                    cmd.CommandText = "insert into User_transaction_table(AccountNo,AmountAvailable,TransMode,TransDate,TransAmount,CurrentAmount,TransDid) values('" + StaticClass.accno + "','" + result + "','" + StaticClass.accmode + "','" + DateTime.Today.ToShortDateString() + "','" + textBox3.Text + "','" + StaticClass.bal + "','d')";
                    //    cmd.CommandText = "update User_transaction_table set BalanceAmount='" + StaticClass.bal + "' where AccountNo='" + StaticClass.accno + "' ";
                    int res2 = cmd.ExecuteNonQuery();
                    StaticClass.bal = result.ToString();

                    if (res2 > 0)
                    {
                        // StaticClass.bal-=Convert.ToInt32(textBox2.ToString());
                        label8.Visible = true;
                        label7.Text = StaticClass.bal;
                        label8.Text = StaticClass.bal.ToString();
                    }
                    else
                    {
                        label8.Text = "please verify your account number";
                    }
                }
                else
                {
                    MessageBox.Show("Improper account type");
                
                }
                
        }

        
    }
}
