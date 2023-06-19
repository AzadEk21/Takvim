namespace YazilimYapimi3
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    // Veritabanına bağlantı
    public partial class Form3 : Form
    {
        private SqlConnection connection;
        private string connectionString = "Data Source=HP-OMEN;Initial Catalog=OgrenciBilgileriVT;Integrated Security=True;User ID=azad;Password=123";
        private DateTime? selectedDate;
        private string selectedEvent = string.Empty; 

        public Form3()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            connection.Open();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void label3_Click(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {
            
        }
        // Veritabanından olayları alıp takvimde göster
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            selectedDate = monthCalendar1.SelectionStart.Date;

            
            string selectQuery = "SELECT YapilanIş FROM Olaylar WHERE Zaman = @Zaman";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Zaman", selectedDate);

            List<string> events = new List<string>();

            using (SqlDataReader reader = selectCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    string yapilanIs = reader.GetString(0);
                    events.Add(yapilanIs);
                }
            }

            // Alınan olayları göster
            if (events.Count > 0)
            {
                string eventList = string.Join(Environment.NewLine, events);
                MessageBox.Show($"Seçili günde kaydedilmiş olaylar:{Environment.NewLine}{eventList}");
            }
            else
            {
                MessageBox.Show("Seçili günde kaydedilmiş olay bulunmamaktadır.");
            }
        }

        public partial class DateSelectionForm : Form
        {
            public DateTime SelectedDate { get; private set; }
        }
        // Veritabanından seçili tarihte kaydedilmiş olayı sil
        private void button1_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart.Date;

            
            string deleteQuery = "DELETE FROM Olaylar WHERE Zaman = @Zaman";
            SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection);
            deleteCommand.Parameters.AddWithValue("@Zaman", selectedDate);
            deleteCommand.ExecuteNonQuery();

            MessageBox.Show("Olay başarıyla silindi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (selectedDate == null)
            {
                MessageBox.Show("Geçerli bir tarih seçiniz!");
                return;
            }

            // Form4'ü açarak tarih seçimini yapar
            using (var form4 = new Form4())
            {
                if (form4.ShowDialog() == DialogResult.OK)
                {
                    DateTime yeniTarih = form4.SelectedDate.Date;

                    // Seçili olayı yeni tarihe güncelle
                    string updateQuery = "UPDATE Olaylar SET Zaman = @YeniTarih WHERE Zaman = @EskiTarih";
                    SqlCommand updateCommand = new SqlCommand(updateQuery, connection);
                    updateCommand.Parameters.AddWithValue("@YeniTarih", yeniTarih);
                    updateCommand.Parameters.AddWithValue("@EskiTarih", selectedDate.Value);
                    int affectedRows = updateCommand.ExecuteNonQuery();

                    if (affectedRows > 0)
                    {
                        MessageBox.Show("Olay başarıyla güncellendi.");
                    }
                    else
                    {
                        MessageBox.Show("Güncellenecek olay bulunamadı!");
                    }
                }
                else
                {
                    MessageBox.Show("Geçersiz tarih seçimi!");
                }
            }
        }
         //Hatırlatıcı oluşturma
        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedDate == null)
            {
                MessageBox.Show("Geçerli bir tarih seçiniz!");
                return;
            }

            // Veritabanından seçili tarihte kaydedilmiş olayları al
            string selectQuery = "SELECT YapilanIş FROM Olaylar WHERE Zaman = @Zaman";
            SqlCommand selectCommand = new SqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@Zaman", selectedDate);

            string? currentSelectedEvent = selectCommand.ExecuteScalar() as string;

            if (currentSelectedEvent == null)
            {
                MessageBox.Show("Seçili tarihte olay bulunmamaktadır.");
                return;
            }

            selectedEvent = currentSelectedEvent; 

            System.Windows.Forms.Timer hatirlaticiTimer = new System.Windows.Forms.Timer();
            hatirlaticiTimer.Interval = 1000; 
            hatirlaticiTimer.Tick += (hatirlaticiSender, hatirlaticiEventArgs) =>
            {
                TimeSpan remainingTime = selectedDate.Value - DateTime.Now;

                if (remainingTime <= TimeSpan.Zero)
                {
                    hatirlaticiTimer.Stop();
                    MessageBox.Show("Hatırlatıcı alarmı: " + selectedEvent);
                    System.Media.SystemSounds.Exclamation.Play(); 
                }
                else
                {   //Kalan zamanı hesaplar
                    int years = remainingTime.Days / 365;
                    int months = (remainingTime.Days % 365) / 30;
                    int days = (remainingTime.Days % 365) % 30;
                    int hours = remainingTime.Hours;
                    int minutes = remainingTime.Minutes;
                    int seconds = remainingTime.Seconds;
                    //Kalan zamanı ekrana yazdırır
                    string countdownMessage = string.Format("{0} adlı olaya {1} yıl, {2} ay, {3} gün, {4} saat, {5} dakika, {6} saniye kaldı",
                        selectedEvent, years, months, days, hours, minutes, seconds);

                    labelCountdown.Text = countdownMessage;
                }
            };

            if (selectedEvent != null)
            {
                hatirlaticiTimer.Start();
            }
        }


        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            selectedEvent = string.Empty; 
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
        //Uygulumadan çıkış
        private void button4_Click(object sender, EventArgs e)
        {
            
            Application.Exit();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
