using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DataStructures
{
    public class Matrix
    {
        public double RMSE(double[,] m1, double[,] m2)
        {
            var se = 0.0;
            foreach(var val in m1)
            {
                se += Math.Pow(val, 2);
            }

            return Math.Sqrt(se) / m2.Length;
        }

        public double[,] Subtract(double[,] m1, double[,] m2)
        {
            if (m1.Length != m2.Length)
                return null;

            var m3 = new double[m1.GetLength(0), m1.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                m3[i, 0] = m1[i, 0] - m2[i, 0];
            }
            return m3;
        }

        public MatrixSet LeastSquares(double[,] m1, double[,] m2)
        {
            for (int j = 0; j < m1.GetLength(0)-1; j++)
            {
                for (int i = m1.GetLength(0) - 1; i > j; i--)
                {
                    if (m1[i, j] != 0)
                    {
                        var mSet = MultiplyRow(m1, m2, i, j, m1[0, j] / m1[i, j]);
                        m1 = mSet.A;
                        m2 = mSet.B;
                    }
                }
            }

            var m3 = GetXValues(m1, m2);
            return new MatrixSet(m1, m2, m3);
        }

        public double[,] GetXValues(double[,] m1, double[,] m2)
        {
            var max = m1.GetLength(0)-1;
            var m3 = new double[m2.GetLength(0), m2.GetLength(1)];
            for (int i = max; i >= 0; i--)
            {
                var value = 0.0;
                for (int j = max; j > i; j--)
                {
                    if (i < max)
                    {
                        value += m1[i, j] * m3[i + 1, 0];
                    }
                }
                m3[i, 0] = (m2[i, 0] - value) / m1[i, i];
            }
            return m3;
        }

        public MatrixSet MultiplyRow(double[,] m1, double[,] m2, int i, int j, double multiplier)
        {
            for (int h = j; h < m1.GetLength(1); h++)
            {
                m1[i, h] = m1[0, h] - multiplier * m1[i, h];
            }

            m2[i, 0] = m2[0, 0] - multiplier * m2[i, 0];

            return new MatrixSet(m1, m2);
        }

        public double[,] Transpose(double[,] m1, double[,] m2)
        {
            var m3 = new double[m1.GetLength(0), m2.GetLength(1)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    m3[i, j] = Multiply(m1, m2, i, j);
                }
            }
            return m3;
        }

        private double Multiply(double[,] m1, double[,] m2, int row, int col)
        {
            var value = 0.0;
            for (int i = 0; i < m1.GetLength(1); i++)
            {
                value += m1[row,i] * m2[i,col];
            }
            return value;
        }

        public double[,] Invert(double[,] matrix)
        {
            var invertMatrix = new double[matrix.GetLength(1), matrix.GetLength(0)];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    invertMatrix[j, i] = matrix[i, j];
                }
            }
            return invertMatrix;
        }

        public void Print(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write($"{string.Format("{0,8}", Math.Round(matrix[i, j], 2))}");
                }
                Console.WriteLine();
            }
        }

    }

    public class MatrixSet
    {
        public MatrixSet(double[,] a = null, double[,] b = null, double[,] c = null)
        {
            A = a;
            B = b;
            C = c;
        }

        public double[,] A { get; set; }
        public double[,] B { get; set; }
        public double[,] C { get; set; }
    }
}
