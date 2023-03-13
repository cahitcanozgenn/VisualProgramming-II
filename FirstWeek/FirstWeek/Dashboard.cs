using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb; // Veri tabanı bağlantısı için gereklidir.

namespace FirstWeek
{
    public partial class Dashboard : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        OleDbCommand command;
        DataSet dataSet;
        public Dashboard()
        {
            InitializeComponent();
        }
        void getAll()
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=student.accdb");
            dataAdapter = new OleDbDataAdapter("SELECT * FROM student", connection);
            dataSet = new DataSet();
            connection.Open();
            dataAdapter.Fill(dataSet, "student");
            dataGridView1.DataSource = dataSet.Tables["student"];
            connection.Close();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            getAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {// Add Data

            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "insert into student (studentFirstName,studentLastName,studentNumber) values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text+ "')";
            command.ExecuteNonQuery();
            connection.Close();
            getAll();

        }

        private void button2_Click(object sender, EventArgs e)
        {// Update Data
           

        }

        private void button3_Click(object sender, EventArgs e)
        {// Delete Data

        }
    }
}
