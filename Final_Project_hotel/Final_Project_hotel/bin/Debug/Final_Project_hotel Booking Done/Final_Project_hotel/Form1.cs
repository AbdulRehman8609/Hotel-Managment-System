using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Project_hotel
{
    public partial class Form1 : Form
    {

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        OleDbDataReader reader;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            comboBox1.Items.Add("Small");
            comboBox1.Items.Add("King");
            comboBox1.Items.Add("Elite");

            // Subscribe to the SelectedIndexChanged event
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;


            label1.Click += label1_Click;
        }

        void GetStudent()
        {
            // conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Talal Iftikhar\\source\\repos\\talal-8570\\Database2.accdb\"");

            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");

            dt = new DataTable();     //Pic the DataBace Table
            adapter = new OleDbDataAdapter("SELECT*FROM Project", conn);    //use to implement query
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;    //Data base come into the Gird view
            conn.Close();
        }



        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Determine the value based on the selected item
            string selectedItem = comboBox1.SelectedItem.ToString();
            int value = 0;

            switch (selectedItem)
            {
                case "Small":
                    value = 10000;
                    break;
                case "King":
                    value = 15000;
                    break;
                case "Elite":
                    value = 25000;
                    break;
                default:
                    break;
            }

            textBox2.Text = value.ToString();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            CategoryPage form2 = new CategoryPage();
            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            user form3 = new user();
            form3.Show();
            this.Hide();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudent();
        }

        private void label5_Click(object sender, EventArgs e)
        {
        

        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Shut down the application
            login loginn = new login();
            loginn.Show();
            this.Hide();
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CategoryPage form6 = new CategoryPage();
            form6.Show();
            this.Hide();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Project (NAME, RoomType, Price, Room_ID, Status) " +
                           "VALUES (@name, @roomType, @price, @room_id, @status)";

            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@roomType", comboBox1.Text);
            cmd.Parameters.AddWithValue("@price", textBox2.Text);
            cmd.Parameters.AddWithValue("@room_id", comboBox3.Text);
            cmd.Parameters.AddWithValue("@roomType", comboBox1.Text);
            cmd.Parameters.AddWithValue("@status", comboBox2.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data is successfully inserted");
            GetStudent();
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            
                String query = "DELETE FROM Project ID " + " WHERE " + "ID = @id";
                cmd = new OleDbCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox4.Text));
                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("SUCCESSFULLY DELETED");
                GetStudent();

            

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard form7 = new Dashboard();
            form7.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Booking form12 = new Booking();
            form12.Show();
            this.Hide();


        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "UPDATE Project SET NAME=@name, RoomType=@roomtype, Room_ID=@room_id, Status=@status, Price=@price WHERE ID=@id";
            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@roomtype", comboBox1.Text);
            cmd.Parameters.AddWithValue("@room_id", comboBox3.Text);
            cmd.Parameters.AddWithValue("@status", comboBox2.Text); // Set status from comboBox2
            cmd.Parameters.AddWithValue("@price", textBox2.Text); // Set price from textBox2
            cmd.Parameters.AddWithValue("@id", textBox4.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated successfully!");
            GetStudent();


        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            comboBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
           
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {
           
        }
    }
}
