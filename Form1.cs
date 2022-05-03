using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SolvingDE
{
    public partial class Form1 : Form
    {
        delegate double[] Van_der_Pol_Method(double[] y, double m, double h);
        Van_der_Pol_Method newPointVanderPol = Methods.VdP.RK2;
        //    delegate double[] Van_der_Pol_Method(double[] y, double m, double h);
        //    Van_der_Pol_Method newPointVanderPol = EulerMethods.Van_der_Pol;
        //    delegate double[] Hamiltonian_Method(double[] y, double h);
        //    Hamiltonian_Method newPointHamiltonian = EulerMethods.Hamiltonian;
        //    delegate double[] Pendulum_Method(double[] y, double derivative, double h);
        //    Pendulum_Method newPointPendulum = EulerMethods.Pendulum;
        //    delegate double[][] DoublePendulum_Method(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h);
        //    DoublePendulum_Method newValuesDoublePendulum = EulerMethods.DoublePendulum;

        public int selectedODU = 0;
        Dictionary<int, Van_der_Pol_Method> methods;

        public Form1()
        {
            InitializeComponent();
            this.MethodsListBox.SetItemChecked(0, true);
            methods = new Dictionary<int, Van_der_Pol_Method>();
            methods.Add(0, Methods.VdP.RK2);
            methods.Add(1, Methods.VdP.RK4);
            methods.Add(2, Methods.VdP.RK6);
            methods.Add(3, Methods.VdP.RK8);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double h = Convert.ToDouble(this.hTextBox.Text);
            double time = Convert.ToDouble(this.timeTextBox.Text);
            double[] y = new double[] { Convert.ToDouble(this.xTextBox.Text), Convert.ToDouble(this.yTextBox.Text) };
            int dec = Convert.ToInt32(this.DecTextBox.Text);

            double m = Convert.ToDouble(this.mTextBox.Text);
            double a = Convert.ToDouble(this.aTextBox.Text);

            this.chart1.Legends.Clear();
            this.chart1.Series.Clear();
            this.timeChart.Series.Clear();

            int sizeArrays = Convert.ToInt32(time / h);
            double hDec = h / dec;
            double[][] analytical = new double[sizeArrays][];
            double[] analyticalY = new double[2];
            Array.Copy(y, analyticalY, 2);
            for (int i = 0; i < sizeArrays; i++)
            {
                for (int j = 0; j < dec; j++)
                {
                    analyticalY = Methods.VdP.RK4(analyticalY, m, hDec);
                }

                analytical[i] = analyticalY;
            }
            

            switch (selectedODU)
            {
                case 0:
                    {
                        // Van der Pol oscillator
                        for (int i = 0, j = 0; i < MethodsListBox.CheckedIndices.Count; i++, j += 2)
                        {
                            
                            if (methods.TryGetValue(MethodsListBox.CheckedIndices[i], out newPointVanderPol))
                            {
                                this.chart1.Series.Add(MethodsListBox.CheckedItems[i].ToString());
                                this.chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                
                                this.timeChart.Series.Add(MethodsListBox.CheckedItems[i].ToString() + " X");
                                this.timeChart.Series[j].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                                this.timeChart.Series.Add(MethodsListBox.CheckedItems[i].ToString() + " Y");
                                this.timeChart.Series[j + 1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                                double[] localY = new double[2];
                                Array.Copy(y, localY, 2);
                                for (double t = 0; t < time; t += h)
                                {
                                    localY = newPointVanderPol(localY, m, h);

                                    this.chart1.Series[i].Points.AddXY(localY[0], localY[1]);

                                    this.timeChart.Series[j].Points.AddXY(t, localY[0]);
                                    this.timeChart.Series[j + 1].Points.AddXY(t, localY[1]);
                                }
                            }
                            else
                            {
                                continue;
                                // Skip a method that is not implemented
                            }
                        }

                        

                        break;
                    }

                case 1:
                    {
                        // Hamiltonian system with inseparable Hamiltonian
                        for (double t = 0; t < time; t += h)
                        {
                            //y = newPointHamiltonian(y, h);

                            this.chart1.Series[0].Points.AddXY(y[0], y[1]);
                        }

                        break;
                    }

                case 2:
                    {
                        // Pendulum with indignation
                        for (double t = 0; t < time; t += h)
                        {
                            //y = newPointPendulum(y, a, h);

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

                            //double[][] newValues = newValuesDoublePendulum(length, mass, p, angle, c, sqrSin, h);
                            //p = newValues[0];
                            //angle = newValues[1];

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
                    throw new ArgumentException("selectedODU not corrected value");
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

        private void ODU1MenuItem_Click(object sender, EventArgs e)
        {
            selectedODU = 0;
            this.Text = "Осциллятор Ван дер Поля";
            mLabel.Visible = true;
            mTextBox.Visible = true;
            aLabel.Visible = false;
            aTextBox.Visible = false;
            ShowFieldsDP(false);
        }

        private void ODU2MenuItem_Click(object sender, EventArgs e)
        {
            selectedODU = 1;
            this.Text = "Гамильтонова система с неразделяемым гамильтонианом";
            mLabel.Visible = false;
            mTextBox.Visible = false;
            aLabel.Visible = false;
            aTextBox.Visible = false;
            ShowFieldsDP(false);
        }

        private void ODU3MenuItem_Click(object sender, EventArgs e)
        {
            selectedODU = 2;
            this.Text = "Маятник с возмущением";
            mLabel.Visible = false;
            mTextBox.Visible = false;
            aLabel.Visible = true;
            aTextBox.Visible = true;
            ShowFieldsDP(false);
        }

        private void ODU4MenuItem_Click(object sender, EventArgs e)
        {
            selectedODU = 3;
            this.Text = "Двойной маятник";
            mLabel.Visible = false;
            mTextBox.Visible = false;
            aLabel.Visible = false;
            aTextBox.Visible = false;
            ShowFieldsDP(true);
        }

        private void ShowFieldsDP(bool show)
        {
            lengthLabel.Visible = show;
            lTextBox.Visible = show;
            massLabel.Visible = show;
            massTextBox.Visible = show;
            angle1Label.Visible = show;
            angle1TextBox.Visible = show;
            angle2Label.Visible = show;
            angle2TextBox.Visible = show;
        }
    }
}
