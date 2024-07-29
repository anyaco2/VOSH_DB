using Npgsql;
using System;
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
    public partial class Form4 : Form
    {
        string connectionString = "Server=localhost;Port=5432;Database=VOSH_DB; User Id = postgres;Password=2789;";
        public Form4()
        {
            InitializeComponent();
            SqlConnectReader();
        }

        private void SqlConnectReader()
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = "SELECT * FROM public.status\r\nORDER BY status_id ASC ";
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if (comandDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = String.Format("INSERT INTO public.status (status_name) values ('{0}')", textBox2.Text);
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if (comandDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
            SqlConnectReader();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = String.Format("UPDATE public.status SET status_name = '{0}' WHERE status_id = '{1}'", textBox6.Text, Convert.ToInt32(textBox7.Text));
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if (comandDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
            SqlConnectReader();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = String.Format("DELETE FROM public.status WHERE status_id = '{0}'", Convert.ToInt32(textBox9.Text));
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if (comandDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
            SqlConnectReader();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            NpgsqlConnection sqlConnection = new NpgsqlConnection(connectionString);
            sqlConnection.Open();
            NpgsqlCommand comand = new NpgsqlCommand();
            comand.Connection = sqlConnection;
            comand.CommandType = CommandType.Text;
            comand.CommandText = String.Format("SELECT * FROM public.status WHERE status_id = '{0}'", Convert.ToInt32(textBox8.Text));
            NpgsqlDataReader comandDataReader = comand.ExecuteReader();
            if (comandDataReader.HasRows)
            {
                DataTable dt = new DataTable();
                dt.Load(comandDataReader);
                dataGridView1.DataSource = dt;
            }
            comand.Dispose();
            sqlConnection.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SqlConnectReader();
        }
    }
}
