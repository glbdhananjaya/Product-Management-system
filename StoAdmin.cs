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
    public partial class StoAdmin : Form
    {
        public StoAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            AdminPanel a1 = new AdminPanel();
            a1.Show();
            this.Hide();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM storage";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "storage");
            dgvpro.DataSource = ds.Tables["storage"];
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Pid = txtpro.Text;
                int samount = int.Parse(txtamm.Text);
                int sreamount = int.Parse(txtrem.Text);
                string sloc = string.Empty;
                if (rdb1.Checked)
                {
                    sloc = "B1";
                }
                else if (rdb2.Checked)
                {
                    sloc = "B2";
                }
                else
                {
                    sloc = "B3";
                }

                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
                try
                {
                    if (Pid != "" && txtamm.Text != "" && sloc != "" && txtrem.Text != "" && bunifuDatePicker1.Value.Date != null)
                    {
                        string update = "UPDATE storage SET SAmount='" + samount + "',SLocation='" + sloc + "',SDDate='" + bunifuDatePicker1.Value.Date + "',SReAmount='" + sreamount + "' WHERE SPID='"+Pid+"'";
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
                catch (SqlException es)
                {
                    MessageBox.Show("" + es);
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txtpro.Text = "";
            txtamm.Text = "";
            txtrem.Text = "";

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            string Pid = txtdel.Text;


            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");

                if (Pid != "")
                {
                    string update = "DELETE FROM storage WHERE SPID='" + Pid + "'";
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

