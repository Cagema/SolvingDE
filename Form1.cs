using System;
using System.Windows.Forms;

namespace SolvingDE
{
    public partial class Form1 : Form
    {
        delegate Point Van_der_Pol_Method(double x, double y, double m, double h);
        Van_der_Pol_Method newPointVanderPol = EulerMethods.Van_der_Pol;
        delegate Point Hamiltonian_Method(double x, double y, double h);
        Hamiltonian_Method newPointHamiltonian = EulerMethods.Hamiltonian;
        delegate Point Pendulum_Method(double x, double y, double derivative, double h);
        Pendulum_Method newPointPendulum = EulerMethods.Pendulum;
        delegate Point[] DoublePendulum_Method(double l1, double l2, double mass1, double mass2, double p1, double p2, double angle1, double angle2, double c1, double c2, double sqrSin, double h);
        DoublePendulum_Method newValuesDoublePendulum = EulerMethods.DoublePendulum;

        public Form1()
        {
            InitializeComponent();
            this.comboBox1.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = Convert.ToDouble(this.hTextBox.Text);
            double time = Convert.ToDouble(this.timeTextBox.Text);
            double x = Convert.ToDouble(this.xTextBox.Text);
            double y = Convert.ToDouble(this.yTextBox.Text);

            this.chart1.Series[0].Points.Clear();

            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        // Van der Pol oscillator
                        double m = Convert.ToDouble(this.mTextBox.Text);

                        while (time >= 0)
                        {
                            var point = newPointVanderPol(x, y, m, h);

                            this.chart1.Series[0].Points.AddXY(point.X, point.Y);
                            x = point.X;
                            y = point.Y;

                            time -= h;
                        }

                        break;
                    }

                case 1:
                    {
                        // Hamiltonian system with inseparable Hamiltonian
                        while (time >= 0)
                        {
                            var point = newPointHamiltonian(x, y, h);

                            this.chart1.Series[0].Points.AddXY(point.X, point.Y);
                            x = point.X;
                            y = point.Y;

                            time -= h;
                        }

                        break;
                    }

                case 2:
                    {
                        // Pendulum with indignation
                        double a = Convert.ToDouble(this.aTextBox.Text);

                        while (time >= 0)
                        {
                            var point = newPointPendulum(x, y, a, h);

                            this.chart1.Series[0].Points.AddXY(point.X, point.Y);
                            x = point.X;
                            y = point.Y;

                            time -= h;
                        }

                        break;
                    }

                case 3:
                    {
                        // double pendulum
                        double mass1 = Convert.ToDouble(this.massTextBox.Text);
                        mass1 = CheckInputMassAndL(mass1);
                        double mass2 = mass1;

                        double l1 = Convert.ToDouble(this.lTextBox.Text);
                        l1 = CheckInputMassAndL(l1);
                        double l2 = l1;

                        double angle1 = Convert.ToDouble(this.angle1TextBox.Text);
                        double angle2 = Convert.ToDouble(this.angle2TextBox.Text);

                        double c1, c2;
                        double p1 = 0, p2 = 0;

                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.ChartAreas[0].AxisX.Maximum = 30;
                        this.chart1.ChartAreas[0].AxisX.Minimum = -30;
                        this.chart1.ChartAreas[0].AxisY.Maximum = 30;
                        this.chart1.ChartAreas[0].AxisY.Minimum = -30;
                        this.chart1.ChartAreas[0].AxisY.Interval = 5;
                        this.chart1.ChartAreas[0].AxisX.Interval = 5;

                        while (time >= 0)
                        {
                            double sqrSin = Math.Sin(Functions.ConvertToRad(angle1 - angle2)) * Math.Sin(Functions.ConvertToRad(angle1 - angle2));
                            c1 = p1 * p2 * Math.Sin(Functions.ConvertToRad(angle1 - angle2)) / l1 * l2 * (mass1 + mass2 * sqrSin);
                            c2 = ((l2 * l2 * mass2 * p1 * p1) + (l1 * l1 * (mass1 + mass2) * p2 * p2) - (l1 * l2 * mass1 * p1 * p2 * Math.Cos(Functions.ConvertToRad(angle1 - angle2)))) / (2 * l1 * l1 * l2 * l2 * (mass1 + mass2 * sqrSin));

                            Point[] newValues = newValuesDoublePendulum(l1, l2, mass1, mass2, p1, p2, angle1, angle2, c1, c2, sqrSin, h);
                            p1 = newValues[0].X;
                            p2 = newValues[0].Y;
                            angle1 = newValues[1].X;
                            angle2 = newValues[1].Y;

                            x = l1 * Math.Cos(Functions.ConvertToRad(angle1 + 90));
                            y = l1 * -Math.Sin(Functions.ConvertToRad(angle1 + 90));
                            this.chart1.Series[0].Points[1] = new System.Windows.Forms.DataVisualization.Charting.DataPoint(x, y);
                            x += l2 * Math.Cos(Functions.ConvertToRad(angle2 + 90));
                            y += l2 * -Math.Sin(Functions.ConvertToRad(angle2 + 90));
                            this.chart1.Series[0].Points[2] = new System.Windows.Forms.DataVisualization.Charting.DataPoint(x, y);
                            this.chart1.Update();

                            time -= h;
                        }

                        this.chart1.ChartAreas[0].AxisX.Maximum = double.NaN;
                        this.chart1.ChartAreas[0].AxisX.Minimum = double.NaN;
                        this.chart1.ChartAreas[0].AxisY.Maximum = double.NaN;
                        this.chart1.ChartAreas[0].AxisY.Minimum = double.NaN;
                        this.chart1.ChartAreas[0].AxisY.Interval = double.NaN;
                        this.chart1.ChartAreas[0].AxisX.Interval = double.NaN;

                        break;
                    }

                default:
                    throw new ArgumentException("comboBox1 not corrected selected index");
            }
        }

        private double CheckInputMassAndL(double value)
        {
            if (value < 1)
            {
                value = 1;
            }

            if (value > 10)
            {
                value = 10;
            }

            return value;
        }

        private void EulerMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ методом Эйлера";
            newPointVanderPol = EulerMethods.Van_der_Pol;
            newPointHamiltonian = EulerMethods.Hamiltonian;
            newPointPendulum = EulerMethods.Pendulum;
            newValuesDoublePendulum = EulerMethods.DoublePendulum;
        }

        private void RK2MenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ методом Рунге-Кутты 2 порядка";
            newPointVanderPol = RungeKutta2Methods.Van_der_Pol;
            newPointHamiltonian = RungeKutta2Methods.Hamiltonian;
            newPointPendulum = RungeKutta2Methods.Pendulum;
            newValuesDoublePendulum = RungeKutta2Methods.DoublePendulum;
        }

        private void RK4MenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ методом Рунге-Кутты 4 порядка";
            newPointVanderPol = RungeKutta4Methods.Van_der_Pol;
            newPointHamiltonian = RungeKutta4Methods.Hamiltonian;
            newPointPendulum = RungeKutta4Methods.Pendulum;
            newValuesDoublePendulum = RungeKutta4Methods.DoublePendulum;
        }

        private void RK8MenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ методом Рунге-Кутты 8 порядка";
        }
    }
}
