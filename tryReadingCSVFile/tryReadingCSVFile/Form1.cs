using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace tryReadingCSVFile
{
    public partial class Form1 : Form 
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string userid, password;
            userid = textBox1.Text;
            password = textBox2.Text;
            string path = @"C:\Users\Sana\Desktop\users.csv";
            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                string[] row;
                List<User> list = new List<User>();
                User u = new User();


                while ((line = sr.ReadLine()) != null)
                {
                    row = line.Split(',');
                    u.setUserName(row[0]);
                    u.setPassword(row[1]);
                    list.Add(u);
                }
                TextBox username = new TextBox();
                username.Name = "textBox1";
                userid = u.getUserName();
                //username.Text = "hhhh";
            }
        }



            


    

    private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}