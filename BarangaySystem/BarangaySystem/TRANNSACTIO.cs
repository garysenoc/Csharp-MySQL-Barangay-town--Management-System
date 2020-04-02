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
    public partial class TRANNSACTIO : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public TRANNSACTIO()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            residentt r = new residentt();
            this.Hide();
            r.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDRESIDENT ad = new ADDRESIDENT();
            this.Hide();
            ad.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EDIT ed = new EDIT();
            this.Hide();
            ed.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            TRANNSACTIO tr = new TRANNSACTIO();
            this.Hide();
            tr.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            organization or = new organization();
            this.Hide();
            or.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logs lo = new Logs();
            this.Hide();
            lo.ShowDialog();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            ADDACOUNT add = new ADDACOUNT();
            this.Hide();
            add.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MANAGEACCOUNT mana = new MANAGEACCOUNT();
            this.Hide();
            mana.ShowDialog();
        }

        private void TRANNSACTIO_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
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

        private void button13_Click(object sender, EventArgs e)
        {
            Form2 t2 = new Form2();
       
            t2.ShowDialog();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            Form3 q = new Form3();
            q.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Form4 a = new Form4();

            a.ShowDialog();
        }
    }
}
