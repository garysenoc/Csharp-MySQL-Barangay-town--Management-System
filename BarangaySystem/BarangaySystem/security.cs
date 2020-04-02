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
    public partial class security : Form
    {
        public string sID;
        public string sql = "";
        public string answer = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public security()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }

        private void security_Load(object sender, EventArgs e)
        {
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            question();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter Answer:")
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
                textBox1.Text = "Enter Answer:";
            }
        }
        private void question()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + clsMySQL.userName + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.question = rd["securityquestion"].ToString();
                answer = rd["secanswer"].ToString();
               

            }
            rd.Close();
            label2.Text = clsMySQL.question;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == answer)
            {
                MessageBox.Show("You can now change your password");
                changepass pass = new changepass();
                this.Hide();
                pass.Show();
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Please put an answer");
            }
            else
            {
                MessageBox.Show("Invalid answer");
            }
        }
    }
}
