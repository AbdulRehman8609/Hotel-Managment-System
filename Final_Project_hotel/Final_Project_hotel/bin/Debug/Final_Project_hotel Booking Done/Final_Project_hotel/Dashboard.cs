using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Final_Project_hotel
{
    public partial class Dashboard : Form

    {
        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        OleDbDataReader reader;
        DataTable dt;

        public Dashboard()
        {
            InitializeComponent();

        }

        // string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Talal Iftikhar\\source\\repos\\Final_Project_hotel\\Final_Project_hotel\\bin\\Debug\\Database6.accdb\"");
        string connectionString = ("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        
        }

        // Method to get the count of occupied rooms from the database
        private int GetOccupiedRoomsCount()
        {
            int count = 0;
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Project WHERE Status = 'Occupied'";
                using (cmd = new OleDbCommand(query, conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }
        private int gettotalcustomer()
        {
            int count1 = 0;
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Project";
                using (cmd = new OleDbCommand(query, conn))
                {
                    count1 = (int)cmd.ExecuteScalar();
                }
            }
            return count1;

        }

        // Method to get the count of booked rooms from the database
        private int GetBookedRoomsCount()
        {
            int count = 0;
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Project WHERE Status = 'Booked'";
                using (cmd = new OleDbCommand(query, conn))
                {
                    count = (int)cmd.ExecuteScalar();
                }
            }
            return count;
        }

        // Method to get the total price from the database
        private decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            using (conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT SUM(Price) FROM Project WHERE Status = 'Booked' OR Status = 'Occupied'";
                using (cmd = new OleDbCommand(query, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        totalPrice = Convert.ToDecimal(result);
                    }
                }
            }
            return totalPrice;
        }


        private void label4_Click(object sender, EventArgs e)
        {
            user u1 = new user();
            u1.Show();
            this.Hide();
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

    //    private void panel1_Paint(object sender, PaintEventArgs e)
     //   {
            
    //    }

        private void label2_Click(object sender, EventArgs e)
        {
            Form f1 = new Form();
            f1.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CategoryPage p1 = new CategoryPage();
            p1.Show();
            this.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Booking b1 = new Booking();
            b1.Show();
            this.Hide();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            int occupiedRooms = GetOccupiedRoomsCount();
            int bookedRooms = GetBookedRoomsCount();
            decimal totalPrice = GetTotalPrice();
            int totalcustomer = gettotalcustomer();

            // Displaying the information
            string displayText = $"Occupied Rooms: {occupiedRooms}         Booked Rooms: {bookedRooms}              Total Price: {totalPrice:C}";
            string displaytotal = $" TOTAL REVENUE {totalPrice}";
            // Assuming you have a label named label1 in panel1
            textBox1.Text = displayText;
            String display1 = $"TOTAL CUSTOMER : {totalcustomer} ";
            textBox2.Text = display1;
            textBox3.Text = displaytotal;
        }
    }
}
