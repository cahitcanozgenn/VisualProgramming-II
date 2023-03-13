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
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=student.accdb");
                dataAdapter = new OleDbDataAdapter("SELECT * FROM student", connection);
                dataSet = new DataSet();
                connection.Open();
                dataAdapter.Fill(dataSet, "student");
                dataGridView1.DataSource = dataSet.Tables["student"];
                
                connection.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
          
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
            MessageBox.Show("Veri Ekleme İşlemi Başarılı.");
            connection.Close();
            getAll();

        }

        private void button2_Click(object sender, EventArgs e)
        {// Update Data
           

        }

        private void button3_Click(object sender, EventArgs e)
        {// Delete Data
            DialogResult dr;
            dr= MessageBox.Show("Silmek istediğinizden emin misiniz?", "Uyarı!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                command = new OleDbCommand();
                connection.Open();
                command.Connection = connection;
                command.CommandText = "delete from student where studentId=" + textBox3.Text + "";
                command.ExecuteNonQuery();
                connection.Close();
                getAll();
            }
        }
    }
}
