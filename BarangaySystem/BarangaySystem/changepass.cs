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
    public partial class changepass : Form
    {

        public string sID;
        public string sql = "";
        public string answer = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public changepass()
        {
            InitializeComponent();
        }

        private void changepass_Load(object sender, EventArgs e)
        {

        }
        private void changePass()
        {
            sql = "UPDATE tbaccount SET password = '" + textBox2.Text + "'WHERE username = '" + clsMySQL.userName + "'";

            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            sql_cmd.ExecuteNonQuery();
            MessageBox.Show("You have successfully change your password");
            Form1 main = new Form1();
            this.Hide();
           
            main.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != textBox1.Text)
            {
                MessageBox.Show("Please input the same password");
            }
            else if (textBox1.Text == textBox2.Text)
            {
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Change Pass','" + clsMySQL.usern + "')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                changePass();
            }
            else if (textBox2.Text == "" || textBox1.Text == "")
            {
                MessageBox.Show("Please input needed same password");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Password:")
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

            if (textBox2.Text == "Re-Enter Password:")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void changepass_Leave(object sender, EventArgs e)
        {

        }

        private void textBox2_Leave(object sender, EventArgs e)
        {

            if (textBox2.Text == "")
            {
                textBox2.ForeColor = Color.Silver;
                textBox2.Text = "Enter Username:";
            }
        }
    }
}
