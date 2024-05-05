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
    public partial class CategoryPage : Form
    {

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        OleDbDataReader reader;
        DataTable dt;


        public CategoryPage()
        {
            InitializeComponent();
        }
        void GetStudent()
        {
            // conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Talal Iftikhar\\source\\repos\\talal-8570\\Database2.accdb\"");

            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");

            dt = new DataTable();     //Pic the DataBace Table
            adapter = new OleDbDataAdapter("SELECT ID, RoomType, Price, Room_ID FROM Project", conn);    //use to implement query
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;    //Data base come into the Gird view
            conn.Close();
        }

        private void CategoryPage_Load(object sender, EventArgs e)
        {
            GetStudent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Project (RoomType, Price, Room_ID) " +
                            "VALUES (@roomType, @price, @room_id)";

            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@roomType", textBox1.Text);
            cmd.Parameters.AddWithValue("@price", comboBox1.Text);
            cmd.Parameters.AddWithValue("@room_id", comboBox2.Text);
            cmd.Parameters.AddWithValue("@roomType", comboBox1.Text);


            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data is successfully inserted");
            GetStudent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();

        }

        private void label4_Click(object sender, EventArgs e)
        {
            user f2 = new user();
            f2.Show();
            this.Hide();

        }

        private void label6_Click(object sender, EventArgs e)
        {
            Booking f3 = new Booking();
            f3.Show();
            this.Hide();

        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard f4 = new Dashboard();
            f4.Show();
            this.Hide();

        }

        private void label3_Click(object sender, EventArgs e)
        {
            CategoryPage f5 = new CategoryPage();
            f5.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "UPDATE Project SET RoomType=@roomtype, Room_ID=@room_id, Price=@price WHERE ID=@id";
            cmd = new OleDbCommand(query, conn);
          
            cmd.Parameters.AddWithValue("@roomtype", textBox1.Text);
            cmd.Parameters.AddWithValue("@room_id", comboBox2.Text);
            cmd.Parameters.AddWithValue("@price", comboBox1.Text); // Set price from textBox2
            cmd.Parameters.AddWithValue("@id",textBox2.Text);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated successfully!");
            GetStudent();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
   
            

        }

       private void button4_Click(object sender, EventArgs e)
        {
            String query = "DELETE FROM Project ID " + " WHERE " + "ID = @id";
            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", Convert.ToInt32(textBox2.Text));
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("SUCCESSFULLY DELETED");
            GetStudent();
        }


        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();

        }
    }
}
