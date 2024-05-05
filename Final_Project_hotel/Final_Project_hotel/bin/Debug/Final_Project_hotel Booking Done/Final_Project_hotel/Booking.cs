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

namespace Final_Project_hotel
{
    public partial class Booking : Form
    {

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        OleDbDataReader reader;
        DataTable dt;

        public Booking()
        {
            InitializeComponent();
            GetStudent();

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

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {
            

        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            login loginn = new login();
            loginn.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb";

            string selectedRoomID = comboBox1.SelectedItem.ToString();

            try
            {
                // Establish connection to the database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define SQL query to check the status of the selected room
                    string query = "SELECT Status FROM Project WHERE Room_ID = @RoomID";

                    // Create a command object
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Add parameter for room ID
                        command.Parameters.AddWithValue("@RoomID", selectedRoomID);

                        // Execute the query and retrieve the status of the room
                        object result = command.ExecuteScalar();

                        if (result != null && result.ToString() == "Occupied")
                        {
                            MessageBox.Show("The room is already booked.", "Room Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            // Update the status of the room to "Booked" in the database
                            string updateQuery = "UPDATE Project SET Status = 'Occupied' WHERE Room_ID = @RoomID";
                            using (OleDbCommand updateCommand = new OleDbCommand(updateQuery, connection))
                            {
                                // Add parameter for room ID
                                updateCommand.Parameters.AddWithValue("@RoomID", selectedRoomID);

                                // Execute the update query
                                updateCommand.ExecuteNonQuery();
                            }

                            MessageBox.Show("Room booked successfully!", "Room Booking", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Optionally, refresh the ComboBox to reflect the updated status
                            LoadRoomIDs();
                            GetStudent();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error booking room: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Booking_Load(object sender, EventArgs e)
        {
            // Load room IDs into the ComboBox
            LoadRoomIDs();

            // Load room types into the ComboBox
            LoadRoomTypes();
        }

        private void LoadRoomIDs()
        {
            // Clear existing items in the ComboBox
            comboBox1.Items.Clear();

            try
            {
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb";
                // Establish connection to the database
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define SQL query to retrieve room IDs
                    string query = "SELECT Room_ID FROM Project";

                    // Create a command object
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Execute the query and retrieve data
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the result set and add room IDs to the ComboBox
                            while (reader.Read())
                            {
                                comboBox1.Items.Add(reader["Room_ID"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room IDs: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadRoomTypes()
        {
            // Clear existing items in the ComboBox
            comboBox2.Items.Clear();

            try
            {
                // Establish connection to the database
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define SQL query to retrieve distinct room types
                    string query = "SELECT DISTINCT RoomType FROM Project";

                    // Create a command object
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Execute the query and retrieve data
                        using (OleDbDataReader reader = command.ExecuteReader())
                        {
                            // Loop through the result set and add room types to the ComboBox
                            while (reader.Read())
                            {
                                comboBox2.Items.Add(reader["RoomType"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading room types: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected room type from the ComboBox
            string selectedRoomType = comboBox2.SelectedItem.ToString();

            // Load rooms of the selected room type into the DataGridView
            LoadRoomsByType(selectedRoomType);
        }

        private void LoadRoomsByType(string roomType)
        {
            try
            {
                // Establish connection to the database
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define SQL query to retrieve rooms of the selected room type
                    string query = "SELECT * FROM Project WHERE RoomType = @RoomType";

                    // Create a command object
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Add parameter for room type
                        command.Parameters.AddWithValue("@RoomType", roomType);

                        // Create a DataTable to hold the results
                        DataTable dt = new DataTable();

                        // Use a data adapter to fill the DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            // Fill the DataTable with data from the database
                            adapter.Fill(dt);
                        }

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading rooms: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

  

        private void button4_Click(object sender, EventArgs e)
        {
            // Clear items in both ComboBoxes
            comboBox2.Items.Clear();
            comboBox1.Items.Clear();

            try
            {
                // Establish connection to the database
                string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb";
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Define SQL query to retrieve all items from the database
                    string query = "SELECT * FROM Project";

                    // Create a DataTable to hold the results
                    DataTable dt = new DataTable();

                    // Create a command object
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        // Use a data adapter to fill the DataTable
                        using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                        {
                            // Fill the DataTable with data from the database
                            adapter.Fill(dt);
                        }
                    }

                    // Bind the DataTable to the DataGridView
                    dataGridView1.DataSource = dt;

                    // Load room IDs into the ComboBox
                    LoadRoomIDs();

                    // Load room types into the ComboBox
                    LoadRoomTypes();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CategoryPage c1 = new CategoryPage();
            c1.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            user u1 = new user();
            u1.Show();
            this.Hide();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard d1 = new Dashboard();
            d1.Show();
            this.Hide();
        }
    }
}
