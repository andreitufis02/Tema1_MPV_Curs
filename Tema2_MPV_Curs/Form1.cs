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
using OfficeOpenXml;
using OfficeOpenXml.Style;


namespace Tema2_MPV_Curs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }

        double[,] numere = new double[5, 4];
        double val_max;
        double val_med = 0;

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            label2.Visible = false;
            // generarea unor valori random intre limitele -10 si 98
            Random r = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    numere[i, j] = r.Next(-10, 98);
            // valorile se vizualizeaza intr-un dataGridView: 4 coloane si 5 linii 
            dataGridView1.Visible = true;
            dataGridView1.Columns.Add("c0", "Coloana0"); ;
            dataGridView1.Columns.Add("c1", "Coloana1");
            dataGridView1.Columns.Add("c2", "Coloana2");
            dataGridView1.Columns.Add("c3", "Coloana3");
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add(new object[] { numere[i, 0], numere[i, 1], numere[i, 2], numere[i, 3] });
            }
            dataGridView1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // determinare valoare medie 
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    val_med = val_med + Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);
            val_med = val_med / 20;

            // comparare cu val_med
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) < val_med)
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Red;
                    else
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.YellowGreen;

            // determinare valoare maxima
            val_max = Convert.ToDouble(dataGridView1.Rows[0].Cells[0].Value);
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    if (val_max < Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value))
                        val_max = Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value);

            // marcare maxim in dataGridView - background verde inchis
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    if (Convert.ToDouble(dataGridView1.Rows[i].Cells[j].Value) == val_max)
                        dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.Green;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool este_sortat;
            double aux;
            for (int j = 0; j < 4; j++)
            {
                //sorarea elementelor din coloana j
                do
                {
                    este_sortat = true;
                    for (int i = 0; i < 4; i++)
                        if (numere[i, j] > numere[i + 1, j])
                        {
                            aux = numere[i, j];
                            numere[i, j] = numere[i + 1, j];
                            numere[i + 1, j] = aux;
                            este_sortat = false;
                        }
                }
                while (este_sortat == false);
            }

            // afisare in dataGridView2 a datelor sortate in cadrul coloanelor
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.Add("c0", "Coloana0");
                dataGridView2.Columns.Add("c1", "Coloana1");
                dataGridView2.Columns.Add("c2", "Coloana2");
                dataGridView2.Columns.Add("c3", "Coloana3");
                for (int i = 0; i < 5; i++)
                {
                    dataGridView2.Rows.Add(new object[] { numere[i, 0], numere[i, 1], numere[i, 2], numere[i, 3] });
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Suma elementelor din coloanele pare si din coloanele impare
            double[] sume = new double[4];
            for (int j = 0; j < 4; j++)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (j % 2 == 0) // coloane pare
                        sume[0] += numere[i, j];
                    else // coloane impare
                        sume[1] += numere[i, j];
                }
            }
            // Suma elementelor plasate in linia 3
            for (int j = 0; j < 4; j++)
            {
                sume[2] += numere[2, j];
            }
            // Suma elementelor plasate in linia 4
            for (int j = 0; j < 4; j++)
            {
                sume[3] += numere[3, j];
            }
            // Afisare sume
            string[] headers = { "Suma coloane pare", "Suma coloane impare", "Suma linia 3", "Suma linia 4" };
            dataGridView3.Columns.Clear();
            dataGridView3.Rows.Clear();
            dataGridView3.Columns.Add("c0", "Suma");
            dataGridView3.Columns.Add("c1", "Descriere");
            for (int i = 0; i < 4; i++)
            {
                dataGridView3.Rows.Add(new object[] { sume[i], headers[i] });
            }
            dataGridView3.ReadOnly = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            numere = new double[5, 4];
            Random r = new Random();
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 4; j++)
                    numere[i, j] = r.Next(-10, 98);

            dataGridView1.Rows.Clear();
            dataGridView2.Rows.Clear();
            dataGridView3.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView2.Columns.Clear();
            dataGridView3.Columns.Clear();
            richTextBox1.Clear();
            chart1.Series.Clear(); 

            dataGridView1.Columns.Add("c0", "Coloana0");
            dataGridView1.Columns.Add("c1", "Coloana1");
            dataGridView1.Columns.Add("c2", "Coloana2");
            dataGridView1.Columns.Add("c3", "Coloana3");
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Rows.Add(new object[] { numere[i, 0], numere[i, 1], numere[i, 2], numere[i, 3] });
            }

            dataGridView1.Refresh();
            dataGridView2.Refresh();
            dataGridView3.Refresh();

            label1.Text = "";
            label2.Text = "";
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            label1.Text = "";
            label1.Visible = true;
            // calculează suma elementelor de pe diagonala principală
            double sumaDiagonalaPrincipala = 0;
            for (int i = 0; i < 4; i++)
                sumaDiagonalaPrincipala += numere[i, i];

            // calculează suma elementelor de pe diagonala secundară
            double sumaDiagonalaSecundara = 0;
            for (int i = 0; i < 4; i++)
                sumaDiagonalaSecundara += numere[i, 3 - i];

            // afișează sumele într-un Label
            label1.Text = string.Format("Suma diagonalei principale: {0}\nSuma diagonalei secundare: {1}", sumaDiagonalaPrincipala, sumaDiagonalaSecundara);
            label1.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            // afișează matricea într-un RichTextBox
            richTextBox1.Clear();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    richTextBox1.AppendText(numere[i, j].ToString().PadRight(5));
                }
                richTextBox1.AppendText("\n");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label2.Visible = true;
            for (int j = 0; j < 4; j++)
            {
                double sumaColoana = 0;
                for (int i = 0; i < 5; i++)
                {
                    sumaColoana += numere[i, j];
                }
                label2.Text += $"Suma coloanei {j}: {sumaColoana}\n";
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text Files|*.txt";
            saveFileDialog1.Title = "Salvează datele sortate";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    for (int i = 0; i < dataGridView2.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView2.Columns.Count; j++)
                        {
                            sw.Write($"{dataGridView2.Rows[i].Cells[j].Value}\t");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new OfficeOpenXml.ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Sheet1");
                // adăugăm datele din dataGridView1
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 1, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }
                // salvăm fișierul
                SaveFileDialog saveFileDialog2 = new SaveFileDialog();
                saveFileDialog2.Filter = "Excel Files|*.xlsx";
                saveFileDialog2.Title = "Salvează datele în Excel";
                if (saveFileDialog2.ShowDialog() == DialogResult.OK)
                {
                    package.SaveAs(new FileInfo(saveFileDialog2.FileName));
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chart1.ChartAreas[0].AxisX.Interval = 1;
            chart1.ChartAreas[0].AxisX.Title = "Rânduri";
            chart1.ChartAreas[0].AxisY.Title = "Coloane";

            // Adăugăm datele din dataGridView1
            for (int j = 0; j < 4; j++)
            {
                chart1.Series.Add(dataGridView1.Columns[j].HeaderText);
                for (int i = 0; i < 5; i++)
                {
                    chart1.Series[j].Points.AddXY(i + 1, numere[i, j]);
                    chart1.Series[j].IsValueShownAsLabel = true;
                }
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (this.BackColor == Color.White) // tema de lumină
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.Red;
                this.button12.BackColor = Color.White;
                this.button12.ForeColor = Color.Black;
            }
            else // tema întunecată
            {
                this.BackColor = Color.Black;
                this.ForeColor = Color.Black;
                this.button12.BackColor = Color.Black;
                this.button12.ForeColor = Color.White;
            }
        }
    }
}
