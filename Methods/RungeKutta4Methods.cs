using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    internal class RungeKutta4Methods
    {
        public static double[] Van_der_Pol(double[] y, double m, double h)
        {
            double[] additionalY = new double[2];
            Array.Copy(y, additionalY, 2);
            double[][] k = new double[4][];
            double[] hRK4 = new double[] { 1, h / 2, h / 2, h };

            k[0] = Functions.DerivativeVanDerPol(m, y);
            for (int i = 1; i < 4; i++)
            {
                k[i] = new double[2];
                additionalY[0] = y[0] + hRK4[i] * k[i - 1][0];
                additionalY[1] = y[1] + hRK4[i] * k[i - 1][1];
                k[i] = Functions.DerivativeVanDerPol(m, additionalY);
            }

            y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
            y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);

            return y;
        }

        public static double[] Hamiltonian(double[] y, double h)
        {
            double[] additionalY = new double[2];
            Array.Copy(y, additionalY, 2);
            double[][] k = new double[4][];
            double[] hRK4 = new double[] { 1, h / 2, h / 2, h };

            k[0] = Functions.DerivativeHamiltonian(additionalY);
            for (int i = 1; i < 4; i++)
            {
                k[i] = new double[2];
                additionalY[0] = y[0] + hRK4[i] * k[i - 1][0];
                additionalY[1] = y[1] + hRK4[i] * k[i - 1][1];
                k[i] = Functions.DerivativeHamiltonian(additionalY);
            }

            y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
            y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);

            return y;
        }

        public static double[] Pendulum(double[] y, double a, double h)
        {
            double[] additionalY = new double[2];
            Array.Copy(y, additionalY, 2);
            double[][] k = new double[4][];
            double[] hRK4 = new double[] { 1, h / 2, h / 2, h };

            k[0] = Functions.DerivativePendulum(a, additionalY);
            for (int i = 1; i < 4; i++)
            {
                k[i] = new double[2];
                additionalY[0] = y[0] + hRK4[i] * k[i - 1][0];
                additionalY[1] = y[1] + hRK4[i] * k[i - 1][1];
                k[i] = Functions.DerivativePendulum(a, additionalY);
            }

            y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
            y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);

            return y;
        }

        public static double[][] DoublePendulum(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h)
        {
            var derivativeP = Functions.DerivativeDPP(mass, length, angle, c);

            double[] additionalAngle = new double[2];
            Array.Copy(angle, additionalAngle, 2);
            double[][] k = new double[4][];
            double[] hRK4 = new double[] { 1, h / 2, h / 2, h };

            k[0] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);
            for (int i = 1; i < 4; i++)
            {
                k[i] = new double[2];
                additionalAngle[0] += hRK4[i] * k[i][0];
                additionalAngle[1] += hRK4[i] * k[i][1];
                k[i] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);
            }

            p[0] += h * derivativeP[0];
            p[1] += h * derivativeP[1];

            angle[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
            angle[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);

            return new double[][] { p, angle };
        }
    }
}
