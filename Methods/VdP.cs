using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE.Methods
{
    internal class VdP
    {
        public static double[] RK2(double[] y, double m, double h)
        {
            var k1 = Functions.DerivativeVanDerPol(m, y);

            var additionalY = new double[] { y[0] + h * k1[0], y[1] + h * k1[1] };

            var k2 = Functions.DerivativeVanDerPol(m, additionalY);

            y[0] += h * (k1[0] + k2[0]) / 2;
            y[1] += h * (k1[1] + k2[1]) / 2;

            return y;
        }

        public static double[] RK4(double[] y, double m, double h)
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

        public static double[] RK6(double[] y, double m, double h)
        {
            double[][] k = new double[6][];

            k[0] = Functions.DerivativeVanDerPol(m, y);

            var additionalY = new double[2] { y[0] + (h * k[0][0] / 4), y[1] + (h * k[0][1] / 4) };
            k[1] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h * 3 / 32) * (k[0][0] + 3 * k[1][0]);
            additionalY[1] = y[1] + (h * 3 / 32) * (k[0][1] + 3 * k[1][1]);
            k[2] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h * 12 / 2197) * (161 * k[0][0] - 600 * k[1][0] + 608 * k[2][0]);
            additionalY[1] = y[1] + (h * 12 / 2197) * (161 * k[0][1] - 600 * k[1][1] + 608 * k[2][1]);
            k[3] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 4104) * (8341 * k[0][0] - 32832 * k[1][0] + 29440 * k[2][0] - 845 * k[3][0]);
            additionalY[1] = y[1] + (h / 4104) * (8341 * k[0][1] - 32832 * k[1][1] + 29440 * k[2][1] - 845 * k[3][1]);
            k[4] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (-8 * h / 27) * (k[0][0] + 2 * k[1][0] - (3544d / 2565d) * k[2][0] + (1859d / 4104d) * k[3][0] - (11d / 40d) * k[4][0]);
            additionalY[1] = y[1] + (-8 * h / 27) * (k[0][1] + 2 * k[1][1] - (3544d / 2565d) * k[2][1] + (1859d / 4104d) * k[3][1] - (11d / 40d) * k[4][1]);
            k[5] = Functions.DerivativeVanDerPol(m, additionalY);

            y[0] += 1d / 5d * ((16d / 27d) * k[0][0] + (6656d / 2565d) * k[2][0] + (28561d / 11286d) * k[3][0] - (9d / 10d) * k[4][0] + (2d / 11d) * k[5][0]) * h;
            y[1] += 1d / 5d * ((16d / 27d) * k[0][1] + (6656d / 2565d) * k[2][1] + (28561d / 11286d) * k[3][1] - (9d / 10d) * k[4][1] + (2d / 11d) * k[5][1]) * h;

            return y;
        }

        public static double[] RK8(double[] y, double m, double h)
        {
            double[][] k = new double[10][];

            k[0] = Functions.DerivativeVanDerPol(m, y);

            var additionalY = new double[2] { y[0] + (h * 4 / 27) * k[0][0], y[1] + (h * 4 / 27) * k[0][1] };
            k[1] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 18) * (k[0][0] + 3 * k[1][0]);
            additionalY[1] = y[1] + (h / 18) * (k[0][1] + 3 * k[1][1]);
            k[2] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 12) * (k[0][0] + 3 * k[2][0]);
            additionalY[1] = y[1] + (h / 12) * (k[0][1] + 3 * k[2][1]);
            k[3] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 8) * (k[0][0] + 3 * k[3][0]);
            additionalY[1] = y[1] + (h / 8) * (k[0][1] + 3 * k[3][1]);
            k[4] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 54) * (13 * k[0][0] - 27 * k[2][0] + 42 * k[3][0] + 8 * k[4][0]);
            additionalY[1] = y[1] + (h / 54) * (13 * k[0][1] - 27 * k[2][1] + 42 * k[3][1] + 8 * k[4][1]);
            k[5] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 4320) * (389 * k[0][0] - 54 * k[2][0] + 966 * k[3][0] - 824 * k[4][0] + 243 * k[5][0]);
            additionalY[1] = y[1] + (h / 4320) * (389 * k[0][1] - 54 * k[2][1] + 966 * k[3][1] - 824 * k[4][1] + 243 * k[5][1]);
            k[6] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 20) * (-234 * k[0][0] + 81 * k[2][0] - 1164 * k[3][0] + 656 * k[4][0] - 122 * k[5][0] + 800 * k[6][0]);
            additionalY[1] = y[1] + (h / 20) * (-234 * k[0][1] + 81 * k[2][1] - 1164 * k[3][1] + 656 * k[4][1] - 122 * k[5][1] + 800 * k[6][1]);
            k[7] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 288) * (-127 * k[0][0] + 18 * k[2][0] - 678 * k[3][0] + 456 * k[4][0] - 9 * k[5][0] + 576 * k[6][0] + 4 * k[7][0]);
            additionalY[1] = y[1] + (h / 288) * (-127 * k[0][1] + 18 * k[2][1] - 678 * k[3][1] + 456 * k[4][1] - 9 * k[5][1] + 576 * k[6][1] + 4 * k[7][1]);
            k[8] = Functions.DerivativeVanDerPol(m, additionalY);

            additionalY[0] = y[0] + (h / 820) * (1481 * k[0][0] - 81 * k[2][0] + 7104 * k[3][0] - 3376 * k[4][0] + 72 * k[5][0] - 5040 * k[6][0] - 60 * k[7][0] + 720 * k[8][0]);
            additionalY[1] = y[1] + (h / 820) * (1481 * k[0][1] - 81 * k[2][1] + 7104 * k[3][1] - 3376 * k[4][1] + 72 * k[5][1] - 5040 * k[6][1] - 60 * k[7][1] + 720 * k[8][1]);
            k[9] = Functions.DerivativeVanDerPol(m, additionalY);

            y[0] += h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]);
            y[1] += h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1]);

            return y;
        }
    }
}
