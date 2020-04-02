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
    public partial class userorg : Form
    {

        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public string usern, pass, status, fullname;
        public userorg()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Logout','" + clsMySQL.usern + "')";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void userorg_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            showlist();
            name();
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
        private void name()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + clsMySQL.usern + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label13.Text = rd["username"].ToString();



            }
            rd.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            USERMAIN1 ma = new USERMAIN1();
            this.Hide();
            ma.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            USERRESIDENT res = new USERRESIDENT();
            this.Hide();
            res.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            USERPROFILE pro = new USERPROFILE();
            this.Hide();
            pro.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }
    }
}
