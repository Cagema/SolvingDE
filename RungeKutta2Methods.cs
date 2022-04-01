using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    internal class RungeKutta2Methods
    {
        public static double[] Van_der_Pol(double[] y, double m, double h)
        {
            var k1 = Functions.DerivativeVanDerPol(m, y);

            var additionalY =  new double[] { y[0] + h * k1[0], y[1] + h * k1[1] };

            var k2 = Functions.DerivativeVanDerPol(m, additionalY);

            y[0] += h * (k1[0] + k2[0]) / 2;
            y[1] += h * (k1[1] + k2[1]) / 2;

            return y;
        }

        public static double[] Hamiltonian(double[] y, double h)
        {
            var k1 = Functions.DerivativeHamiltonian(y);

            var additionalY = new double[] { y[0] + h * k1[0], y[1] + h * k1[1] };

            var k2 = Functions.DerivativeHamiltonian(additionalY);

            y[0] += h * (k1[0] + k2[0]) / 2;
            y[1] += h * (k1[1] + k2[1]) / 2;

            return y;
        }

        public static double[] Pendulum(double[] y, double a, double h)
        {
            var k1 = Functions.DerivativePendulum(a, y);

            var additionalY = new double[] { y[0] + h * k1[0], y[1] + h * k1[1] };

            var k2 = Functions.DerivativePendulum(a, additionalY);

            y[0] += h * (k1[0] + k2[0]) / 2;
            y[1] += h * (k1[1] + k2[1]) / 2;

            return y;
        }

        public static double[][] DoublePendulum(double[] length, double[] mass, double[] p, double[] angle, double[] c, double sqrSin, double h)
        {
            var derivativeP = Functions.DerivativeDPP(mass, length, angle, c);
            
            var k1 = Functions.DerivativeDPAngle(mass, length, p, angle, sqrSin);

            var additionalAngle = new double[] { angle[0] + h * k1[0], angle[1] + h * k1[1] };

            var k2 = Functions.DerivativeDPAngle(mass, length, p, additionalAngle, sqrSin);

            p[0] += h * derivativeP[0];
            p[1] += h * derivativeP[1];

            angle[0] += h * (k1[0] + k2[0]) / 2;
            angle[1] += h * (k1[1] + k2[1]) / 2;

            return new double[][] { p, angle };
        }
    }
}
