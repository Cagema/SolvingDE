using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    internal class RungeKutta2Methods
    {
        public static Point Van_der_Pol(double x, double y, double m, double h)
        {
            var k1 = Functions.DerivativeVanDerPol(m, x, y);

            var additionalX = x + h * k1[0];
            var additionalY = y + h * k1[1];

            var k2 = Functions.DerivativeVanDerPol(m, additionalX, additionalY);

            x += h * (k1[0] + k2[0]) / 2;
            y += h * (k1[1] + k2[1]) / 2;

            return new Point(x, y);
        }

        public static Point Hamiltonian(double x, double y, double h)
        {
            var k1 = Functions.DerivativeHamiltonianY(x, y);

            var additionalY = y + h * k1;
            x += h * Functions.DerivativeHamiltonianX(x, y);
            y += h * (k1 + Functions.DerivativeHamiltonianY(x, additionalY)) / 2;

            return new Point(x, y);
        }

        public static Point Pendulum(double x, double y, double a, double h)
        {
            var k1 = Functions.DerivativePendulum(a, x, y);

            var additionalY = y + h * k1;
            x += h * y;
            y += h * (k1 + Functions.DerivativePendulum(a, x, additionalY)) / 2;

            return new Point(x, y);
        }

        public static Point[] DoublePendulum(double l1, double l2, double mass1, double mass2, double p1, double p2, double angle1, double angle2, double c1, double c2, double sqrSin, double h)
        {
            double currentP1 = p1;
            double currentP2 = p2;

            p1 += h * Functions.DerivativeDPP1(mass1, mass2, l1, angle1, c1, c2);
            p2 += h * Functions.DerivativeDPP2(mass2, l2, angle2, c1, c2);

            var k1 = Functions.DerivativeDPAngle2(mass1, mass2, l1, l2, currentP1, currentP2, angle1, angle2, sqrSin);

            var additionalAngle2 = angle2 + h * k1;
            angle1 += h * Functions.DerivativeDPAngle1(mass1, mass2, l1, l2, p1, p2, angle1, angle2, sqrSin);
            angle2 += h * (k1 +Functions.DerivativeDPAngle2(mass1, mass2, l1, l2, p1, p2, angle1, additionalAngle2, sqrSin))/2;

            return new Point[] { new Point(p1, p2), new Point(angle1, angle2) };
        }
    }
}
