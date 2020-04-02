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
    public partial class userlogin : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public string usern, pass, status, fullname;
        public userlogin()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            login(textBox1.Text, textBox2.Text);
        }
        private void toCheckStatus()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + usern + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                status = rd["status"].ToString();
             
            }
            rd.Close();

            if (status == "Active")
            {

                MessageBox.Show("You have successfully login");
                clsMySQL.usern = usern;
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Login','" + clsMySQL.usern + "')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                USERMAIN1 m = new USERMAIN1();
                this.Hide();
                m.ShowDialog();
              
            }
            else if (status == "Not Active")
            {
                MessageBox.Show("Your account has been deactivated by the admin");
            }
        }
        private void login(String username, String password)
        {
            sql = "SELECT  * FROM tbaccount WHERE username like '" + username + "' AND password = '" + password + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                usern = rd["username"].ToString();
                pass = rd["password"].ToString();
            }
            rd.Close();

            if (username == usern && password == pass)
            {

                toCheckStatus();


            }
            else if (username == "Enter Username:" || pass == "Enter Password:")
            {
                MessageBox.Show("Please fill up all the requirements", "Fill up", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                MessageBox.Show("Invalid Username or Password", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                login(textBox1.Text, textBox2.Text);
            }
        }

        private void userlogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "Enter Username:")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.ForeColor = Color.Silver;
                textBox1.Text = "Enter Username:";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Password:")
                textBox2.Text = "";
            textBox2.ForeColor = Color.Black;
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Silver;
                textBox2.Text = "Enter Username:";
            }
        }

        private void label2_Click(object sender, EventArgs e)   
        {
            forgotpass fore = new forgotpass();
                this.Hide();
            fore.ShowDialog();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
