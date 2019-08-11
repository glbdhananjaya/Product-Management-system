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
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            lbl3.Text = "";
            pnl3.BackColor = Color.FromArgb(51, 122, 183);
            txt3.ForeColor = Color.FromArgb(51, 122, 183);

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt4_TextChanged(object sender, EventArgs e)
        {
            lbl4.Text = "";
            pnl4.BackColor = Color.FromArgb(51, 122, 183);
            txt4.ForeColor = Color.FromArgb(51, 122, 183);

           

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

           

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            lbl5.Text = "";
            pnl5.BackColor = Color.FromArgb(51, 122, 183);
            txt5.ForeColor = Color.FromArgb(51, 122, 183);

          

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

         

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            lbl6.Text = "";
            pnl6.BackColor = Color.FromArgb(51, 122, 183);
            txt6.ForeColor = Color.FromArgb(51, 122, 183);

           

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;

            pnl4.BackColor = Color.WhiteSmoke;
            txt4.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;

           
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Home d = new Home();
            d.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {

                string Cname = txt3.Text;
                string Cmail = txt4.Text;
                string Ctel = txt5.Text;
                string Cadd = txt6.Text;



                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");



                System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-z][a-zA-Z\.]*[a-zA-Z]$");
                if (txt4.Text.Length > 0)
                {
                        if (!rEmail.IsMatch(txt4.Text))
                        {
                            MessageBox.Show("Invalid EmailAddress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txt4.SelectAll();

                            MessageBox.Show("Invalid Email Address");
                            txt3.Text = "";
                            txt4.Text = "";
                            txt5.Text = "";
                            txt6.Text = "";
                        }
                        else if (Cname != "" && Cmail != "" && Ctel != "" && Cadd != "")
                        {
                            string qry = "INSERT INTO Customer VALUES ('" + Cname + "','" + Cmail + "','" + Ctel + "','" + Cadd + "')";
                            SqlCommand cmd = new SqlCommand(qry, con);
                            con.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Data Inserted successfully");
                        }
                      
                }
                else
                {
                    MessageBox.Show("Fill All the Feilds");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
        }
    }
}
