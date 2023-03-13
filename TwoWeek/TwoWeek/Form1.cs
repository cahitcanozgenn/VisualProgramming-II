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

namespace TwoWeek
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        OleDbCommand command;
        DataSet dataSet;
        public Form1()
        {
            InitializeComponent();
        }

        void yenile()
        {
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=school2.accdb");
                dataAdapter = new OleDbDataAdapter("SELECT * FROM sinif", connection);
                dataSet = new DataSet();
                connection.Open();
                dataAdapter.Fill(dataSet, "sinif");
                dataGridView1.DataSource = dataSet.Tables["sinif"];
                connection.Close();
            }
            catch(Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void button1_Click(object sender, EventArgs e)
        {// EKLE

            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO sinif (okulNo,adi,soyadi,bolum) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command.ExecuteNonQuery();
            MessageBox.Show("BAŞARILI");
            connection.Close();
            yenile();
        }
    }
}
