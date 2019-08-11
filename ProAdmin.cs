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
    public partial class ProAdmin : Form
    {
        public ProAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

            AdminPanel a1 = new AdminPanel();
            a1.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM product";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "product");
            dgvpro.DataSource = ds.Tables["product"];
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
                if (Pid != "" && txtcol.Text != "" && shift != "" && dtpproduct.Value.Date != null)
                {
                    string update = "UPDATE product SET Shift='"+shift+"',PColorCode='"+pcolorcode+"',Date='"+ dtpproduct.Value.Date + "' WHERE PId='"+Pid+"'";
                    SqlCommand cmd = new SqlCommand(update, con);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Updated successfully");
                }
                else
                {
                    MessageBox.Show("Fill all the fields to Update");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }

            txtpro.Text = "";
            txtcol.Text = "";
            shift = null;
            
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string Pid = txtdel.Text;


            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");

                if (Pid != "")
                {
                    string update = "DELETE FROM product WHERE PId='" + Pid + "'";
                    SqlCommand cmd = new SqlCommand(update, con);

                    con.Open();

                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data Deleted successfully");
                }
                else
                {
                    MessageBox.Show("Enter the Product ID to delete");
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txtdel.Text = "";
        }
    }
}
