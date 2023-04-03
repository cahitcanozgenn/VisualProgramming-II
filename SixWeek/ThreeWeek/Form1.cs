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

namespace ThreeWeek
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

        void data()
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
            catch (Exception hata)
            {
                MessageBox.Show(hata.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        { // Veri Ekleme 
            if (textBox1.Text.Trim() != "" && textBox2.Text.Trim() != "" && textBox3.Text.Trim() != "" && textBox4.Text.Trim() != "")
            { 
            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "INSERT INTO sinif (okulNo,adi,soyadi,bolum) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')";
            command.ExecuteNonQuery();
            MessageBox.Show("Veri Ekleme İşlemi Başarılı");
                for(int i=0;i<this.Controls.Count;i++)
                {// Veri ekledikten sonra textboxları temizler
                    if (Controls[i] is TextBox) Controls[i].Text = "";
                }
            connection.Close();
            data();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakılmamalıdır.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data();
        }

        private void button2_Click(object sender, EventArgs e)
        { // Veri Güncelleme
            command = new OleDbCommand();
            connection.Open();
            command.Connection = connection;
            command.CommandText = "update sinif set okulNo='" + textBox1.Text + "', adi='" + textBox2.Text + "', soyadi='" + textBox3.Text + "', bolum='" + textBox4.Text + "' where okulNo='" + textBox5.Text + "'";
            command.ExecuteNonQuery();
            connection.Close();
            dataSet.Clear();
            data();
            MessageBox.Show("Veri Güncelleme İşlemi Başarılı");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand dataDelete = new OleDbCommand("delete from sinif where okulNo = '" + textBox6.Text + "'", connection);
            dataDelete.ExecuteNonQuery();
            connection.Close();
            data();
            MessageBox.Show("Veri Silme İşlemi Başarılı");
        }
    }
}
