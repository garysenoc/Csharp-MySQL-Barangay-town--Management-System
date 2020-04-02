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
    public partial class organization : Form
    {
        public string sID = "";
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public organization()
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

        private void organization_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            showlist();
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
        }
        private void showlist()
        {
            sql = "SELECT * FROM tbofficial WHERE id = 1";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                tx1.Text = rd["q"].ToString();
                tx2.Text = rd["w"].ToString();
                tx3.Text = rd["e"].ToString();
                tx4.Text = rd["r"].ToString();
                tx5.Text = rd["t"].ToString();
                tx6.Text = rd["y"].ToString();
                tx7.Text = rd["u"].ToString();
                tx8.Text = rd["i"].ToString();
                tx9.Text = rd["o"].ToString();
                tx10.Text = rd["p"].ToString();
               
               

            }
            rd.Close();

        }

        private void button11_Click(object sender, EventArgs e)
        {
           
            sql = string.Format("UPDATE tbofficial SET q='{0}', w='{1}', e='{2}',r='{3}', t='{4}', y='{5}', u='{6}', i='{7}', o='{8}', p='{9}' WHERE id=1",
        tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text, tx8.Text, tx9.Text, tx10.Text);
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            MessageBox.Show("Organization Data has been update successfully!", "Update Organization");
            showlist();
            sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Update Organization', 'Admin')";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button12_Click(object sender, EventArgs e)
        {
            showlist();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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
