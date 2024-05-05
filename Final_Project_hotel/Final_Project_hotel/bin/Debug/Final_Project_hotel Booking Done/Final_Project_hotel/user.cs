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
    public partial class user : Form
    {

        OleDbConnection conn;
        OleDbCommand cmd;
        OleDbDataAdapter adapter;

        OleDbDataReader reader;
        DataTable dt;

        public user()
        {
            InitializeComponent();
            label1.Click += label1_Click;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            //Application.Exit();
        }
        void GetStudent()
        {
            // conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Talal Iftikhar\\source\\repos\\talal-8570\\Database2.accdb\"");

            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Database6.accdb");

            dt = new DataTable();     //Pic the DataBace Table
            adapter = new OleDbDataAdapter("SELECT ID, Name, Room_ID,Contact FROM Project", conn);    //use to implement query
            conn.Open();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;    //Data base come into the Gird view
            conn.Close();
        }

        private void user_Load(object sender, EventArgs e)
        {
            GetStudent();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            Dashboard d1 = new Dashboard();
            d1.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
         
        }

        private void label3_Click(object sender, EventArgs e)
        {
            CategoryPage C1 = new CategoryPage();
            C1.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            user f1 = new user();
            f1.Show();
            this.Hide();
        }

        private void x(object sender, EventArgs e)
        {
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {
            Booking b1 = new Booking();
            b1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Project ([NAME], Contact) " +
                          "VALUES (@name, @contact)";

            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@contact", textBox2.Text);
     
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Data is successfully inserted");
            GetStudent();

        }

        private void button2_Click(object sender, EventArgs e)
        {

            string query = "UPDATE Project SET [NAME]=@name, Contact=@contact, Room_ID=@Room_id WHERE ID=@id";
            cmd = new OleDbCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", textBox1.Text);
            cmd.Parameters.AddWithValue("@contact", textBox2.Text);
            cmd.Parameters.AddWithValue("@id", textBox3.Text);
            cmd.Parameters.AddWithValue("@Room_id", textBox4.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Updated successfully!");
            GetStudent();

        }

        private void user_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            textBox4.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();




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


        private void panel4_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }
    }
}
