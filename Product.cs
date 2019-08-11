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
    public partial class Product : Form
    {
        public Product()
        {
            InitializeComponent();
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
                string Pid = txtpro.Text;
                string pcolorcode = txtcol.Text;  
                string shift = string.Empty;
                if (rdb1.Checked)
                {
                    shift = "Morning";
                }
                else
                {
                    shift = "Evening";
                } 
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
                if (Pid != "" && txtcol.Text != "" && shift != "")
                {
                    string qry = "INSERT INTO product VALUES ('" + Pid + "','" + pcolorcode + "','" + shift + "','" + dtpproduct.Value.Date + "')";
                    SqlCommand cmd = new SqlCommand(qry, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully");
                }
                else
                {
                    MessageBox.Show("Fill all the fields");
                }
            }
            catch(SqlException se)
            {
                MessageBox.Show("" + se);
            }

            txtpro.Text = "";
            txtcol.Text = "";
        }
        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txtpro.Text = "";
            txtcol.Text = "";
        }

        private void txtpro_TextChanged(object sender, EventArgs e)
        {
           
            pnl1.BackColor = Color.FromArgb(51, 122, 183);
            txtpro.ForeColor = Color.FromArgb(51, 122, 183);

            pnl4.BackColor = Color.WhiteSmoke;
            txtcol.ForeColor = Color.White;
        }

        private void txtcol_TextChanged(object sender, EventArgs e)
        {
            pnl2.BackColor = Color.FromArgb(51, 122, 183);
            txtcol.ForeColor = Color.FromArgb(51, 122, 183);

            pnl1.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }
    }
}
