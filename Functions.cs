using System;

namespace SolvingDE
{
    public static class Functions
    {
        public static double ConvertToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        public static double[] DerivativeVanDerPol(double m, double[] y)
        {
            double[] result = new double[2];
            result[0] = y[1];
            result[1] = m * (1 - y[0] * y[0]) * y[1] - y[0];
            return result;
        }

        public static double[] DerivativeHamiltonian(double[] y)
        {
            double[] result = new double[2];
            result[0] = -y[0] * y[0] * y[1] - y[1];
            result[1] = y[0] * y[1] * y[1] + y[0];
            return result;
        }

        public static double[] DerivativePendulum(double a, double[] y)
        {
            double[] result = new double[2];
            result[0] = y[1];
            result[1] = -a * y[1] + Math.Sin(ConvertToRad(y[0]));
            return result;
        }

        public static double[] DerivativeDPP(double[] mass, double[] length, double[] angle, double[] c)
        {
            double[] result = new double[2];
            double g = 9.81d;

            result[0] = -(mass[0] + mass[1]) * g * length[0] * Math.Sin(ConvertToRad(angle[0])) - c[0] + c[1];
            result[1] = -mass[1] * g * length[1] * Math.Sin(ConvertToRad(angle[1])) + c[0] - c[1];

            return result;
        }

        public static double[] DerivativeDPAngle(double[] mass, double[] length, double[] p, double[] angle, double sqrSin)
        {
            var result = new double[2];
            result[0] = ((length[1] * p[0]) - (length[0] * p[1] * Math.Cos(ConvertToRad(angle[0] - angle[1])))) / length[0] * length[0] * length[1] * (mass[0] + mass[1] * sqrSin);
            result[1] = ((length[0] * p[1] * (mass[0] + mass[1])) - (length[1] * mass[1] * p[0] * Math.Cos(ConvertToRad(angle[0] - angle[1])))) / length[1] * length[1] * length[0] * mass[1] * (mass[0] + mass[1] * sqrSin);
            return result;
        }
    }
}
