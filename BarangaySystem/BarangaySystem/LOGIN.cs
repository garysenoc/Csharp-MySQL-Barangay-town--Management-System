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
    public partial class LOGIN : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public string usern, pass;
        public LOGIN()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {

            if (textBox1.Text == "Enter Username:")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void LOGIN_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
        }

        private void LOGIN_Enter(object sender, EventArgs e)
        {
        }

        private void LOGIN_Leave(object sender, EventArgs e)
        {

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
        private void login(String username, String password)
        {
            sql = "SELECT  * FROM tbadmin WHERE username like '" + username + "' AND password = '" + password + "'";
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
                MessageBox.Show("Admin have successfully logged in");
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Login', 'Admin')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                Form1 main = new Form1();
                this.Hide();
                main.ShowDialog();


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

        private void button1_Click(object sender, EventArgs e)
        {
            login(textBox1.Text, textBox2.Text);
        }
    }
}
