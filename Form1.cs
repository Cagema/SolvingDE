using System;
using System.Windows.Forms;

namespace SolvingDE
{
    public partial class Form1 : Form
    {
        delegate double[] Van_der_Pol_Method(double[] y, double m, double h);
        Van_der_Pol_Method newPointVanderPol = EulerMethods.Van_der_Pol;
        delegate double[] Hamiltonian_Method(double[] y, double h);
        Hamiltonian_Method newPointHamiltonian = EulerMethods.Hamiltonian;
        delegate double[] Pendulum_Method(double[] y, double derivative, double h);
        Pendulum_Method newPointPendulum = EulerMethods.Pendulum;
        delegate double[][] DoublePendulum_Method(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h);
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
            double[] y = new double[] { Convert.ToDouble(this.xTextBox.Text), Convert.ToDouble(this.yTextBox.Text) };

            this.chart1.Series[0].Points.Clear();

            switch (this.comboBox1.SelectedIndex)
            {
                case 0:
                    {
                        // Van der Pol oscillator
                        double m = Convert.ToDouble(this.mTextBox.Text);

                        for (double t = 0; t < time; t += h)
                        {
                            y = newPointVanderPol(y, m, h);

                            this.chart1.Series[0].Points.AddXY(y[0], y[1]);
                        }

                        break;
                    }

                case 1:
                    {
                        // Hamiltonian system with inseparable Hamiltonian
                        for (double t = 0; t < time; t += h)
                        {
                            y = newPointHamiltonian(y, h);

                            this.chart1.Series[0].Points.AddXY(y[0], y[1]);
                        }

                        break;
                    }

                case 2:
                    {
                        // Pendulum with indignation
                        double a = Convert.ToDouble(this.aTextBox.Text);

                        for (double t = 0; t < time; t += h)
                        {
                            y = newPointPendulum(y, a, h);

                            this.chart1.Series[0].Points.AddXY(y[0], y[1]);
                        }

                        break;
                    }

                case 3:
                    {
                        // double pendulum
                        double mass1 = Convert.ToDouble(this.massTextBox.Text);
                        mass1 = CheckInputMassAndL(mass1);
                        double[] mass = new double[] {mass1, mass1};

                        double l1 = Convert.ToDouble(this.lTextBox.Text);
                        l1 = CheckInputMassAndL(l1);
                        double[] length = new double[] {l1, l1};

                        double[] angle = new double[] { Convert.ToDouble(this.angle1TextBox.Text), Convert.ToDouble(this.angle2TextBox.Text) };

                        double[] c = new double[2];
                        double[] p = new double[2];

                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.Series[0].Points.AddXY(0, 0);
                        this.chart1.ChartAreas[0].AxisX.Maximum = 30;
                        this.chart1.ChartAreas[0].AxisX.Minimum = -30;
                        this.chart1.ChartAreas[0].AxisY.Maximum = 30;
                        this.chart1.ChartAreas[0].AxisY.Minimum = -30;
                        this.chart1.ChartAreas[0].AxisY.Interval = 5;
                        this.chart1.ChartAreas[0].AxisX.Interval = 5;

                        for (double t = 0; t < time; t += h)
                        {
                            double sqrSin = Math.Sin(Functions.ConvertToRad(angle[0] - angle[1])) * Math.Sin(Functions.ConvertToRad(angle[0] - angle[1]));
                            c[0] = p[0] * p[1] * Math.Sin(Functions.ConvertToRad(angle[0] - angle[1])) / (length[0] * length[1] * (mass[0] + mass[1] * sqrSin));
                            c[1] = ((length[1] * length[1] * mass[1] * p[0] * p[0]) + (length[0] * length[0] * (mass[0] + mass[1]) * p[1] * p[1]) - (length[0] * length[1] * mass[0] * p[0] * p[1] * Math.Cos(Functions.ConvertToRad(angle[0] - angle[1])))) / (2 * length[0] * length[0] * length[1] * length[1] * (mass[0] + mass[1] * sqrSin));

                            double[][] newValues = newValuesDoublePendulum(length, mass, p, angle, c, sqrSin, h);
                            p = newValues[0];
                            angle = newValues[1];

                            y[0] = length[0] * Math.Cos(Functions.ConvertToRad(angle[0] + 90));
                            y[1] = length[0] * -Math.Sin(Functions.ConvertToRad(angle[0] + 90));
                            this.chart1.Series[0].Points[1] = new System.Windows.Forms.DataVisualization.Charting.DataPoint(y[0], y[1]);
                            y[0] += length[1] * Math.Cos(Functions.ConvertToRad(angle[1] + 90));
                            y[1] += length[1] * -Math.Sin(Functions.ConvertToRad(angle[1] + 90));
                            this.chart1.Series[0].Points[2] = new System.Windows.Forms.DataVisualization.Charting.DataPoint(y[0], y[1]);
                            this.chart1.Update();
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
            newPointVanderPol = RungeKutta8Methods.Van_der_Pol;
            newPointHamiltonian = RungeKutta8Methods.Hamiltonian;
            newPointPendulum = RungeKutta8Methods.Pendulum;
            newValuesDoublePendulum = RungeKutta8Methods.DoublePendulum;
        }

        private void ImplicitMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ неявным методом";
        }

        private void ExtraMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ методом экстраполятора";
        }

        private void CompMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Решение ДУ композиционным методом";
        }
    }
}
