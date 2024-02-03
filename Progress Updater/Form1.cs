using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Progress_Updater
{
    public partial class Form1 : Form
    {
        private string string_to_append;
        private string path = "";
        public List<TextBox> textBoxes = new List<TextBox>();
        public Form1()
        {
            InitializeComponent();
            // Creating textbox list on boot because C# won't let me add them above
            textBoxes.Add(textBox1);
            textBoxes.Add(textBox2);
            textBoxes.Add(textBox3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Submit button method
        private void button1_Click(object sender, EventArgs e)
        {
            string_to_append = textBox1.Text + ", " + comboBox2.Text + ", " + textBox3.Text + ", " + textBox2.Text;
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.WriteLine("name, status, rating, date");
                }
            }
            try
            {
                using (StreamWriter sw = File.AppendText(path))
                {
                    sw.WriteLine(string_to_append);
                }
                foreach(var tb in textBoxes)
                {
                    tb.Text = "";
                }
                comboBox2.SelectedIndex = -1;
                MessageBox.Show("Entry to " + path + " successfully added!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        // Open Spreadsheet button method
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
                        sw.WriteLine("name, status, rating, date");
                    }
                }
                Process.Start(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        // Assigns path based on selection in dropdown 1
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case -1: { path = ""; break; }
                case 0: { path = "books.csv"; break; }
                case 1: { path = "games.csv"; break; }
            }
        }
    }
}
