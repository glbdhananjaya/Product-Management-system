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
using System.Net.Mail;



namespace srinko2
{
    public partial class Report : Form
    {
        public Report()
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

        private void button1_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM Customer";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "Customer");
            dgvreports.DataSource = ds.Tables["Customer"];
        }

        private void txt6_TextChanged(object sender, EventArgs e)
        {
            lbl6.Text = "";
            pnl6.BackColor = Color.FromArgb(51, 122, 183);
            txt6.ForeColor = Color.FromArgb(51, 122, 183);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string to;
            string subject;
            string body;

            to = txt6.Text;
            System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-z][a-zA-Z\.]*[a-zA-Z]$");
            if (txt6.Text.Length > 0)
            {
                if (!rEmail.IsMatch(txt6.Text))
                {
                    MessageBox.Show("Invalid EmailAddress", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt6.SelectAll();
                    MessageBox.Show("Invalid Email Address");
                    txt6.Text = "";
                }
                else
                {
                    subject = textBox1.Text;
                    body = textBox2.Text;

                    string email = "bunnydbot@gmail.com";
                    string password = "bunny 12";

                    SmtpClient client = new SmtpClient();

                    client.Port = 587;
                    client.Host = "smtp.gmail.com";
                    client.EnableSsl = true;
                    client.Timeout = 10000;
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.Credentials = new System.Net.NetworkCredential(email, password);

                    MailMessage mail = new MailMessage(email, to, subject, body);
                    mail.BodyEncoding = UTF8Encoding.UTF8;
                    mail.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                    client.Send(mail);

                    MessageBox.Show("Email sent successfully");
                }
                txt6.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM product";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "product");
            dgvreports.DataSource = ds.Tables["product"];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM Storage";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "Storage");
            dgvreports.DataSource = ds.Tables["Storage"];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constring = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Databases\37Srinko.mdf;Integrated Security=True;Connect Timeout=30";
            string qry = "SELECT * FROM Finance";

            SqlDataAdapter da = new SqlDataAdapter(qry, constring);
            DataSet ds = new DataSet();

            da.Fill(ds, "Finance");
            dgvreports.DataSource = ds.Tables["Finance"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            label2.Text = "";
           panel3.BackColor = Color.FromArgb(51, 122, 183);
            textBox1.ForeColor = Color.FromArgb(51, 122, 183);

            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;

            panel4.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.White;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            label3.Text = "";
            panel3.BackColor = Color.FromArgb(51, 122, 183);
            textBox2.ForeColor = Color.FromArgb(51, 122, 183);
        
            pnl6.BackColor = Color.WhiteSmoke;
            txt6.ForeColor = Color.White;

            panel4.BackColor = Color.WhiteSmoke;
            textBox2.ForeColor = Color.White;
        }
    }
}
