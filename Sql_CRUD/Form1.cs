using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace Sql_CRUD
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1. address of SQL server and database und  //2.establish connection
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SSAGJO0\\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True");
            //3.open connection
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO mitarbeiter2 VALUES (@id,@vorname,@nachname)", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@vorname", textBox2.Text);
            cmd.Parameters.AddWithValue("@nachname", textBox3.Text);
            //4.Execute Query
            cmd.ExecuteNonQuery();
            //6.Close connection
            con.Close();
            MessageBox.Show("Datei erfolgreich gespeichert!");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SSAGJO0\\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update mitarbeiter2 Set Vorname=@vorname, Nachname=@nachname Where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@vorname", textBox2.Text);
            cmd.Parameters.AddWithValue("@nachname", textBox3.Text);
            cmd.ExecuteNonQuery();
            
            con.Close();
            MessageBox.Show("Datei aktualisiert!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SSAGJO0\\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete mitarbeiter2 Where ID=@id", con);
            cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Datei ist gelöscht!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-SSAGJO0\\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True");
            con.Open();      
            SqlCommand cmd = new SqlCommand("Select * from mitarbeiter2", con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }
    }

 }

/* Data Source=DESKTOP-SSAGJO0\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True
            //1. address of SQL server and database
            string ConnectionString = "Data Source=DESKTOP-SSAGJO0\\SQLEXPRESS;Initial Catalog=firma2;Integrated Security=True";

            //2.establish connection
            SqlConnection con = new SqlConnection(ConnectionString);

            //3.open connection
            con.Open();

            //4.prepare Query
            string Vorname = textBox2.Text;
            string Nachname = textBox3.Text;
            string Query = "INSERT INTO mitarbeiter2 (vorname, nachname) VALUES('"+ Vorname + "', '"+ Nachname + "')";
                 
            //5.Execute Query
            SqlCommand cmd = new SqlCommand(Query, con);
            cmd.ExecuteNonQuery();

            //6.Close connection
            con.Close();
            MessageBox.Show("Data erfolgreich gespeichert!");*/
