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
    public partial class login : Form
    {
        public static string uname, upass;
        public login()
        {
            InitializeComponent();
            txt5.PasswordChar = '*';
        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {
            lbl3.Text = "";
            pnl3.BackColor = Color.FromArgb(51, 122, 183);
            txt3.ForeColor = Color.FromArgb(51, 122, 183);

            pnl5.BackColor = Color.WhiteSmoke;
            txt5.ForeColor = Color.White;
        }

        private void txt5_TextChanged(object sender, EventArgs e)
        {
            lbl5.Text = "";
            pnl5.BackColor = Color.FromArgb(51, 122, 183);
            txt5.ForeColor = Color.FromArgb(51, 122, 183);

            pnl3.BackColor = Color.WhiteSmoke;
            txt3.ForeColor = Color.White;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txt3.Text = "";
            txt5.Text = "";
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            uname = txt3.Text;
              upass = txt5.Text;

            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
            string qry = "SELECT * FROM SignUp WHERE username ='" + uname + "'  AND password ='" + upass + "' ";

            SqlCommand cmd = new SqlCommand(qry, con);

            try
            {
                if (uname != "" && upass != "")
                {
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        Home h = new Home();

                        h.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorecct Username and Password");
                        txt3.Text = "";
                        txt5.Text = "";
                    }
                }
                else
                {
                    MessageBox.Show("Fill the feilds to login");
                }
                
            }
            catch(SqlException se)
            {
                MessageBox.Show("" + se);
            }

        }
    }
}
