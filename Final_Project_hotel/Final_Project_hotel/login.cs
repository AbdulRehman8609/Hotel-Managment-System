using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Project_hotel
{
    public partial class login : Form
    {
        public login()
        {
            InitializeComponent();
        }

        private void login_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "admin";
            string password = "1234";
            if (textBox1.Text.Equals(username) && textBox2.Text.Equals(password))
            {
                MessageBox.Show("SUCCESS!");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Wrong username or password!!! Please try once more");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
