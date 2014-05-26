using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Labirunt
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            listBox1.Items.Clear();
            string[] mas = new string[20];
            for (int i = 0; i < 14; i++)
            {
                for (int j = 0; j < 17; j++)
                {
                    mas[i] += "  " + form1.MASIV[j, i].ToString();
                }
                listBox1.Items.Add(mas[i]);
            }       
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            listBox1.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }

}
