using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolvingDE.Methods
{
    internal class VdP
    {
        public static double[][] RK2(double[] y, double m, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] {y[0], y[1]};

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var k1 = Functions.DerivativeVanDerPol(m, result[stepIndex - 1]);
                var halfStepY = new double[2]
                {
                    result[stepIndex - 1][0] + h/2 * k1[0],
                    result[stepIndex - 1][1] + h/2 * k1[1]
                };

                
                var k2 = Functions.DerivativeVanDerPol(m, halfStepY);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + h * k2[0],
                    result[stepIndex - 1][1] + h * k2[1]
                };
            }
            
            return result;
        }

        public static double[][] RK4(double[] y, double m, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                double[][] k = new double[4][];
                double[] hRK4 = new double[] { 1d, h / 2, h / 2, h };

                k[0] = Functions.DerivativeVanDerPol(m, result[stepIndex - 1]);
                for (int i = 1; i < 4; i++)
                {
                    k[i] = Functions.DerivativeVanDerPol(m, new double[2] {result[stepIndex - 1][0] + hRK4[i] * k[i - 1][0],
                                                                           result[stepIndex - 1][1] + hRK4[i] * k[i - 1][1] });
                }

                result[stepIndex] = new double[2] { result[stepIndex - 1][0] + (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]),
                                                    result[stepIndex - 1][1] + (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1])};
            }

            return result;
        }

        public static double[][] RK4WithDec(double[] y, double m, double h, int sizeArrays, int dec)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            //for (int decIndex = 0; decIndex < dec; decIndex++)
            //{
            //    double[][] k = new double[4][];
            //    double[] hRK4 = new double[] { 1d, h / 2, h / 2, h };

            //    k[0] = Functions.DerivativeVanDerPol(m, y);
            //    for (int i = 1; i < 4; i++)
            //    {
            //        k[i] = Functions.DerivativeVanDerPol(m, new double[2] {y[0] + hRK4[i] * k[i - 1][0],
            //                                                               y[1] + hRK4[i] * k[i - 1][1] });
            //    }

            //    y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
            //    y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);
            //}

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                for (int decIndex = 0; decIndex < dec; decIndex++)
                {
                    double[][] k = new double[4][];
                    double[] hRK4 = new double[] { 1d, h / 2, h / 2, h };

                    k[0] = Functions.DerivativeVanDerPol(m, y);
                    for (int i = 1; i < 4; i++)
                    {
                        k[i] = Functions.DerivativeVanDerPol(m, new double[2] {y[0] + hRK4[i] * k[i - 1][0],
                                                                               y[1] + hRK4[i] * k[i - 1][1] });
                    }

                    y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
                    y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);
                }
                

                result[stepIndex] = new double[2] { y[0], y[1]};
            }

            return result;
        }

        public static double[][] RK6(double[] y, double m, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                double[][] k = new double[6][];
                k[0] = Functions.DerivativeVanDerPol(m, result[stepIndex - 1]);

                var dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h * k[0][0] / 4),
                    result[stepIndex - 1][1] + (h * k[0][1] / 4)
                };
                k[1] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]

                {
                    result[stepIndex - 1][0] + (h * 3 / 32) * (k[0][0] + 3 * k[1][0]),
                    result[stepIndex - 1][1] + (h * 3 / 32) * (k[0][1] + 3 * k[1][1])
                };
                k[2] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]

                {
                    result[stepIndex - 1][0] + (h * 12 / 2197) * (161 * k[0][0] - 600 * k[1][0] + 608 * k[2][0]),
                    result[stepIndex - 1][1] + (h * 12 / 2197) * (161 * k[0][1] - 600 * k[1][1] + 608 * k[2][1])
                };
                k[3] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 4104) * (8341 * k[0][0] - 32832 * k[1][0] + 29440 * k[2][0] - 845 * k[3][0]),
                    result[stepIndex - 1][1] + (h / 4104) * (8341 * k[0][1] - 32832 * k[1][1] + 29440 * k[2][1] - 845 * k[3][1])
                };
                k[4] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (-8 * h / 27) * (k[0][0] + 2 * k[1][0] - (3544d / 2565d) * k[2][0] + (1859d / 4104d) * k[3][0] - (11d / 40d) * k[4][0]),
                    result[stepIndex - 1][1] + (-8 * h / 27) * (k[0][1] + 2 * k[1][1] - (3544d / 2565d) * k[2][1] + (1859d / 4104d) * k[3][1] - (11d / 40d) * k[4][1])
                };
                k[5] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                result[stepIndex] = new double[2] 
                {
                    result[stepIndex - 1][0] + 1d / 5d * ((16d / 27d) * k[0][0] + (6656d / 2565d) * k[2][0] + (28561d / 11286d) * k[3][0] - (9d / 10d) * k[4][0] + (2d / 11d) * k[5][0]) * h,
                    result[stepIndex - 1][1] + 1d / 5d * ((16d / 27d) * k[0][1] + (6656d / 2565d) * k[2][1] + (28561d / 11286d) * k[3][1] - (9d / 10d) * k[4][1] + (2d / 11d) * k[5][1]) * h
                };
            }

            return result;
        }

        public static double[][] RK8(double[] y, double m, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                double[][] k = new double[10][];

                k[0] = Functions.DerivativeVanDerPol(m, result[stepIndex - 1]);

                var dynamicStepResult = new double[2] 
                { 
                    result[stepIndex - 1][0] + (h * 4 / 27) * k[0][0],
                    result[stepIndex - 1][1] + (h * 4 / 27) * k[0][1] 
                };
                k[1] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 18) * (k[0][0] + 3 * k[1][0]),
                    result[stepIndex - 1][1] + (h / 18) * (k[0][1] + 3 * k[1][1])
                };
                k[2] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 12) * (k[0][0] + 3 * k[2][0]),
                    result[stepIndex - 1][1] + (h / 12) * (k[0][1] + 3 * k[2][1])
                };
                k[3] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 8) * (k[0][0] + 3 * k[3][0]),
                    result[stepIndex - 1][1] + (h / 8) * (k[0][1] + 3 * k[3][1])
                };
                k[4] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 54) * (13 * k[0][0] - 27 * k[2][0] + 42 * k[3][0] + 8 * k[4][0]),
                    result[stepIndex - 1][1] + (h / 54) * (13 * k[0][1] - 27 * k[2][1] + 42 * k[3][1] + 8 * k[4][1])
                };
                k[5] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 4320) * (389 * k[0][0] - 54 * k[2][0] + 966 * k[3][0] - 824 * k[4][0] + 243 * k[5][0]),
                    result[stepIndex - 1][1] + (h / 4320) * (389 * k[0][1] - 54 * k[2][1] + 966 * k[3][1] - 824 * k[4][1] + 243 * k[5][1])
                };
                k[6] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 20) * (-234 * k[0][0] + 81 * k[2][0] - 1164 * k[3][0] + 656 * k[4][0] - 122 * k[5][0] + 800 * k[6][0]),
                    result[stepIndex - 1][1] + (h / 20) * (-234 * k[0][1] + 81 * k[2][1] - 1164 * k[3][1] + 656 * k[4][1] - 122 * k[5][1] + 800 * k[6][1])
                };
                k[7] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 288) * (-127 * k[0][0] + 18 * k[2][0] - 678 * k[3][0] + 456 * k[4][0] - 9 * k[5][0] + 576 * k[6][0] + 4 * k[7][0]),
                    result[stepIndex - 1][1] + (h / 288) * (-127 * k[0][1] + 18 * k[2][1] - 678 * k[3][1] + 456 * k[4][1] - 9 * k[5][1] + 576 * k[6][1] + 4 * k[7][1])
                };
                k[8] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 820) * (1481 * k[0][0] - 81 * k[2][0] + 7104 * k[3][0] - 3376 * k[4][0] + 72 * k[5][0] - 5040 * k[6][0] - 60 * k[7][0] + 720 * k[8][0]),
                    result[stepIndex - 1][1] + (h / 820) * (1481 * k[0][1] - 81 * k[2][1] + 7104 * k[3][1] - 3376 * k[4][1] + 72 * k[5][1] - 5040 * k[6][1] - 60 * k[7][1] + 720 * k[8][1])
                };
                k[9] = Functions.DerivativeVanDerPol(m, dynamicStepResult);

                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + h / 840 * (41 * k[0][0] + 27 * k[3][0] + 272 * k[4][0] + 27 * k[5][0] + 216 * k[6][0] + 216 * k[8][0] + 41 * k[9][0]),
                    result[stepIndex - 1][1] + h / 840 * (41 * k[0][1] + 27 * k[3][1] + 272 * k[4][1] + 27 * k[5][1] + 216 * k[6][1] + 216 * k[8][1] + 41 * k[9][1])
                };
            }
            return result;
        }

        public static double[][] ImplicitRK2Trapezoid(double[] y, double m, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var k1 = Functions.DerivativeVanDerPol(m, result[stepIndex - 1]);
                var forecast = new double[2]
                {
                    result[stepIndex - 1][0] + h * k1[0],
                    result[stepIndex - 1][1] + h * k1[1]
                };

                var k2 = Functions.DerivativeVanDerPol(m, forecast);
                var correction = new double[2]
                {
                    result[stepIndex - 1][0] + h/2 * (k1[0] + k2[0]),
                    result[stepIndex - 1][1] + h/2 * (k1[1] + k2[1])
                };

                result[stepIndex] = correction;
            }

            return result;
        }
    }
}
