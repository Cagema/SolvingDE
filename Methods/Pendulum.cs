﻿namespace SolvingDE.Methods
{
    internal class Pendulum
    {
        public static double[] MidpointMethod(double[] y, double a, double h)
        {
            var k1 = Functions.DerivativePendulum(a, y);
            var halfStepY = new double[2]
            {
                    y[0] + h/2 * k1[0],
                    y[1] + h/2 * k1[1]
            };


            var k2 = Functions.DerivativePendulum(a, halfStepY);

            return new double[2]
            {
                    y[0] + h * k2[0],
                    y[1] + h * k2[1]
            };
        }

        public static double[][] RK2(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] {y[0], y[1]};

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                result[stepIndex] = MidpointMethod(result[stepIndex - 1], a, h);
            }
            
            return result;
        }

        private static double[] RK4OneStep(double[] y, double a, double h)
        {
            double[][] k = new double[4][];
            double[] hRK4 = new double[] { 1d, h / 2, h / 2, h };

            k[0] = Functions.DerivativePendulum(a, y);
            for (int i = 1; i < 4; i++)
            {
                k[i] = Functions.DerivativePendulum(a, new double[2] { y[0] + hRK4[i] * k[i - 1][0],
                                                                        y[1] + hRK4[i] * k[i - 1][1] });
            }

            return new double[2] { y[0] + (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]),
                                   y[1] + (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1])};
        }

        public static double[][] RK4(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                result[stepIndex] = RK4OneStep(result[stepIndex - 1], a, h);
            }

            return result;
        }

        public static double[][] RK4WithDec(double[] y, double a, double h, int sizeArrays, int dec)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                for (int decIndex = 0; decIndex < dec; decIndex++)
                {
                    double[][] k = new double[4][];
                    double[] hRK4 = new double[] { 1d, h / 2, h / 2, h };

                    k[0] = Functions.DerivativePendulum(a, y);
                    for (int i = 1; i < 4; i++)
                    {
                        k[i] = Functions.DerivativePendulum(a, new double[2] {y[0] + hRK4[i] * k[i - 1][0],
                                                                               y[1] + hRK4[i] * k[i - 1][1] });
                    }

                    y[0] += (h / 6) * (k[0][0] + (2 * k[1][0]) + (2 * k[2][0]) + k[3][0]);
                    y[1] += (h / 6) * (k[0][1] + (2 * k[1][1]) + (2 * k[2][1]) + k[3][1]);
                }
                

                result[stepIndex] = new double[2] { y[0], y[1]};
            }

            return result;
        }

        public static double[][] RK6(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                result[stepIndex] = RK6OneStep(result[stepIndex - 1], a, h);
            }

            return result;
        }

        private static double[] RK6OneStep(double[] y, double a, double h)
        {
            double[][] k = new double[7][];
            k[0] = Functions.DerivativePendulum(a, y);

            var dynamicStepResult = new double[2]
            {
                    y[0] + (h * k[0][0] / 2),
                    y[1] + (h * k[0][1] / 2)
            };
            k[1] = Functions.DerivativePendulum(a, dynamicStepResult);

            dynamicStepResult = new double[2]

            {
                    y[0] + h * (k[0][0] * (2 / 9d) + k[1][0] * (4 / 9d)),
                    y[1] + h * (k[0][1] * (2 / 9d) + k[1][1] * (4 / 9d))
            };
            k[2] = Functions.DerivativePendulum(a, dynamicStepResult);

            dynamicStepResult = new double[2]

            {
                    y[0] + h * ((7/36d) * k[0][0] + (2/9d) * k[1][0] + (-1/12d) * k[2][0]),
                    y[1] + h * ((7/36d) * k[0][1] + (2/9d) * k[1][1] + (-1/12d) * k[2][1])
            };
            k[3] = Functions.DerivativePendulum(a, dynamicStepResult);

            dynamicStepResult = new double[2]
            {
                    y[0] + h * ((-35/144d) * k[0][0] + (-55/36d) * k[1][0] + (35/48d) * k[2][0] + (15/8d) * k[3][0]),
                    y[1] + h * ((-35/144d) * k[0][1] + (-55/36d) * k[1][1] + (35/48d) * k[2][1] + (15/8d) * k[3][1])
            };
            k[4] = Functions.DerivativePendulum(a, dynamicStepResult);

            dynamicStepResult = new double[2]
            {
                    y[0] + h * ((-1/360d) * k[0][0] + (-11/36d) * k[1][0] + (-1/8d) * k[2][0] + (1/2d) * k[3][0] + (1/10d) * k[4][0]),
                    y[1] + h * ((-1/360d) * k[0][1] + (-11/36d) * k[1][1] + (-1/8d) * k[2][1] + (1/2d) * k[3][1] + (1/10d) * k[4][1])
            };
            k[5] = Functions.DerivativePendulum(a, dynamicStepResult);

            dynamicStepResult = new double[2]
            {
                    y[0] + h * ((-41/260d) * k[0][0] + (22/13d) * k[1][0] + (43/156d) * k[2][0] + (-118/39d) * k[3][0] + (32/195d) * k[4][0] + (80/39d) * k[5][0]),
                    y[1] + h * ((-41/260d) * k[0][1] + (22/13d) * k[1][1] + (43/156d) * k[2][1] + (-118/39d) * k[3][1] + (32/195d) * k[4][1] + (80/39d) * k[5][1])
            };
            k[6] = Functions.DerivativePendulum(a, dynamicStepResult);

            return new double[2]
            {
                    y[0] + h * ((13/200d) * k[0][0] + (11/40d) * k[2][0] + (11/40d) * k[3][0] + (4/25d) * k[4][0] + (4/25d) * k[5][0] + (13/200d) * k[6][0]),
                    y[1] + h * ((13/200d) * k[0][1] + (11/40d) * k[2][1] + (11/40d) * k[3][1] + (4/25d) * k[4][1] + (4/25d) * k[5][1] + (13/200d) * k[6][1])
            };
        }

        public static double[][] RK8(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                double[][] k = new double[13][];

                k[0] = Functions.DerivativePendulum(a, result[stepIndex - 1]);

                var dynamicStepResult = new double[2] 
                { 
                    result[stepIndex - 1][0] + h * ((2/27d) * k[0][0]),
                    result[stepIndex - 1][1] + h * ((2/27d) * k[0][1])
                };
                k[1] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((1/36d) * k[0][0] + (1/12d) * k[1][0]),
                    result[stepIndex - 1][1] + h * ((1/36d) * k[0][1] + (1/12d) * k[1][1])
                };
                k[2] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((1/24d) * k[0][0] + (1/8d) * k[2][0]),
                    result[stepIndex - 1][1] + h * ((1/24d) * k[0][1] + (1/8d) * k[2][1])
                };
                k[3] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((5/12d) * k[0][0] + (-25/16d) * k[2][0] + (25/16d) * k[3][0]),
                    result[stepIndex - 1][1] + h * ((5/12d) * k[0][1] + (-25/16d) * k[2][1] + (25/16d) * k[3][1])
                };
                k[4] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((1/20d) * k[0][0] + (1/4d) * k[3][0] + (1/5d) * k[4][0]),
                    result[stepIndex - 1][1] + h * ((1/20d) * k[0][1] + (1/4d) * k[3][1] + (1/5d) * k[4][1])
                };
                k[5] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((-25/108d) * k[0][0] + (125/108d) * k[3][0] + (-65/27d) * k[4][0] + (125/54d) * k[5][0]),
                    result[stepIndex - 1][1] + h * ((-25/108d) * k[0][1] + (125/108d) * k[3][1] + (-65/27d) * k[4][1] + (125/54d) * k[5][1])
                };
                k[6] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((31/300d) * k[0][0] + (61/225d) * k[4][0] + (-2/9d) * k[5][0] + (13/900d) * k[6][0]),
                    result[stepIndex - 1][1] + h * ((31/300d) * k[0][1] + (61/225d) * k[4][1] + (-2/9d) * k[5][1] + (13/900d) * k[6][1])
                };
                k[7] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((2d) * k[0][0] + (-53/6d) * k[3][0] + (704/45d) * k[4][0] + (-107/9d) * k[5][0] + (67/90d) * k[6][0] + 3d * k[7][0]),
                    result[stepIndex - 1][1] + h * ((2d) * k[0][1] + (-53/6d) * k[3][1] + (704/45d) * k[4][1] + (-107/9d) * k[5][1] + (67/90d) * k[6][1] + 3d * k[7][1])
                };
                k[8] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((-91/108d) * k[0][0] + (23/108d) * k[3][0] + (-976/135d) * k[4][0] + (311/54d) * k[5][0] + (-19/60d) * k[6][0] + (17/6d) * k[7][0] + (-1/12d) * k[8][0]),
                    result[stepIndex - 1][1] + h * ((-91/108d) * k[0][1] + (23/108d) * k[3][1] + (-976/135d) * k[4][1] + (311/54d) * k[5][1] + (-19/60d) * k[6][1] + (17/6d) * k[7][1] + (-1/12d) * k[8][1])
                };
                k[9] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((2383/4100d) * k[0][0] + (-341/164d) * k[3][0] + (4496/1025d) * k[4][0] + (-301/82d) * k[5][0] + (2133/4100d) * k[6][0] + (45/82d) * k[7][0] + (45/164d) * k[8][0] + (18/41d) * k[9][0]),
                    result[stepIndex - 1][1] + h * ((2383/4100d) * k[0][1] + (-341/164d) * k[3][1] + (4496/1025d) * k[4][1] + (-301/82d) * k[5][1] + (2133/4100d) * k[6][1] + (45/82d) * k[7][1] + (45/164d) * k[8][1] + (18/41d) * k[9][1])
                };
                k[10] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((3/205d) * k[0][0] + (-6/41d) * k[5][0] + (-3/205d) * k[6][0] + (-3/41d) * k[7][0] + (3/41d) * k[8][0] + (6/41d) * k[9][0]),
                    result[stepIndex - 1][1] + h * ((3/205d) * k[0][1] + (-6/41d) * k[5][1] + (-3/205d) * k[6][1] + (-3/41d) * k[7][1] + (3/41d) * k[8][1] + (6/41d) * k[9][1])
                };
                k[11] = Functions.DerivativePendulum(a, dynamicStepResult);

                dynamicStepResult = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((-1777/4100d) * k[0][0] + (-341/164d) * k[3][0] + (4496/1025d) * k[4][0] + (-289/82d) * k[5][0] + (2193/4100d) * k[6][0] + (51/82d) * k[7][0] + (33/164d) * k[8][0] + (12/41d) * k[9][0] + k[11][0]),
                    result[stepIndex - 1][1] + h * ((-1777/4100d) * k[0][1] + (-341/164d) * k[3][1] + (4496/1025d) * k[4][1] + (-289/82d) * k[5][1] + (2193/4100d) * k[6][1] + (51/82d) * k[7][1] + (33/164d) * k[8][1] + (12/41d) * k[9][1] + k[11][1])
                };
                k[12] = Functions.DerivativePendulum(a, dynamicStepResult);

                //result[stepIndex] = new double[2]
                //{
                //    result[stepIndex - 1][0] + h * ((41/840d) * k[0][0] + (34/105d) * k[5][0] + (9/35d) * k[6][0] + (9/35d) * k[7][0] + (9/280d) * k[8][0] + (9/280d) * k[9][0] + (41/840d) * k[10][0]),
                //    result[stepIndex - 1][1] + h * ((41/840d) * k[0][1] + (34/105d) * k[5][1] + (9/35d) * k[6][1] + (9/35d) * k[7][1] + (9/280d) * k[8][1] + (9/280d) * k[9][1] + (41/840d) * k[10][1])
                //};

                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + h * ((34/105d) * k[5][0] + (9/35d) * k[6][0] + (9/35d) * k[7][0] + (9/280d) * k[8][0] + (9/280d) * k[9][0] + (41/840d) * k[11][0] + (41/840d) * k[12][0]),
                    result[stepIndex - 1][1] + h * ((34/105d) * k[5][1] + (9/35d) * k[6][1] + (9/35d) * k[7][1] + (9/280d) * k[8][1] + (9/280d) * k[9][1] + (41/840d) * k[11][1] + (41/840d) * k[12][1])
                };
            }
            return result;
        }

        public static double[][] ImplicitRK2Trapezoid(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var resultThisStep = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };

                for (int i = 0; i < 100; i++)
                {
                    var k1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);

                    var k2 = Functions.DerivativePendulum(a, resultThisStep);
                    var hf = new double[2]
                    {
                        (k1[0] + k2[0]) * 0.5d * h,
                        (k1[1] + k2[1]) * 0.5d * h
                    };

                    var residual = new double[2]
                    {
                        resultThisStep[0] - result[stepIndex - 1][0] - hf[0],
                        resultThisStep[1] - result[stepIndex - 1][1] - hf[1]
                    };

                    double[,] jac = Jacob(a, h * 0.5d, resultThisStep);

                    residual = new double[2]
                    {
                        jac[0,0] * residual[0] + jac[0,1] * residual[1],
                        jac[1,0] * residual[0] + jac[1,1] * residual[1]
                    };

                    var magnitudePow = residual[0] * residual[0] + residual[1] * residual[1];

                    resultThisStep[0] -= residual[0];
                    resultThisStep[1] -= residual[1];

                    if (magnitudePow <= 0.00000001f)
                    {
                        break;
                    }
                }

                result[stepIndex] = new double[2]
                {
                    resultThisStep[0],
                    resultThisStep[1]
                };
            }

            return result;
        }

        public static double[] ImplicitMidpointMethod(double[] y, double a, double h)
        {
            var resultThisStep = new double[2] { y[0], y[1] };

            for (int i = 0; i < 3; i++)
            {
                var fx = Functions.DerivativePendulum(a, resultThisStep);
                var midpoint = new double[2]
                {
                        y[0] + fx[0] * h * 0.5d,
                        y[1] + fx[1] * h * 0.5d
                };

                var f = Functions.DerivativePendulum(a, midpoint);
                var hf = new double[2]
                {
                        f[0] * h,
                        f[1] * h
                };

                var residual = new double[2]
                {
                        resultThisStep[0] - y[0] - hf[0],
                        resultThisStep[1] - y[1] - hf[1]
                };

                //double[,] jac = Jacob(m, h, new double[] { y[0], y[1] });
                double[,] jac = Jacob(a, h, resultThisStep);

                residual = new double[2]
                {
                        jac[0,0] * residual[0] + jac[0,1] * residual[1],
                        jac[1,0] * residual[0] + jac[1,1] * residual[1]
                };

                var magnitudePow = residual[0] * residual[0] + residual[1] * residual[1];

                resultThisStep[0] -= residual[0];
                resultThisStep[1] -= residual[1];

                if (magnitudePow <= 0.000001f)
                {
                    break;
                }
            }

            return new double[2]
            {
                    resultThisStep[0],
                    resultThisStep[1]
            };
        }

        public static double[][] ImplicitRK2Midpoint(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                result[stepIndex] = ImplicitMidpointMethod(result[stepIndex - 1], a, h);
            }

            return result;
        }

        public static double[][] ImplicitRK4(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                double[] k1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                double[] k2 = Functions.DerivativePendulum(a, result[stepIndex - 1]);

                for (int i = 0; i < 3; i++)
                {
                    k1 = F1(result[stepIndex - 1][0], result[stepIndex - 1][1], k1, k2, a, h);
                    k2 = F2(result[stepIndex - 1][0], result[stepIndex - 1][1], k1, k2, a, h);

                }
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + h * 0.5 * (k1[0] + k2[0]),
                    result[stepIndex - 1][1] + h * 0.5 * (k1[1] + k2[1])
                };
            }

            return result;
        }

        private static double[] F1(double y, double z, double[] k1, double[] k2, double a, double h)
        {
            var tempVal = new double[2]
            {
                y + 0.25 * h * k1[0] - 0.03867513459 * h * k2[0],
                z + 0.25 * h * k1[1] - 0.03867513459 * h * k2[1]
            };
            
            return Functions.DerivativePendulum(a, tempVal);
        }

        private static double[] F2(double y, double z, double[] k1, double[] k2, double a, double h)
        {
            var tempVal = new double[2]
            {
                y + 0.53867513459 * h * k1[0] + 0.25 * h * k2[0],
                z + 0.53867513459 * h * k1[1] + 0.25 * h * k2[1]
            };

            return Functions.DerivativePendulum(a, tempVal);
        }

        public static double[][] Euler(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var k1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + k1[0]*h,
                    result[stepIndex - 1][1] + k1[1]*h
                };
            }

            return result;
        }

        public static double[][] ImplicitEuler(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                result[stepIndex] = HelpEulerNewton(a, h, result[stepIndex - 1]);
            }

            return result;
        }

        private static double[] HelpEulerNewton(double a, double h, double[] lastStep)
        {
            var resultThisStep = new double[2] { lastStep[0], lastStep[1] };

            for (int i = 0; i < 3; i++)
            {
                var k1 = Functions.DerivativePendulum(a, resultThisStep);
                var euler = new double[2]
                {
                        k1[0] * h,
                        k1[1] * h
                };

                var residual = new double[2]
                {
                        resultThisStep[0] - lastStep[0] - euler[0],
                        resultThisStep[1] - lastStep[1] - euler[1]
                };

                double[,] jac = Jacob(a, h, resultThisStep);

                residual = new double[2]
                {
                        jac[0,0] * residual[0] + jac[0,1] * residual[1],
                        jac[1,0] * residual[0] + jac[1,1] * residual[1]
                };

                var magnitudePow = residual[0] * residual[0] + residual[1] * residual[1];

                resultThisStep[0] -= residual[0];
                resultThisStep[1] -= residual[1];

                if (magnitudePow <= 0.000001f)
                {
                    break;
                }
            }

            return new double[2]
            {
                    resultThisStep[0],
                    resultThisStep[1]
            };
        }

        private static double[,] Jacob(double a, double h, double[] resultThisStep)
        {
            var jac = Functions.JacPendulum(a, resultThisStep);
            jac[0, 0] *= h;
            jac[0, 1] *= h;
            jac[1, 0] *= h;
            jac[1, 1] *= h;

            jac[0, 0] = 1 - jac[0, 0];
            jac[0, 1] *= -1;
            jac[1, 0] *= -1;
            jac[1, 1] = 1 - jac[1, 1];

            var det = jac[0, 0] * jac[1, 1] - jac[1, 0] * jac[0, 1];
            det = 1 / det;
            jac = new double[2, 2]
            {
                    { det * jac[1,1], det * -jac[0,1] },
                    { det * -jac[1,0], det * jac[0,0] }
            };
            return jac;
        }

        public static double[][] ExtrapolatorMidpoint(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                // 2 levels
                int numLvls = 2;
                double[][][] levels = new double[numLvls][][];

                for (int i = 0; i < numLvls; i++)
                {
                    levels[i] = new double[i + 1][];
                    levels[i][0] = MidpointMethod(result[stepIndex - 1], a, h / (i + 1));
                    for (int j = 1; j <= i; j++)
                    {
                        levels[i][j] = MidpointMethod(levels[i][0], a, h / (i + 1));
                    }
                }

                result[stepIndex] = new double[2]
                {
                    (4 * levels[1][1][0] - levels[0][0][0]) / 3d,
                    (4 * levels[1][1][1] - levels[0][0][1]) / 3d
                };
            }

            return result;
        }

        public static double[][] ExtrapolatorIMidpoint(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                // 2 levels
                int numLvls = 2;
                double[][][] levels = new double[numLvls][][];

                for (int i = 0; i < numLvls; i++)
                {
                    levels[i] = new double[i + 1][];
                    levels[i][0] = ImplicitMidpointMethod(result[stepIndex - 1], a, h / (i + 1));
                    for (int j = 1; j <= i; j++)
                    {
                        levels[i][j] = ImplicitMidpointMethod(levels[i][0], a, h / (i + 1));
                    }
                }

                result[stepIndex] = new double[2]
                {
                    (4 * levels[1][1][0] - levels[0][0][0]) / 3d,
                    (4 * levels[1][1][1] - levels[0][0][1]) / 3d
                };
            }

            return result;
        }

        public static double[][] CompositionIMidpoint4(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double k = 1.25992104989d;
            double[] step = new double[] { h / (2 - k), -h * k / (2 - k), h / (2 - k) };
            
            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = RK2(X, a, step[i], 2)[1];
                    //X = ImplicitMidpointMethod(X, m, step[i]);
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] CompositionIMidpoint6(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double[] step = new double[] { 0.78451361047755726382 * h, 0.23557321335935813368 * h, -1.1776799841788710069 * h, 1.3151863206839112189 * h, -1.1776799841788710069 * h, 0.23557321335935813368 * h, 0.78451361047755726382 * h };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = RK2(X, a, step[i], 2)[1];
                    //X = ImplicitMidpointMethod(X, m, step[i]);
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] CompositionIMidpoint8(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double[] step = new double[] { 0.74167036435061295345 * h, -0.40910082580003159400 * h, 0.19075471029623837995 * h, -0.57386247111608226666 * h, 0.29906418130365592384 * h, 0.33462491824529818378 * h, 0.31529309239676659663 * h, -0.79688793935291635402 * h, 0.31529309239676659663 * h, 0.33462491824529818378 * h, 0.29906418130365592384 * h, -0.57386247111608226666 * h, 0.19075471029623837995 * h, -0.40910082580003159400 * h, 0.74167036435061295345 * h };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = RK8(X, a, step[i], 2)[1];
                    //X = ImplicitMidpointMethod(X, m, step[i]);
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] Composition4KD(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double k = 1.25992104989d;
            double[] step = new double[] { h / (2 - k), -h * k / (2 - k), h / (2 - k) };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = ImplicitMidpointMethod(X, a, step[i]);
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] Composition6KD(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double[] step = new double[] { 0.78451361047755726382 * h, 0.23557321335935813368 * h, -1.1776799841788710069 * h, 1.3151863206839112189 * h, -1.1776799841788710069 * h, 0.23557321335935813368 * h, 0.78451361047755726382 * h };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = ImplicitMidpointMethod(X, a, step[i]);
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] Composition8KD(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            double[] step = new double[] { 0.74167036435061295345 * h, -0.40910082580003159400 * h, 0.19075471029623837995 * h, -0.57386247111608226666 * h, 0.29906418130365592384 * h, 0.33462491824529818378 * h, 0.31529309239676659663 * h, -0.79688793935291635402 * h, 0.31529309239676659663 * h, 0.33462491824529818378 * h, 0.29906418130365592384 * h, -0.57386247111608226666 * h, 0.19075471029623837995 * h, -0.40910082580003159400 * h, 0.74167036435061295345 * h };

            for (int stepIndex = 1; stepIndex < sizeArrays; stepIndex++)
            {
                var X = new double[2] { result[stepIndex - 1][0], result[stepIndex - 1][1] };
                for (int i = 0; i < step.Length; i++)
                {
                    X = CompositionIMidpoint8(X, a, step[i], 2)[1];
                }

                result[stepIndex] = new double[2] { X[0], X[1] };
            }

            return result;
        }

        public static double[][] AdamsBashforth2(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int i = 1; i <= 2; i++)
            {
                result[i] = MidpointMethod(result[i - 1], a, h);
            }

            for (int stepIndex = 3; stepIndex < sizeArrays; stepIndex++)
            {
                var y1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                var y2 = Functions.DerivativePendulum(a, result[stepIndex - 2]);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + h * 0.5d * (3 * y1[0] - y2[0]),
                    result[stepIndex - 1][1] + h * 0.5d * (3 * y1[1] - y2[1])
                };
            }

            return result;
        }

        public static double[][] AdamsBashforth4(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int i = 1; i <= 4; i++)
            {
                result[i] = RK4OneStep(result[i - 1], a, h);
            }

            for (int stepIndex = 5; stepIndex < sizeArrays; stepIndex++)
            {
                var y1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                var y2 = Functions.DerivativePendulum(a, result[stepIndex - 2]);
                var y3 = Functions.DerivativePendulum(a, result[stepIndex - 3]);
                var y4 = Functions.DerivativePendulum(a, result[stepIndex - 4]);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 24d) * (55 * y1[0] - 59 * y2[0] + 37 * y3[0] - 9 * y4[0]),
                    result[stepIndex - 1][1] + (h / 24d) * (55 * y1[1] - 59 * y2[1] + 37 * y3[1] - 9 * y4[1])
                };
            }

            return result;
        }

        public static double[][] AdamsBashforth6(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int i = 1; i <= 6; i++)
            {
                result[i] = RK6OneStep(result[i - 1], a, h);
            }

            for (int stepIndex = 7; stepIndex < sizeArrays; stepIndex++)
            {
                var y1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                var y2 = Functions.DerivativePendulum(a, result[stepIndex - 2]);
                var y3 = Functions.DerivativePendulum(a, result[stepIndex - 3]);
                var y4 = Functions.DerivativePendulum(a, result[stepIndex - 4]);
                var y5 = Functions.DerivativePendulum(a, result[stepIndex - 5]);
                var y6 = Functions.DerivativePendulum(a, result[stepIndex - 6]);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 1440d) * (4277 * y1[0] - 7923 * y2[0] + 9982 * y3[0] - 7298 * y4[0] + 2877 * y5[0] - 475 * y6[0]),
                    result[stepIndex - 1][1] + (h / 1440d) * (4277 * y1[1] - 7923 * y2[1] + 9982 * y3[1] - 7298 * y4[1] + 2877 * y5[1] - 475 * y6[1])
                };
            }

            return result;
        }

        public static double[][] Toming2(double[] y, double a, double h, int sizeArrays)
        {
            double[][] result = new double[sizeArrays][];
            result[0] = new double[2] { y[0], y[1] };

            for (int i = 1; i <= 2; i++)
            {
                result[i] = RK6OneStep(result[i - 1], a, h);
            }
            double k1 = 1.142857142857d;
            double k2 = 0.142857d;
            for (int stepIndex = 7; stepIndex < sizeArrays; stepIndex++)
            {
                var y1 = Functions.DerivativePendulum(a, result[stepIndex - 1]);
                var y2 = Functions.DerivativePendulum(a, result[stepIndex - 2]);
                var y3 = Functions.DerivativePendulum(a, result[stepIndex - 3]);
                var y4 = Functions.DerivativePendulum(a, result[stepIndex - 4]);
                var y5 = Functions.DerivativePendulum(a, result[stepIndex - 5]);
                var y6 = Functions.DerivativePendulum(a, result[stepIndex - 6]);
                result[stepIndex] = new double[2]
                {
                    result[stepIndex - 1][0] + (h / 1440d) * (4277 * y1[0] - 7923 * y2[0] + 9982 * y3[0] - 7298 * y4[0] + 2877 * y5[0] - 475 * y6[0]),
                    result[stepIndex - 1][1] + (h / 1440d) * (4277 * y1[1] - 7923 * y2[1] + 9982 * y3[1] - 7298 * y4[1] + 2877 * y5[1] - 475 * y6[1])
                };
            }

            return result;
        }
    }
}