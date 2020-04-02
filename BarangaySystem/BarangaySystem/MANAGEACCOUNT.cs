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
    public partial class MANAGEACCOUNT : Form
    {
        public string sID = "";
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        public MANAGEACCOUNT()
        {
            InitializeComponent();
        }

        private void MANAGEACCOUNT_Load(object sender, EventArgs e)
        {
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            showlist();
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void showlist()
        {
            sql = "SELECT * FROM tbaccount";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["surname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["mname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["username"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["password"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["securityquestion"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["secanswer"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["status"].ToString());
               
            }
            rd.Close();
        }
        private void Show_StudData(string srcID)
        {

            sql = "SELECT * FROM tbaccount WHERE id = " + srcID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                tx1.Text = rd["surname"].ToString();
                tx2.Text = rd["fname"].ToString();
                tx3.Text = rd["mname"].ToString();
                tx4.Text = rd["username"].ToString();
                tx5.Text = rd["password"].ToString();
                tx6.Text = rd["securityquestion"].ToString();
                tx7.Text = rd["secanswer"].ToString();
                label13.Text = rd["status"].ToString();
              pictureBox5.ImageLocation = rd["pic"].ToString();

            }
            rd.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sID = listView1.FocusedItem.Text;
            if (sID == "" || sID == null) { return; }
            Show_StudData(sID);
            checkStatus();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();

            // image filters  
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                // display image in picture box  
                pictureBox5.Image = new Bitmap(open.FileName);
                pic = open.FileName.Replace(@"\", @"\\");
            }
        }
        private void updateRecord(string srcID)
        {
            if (pic == ""||pic ==null)
            {
                sql = string.Format("UPDATE tbaccount SET surname='{0}', fname='{1}', mname='{2}',username='{3}', password='{4}', securityquestion='{5}', secanswer='{6}' WHERE id={7}",
tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text,srcID);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("Account Data has been update successfully!", "Update Account");
                clearall();
                showlist();
                Show_StudData(sID);
            }
            else
            {
                sql = string.Format("UPDATE tbaccount SET surname='{0}', fname='{1}', mname='{2}',username='{3}', password='{4}', securityquestion='{5}', secanswer='{6}', pic='{7}' WHERE id={8}",
tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text, pic, srcID);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                clearall();
                showlist();
                Show_StudData(sID);
                MessageBox.Show("Account Data has been update successfully!", "Update Account");

            }
          
        }
        private void clearall()
        {
            tx1.Text = ""; tx2.Text = ""; tx3.Text = ""; tx4.Text = ""; tx5.Text = ""; tx6.Text = ""; tx7.Text = "";
            pictureBox5.Image = null;
            pic = "";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (sID == "" || sID == null)
            {
                MessageBox.Show("Select first a student");
            }
            else
            {
                updateRecord(sID);
                showlist();
                Show_StudData(sID);
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Update an account', 'Admin')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            Show_StudData(sID);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            sID = listView1.FocusedItem.Text;
            if (sID == "" || sID == null) { return; }
            else
            {

            }
            {
                sql = "DELETE FROM tbaccount WHERE id=" + sID;
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("You have successfully deleted a record of a resident");
                showlist();
                clearall();
          

            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (sID == "")
            {
                MessageBox.Show("Select a student first");
            }
            else if(button12.Text == "Deactivate Account")
            {
                sID = listView1.FocusedItem.Text;
                if (sID == "" || sID == null) { return; }
              
                else
                {
                    sql = "UPDATE tbaccount set status = 'Not Active' WHERE id=" + sID;
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    sql_cmd.ExecuteNonQuery();
                    MessageBox.Show("You have successfully deactivate an account");
                    showlist();
                    clearall();
                    Show_StudData(sID);
                    checkStatus();

                    sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Deactivate an account', 'Admin')";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    sql_cmd.ExecuteNonQuery();
                }

               
            }

            else
            {
                sID = listView1.FocusedItem.Text;
                if (sID == "" || sID == null) { return; }
                else
                {

                }
                {
                    sql = "UPDATE tbaccount set status = 'Active' WHERE id=" + sID;
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    sql_cmd.ExecuteNonQuery();
                    MessageBox.Show("You have successfully activate a record of a resident");
                    showlist();
                    clearall();
                    Show_StudData(sID);
                    checkStatus();
                    sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Activate an account', 'Admin')";
                    sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                    sql_cmd.ExecuteNonQuery();
                    sID = "";
                }
            }

           
        }

        private void checkStatus()
        {
            if(label13.Text == "Active")
            {
                button12.Text = "Deactivate Account";

            }
            else
            {
                button12.Text = "Activate Account";
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbaccount where id like '%" + textBox10.Text + "%' or surname like '%" + textBox10.Text + "%' or fname like '%" + textBox10.Text + "%' or mname like '%" + textBox10.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["surname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["mname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["username"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["password"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["securityquestion"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["secanswer"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["status"].ToString());

            }
            rd.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            residentt r = new residentt();
            this.Hide();
            r.ShowDialog();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
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
