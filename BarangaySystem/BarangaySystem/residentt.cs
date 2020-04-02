﻿using System;
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
    public partial class residentt : Form
    {
        public string sID;
        public string sql = "";
        public string pic;
        public MySqlCommand sql_cmd = new MySqlCommand();
        
        public residentt()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EDIT ed = new EDIT();
            this.Hide();
            ed.ShowDialog();
        }

        private void residentt_Load(object sender, EventArgs e)
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
              sql = "SELECT * FROM tbresident";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
               listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["surname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["mname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["bday"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["age"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["birthplace"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["sex"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["civil"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["citizen"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["relgion"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["occupation"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["houseno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["purok"].ToString());
            }
            rd.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void Show_StudData(string srcID)
        {

            sql = "SELECT * FROM tbresident WHERE id = " + srcID;
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            while (rd.Read())
            {
                lb1.Text = rd["surname"].ToString();
                lb2.Text = rd["fname"].ToString();
                lb3.Text = rd["mname"].ToString();
                lb4.Text = rd["bday"].ToString();
                lb5.Text = rd["age"].ToString();
                lb6.Text = rd["birthplace"].ToString();
                lb7.Text = rd["sex"].ToString();
                lb8.Text = rd["civil"].ToString();
                lb9.Text = rd["citizen"].ToString();
                lb10.Text = rd["relgion"].ToString();
                lb11.Text = rd["occupation"].ToString();
                lb12.Text = rd["houseno"].ToString();
                lb13.Text = rd["purok"].ToString();
             
            }
            rd.Close();

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            sID = listView1.FocusedItem.Text;
            if (sID == "" || sID == null) { return; }
            Show_StudData(sID);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            sql = "SELECT * FROM tbresident where id like '%" + textBox1.Text + "%' OR surname like '%" + textBox1.Text + "%'OR fname like '%" + textBox1.Text + "%'OR mname like '%" + textBox1.Text + "%'OR bday like '%" + textBox1.Text + "%'OR age like '%" + textBox1.Text + "%'OR birthplace like '%" + textBox1.Text + "%'OR sex like '%" + textBox1.Text + "%'OR civil like '%" + textBox1.Text + "%'OR citizen like '%" + textBox1.Text + "%'OR relgion like '%" + textBox1.Text + "%'OR occupation like '%" + textBox1.Text + "%'OR houseno like '%" + textBox1.Text + "%'OR purok like '%" + textBox1.Text + "%'";
            sql_cmd = new MySqlCommand(sql, clsMySQL.sql_con);
            MySqlDataReader rd = sql_cmd.ExecuteReader();
            listView1.Items.Clear();
            while (rd.Read())
            {
                listView1.Items.Add(rd["id"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["surname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["fname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["mname"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["bday"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["age"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["birthplace"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["sex"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["civil"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["citizen"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["relgion"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["occupation"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["houseno"].ToString());
                listView1.Items[listView1.Items.Count - 1].SubItems.Add(rd["purok"].ToString());
            }
            rd.Close();
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            residentt r = new residentt();
            this.Hide();
            r.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            this.Hide();
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ADDRESIDENT ad = new ADDRESIDENT();
            this.Hide();
            ad.ShowDialog();
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

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
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

