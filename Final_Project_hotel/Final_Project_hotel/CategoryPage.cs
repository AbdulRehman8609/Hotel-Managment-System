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

            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\Talal Iftikhar\\source\\repos\\Final_Project_hotel\\Final_Project_hotel\\bin\\Debug\\Database6.accdb\"");

            dt = new DataTable();     //Pic the DataBace Table
            adapter = new OleDbDataAdapter("SELECT RoomType, Price FROM Project", conn);    //use to implement query
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
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
