using System;
using System.Windows.Forms;

namespace YazilimYapimi3
{
    public partial class Form4 : Form
    {
        public DateTime SelectedDate { get; private set; }

        public Form4()
        {
            InitializeComponent();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            SelectedDate = monthCalendar1.SelectionStart.Date;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
