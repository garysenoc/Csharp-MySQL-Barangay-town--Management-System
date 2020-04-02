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
    public partial class ADDRESIDENT : Form
    {
        public string sID;
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public ADDRESIDENT()
        {
            InitializeComponent();
        }

        private void ADDRESIDENT_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
        }

        private void button11_Click(object sender, EventArgs e)
        {

            if (tx1.Text == "" || tx2.Text == "" || tx3.Text == "" || tx4.Text == "" || tx5.Text == "" || tx6.Text == "" || tx7.Text == "" || tx8.Text == "" || tx9.Text == "" || tx10.Text == "" || tx11.Text == "" || tx12.Text == "" || tx13.Text=="")
            {
                MessageBox.Show("Please fill up all the requirements");
            }
            else
            {
                addResident();
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Add a resident profile', 'Admin')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
            }
              
        }
        private void addResident()
        {

            sql = string.Format("INSERT INTO tbresident VALUES (null, '{0}', '{1}', '{2}','{3}', '{4}', '{5}', '{6}', '{7}', '{8}','{9}', '{10}','{11}', '{12}')",
      tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text, tx8.Text, tx9.Text, tx10.Text, tx11.Text, tx12.Text, tx13.Text);
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            MessageBox.Show("New Resident has been added successfully!", "Add Resident");
            clearall();

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            
              }

        private void clearall()
        {
            tx1.Text = ""; tx2.Text = ""; tx3.Text = ""; tx4.Text = ""; tx5.Text = ""; tx6.Text = ""; tx7.Text = ""; tx8.Text = ""; tx9.Text = ""; tx10.Text = ""; tx11.Text = ""; tx12.Text = ""; tx13.Text = "";
    
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
            Form1 fo = new Form1();
            this.Hide();
            fo.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

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
            ADDACOUNT ad = new ADDACOUNT();
            this.Hide();
            ad.ShowDialog();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            MANAGEACCOUNT man = new MANAGEACCOUNT();
            this.Hide();
            man.ShowDialog();
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
