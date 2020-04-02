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
    public partial class forgotpass : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public forgotpass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            toKnow();
        }

        private void forgotpass_Load(object sender, EventArgs e)
        {
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
        }
        private void toKnow()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + textBox1.Text + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {

                clsMySQL.userName = rd["username"].ToString();

            }
            rd.Close();

            if (clsMySQL.userName == textBox1.Text)
            {
                MessageBox.Show("Please Answer the Security question then continue");
                security q = new security();
                this.Hide();
                q.ShowDialog();
            }
            else
            {
                MessageBox.Show("The username you entered do not match any username in the database");
            }
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

        private void button2_Click(object sender, EventArgs e)
        {
            start st = new start();
            this.Hide();
            st.ShowDialog();
        }
    }
}
