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
    public partial class USERMAIN1 : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public USERMAIN1()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Logout','"+clsMySQL.usern+"')";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void USERMAIN1_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            name();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void name()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + clsMySQL.usern + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label8.Text = rd["username"].ToString();



            }
            rd.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {

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

        private void button5_Click(object sender, EventArgs e)
        {
            userorg org = new userorg();
            this.Hide();
            org.ShowDialog();
        }

    
    }
}
