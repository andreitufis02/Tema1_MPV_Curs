using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema01_MPV_CURS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("PF1");
            comboBox1.Items.Add("PF2");
            comboBox1.Items.Add("PF3");
            comboBox1.Items.Add("PF4");
            comboBox2.Items.Add("PJ1");
            comboBox2.Items.Add("PJ2");

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                comboBox1.Visible = true;
                comboBox1.SelectedIndex = 0;
                comboBox2.Visible = false;
            }
            else
            {
                comboBox1.Visible = false;
                comboBox2.SelectedIndex = 0;
                comboBox2.Visible = true;
            }
        }

        // se definesc tablourile globale
        // var I. 3 tablouri liniare pentru a memora: clientul care a emis comanda, data comenzii si valoarea acesteia
        string[] client = new string[50];
        string[] data = new string[50];
        double[] valoare = new double[50];
        // var II. un tablou bidimensional cu 3 coloane pentru client, data comanda si valoare; toate informatiile fiind considerate de tip string
        string[,] date = new string[50, 3];
        int i1 = 0;
        int i2 = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                client[i1] = comboBox1.Text;
            else
                client[i1] = comboBox2.Text;
            data[i1] = monthCalendar1.SelectionRange.Start.ToShortDateString();
            valoare[i1] = Convert.ToDouble(textBox1.Text);
            i1++;
            textBox1.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int j;
            listBox1.Items.Clear();
            for (j = 0; j < i1; j++)
            listBox1.Items.Add(client[j] + "   " + data[j] + "   " + valoare[j]);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
                date[i2, 0] = comboBox1.Text;
            else
                date[i2, 0] = comboBox2.Text;
            date[i2, 1] = monthCalendar1.SelectionRange.Start.ToShortDateString();
            date[i2, 2] = textBox1.Text;
            i2++;
            textBox1.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int j;
            listBox1.Items.Clear();
            for (j = 0; j < i2; j++)
            listBox1.Items.Add(date[j, 0] + "   " + date[j, 1] + "   " + date[j, 2]);

        }

        private void button5_Click(object sender, EventArgs e)
        {
            i1 = 0;
            i2 = 0;
            radioButton1.Checked = true;
            textBox1.Text = "";
            listBox1.Items.Clear();
        }
    }
}