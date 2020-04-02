using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace BarangaySystem
{
    public partial class Form1 : Form
    {
        public string sID;
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public Form1()
        {
            InitializeComponent();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            residentt r = new residentt();
            this.Hide();
            r.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDRESIDENT a = new ADDRESIDENT();
            this.Hide();
            a.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EDIT s = new EDIT();
            this.Hide();
            s.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TRANNSACTIO T = new TRANNSACTIO();
            this.Hide();
            T.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            organization o = new organization();
            this.Hide();
            o.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logs l = new Logs();
            this.Hide();
            l.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ADDACOUNT ac = new ADDACOUNT();
            this.Hide();
            ac.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MANAGEACCOUNT mn = new MANAGEACCOUNT();
            this.Hide();
            mn.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();

            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Logout', 'Admin')";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }
    }
}
