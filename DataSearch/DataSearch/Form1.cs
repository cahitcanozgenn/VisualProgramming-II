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

namespace DataSearch
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=school2.accdb");
        OleDbDataAdapter da;
        DataTable dt;
        string sql = "SELECT * FROM sinif";

        void Listele(string data)
        {
            da = new OleDbDataAdapter(sql, con);
            dt = new DataTable();
            con.Open();
            da.Fill(dt);
            con.Close();
            dataGridView1.DataSource = dt;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Listele(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sql = "SELECT *FROM sinif WHERE okulNo='" + textBox1.Text + "'";
            Listele(sql);
        }
    }
}
