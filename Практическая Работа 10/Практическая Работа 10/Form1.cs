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

namespace Практическая_Работа_10
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;
            button5.Enabled = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            if (f.ShowDialog() == DialogResult.OK)
            {
                string fio = f.textBox2.Text;
                double v = Convert.ToDouble(f.textBox3.Text);
                int r = Convert.ToInt32(f.textBox4.Text);
                People p = new People();
                p.FIO = fio;
                p.ves = v;
                p.rost = r;
                listBox1.Items.Add(p);

                button5.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран объект для удаления");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(k);
                if (listBox1.Items.Count == 0)
                {
                    button5.Enabled = false;
                }
                button2.Enabled = false;
                button3.Enabled = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Не выбран объект для редактирования");
            }
            else
            {
                int k = listBox1.SelectedIndex;
                People p = listBox1.Items[k] as People;
                Form2 f = new Form2();
                f.textBox2.Text = p.FIO;
                f.textBox3.Text = p.rost.ToString();
                f.textBox4.Text = p.ves.ToString();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    p.FIO = f.textBox2.Text;
                    p.rost = Convert.ToInt32(f.textBox3.Text);
                    p.ves = Convert.ToDouble(f.textBox4.Text);
                    listBox1.Items[k] = p;
                }

        }   }

        private void button6_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(saveFileDialog1.FileName);
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    People p = listBox1.Items[i] as People;
                    sw.WriteLine(p.FIO);
                    sw.WriteLine(p.ves);
                    sw.WriteLine(p.rost);
                }
                sw.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while (!sr.EndOfStream)
                {
                    People p = new People();
                    p.FIO = sr.ReadLine();
                    p.ves = Convert.ToDouble(sr.ReadLine());
                    p.rost = Convert.ToInt32(sr.ReadLine());

                    listBox1.Items.Add(p);
                }
                sr.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sum = 0;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                People p = listBox1.Items[i] as People;
                sum += p.rost;

            }
            MessageBox.Show((sum * 1.0 / listBox1.Items.Count).ToString());
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button5.Enabled = true;
            }
        }
    }
} 
