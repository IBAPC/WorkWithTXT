using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Lab2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public string TxtBox
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "";
            for (int i = 0; i < textBox1.Text.Length; i++)
            {
                if (textBox1.Text[i] == ' ')
                {
                    int count = 0;
                    for (int j = i+1; textBox1.Text[j] != ' ' && j < textBox1.Text.Length - 1; j++)
                    {
                        char t = textBox1.Text[j];
                        str += t;
                        if (t == 'A' || t == 'E' || t == 'I' || t == 'O' || t == 'U' || t == 'Y' || t == 'a' || t == 'e' || t == 'i' || t == 'o' || t == 'u' || t == 'y')
                        {
                            count++;
                        }
                    }
                    if (count >= Convert.ToInt32(numericUpDown1.Value))
                    {
                        str = Regex.Replace(str, @"\W", "");
                        textBox2.Text += str.ToLower() + " ";
                        str = "";
                    }
                    else
                    {
                        str = "";
                    }
                }
            }
        }
    }
}
