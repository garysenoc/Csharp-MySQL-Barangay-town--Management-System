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
    public partial class Logs : Form
    {
        public string sID = "";
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public Logs()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Logs lo = new Logs();
            this.Hide();
            lo.ShowDialog();
        }

        private void Logs_Load(object sender, EventArgs e)
        {

            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            showList();
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
        }

        private void showList()
        {
            sql = "SELECT * FROM tbhistory";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["timeanddate"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["username"].ToString());
             
            }
            rd.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sID = listView1.FocusedItem.Text;
            if (sID == "" || sID == null) { return; }
            else
            {

            }
            {
                sql = "DELETE FROM history WHERE id=" + sID;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("You have successfully deleted a record");
                showList();
              


            }
        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbhistory where id like '%" + textBox10.Text + "%' OR  timeanddate like '%" + textBox10.Text + "%' OR  activity like '%" + textBox10.Text + "%' OR  username like '%" + textBox10.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["timeanddate"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["activity"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["username"].ToString());

            }
            rd.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            residentt r = new residentt();
            this.Hide();
            r.ShowDialog();
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

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

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
