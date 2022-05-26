using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    public static class EulerMethods
    {
        public static double[] Van_der_Pol(double[] y, double m, double h)
        {
            CheckInputParameter(y);

            var derivative = Functions.DerivativePendulum(m, y);
            y[0] += h * derivative[0];
            y[1] += h * derivative[1];
            return y;
        }

        public static double[] Hamiltonian(double[] y, double h)
        {
            CheckInputParameter(y);

            var derivative = Functions.DerivativeHamiltonian(y);
            y[0] += h * derivative[0];
            y[1] += h * derivative[1];
            return y;
        }

        public static double[] Pendulum(double[] y, double a, double h)
        {
            CheckInputParameter(y);

            var derivative = Functions.DerivativePendulum(a, y);
            y[0] += h * derivative[0];
            y[1] += h * derivative[1];
            return y;
        }

        public static double[][] DoublePendulum(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h)
        {
            CheckInputParameter(p);
            CheckInputParameter(angle);

            var derivativeP = Functions.DerivativeDPP(mass, length, angle, c);
            var derivativeAngle = Functions.DerivativeDPAngle(mass, length, p, angle, sqrSin);

            angle[0] += h * derivativeAngle[0];
            angle[1] += h * derivativeAngle[1];

            p[0] += h * derivativeP[0];
            p[1] += h * derivativeP[1];

            return new double[][] { p, angle };
        }

        private static void CheckInputParameter(double[] y)
        {
            if (y.Length > 2)
            {
                throw new ArgumentException("More than 2 elements massive");
            }
        }
    }
}
