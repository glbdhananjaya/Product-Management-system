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
    public partial class Admin : Form
    {
        public static string Aname, pword;
        public Admin()
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                 Aname = txt3.Text;
                 pword = txt5.Text;

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
                string qry = "select * from SignUp where username='" + Aname + "' AND  password='" + pword + "'";

                SqlCommand cmd = new SqlCommand(qry, con);

                try
                {
                    if (Aname == "DeepalA" && pword == "da123")
                    {
                        con.Open();
                        cmd.ExecuteNonQuery();

                        AdminPanel ap = new AdminPanel();
                        ap.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorecct Username and Password");
                        txt3.Text = "";
                        txt5.Text = "";
                    }
                    
                  

                }
                catch (SqlException se)
                {
                    MessageBox.Show("" + se);
                }


            }
            catch(SqlException es)
            {
                MessageBox.Show("" + es);
            }




        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txt3.Text = "";
            txt5.Text = "";
        }
    }
}
