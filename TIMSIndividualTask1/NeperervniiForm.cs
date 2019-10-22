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
    public partial class NeperervniiForm : Form
    {
        public NeperervniiForm()
        {
            InitializeComponent();
        }

        private void NeperervniiForm_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Axis ax = new Axis();
            ax.Title = "Fx";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "X";
            chart1.ChartAreas[0].AxisY = ay;
            double k = 0;
            while (k < 5 * Math.Log10(Program.xi.Length))
                k++;
            double R = Program.xi[Program.xi.Length - 1] - Program.xi[0]; // розмах
            double r = R / k;
            textBox1.Text = $"k={k},R={R},r={r}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double k = 0;
            while (k < 5 * Math.Log10(Program.xi.Length))
                k++;
            double R = Program.xi[Program.xi.Length - 1] - Program.xi[0]; // розмах
            double r = R / k;
            double[] IntervalsXi = new double[(Program.xi.Length / (int)Math.Round(r)) + 1];
            //for(int i = 0; IntervalsXi[i] <= Program.xi[Program.xi.Length+1];i++)
            //{
            //    double krok += 
            //    IntervalsXi[i] = krok;
            //}
            
            //chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            for (int i = 0; i < IntervalsXi.Length; i++)
                chart1.Series[0].Points.AddXY(IntervalsXi[i], Program.Emperichna(Program.mi, Program.xi, Program.array.Length)[i]);
        }
    }
}
