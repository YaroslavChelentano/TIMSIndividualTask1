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
    public partial class PoligonChastotWIForm : Form
    {
        public PoligonChastotWIForm()
        {
            InitializeComponent();
        }
        private void PoligonChastotWIForm_Load(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            Axis ax = new Axis();
            ax.Title = "Xi";
            chart1.ChartAreas[0].AxisX = ax;
            Axis ay = new Axis();
            ay.Title = "Wi";
            chart1.ChartAreas[0].AxisY = ay;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            chart1.Series["Series1"].ChartType = SeriesChartType.Line;
            for (int i = 0; i < Program.xi.Length; i++)
                chart1.Series[0].Points.AddXY(Program.xi[i], Program.Wi(Program.mi,Program.array.Length)[i]);
        }

       
    }
}
