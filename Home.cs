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
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Customer e1 = new Customer();
            e1.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Product e2 = new Product();
            e2.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Storage e3 = new Storage();
            e3.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Finance e4 = new Finance();
            e4.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 e5 = new Form1();
            e5.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Report e6 = new Report();
            e6.Show();
            this.Hide();
        }

        private void Home_Load(object sender, EventArgs e)
        {
            lbl3.Text = login.uname;
            
        }

        private void dashboard1_Load(object sender, EventArgs e)
        {

        }
    }
}
