namespace YazilimYapimi3
{
    using System;
    using System.Data.SqlClient;
    using System.Windows.Forms;

    public partial class Form1 : Form
    {
        private string userType = "Üye";


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Ad = textBox1.Text;
            string Soyad = textBox2.Text;
            string KullanýcýAdý = textBox3.Text;
            string Password = textBox4.Text;
            string TCKimlikNo = textBox5.Text;
            string TelefonNo = textBox6.Text;
            string Adres = textBox7.Text;

            string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veritabanýna baðlandý!");

                    if (checkBox1.Checked)
                    {
                        userType = "Üye";
                    }
                    else if (checkBox2.Checked)
                    {
                        userType = "Admin";
                    }
                    else
                    {
                        MessageBox.Show("Lütfen kullanýcý tipini seçin.", "Uyarý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "INSERT INTO Bilgi (Ad, Soyad, KullanýcýAdý, Password, TCKimlikNo, TelefonNo, Adres, KullanýcýType) VALUES (@ad, @soyad, @kullaniciAdi, @password, @tcKimlikNo, @telefonNo, @adres, @kullaniciType)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ad", Ad);
                    command.Parameters.AddWithValue("@soyad", Soyad);
                    command.Parameters.AddWithValue("@kullaniciAdi", KullanýcýAdý);
                    command.Parameters.AddWithValue("@password", Password);
                    command.Parameters.AddWithValue("@tcKimlikNo", TCKimlikNo);
                    command.Parameters.AddWithValue("@telefonNo", TelefonNo);
                    command.Parameters.AddWithValue("@adres", Adres);
                    command.Parameters.AddWithValue("@kullaniciType", userType);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Kullanýcý kaydý baþarýyla oluþturuldu");
                        MessageBox.Show("Kullanýcý kaydý baþarýyla oluþturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine("Kullanýcý kaydý oluþturulamadý.");
                        MessageBox.Show("Kullanýcý kaydý oluþturulamadý.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Baðlantý hatasý: " + ex.Message);
                    MessageBox.Show("Baðlantý hatasý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox8.Text.ToLower();
            string sifre = textBox9.Text;

            string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veritabanýna baðlandý!");

                    string query = "SELECT COUNT(*) FROM Bilgi WHERE LOWER(KullanýcýAdý) = @kullaniciAdi AND LOWER(PASSWORD) = LOWER(@sifre)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@sifre", sifre);

                    int kullaniciSayisi = (int)command.ExecuteScalar();

                    if (kullaniciSayisi > 0)
                    {
                        Console.WriteLine("Giriþ baþarýlý. Sisteme hoþ geldiniz.");
                        MessageBox.Show("Giriþ baþarýlý. Sisteme hoþ geldiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2 form2 = new Form2();
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        Console.WriteLine("Kullanýcý adý veya þifre hatalý. Giriþ baþarýsýz!");
                        MessageBox.Show("Kullanýcý adý veya þifre hatalý. Giriþ baþarýsýz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Baðlantý hatasý: " + ex.Message);
                    MessageBox.Show("Baðlantý hatasý: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void label10_Click(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            // Existing code...
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            // Existing code...
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Close the application
            Application.Exit();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
