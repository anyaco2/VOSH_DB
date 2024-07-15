using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ВСОШ_База_Данных
{
    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=VOSH_DB; User Id = postgres;Password=2789;";
        public Form1()
        {
            InitializeComponent();
            SqlConnectReader();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SqlConnectReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = "SELECT * FROM public.gender\r\nORDER BY gender_id ASC \r\n";
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if(comandDataReader.HasRows) {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
        }
    }

    
}
