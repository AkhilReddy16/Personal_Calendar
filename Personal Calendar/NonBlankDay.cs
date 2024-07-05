using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Personal_Calendar
{
    public partial class NonBlankDay : UserControl
    {
        public NonBlankDay()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void NonBlankDay_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }
    }
}
