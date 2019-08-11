using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace srinko2
{
    public partial class AdminPanel : Form
    {
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CusAdmin a2 = new CusAdmin();
            a2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ProAdmin a3 = new ProAdmin();
            a3.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            StoAdmin a4 = new StoAdmin();
            a4.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Admin a1 = new Admin();
            a1.Show();
            this.Hide();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            lblad.Text = Admin.Aname;
        }
    }
}
