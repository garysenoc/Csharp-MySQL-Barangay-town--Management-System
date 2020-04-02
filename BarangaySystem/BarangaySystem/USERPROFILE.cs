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
    public partial class USERPROFILE : Form
    {
        public string sID;
        public string sql = "";
        public MySqlCommand sql_cmd = new MySqlCommand();
        public string pic = "";
        public USERPROFILE()
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

        private void USERPROFILE_Load(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            label3.Text = now.ToString();
            this.ActiveControl = label1;
            clsMySQL.sql_con.Close();
            clsMySQL.sql_con.Open();
            name();
            Show_StudData();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private void name()
        {
            sql = "SELECT * FROM tbaccount WHERE username = '" + clsMySQL.usern + "'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                label30.Text = rd["username"].ToString();
            }
            rd.Close();

        }
        private void Show_StudData()
        {

            sql = "SELECT * FROM tbaccount WHERE username= '" +clsMySQL.usern+"'";
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
                      pictureBox5.ImageLocation=  rd["pic"].ToString();
                      clsMySQL.usern = rd["username"].ToString();
                
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

        private void button5_Click(object sender, EventArgs e)
        {
            userorg or = new userorg();
            this.Hide();
            or.ShowDialog();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if(pic==""||pic==null)
            {
                sql = string.Format("UPDATE tbaccount SET surname='{0}', fname='{1}', mname='{2}',username='{3}', password='{4}', securityquestion='{5}', secanswer='{6}', secanswer='{6}'WHERE username='{7}'",
                tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text, clsMySQL.usern);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("Your profile has been update successfully!", "Update Resident");
                Show_StudData();
                sql = "INSERT INTO tbhistory(timeanddate,activity,username) VALUES(now(),'Update Profile','" + clsMySQL.usern + "')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
            }
            else
            {
                sql = string.Format("UPDATE tbaccount SET surname='{0}', fname='{1}', mname='{2}',username='{3}', password='{4}', securityquestion='{5}', secanswer='{6}', secanswer='{6}',pic='{7}' WHERE username='{8}'",
               tx1.Text, tx2.Text, tx3.Text, tx4.Text, tx5.Text, tx6.Text, tx7.Text, pic, clsMySQL.usern);
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                MessageBox.Show("Your profile has been update successfully!", "Update Resident");
                sql = "INSERT INTO tbhistory(timeanddate,activity,username)VALUES(now(),'Update Profile','" + clsMySQL.usern + "')";
                sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
                sql_cmd.ExecuteNonQuery();
                Show_StudData();
            }
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

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

        private void button14_Click(object sender, EventArgs e)
        {
            Show_StudData();
        }
    }
}
