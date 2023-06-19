using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows.Forms;

namespace YazilimYapimi3
{
    public partial class Form2 : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";

        public Form2()
        {
            InitializeComponent();
            InitializeDatabase();
            connection = new SqlConnection(connectionString);
            connection.Open();
        }


        private void InitializeDatabase()
        {
            connection = new SqlConnection(connectionString);
            connection.Open();

            
            string checkTableQuery = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'Olaylar') BEGIN CREATE TABLE Olaylar (Zaman DATE, YapilanIş NVARCHAR(100)) END;";
            SqlCommand checkTableCommand = new SqlCommand(checkTableQuery, connection);
            checkTableCommand.ExecuteNonQuery();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime zaman = dateTimePicker1.Value;
            string yapilacakIs = textBox2.Text;

            
            string insertQuery = "INSERT INTO Olaylar (Zaman, YapilanIş) VALUES (@Zaman, @YapilacakIs);";
            SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@Zaman", zaman);
            insertCommand.Parameters.AddWithValue("@YapilacakIs", yapilacakIs);
            insertCommand.ExecuteNonQuery();

            MessageBox.Show("Olay başarıyla eklendi");
        }



        private void button1_Click(object sender, EventArgs e)
        {
            
            string selectQuery = "SELECT * FROM Olaylar;";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            SqlDataReader reader = selectCommand.ExecuteReader();

            string tarihBilgileri = "";
            while (reader.Read())
            {
                string tarih = reader["Zaman"]?.ToString() ?? string.Empty;  
                string yapilanIs = reader["YapilanIş"]?.ToString() ?? string.Empty; 
                tarihBilgileri += "Tarih: " + tarih + ", Kaydedilen Olay: " + yapilanIs + "\n";
            }

            reader.Close();

            MessageBox.Show("Kaydedilen Olaylar:\n" + tarihBilgileri);
        }




        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // textBox2 değiştiğinde yapılacak işlemler
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // label1 tıklandığında yapılacak işlemler
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Form3'ü aç
            Form3 form3 = new Form3();
            form3.Show();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }
    }
}
