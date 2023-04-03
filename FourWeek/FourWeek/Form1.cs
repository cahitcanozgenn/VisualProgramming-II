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

namespace FourWeek
{
    public partial class Form1 : Form
    {
        OleDbConnection connection;
        OleDbDataAdapter dataAdapter;
        OleDbCommand command;
        DataSet dataSet;
        int toplamKayit = 0;
        int i;
        public Form1()
        {
            InitializeComponent();
        }

        void data()
        {
            try
            {
                connection = new OleDbConnection("Provider=Microsoft.ACE.Oledb.12.0;Data Source=okul.accdb");
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

        private void Form1_Load(object sender, EventArgs e)
        {
            data();
            DataTable dt = new DataTable();
            connection.Open();
            dataAdapter = new OleDbDataAdapter("SELECT * FROM sinif", connection);
            dataAdapter.Fill(dt);
            dataGridView1.DataSource = dt;
            toplamKayit = dataGridView1.Rows.Count;
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            i = 0;
            textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            //CurrentRow
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(i!=toplamKayit-2)
            {
                i += 1;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("SON KAYITTASINIZ.");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(i>0)
            {
                i -= 1;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            }
            else
            {
                MessageBox.Show("İLK KAYITTASINIZ");
            }
          
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
                i += 1;
                textBox1.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();

           
          
           
        }
    }
}
