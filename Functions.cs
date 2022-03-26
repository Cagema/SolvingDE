using System;

namespace SolvingDE
{
    public static class Functions
    {
        public static double ConvertToRad(double angle)
        {
            return angle * Math.PI / 180;
        }

        public static double[] DerivativeVanDerPol(double m, double x, double y)
        {
            double[] result = new double[2];
            result[0] = y;
            result[1] = m * (1 - x * x) * y - x;
            return result;
        }

        public static double DerivativeHamiltonianX(double x, double y)
        {
            return -x * x * y - y;
        }

        public static double DerivativeHamiltonianY(double x, double y)
        {
            return x * y * y + x;
        }

        public static double DerivativePendulum(double a, double x, double y)
        {
            return -a * y + Math.Sin(ConvertToRad(x));
        }

        public static double DerivativeDPP2(double mass2, double l2, double angle2, double c1, double c2)
        {
            double g = 9.81d;
            return -mass2 * g * l2 * Math.Sin(ConvertToRad(angle2)) + c1 - c2;
        }

        public static double DerivativeDPP1(double mass1, double mass2, double l1, double angle1, double c1, double c2)
        {
            double g = 9.81d;
            return -(mass1 + mass2) * g * l1 * Math.Sin(ConvertToRad(angle1)) - c1 + c2;
        }

        public static double DerivativeDPAngle1(double mass1,
                                                double mass2,
                                                double l1,
                                                double l2,
                                                double p1,
                                                double p2,
                                                double angle1,
                                                double angle2,
                                                double sqrSin)
        {
            return ((l2 * p1) - (l1 * p2 * Math.Cos(ConvertToRad(angle1 - angle2)))) / l1 * l1 * l2 * (mass1 + mass2 * sqrSin);
        }

        public static double DerivativeDPAngle2(double mass1,
                                                double mass2,
                                                double l1,
                                                double l2,
                                                double p1,
                                                double p2,
                                                double angle1,
                                                double angle2,
                                                double sqrSin)
        {
            return ((l1 * p2 * (mass1 + mass2)) - (l2 * mass2 * p1 * Math.Cos(ConvertToRad(angle1 - angle2)))) / l2 * l2 * l1 * mass2 * (mass1 + mass2 * sqrSin);
        }
    }
}
