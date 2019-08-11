using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace srinko2
{
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
            txt5.PasswordChar = '*';
            txt6.PasswordChar = '*';
        }

        private void pictureBox6_Click_1(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {
            lbl1.Text = "";
            pnl1.BackColor = Color.FromArgb(51, 122, 183);
            txt1.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txt2.ForeColor = Color.White;

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt2_TextChanged_1(object sender, EventArgs e)
        {
            lbl2.Text = "";
            pnl2.BackColor = Color.FromArgb(51, 122, 183);
            txt2.ForeColor = Color.FromArgb(51, 122, 183);

            pnl1.BackColor = Color.WhiteSmoke;
            txt1.ForeColor = Color.White;

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt3_TextChanged_1(object sender, EventArgs e)
        {
            lbl3.Text = "";
            pnl3.BackColor = Color.FromArgb(51, 122, 183);
            txt3.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txt2.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txt1.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt4_TextChanged_1(object sender, EventArgs e)
        {
            lbl4.Text = "";
            pnl4.BackColor = Color.FromArgb(51, 122, 183);
            txt4.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txt2.ForeColor = Color.White;

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txt1.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt5_TextChanged_1(object sender, EventArgs e)
        {
            lbl5.Text = "";
            pnl5.BackColor = Color.FromArgb(51, 122, 183);
            txt5.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txt2.ForeColor = Color.White;

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txt1.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt6_TextChanged_1(object sender, EventArgs e)
        {
            lbl6.Text = "";
            pnl6.BackColor = Color.FromArgb(51, 122, 183);
            txt6.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txt2.ForeColor = Color.White;

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txt1.ForeColor = Color.White;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string fname = txt1.Text;
            string lname = txt2.Text;
            string uname = txt3.Text;
            string umail = txt4.Text;
            string upass = txt5.Text;
            string uconpass = txt6.Text;

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
                System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-z][a-zA-Z\.]*[a-zA-Z]$");
                if (txt4.Text.Length > 0)
                {
                    if (!rEmail.IsMatch(txt4.Text))
                    {
                        MessageBox.Show("Invalid EmailAddress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt4.SelectAll();

                        MessageBox.Show("Invalid Email Address");
                        txt1.Text = "";
                        txt3.Text = "";
                        txt4.Text = "";
                        txt5.Text = "";
                        txt6.Text = "";
                    }
                    else if (fname != "" && lname != "" && uname != "" && umail != "" && upass!=""&&uconpass!="")
                    {
                        if (upass == uconpass)
                        {
                            string qry = "INSERT INTO SignUp VALUES ('" + fname + "','" + lname + "','" + uname + "','" + umail + "','" + upass + "','" + uconpass + "')";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            con.Open();
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Signedup Successfully");

                            login f = new login();
                            f.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Password Mismatch");
                    }

                }
                else
                {
                    MessageBox.Show("Fill all the fields");
                }
            
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txt1.Text = "";
            txt2.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
        }
    }
}
