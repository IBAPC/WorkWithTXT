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

namespace Lab2
{
    public partial class Form1 : Form
    {
        private string str = string.Empty;
        private bool Edited = false;

        public Form1()
        {
            InitializeComponent();

            textBox1.Text = string.Empty;
            this.Text = "Лабораторная №2";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ClassLibrary.Class1 c = new ClassLibrary.Class1();
            toolStripStatusLabel3.Text = "Состояние: Открытие файла";
            openFileDialog1.Filter = "txt files|*.txt;";
            openFileDialog1.Title = "Открыть файл";
            openFileDialog1.Multiselect = false;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                this.Text = openFileDialog1.FileName;
                textBox1.Text = c.OpenFile(openFileDialog1.FileName);
            }
            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Состояние: Печать документа";

            printDialog1.ShowDialog();

            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            ClassLibrary.Class1 c = new ClassLibrary.Class1();
            toolStripStatusLabel3.Text = "Состояние: Сохранение файла";
            saveFileDialog1.Filter = "txt files|*.txt;";
            if (str == string.Empty)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    str = saveFileDialog1.FileName;
                    this.Text = str;
                    c.SaveFile(saveFileDialog1.FileName, textBox1.Text);
                }

            }

            if (str != string.Empty)
            {
                c.SaveFile(saveFileDialog1.FileName, textBox1.Text);
            }

            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void шрифтToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Состояние: Выбор шрифта";

            fontDialog1.Font = textBox1.Font;

            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.Font = fontDialog1.Font;
            }

            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void панельИнструментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (панельИнструментовToolStripMenuItem.Checked == true)
            {
                toolStrip1.Visible = false;
                панельИнструментовToolStripMenuItem.Checked = false;
            }
            else
            {
                toolStrip1.Visible = true;
                панельИнструментовToolStripMenuItem.Checked = true;
            }
        }

        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Состояние: Справка о программе";
            Form2 about = new Form2();
            about.ShowDialog();
            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Edited = true;
            toolStripStatusLabel1.Text = "Число знаков: " + textBox1.Text.Length.ToString("D");
            toolStripStatusLabel2.Text = "Число строк: " + textBox1.Lines.Length.ToString("D");
            toolStripStatusLabel3.Text = "Состояние: Редактирование файла";
        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            str = string.Empty;
            toolStripButton2_Click(sender, e);
        }

        private void цветШрифтаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel3.Text = "Состояние: Выбор цвета шрифта";

            colorDialog1.Color = textBox1.ForeColor;

            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                textBox1.ForeColor = colorDialog1.Color;
            }

            toolStripStatusLabel3.Text = "Состояние: ";
        }

        private void поисToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 search = new Form3();
            search.TxtBox = textBox1.Text;
            toolStripStatusLabel3.Text = "Состояние: Поиск слов";
            search.ShowDialog();
            toolStripStatusLabel3.Text = "Состояние: ";
        }
    }
}
