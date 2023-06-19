namespace YazilimYapimi3
{
    public partial class Form2 : Form
    {


        private void Form2_Load(object sender, EventArgs e)
        {
            // Form2'nin yüklenmesi sırasında yapılacak işlemler
        }

        private void InitializeComponent()
        {
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            dateTimePicker1 = new DateTimePicker();
            button4 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(111, 191);
            button1.Name = "button1";
            button1.Size = new Size(161, 23);
            button1.TabIndex = 0;
            button1.Text = "Olayları Listeleme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(111, 133);
            button2.Name = "button2";
            button2.Size = new Size(161, 23);
            button2.TabIndex = 1;
            button2.Text = "Olay Tanımlama";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 2;
            label1.Text = "Tarih :";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 83);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 4;
            label2.Text = "Olay  :";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(91, 75);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(200, 23);
            textBox2.TabIndex = 5;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(111, 249);
            button3.Name = "button3";
            button3.Size = new Size(161, 23);
            button3.TabIndex = 6;
            button3.Text = "Olaylara Git";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(91, 22);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 7;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // button4
            // 
            button4.Location = new Point(111, 307);
            button4.Name = "button4";
            button4.Size = new Size(161, 23);
            button4.TabIndex = 25;
            button4.Text = "Çıkış Yap";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form2
            // 
            ClientSize = new Size(374, 350);
            Controls.Add(button4);
            Controls.Add(dateTimePicker1);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form2";
            Text = "Olay Tanımlama Ve Listeleme Ekranı";
            ResumeLayout(false);
            PerformLayout();
        }

        private Button button1;
        private Button button2;
        private Label label1;
        private Label label2;
        private TextBox textBox2;
        private Button button3;
        private DateTimePicker dateTimePicker1;
        private Button button4;
    }
}
