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
        //Kullanıcıdan kayıt olmak için alınan bilgiler
        private void button1_Click(object sender, EventArgs e)
        {
            string Ad = textBox1.Text;
            string Soyad = textBox2.Text;
            string KullanıcıAdı = textBox3.Text;
            string Password = textBox4.Text;
            string TCKimlikNo = textBox5.Text;
            string TelefonNo = textBox6.Text;
            string Adres = textBox7.Text;
            
            // Veritabanına bağlantı 
           
            string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veritabanına bağlandı!");

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
                        MessageBox.Show("Lütfen kullanıcı tipini seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    string query = "INSERT INTO Bilgi (Ad, Soyad, KullanıcıAdı, Password, TCKimlikNo, TelefonNo, Adres, KullanıcıType) VALUES (@ad, @soyad, @kullaniciAdi, @password, @tcKimlikNo, @telefonNo, @adres, @kullaniciType)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@ad", Ad);
                    command.Parameters.AddWithValue("@soyad", Soyad);
                    command.Parameters.AddWithValue("@kullaniciAdi", KullanıcıAdı);
                    command.Parameters.AddWithValue("@password", Password);
                    command.Parameters.AddWithValue("@tcKimlikNo", TCKimlikNo);
                    command.Parameters.AddWithValue("@telefonNo", TelefonNo);
                    command.Parameters.AddWithValue("@adres", Adres);
                    command.Parameters.AddWithValue("@kullaniciType", userType);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Kullanıcı kaydı başarıyla oluşturuldu");
                        MessageBox.Show("Kullanıcı kaydı başarıyla oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        Console.WriteLine("Kullanıcı kaydı oluşturulamadı.");
                        MessageBox.Show("Kullanıcı kaydı oluşturulamadı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bağlantı hatası: " + ex.Message);
                    MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Veritabanından giriş kontrolü
        private void button2_Click(object sender, EventArgs e)
        {
            string kullaniciAdi = textBox8.Text.ToLower();
            string sifre = textBox9.Text;

            // Veritabanına bağlantı 
            string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Veritabanına bağlandı!");

                    string query = "SELECT COUNT(*) FROM Bilgi WHERE LOWER(KullanıcıAdı) = @kullaniciAdi AND LOWER(PASSWORD) = LOWER(@sifre)";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    command.Parameters.AddWithValue("@sifre", sifre);

                    int kullaniciSayisi = (int)command.ExecuteScalar();

                    if (kullaniciSayisi > 0)
                    {
                        Console.WriteLine("Giriş başarılı. Sisteme hoş geldiniz.");
                        MessageBox.Show("Giriş başarılı. Sisteme hoş geldiniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        Form2 form2 = new Form2();
                        this.Hide();
                        form2.Show();
                    }
                    else
                    {
                        Console.WriteLine("Kullanıcı adı veya şifre hatalı. Giriş başarısız!");
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı. Giriş başarısız!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Bağlantı hatası: " + ex.Message);
                    MessageBox.Show("Bağlantı hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }




        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void label10_Click(object sender, EventArgs e)
        {
            
        }

        private void toolTip2_Popup(object sender, PopupEventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        //Uygulumadan çıkış
        private void button3_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
