using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TIMSIndividualTask1
{
    public partial class Histograma : Form
    {
        public Histograma()
        {
            InitializeComponent();
        }

        private void Histograma_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Axis ax = new Axis();
            ax.Title = "Xi";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "F(x)";
            chart1.ChartAreas[0].AxisY = ay;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k = 0;
            while (k < 5 * Math.Log10(Program.xi.Length))
                k++;
            double R = Program.xi[Program.xi.Length - 1] - Program.xi[0]; // розмах
            double r = R / k;
            double krok = 0;
            double[] IntervalsXi = new double[(Program.xi.Length / (int)Math.Round(r)) + 1];
            IntervalsXi[0] = 0;
            for (int i = 1; IntervalsXi.Length <= (Program.xi.Length / (int)Math.Round(r)); i++)
            {
                krok += Math.Round(r);
                IntervalsXi[i] = krok;
            }
            for (int i = 0; i <= Program.xi.Length; i++)
                chart1.Series[0].Points.AddXY(IntervalsXi[i], Program.Emperichna(Program.mi, Program.xi, Program.array.Length)[i]);
        }

    }
}
