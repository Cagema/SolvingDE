using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    internal class RungeKutta8Methods
    {
        public static double[] Van_der_Pol(double[] y, double m, double h)
        {
            double[][] k = new double[10][];

            k[0] = Functions.DerivativeVanDerPol(m, y);

            var additionalY = new double[2] { y[0] + (h * 4 / 27) * k[0][0], y[1] + (h * 4 / 27) * k[0][1] };
            k[1] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK2(additionalY, y, h, k);
            k[2] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK3(additionalY, y, h, k);
            k[3] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK4(additionalY, y, h, k);
            k[4] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK5(additionalY, y, h, k); 
            k[5] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK6(additionalY, y, h, k);
            k[6] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK7(additionalY, y, h, k); 
            k[7] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK8(additionalY, y, h, k); 
            k[8] = Functions.DerivativeVanDerPol(m, additionalY);

            AdditionalYForK9(additionalY, y, h, k); 
            k[9] = Functions.DerivativeVanDerPol(m, additionalY);

            y[0] += h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]);
            y[1] += h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1]);

            return y;
        }

        public static double[] Hamiltonian(double[] y, double h)
        {
            double[][] k = new double[10][];

            k[0] = Functions.DerivativeHamiltonian(y);

            var additionalY = new double[2] { y[0] + (h * 4 / 27) * k[0][0], y[1] + (h * 4 / 27) * k[0][1] };
            k[1] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK2(additionalY, y, h, k);
            k[2] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK3(additionalY, y, h, k); 
            k[3] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK4(additionalY, y, h, k); 
            k[4] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK5(additionalY, y, h, k); 
            k[5] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK6(additionalY, y, h, k); 
            k[6] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK7(additionalY, y, h, k); 
            k[7] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK8(additionalY, y, h, k); 
            k[8] = Functions.DerivativeHamiltonian(additionalY);

            AdditionalYForK9(additionalY, y, h, k); 
            k[9] = Functions.DerivativeHamiltonian(additionalY);

            y[0] += h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]);
            y[1] += h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1]);

            return y;
        }

        public static double[] Pendulum(double[] y, double a, double h)
        {
            double[][] k = new double[10][];

            k[0] = Functions.DerivativePendulum(a, y);

            var additionalY = new double[2] { y[0] + (h * 4 / 27) * k[0][0], y[1] + (h * 4 / 27) * k[0][1] };
            k[1] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK2(additionalY, y, h, k);
            k[2] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK3(additionalY, y, h, k);
            k[3] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK4(additionalY, y, h, k); 
            k[4] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK5(additionalY, y, h, k);
            k[5] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK6(additionalY, y, h, k);
            k[6] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK7(additionalY, y, h, k);
            k[7] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK8(additionalY, y, h, k);
            k[8] = Functions.DerivativePendulum(a, additionalY);

            AdditionalYForK9(additionalY, y, h, k);
            k[9] = Functions.DerivativePendulum(a, additionalY);

            y[0] += h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]);
            y[1] += h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1]);

            return y;
        }

        public static double[][] DoublePendulum(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h)
        {
            var derivativeP = Functions.DerivativeDPP(mass, length, angle, c);

            double[][] k = new double[10][];

            k[0] = Functions.DerivativeDPAngle(mass, length, p, angle, sqrSin);

            var additionalAngle = new double[2] { angle[0] + (h * 4 / 27) * k[0][0], angle[1] + (h * 4 / 27) * k[0][1] };
            k[1] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK2(additionalAngle, angle, h, k);
            k[2] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK3(additionalAngle, angle, h, k);
            k[3] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK4(additionalAngle, angle, h, k);
            k[4] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK5(additionalAngle, angle, h, k);
            k[5] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK6(additionalAngle, angle, h, k);
            k[6] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK7(additionalAngle, angle, h, k);
            k[7] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK8(additionalAngle, angle, h, k);
            k[8] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            AdditionalYForK9(additionalAngle, angle, h, k);
            k[9] = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            p[0] += h * derivativeP[0];
            p[1] += h * derivativeP[1];

            angle[0] += h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]);
            angle[1] += h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1]);

            return new double[][] { p, angle };
        }

        private static void AdditionalYForK2(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 18) * (k[0][0] + 3 * k[1][0]);
            additionalY[1] = y[1] + (h / 18) * (k[0][1] + 3 * k[1][1]);
        }

        private static void AdditionalYForK3(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 12) * (k[0][0] + 3 * k[2][0]);
            additionalY[1] = y[1] + (h / 12) * (k[0][1] + 3 * k[2][1]);
        }
        private static void AdditionalYForK4(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 8) * (k[0][0] + 3 * k[3][0]);
            additionalY[1] = y[1] + (h / 8) * (k[0][1] + 3 * k[3][1]);
        }
        private static void AdditionalYForK5(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 54) * (13 * k[0][0] - 27 * k[2][0] + 42 * k[3][0] + 8 * k[4][0]);
            additionalY[1] = y[1] + (h / 54) * (13 * k[0][1] - 27 * k[2][1] + 42 * k[3][1] + 8 * k[4][1]);
        }
        private static void AdditionalYForK6(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 4320) * (389 * k[0][0] - 54 * k[2][0] + 966 * k[3][0] - 824 * k[4][0] + 243 * k[5][0]);
            additionalY[1] = y[1] + (h / 4320) * (389 * k[0][1] - 54 * k[2][1] + 966 * k[3][1] - 824 * k[4][1] + 243 * k[5][1]);
        }
        private static void AdditionalYForK7(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 20) * (-234 * k[0][0] + 81 * k[2][0] - 1164 * k[3][0] + 656 * k[4][0] - 122 * k[5][0] + 800 * k[6][0]);
            additionalY[1] = y[1] + (h / 20) * (-234 * k[0][1] + 81 * k[2][1] - 1164 * k[3][1] + 656 * k[4][1] - 122 * k[5][1] + 800 * k[6][1]);
        }
        private static void AdditionalYForK8(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 288) * (-127 * k[0][0] + 18 * k[2][0] - 678 * k[3][0] + 456 * k[4][0] - 9 * k[5][0] + 576 * k[6][0] + 4 * k[7][0]);
            additionalY[1] = y[1] + (h / 288) * (-127 * k[0][1] + 18 * k[2][1] - 678 * k[3][1] + 456 * k[4][1] - 9 * k[5][1] + 576 * k[6][1] + 4 * k[7][1]);
        }
        private static void AdditionalYForK9(double[] additionalY, double[] y, double h, double[][] k)
        {
            additionalY[0] = y[0] + (h / 820) * (1481 * k[0][0] - 81 * k[2][0] + 7104 * k[3][0] - 3376 * k[4][0] + 72 * k[5][0] - 5040 * k[6][0] - 60 * k[7][0] + 720 * k[8][0]);
            additionalY[1] = y[1] + (h / 820) * (1481 * k[0][1] - 81 * k[2][1] + 7104 * k[3][1] - 3376 * k[4][1] + 72 * k[5][1] - 5040 * k[6][1] - 60 * k[7][1] + 720 * k[8][1]);
        }

    }
}
