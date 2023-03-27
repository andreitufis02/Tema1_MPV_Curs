using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tema_1___MPV___CURS___APLICATIA_2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double[,] valori = new double[10, 3] { { 69, 0, 0 }, { 6.9, 0, 0 }, { 987, 0, 0 }, { 98.7, 0, 0 }, { 23, 0, 0 }, { 2.3, 0, 0 }, { 8.34, 0, 0 }, { 3.8, 0, 0 }, { 10.02, 0, 0 }, { 4.67, 0, 0 } };
        double total = 0;
        double val_medie = 0;




        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            dataGridView1.Visible = false;
            listView1.Visible = false;
            for (int i = 0; i < 10; i++)
            {
                total = total + valori[i, 0];
                val_medie = val_medie + valori[i, 0] / 6;
            }

            for (int i = 0; i < 10; i++)
            {
                valori[i, 1] = valori[i, 0] / total * 100;
                valori[i, 2] = valori[i, 0] - val_medie;
            }
            label1.Text = label1.Text + Convert.ToString(total);
            label2.Text = label2.Text + Convert.ToString(val_medie);

        }

        private void btn_afisgrid_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            label1.Text = "Valoarea totala este = " + Math.Round(total);
            dataGridView1.Visible = true;
            dataGridView1.Columns.Add("Valori", "Valori"); ;
            dataGridView1.Columns.Add("Valori%", "Valori%");
            dataGridView1.Columns.Add("Abatere_medie", "Abatere_medie");

            for (int i = 0; i < 10; i++)
            {
                dataGridView1.Rows.Add(new object[] { Math.Round(valori[i, 0], 2), Math.Round(valori[i, 1]) + " %", Math.Round(valori[i, 2], 2) });
            }
        }

        private void btnlistView_Click(object sender, EventArgs e)
        {
            listView1.Visible = true;
            listView1.View = View.Details;
            listView1.Columns.Add("Valoare", 50, HorizontalAlignment.Left);
            listView1.Columns.Add("Valoare%", 75, HorizontalAlignment.Center);
            listView1.Columns.Add("Abatere_medie", 100, HorizontalAlignment.Right);

            for (int i = 0; i < 10; i++)
            {
                listView1.Items.Add(new ListViewItem(new[] { Math.Round(valori[i, 0], 2).ToString(), Convert.ToString(Math.Round(valori[i, 1])) + " %", Convert.ToString(Math.Round(valori[i, 2], 2)) }));
            }
            label2.Visible = true;
            label2.Text = "Valoarea medie este = " + Math.Round(val_medie);
        }
    }
}
