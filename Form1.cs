﻿using System;
using Npgsql;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            comand.CommandText = "SELECT * FROM public.schools\r\nORDER BY school_id ASC ";
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
            comand.CommandText = String.Format("INSERT INTO public.schools (school_number, school_short_name, school_full_name) values  ('{0}', '{1}', '{2}')", textBox1.Text, textBox2.Text, textBox3.Text);
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
            comand.CommandText = String.Format("UPDATE public.schools SET school_number = '{0}',school_short_name = '{1}',school_full_name = '{2}' WHERE school_id = '{3}'", textBox6.Text, textBox5.Text, textBox4.Text, Convert.ToInt32(textBox7.Text));
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
            comand.CommandText = String.Format("DELETE FROM public.schools WHERE school_id = '{0}'", Convert.ToInt32(textBox9.Text));
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
            comand.CommandText = String.Format("SELECT * FROM public.schools WHERE school_id = '{0}'", Convert.ToInt32(textBox8.Text));
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
