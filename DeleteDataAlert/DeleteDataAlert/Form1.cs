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

namespace DeleteDataAlert
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
        {
            DialogResult result2 = MessageBox.Show("Veriyi silmek istediğinizden emin misiniz?", "Veri Silme", MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
            if (result2 == DialogResult.Yes)
            {
                connection.Open();
                OleDbCommand dataDelete = new OleDbCommand("delete from sinif where okulNo = '" + textBox1.Text + "'", connection);
                dataDelete.ExecuteNonQuery();
                connection.Close();
                data();
                MessageBox.Show("Veri Silme İşlemi Başarılı");
            }
            else if (result2 == DialogResult.No)
            {
                MessageBox.Show("Veri Silinmedi");
            }
        
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            data();
        }
    }
}
