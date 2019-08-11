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
    public partial class CusAdmin : Form
    {
        public CusAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            AdminPanel a1 = new AdminPanel();
            a1.Show();
            this.Hide();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM customer";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "customer");
            dgvpro.DataSource = ds.Tables["customer"];
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            int cid = int.Parse(txtid.Text);
            string Cname = txt3.Text;
            string Cmail = txt4.Text;
            string Ctel = txt5.Text;
            string Cadd = txt6.Text;

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");

                if (Cname != "" && Cmail != "" && Ctel != "" && Cadd != "")
                {
                    string update = "UPDATE Customer SET CuName='" + Cname + "',CuMail='" + Cmail+"',CuTel='"+Ctel+"',CuAdd='"+Cadd+ "' WHERE CId='"+cid+"'";
                    SqlCommand cmd = new SqlCommand(update, con);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated successfully");
                }
                else
                {
                    MessageBox.Show("Fill All the Blanks to Update");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }

            txtid.Text = "";
            txt3.Text = "";
            txt4.Text = "";
            txt5.Text = "";
            txt6.Text = "";
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            int cid = int.Parse (txtdel.Text);
           

            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");

                if (txtdel.Text!="" )
                {
                    string update = "DELETE FROM Customer WHERE CId='" + cid + "'";
                    SqlCommand cmd = new SqlCommand(update, con);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted successfully");
                }
                else
                {
                    MessageBox.Show("Enter the customer name to delete");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txtdel.Text = "";
            
        }

        private void lbl3_Click(object sender, EventArgs e)
        {

        }

        private void pnl3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }

      
    }
}
