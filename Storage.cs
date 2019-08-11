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
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Home d = new Home();
            d.Show();
            this.Hide();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Pid = txtpro.Text;
                int samount = int.Parse(txtamm.Text);
                int sreamount = int.Parse(txtrem.Text);
                string sloc = string.Empty;
                if(rdb1.Checked)
                {
                    sloc = "B1";
                }
                else if(rdb2.Checked)
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
                    if (Pid!= ""&&txtamm.Text != "" && sloc != "" && txtrem.Text != "")
                    {
                        string qry = "insert into Storage values('"  + Pid + "','" + samount + "','" + sloc + "','" + bunifuDatePicker1.Value.Date + "','" + sreamount + "')";
                        SqlCommand cmd = new SqlCommand(qry, con);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Data inserted successfully");
                    }
                    else
                    {
                        MessageBox.Show("Fill in all the fields");
                    }
                }
                catch(SqlException es)
                {
                    MessageBox.Show("" + es);
                }
                

            }
            catch(SqlException se)
            {
                MessageBox.Show("" + se);
            }
            txtpro.Text = "";
            txtamm.Text = "";
            txtrem.Text = "";
            
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txtpro.Text = "";
            txtamm.Text = "";
            txtrem.Text = "";
        }

        private void txtpro_TextChanged(object sender, EventArgs e)
        {
            pnl1.BackColor = Color.FromArgb(51, 122, 183);
            txtpro.ForeColor = Color.FromArgb(51, 122, 183);

            pnl4.BackColor = Color.WhiteSmoke;
            txtamm.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txtrem.ForeColor = Color.White;
        }

        private void txtrem_TextChanged(object sender, EventArgs e)
        {
            pnl5.BackColor = Color.FromArgb(51, 122, 183);
            txtrem.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txtamm.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }

        private void txtamm_TextChanged(object sender, EventArgs e)
        {
            pnl2.BackColor = Color.FromArgb(51, 122, 183);
            txtamm.ForeColor = Color.FromArgb(51, 122, 183);

            pnl5.BackColor = Color.WhiteSmoke;
            txtrem.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }
    }
    }

