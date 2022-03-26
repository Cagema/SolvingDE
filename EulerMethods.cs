using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE
{
    public static class EulerMethods
    {
        public static Point Van_der_Pol(double x, double y, double derivative, double h)
        {
            x += h * y;
            y += h * derivative;
            return new Point(x, y);
        }

        public static Point Hamiltonian(double x, double y, double h)
        {
            var xBuffer = x;
            x += h * (-x * x * y - y);
            y += h * (x * y * y + xBuffer);
            return new Point(x, y);
        }

        public static Point Pendulum(double x, double y, double derivative, double h)
        {
            x += h * y;
            y += h * derivative;
            return new Point(x, y);
        }

        public static Point[] DoublePendulum(double l1, double l2, double mass1, double mass2, double p1, double p2, double angle1, double angle2, double c1, double c2, double sqrSin, double h)
        {
            double g = 9.81d;

            double bufferP1 = p1;
            double bufferP2 = p2;
            p1 += h * (-(mass1 + mass2) * g * l1 * Math.Sin(Functions.ConvertToRad(angle1)) - c1 + c2);
            p2 += h * (-mass2 * g * l2 * Math.Sin(Functions.ConvertToRad(angle2)) + c1 - c2);

            double bufferAngle1 = angle1;
            angle1 += h * (((l2 * bufferP1) - (l1 * bufferP2 * Math.Cos(Functions.ConvertToRad(angle1 - angle2)))) / l1 * l1 * l2 * (mass1 + mass2 * sqrSin));
            angle2 += h * (((l1 * bufferP2 * (mass1 + mass2)) - (l2 * mass2 * bufferP1 * Math.Cos(Functions.ConvertToRad(bufferAngle1 - angle2)))) / l2 * l2 * l1 * mass2 * (mass1 + mass2 * sqrSin));

            return new Point[] { new Point(p1, p2), new Point(angle1, angle2) };
        }


        
    }
}
