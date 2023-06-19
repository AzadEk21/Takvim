namespace YazilimYapimi3
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            monthCalendar1 = new MonthCalendar();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            labelCountdown = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 36);
            label1.Name = "label1";
            label1.Size = new Size(120, 45);
            label1.TabIndex = 0;
            label1.Text = "Olayı silmek için \r\ntarih seçip Olay Silme\r\nbuttonuna tıklayın";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 185);
            label2.Name = "label2";
            label2.Size = new Size(139, 45);
            label2.TabIndex = 1;
            label2.Text = "Hatırlatıcı eklemek için \r\ntarih seçip Hatırlatıcı Ekle\r\nbuttonuna tıklayın";
            label2.Click += label2_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(12, 111);
            label3.Name = "label3";
            label3.Size = new Size(157, 45);
            label3.TabIndex = 2;
            label3.Text = "Olayı güncellemek için tarih \r\nseçip Olay Güncelleme\r\nbuttonuna tıklayın\r\n";
            label3.Click += label3_Click;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(461, 47);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 4;
            monthCalendar1.DateChanged += monthCalendar1_DateChanged;
            // 
            // button1
            // 
            button1.Location = new Point(196, 47);
            button1.Name = "button1";
            button1.Size = new Size(171, 23);
            button1.TabIndex = 5;
            button1.Text = "Olay Silme";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(196, 122);
            button2.Name = "button2";
            button2.Size = new Size(171, 23);
            button2.TabIndex = 6;
            button2.Text = "Olay Güncelleme";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(196, 200);
            button3.Name = "button3";
            button3.Size = new Size(171, 23);
            button3.TabIndex = 7;
            button3.Text = "Hatırlatıcı Ekle";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(196, 248);
            button4.Name = "button4";
            button4.Size = new Size(171, 23);
            button4.TabIndex = 26;
            button4.Text = "Çıkış Yap";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // labelCountdown
            // 
            labelCountdown.AutoSize = true;
            labelCountdown.Location = new Point(388, 232);
            labelCountdown.Name = "labelCountdown";
            labelCountdown.Size = new Size(16, 15);
            labelCountdown.TabIndex = 27;
            labelCountdown.Text = "   ";
            labelCountdown.Click += label4_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 302);
            Controls.Add(labelCountdown);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(monthCalendar1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form3";
            Text = "Olayları Silme Güncelleme Ve Hatırlatıcı Ekleme Ekranı";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private MonthCalendar monthCalendar1;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Label labelCountdown;
    }
}