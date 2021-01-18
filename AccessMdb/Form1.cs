using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AccessMdb
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connectionString =
                $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={System.Environment.CurrentDirectory}\\northwind.mdb;Persist Security Info=False;";
            try
            {
                var conn = new OleDbConnection(connectionString);
                conn.Open();
                var cmd = new OleDbCommand("Select * from products", conn);
                OleDbDataAdapter da = new OleDbDataAdapter(cmd);
                DataTable dt=new DataTable();
                da.Fill(dt);
                this.dataGridView1.DataSource = dt.DefaultView;
                conn.Close();
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.Message);
            }
        }
    }
}
