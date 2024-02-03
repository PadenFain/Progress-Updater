using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Progress_Updater
{     
    public partial class Form1 : Form
    {
        private string string_to_append;
        private string path = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string_to_append = textBox1.Text + ", " + comboBox2.Text + ", " + textBox3.Text;
            if(!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("name, status, rating");
                }
            }
            using(StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(string_to_append);
            }
            MessageBox.Show("You added " + string_to_append + " to " +  path);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (path == "")
                {
                    MessageBox.Show("Select a dropdown option");
                    return;
                }
                if (!File.Exists(path))
                {
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine("name, status, rating");
                    }
                }
                Process.Start(path);
            }
            catch (Exception except)
            {
                MessageBox.Show(except.Message);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1: { path = "";  break; }
                case 0: { path = "books.csv"; break; }
                case 1: { path = "games.csv"; break; }
            }
        }
    }
}
