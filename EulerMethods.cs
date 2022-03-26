﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    public static class EulerMethods
    {
        public static Point Van_der_Pol(double x, double y, double m, double h)
        {
            var derivative = Functions.DerivativeVanDerPol(m, x, y);
            x += h * derivative[0];
            y += h * derivative[1];
            return new Point(x, y);
        }

        public static Point Hamiltonian(double x, double y, double h)
        {
            var currentX = x;
            x += h * (-x * x * y - y);
            y += h * (currentX * y * y + currentX);
            return new Point(x, y);
        }

        public static Point Pendulum(double x, double y, double a, double h)
        {
            var currentX = x;
            x += h * y;
            y += h * Functions.DerivativePendulum(a, currentX, y);
            return new Point(x, y);
        }

        public static Point[] DoublePendulum(double l1, double l2, double mass1, double mass2, double p1, double p2, double angle1, double angle2, double c1, double c2, double sqrSin, double h)
        {
            double currentP1 = p1;
            double currentP2 = p2;
            p1 += h * Functions.DerivativeDPP1(mass1, mass2, l1, angle1, c1, c2);
            p2 += h * Functions.DerivativeDPP2(mass2, l2, angle2, c1, c2);

            double currentAngle1 = angle1;
            angle1 += h * Functions.DerivativeDPAngle1(mass1, mass2, l1, l2, p1, p2, angle1, angle2, sqrSin);
            angle2 += h * Functions.DerivativeDPAngle2(mass1, mass2, l1, l2, currentP1, currentP2, currentAngle1, angle2, sqrSin);

            return new Point[] { new Point(p1, p2), new Point(angle1, angle2) };
        }
    }
}
