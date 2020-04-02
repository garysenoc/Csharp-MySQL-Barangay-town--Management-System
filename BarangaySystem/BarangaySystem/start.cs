using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BarangaySystem
{
    public partial class start : Form
    {
        public start()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            LOGIN lo = new LOGIN();
            this.Hide();
            lo.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            userlogin us = new userlogin();
            this.Hide();
            us.ShowDialog();
        }
    }
}
