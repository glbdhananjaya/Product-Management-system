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
    public partial class Finance : Form
    {
        public Finance()
        {
            InitializeComponent();
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Home d = new Home();
            d.Show();
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

       

        private void txtpro_TextChanged(object sender, EventArgs e)
        {
            pnl1.BackColor = Color.FromArgb(51, 122, 183);
            txtpro.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txtamm.ForeColor = Color.White;

            pnl5.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }

        private void txtamm_TextChanged(object sender, EventArgs e)
        {
            pnl2.BackColor = Color.FromArgb(51, 122, 183);
            txtamm.ForeColor = Color.FromArgb(51, 122, 183);

            pnl5.BackColor = Color.WhiteSmoke;
            txtwei.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }

        private void txtwei_TextChanged(object sender, EventArgs e)
        {
            pnl5.BackColor = Color.FromArgb(51, 122, 183);
            txtwei.ForeColor = Color.FromArgb(51, 122, 183);

            pnl2.BackColor = Color.WhiteSmoke;
            txtamm.ForeColor = Color.White;

            pnl1.BackColor = Color.WhiteSmoke;
            txtpro.ForeColor = Color.White;
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            try
            {
                string Pid = txtpro.Text;
                string shift = string.Empty;
                if (rdb1.Checked)
                {
                    shift = "Morning";
                }
                else
                {
                    shift = "Evening";
                }
                int amm = int.Parse(txtamm.Text);
                int wei = int.Parse(txtwei.Text);
                int mcpu = int.Parse(txtmc.Text);
                int sppu = int.Parse(txtsp.Text);

                
                int mc = amm * mcpu;
                int sp = amm * sppu;
                int finstat = sp - mc;
                if (finstat> mc)
                {
                    txtprofit.Text = "" + finstat;
                }
                else
                {
                    txtprofit.Text = "" + finstat;
                }

                textmc.Text = "" + mc;
                txttotsp.Text = "" + sp;


                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30");
                if (Pid != "" && shift != "" && txtamm.Text != "" && txtmc.Text != "" && txtwei.Text != "" && txtsp.Text != ""&& dtpfinance.Value.Date!=null)
                {
                    string qry = "INSERT INTO Finance VALUES ('" + Pid + "','" + shift + "','"+ dtpfinance.Value.Date+ "','" + amm + "','" + wei + "','" + mcpu + "','" + sppu + "','" + mc + "','" + sp + "','"+finstat+"')";
                    SqlCommand cmd = new SqlCommand(qry, con);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Data inserted successfully");
                }
                else
                {
                    MessageBox.Show("Fill all the feilds");
                }
                txtpro.Text = "";
                txtamm.Text="";
                txtwei.Text="";
                txtmc.Text="";
                txtsp.Text="";
                textmc.Text = "";
                txttotsp.Text = "";
                txtprofit.Text = "";

            }
            catch(SqlException se)
            {
                MessageBox.Show("" + se);
            }
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            txtamm.Text = "";
            txtwei.Text = "";
            txtmc.Text = "";
            txtsp.Text = "";
            textmc.Text = "";
            txttotsp.Text = "";
        }
    }
}
