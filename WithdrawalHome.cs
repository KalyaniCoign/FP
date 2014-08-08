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
    public partial class WithdrawalHome : Form
    {
        public WithdrawalHome()
        {
            InitializeComponent();
        }

        private void WithdrawalHome_Load(object sender, EventArgs e)
        {
           
            
            label3.Visible = false;
            label4.Visible = false;
            label2.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            textBox2.Visible = false;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            btnlgout.Visible = false;
            label6.Visible = false;
        }

           

        private void button5_Click(object sender, EventArgs e)
        {
             StaticClass.accno = txtAccNo.Text;
             txtAccNo.Enabled = false;
             button5.Visible = false;

            SqlConnection cn = new SqlConnection(ConfigurationSettings.AppSettings["conn"].ToString());
            cn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = cn;

            cmd.CommandText = "select top 1 AmountAvailable,TransMode from User_transaction_table where AccountNo='" + StaticClass.accno + "' order by transactionid  desc ";
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
                label7.Visible = true;
                label8.Visible = true;
                textBox2.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                btnlgout.Visible = true;
                label6.Visible = true;

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
        //        SqlDataReader sdr1;
        //        sdr1 = cmd.ExecuteReader();
        //        if (sdr1.Read())
        //        {

                   
        //            cmd.CommandText = "select *from User_transaction_table where AccountNo='" + StaticClass.accno.ToString() + "' and TransMode='credit' ";
        //            cmd.Connection = cn;
        //            if (Convert.ToBoolean(cn.State) == true)
        //                cn.Close();
        //            cn.Open();
        //            SqlDataReader sdr2;
        //            sdr2 = cmd.ExecuteReader();
        //            if (sdr2.Read())
        //            {
        //                StaticClass.bal = sdr1[1].ToString();
        //                label2.Visible = true;
        //                label7.Visible = true;
        //              //  label8.Visible = true;
        //                label2.Text = StaticClass.accno.ToString();
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
        //                    label2.Visible = true;
        //                    label7.Visible = true;
        //                    label8.Visible = true;
        //                    label2.Text = StaticClass.accno.ToString();
        //                    label7.Text = StaticClass.bal.ToString();
        //                    //StaticClass.bal = Convert.ToString (Convert.ToInt32(StaticClass.bal) - Convert.ToInt32(textBox2.ToString()));
        //                    //StaticClass.bal -= Convert.ToInt32(textBox2.ToString());
                            
        //                }

        //            }

        //            cn.Close();
        //        }
            


        //}

        //private void button4_Click(object sender, EventArgs e)
        //{
        //    ExitHome exh = new ExitHome();
        //    exh.Show();
        //    this.Hide();
        //}

        private void button3_Click(object sender, EventArgs e)
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
                result = Convert.ToInt32(StaticClass.bal) - Convert.ToInt32(textBox2.Text);

                cmd.CommandText = "insert into User_transaction_table(AccountNo,AmountAvailable,TransMode,TransDate,TransAmount,CurrentAmount,TransDid) values('" + StaticClass.accno + "','" + result + "','" + StaticClass.accmode + "','" + DateTime.Today.ToShortDateString() + "','" + textBox2.Text + "','" + StaticClass.bal + "','w')";
       //         cmd.CommandText = "update User_transaction_table set BalanceAmount='" + StaticClass.bal + "' where AccountNo='" + StaticClass.accno + "' ";
                int result1 = cmd.ExecuteNonQuery();
                StaticClass.bal = result.ToString();
                if (result1 > 0)
                {
                    // StaticClass.bal-=Convert.ToInt32(textBox2.ToString());
                    label8.Visible = true;
                    label7.Visible = false;
                    label7.Text = StaticClass.bal.ToString();
                    label8.Text = StaticClass.bal.ToString();
                }

                else
                {
                    label8.Text = "balance not sufficient for withdrawal";
                
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
                    result = Convert.ToInt32(StaticClass.bal) - Convert.ToInt32(textBox2.Text);

                    cmd.CommandText = "insert into User_transaction_table(AccountNo,AmountAvailable,TransMode,TransDate,TransAmount,CurrentAmount,TransDid) values('" + StaticClass.accno + "','" + result + "','" + StaticClass.accmode + "','" + DateTime.Today.ToShortDateString() + "','" + textBox2.Text + "','" + StaticClass.bal + "','w')";
                    //cmd.CommandText = "update User_transaction_table set BalanceAmount='" + StaticClass.bal + "' where AccountNo='" + StaticClass.accno + "' ";
                    int result2 = cmd.ExecuteNonQuery();
                    StaticClass.bal = result.ToString();
                    if (result2 > 0)
                    {

                        label8.Visible = true;
                        label7.Visible = false;
                        label7.Text = StaticClass.bal.ToString();
                        label8.Text = StaticClass.bal.ToString();

                    }
                    // StaticClass.bal-=Convert.ToInt32(textBox2.ToString());
                    else
                    {
                        label8.Text = " balance not sufficient for withdrawal";
                    }

                }
                else
                {
                    MessageBox.Show("Improper account type");
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (StaticClass.acctype == "current" && StaticClass.accmode == "credit")
            {
                textBox2.Text = string.Empty;
            }
            if (StaticClass.acctype == "saving" && StaticClass.accmode == "debit")
            {
                textBox2.Text = string.Empty;
            }
        }

        private void btnlgout_Click(object sender, EventArgs e)
        {
            ExitHome eh = new ExitHome();
            eh.Show();
            
            this.Hide();
        }

       
    }
}
