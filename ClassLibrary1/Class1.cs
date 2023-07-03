using System;
using System.IO;
using System.Reflection;

namespace ClassLibrary1
{
    public class Class
    {
        public static double TR(double[,] Matrix)
        {
            if (Matrix.GetLength(0) == Matrix.GetLength(1))
            {
                double lul = 0;
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                    {
                        if (i == j)
                            lul += Matrix[i, j];
                    }
                }
                Console.WriteLine("Tr = " + lul);
                return lul;
            }
            else
            {
                Console.WriteLine("Лох");
                return 0;
            }
        }
        public static double[,] Transporent(double[,] Mat)
        {
            double[,] rix = new double[Mat.GetLength(1), Mat.GetLength(0)];
                for (int j = 0; j < Mat.GetLength(1); j++)
                {
                    for (int i = 0; i < Mat.GetLength(0); i++)
                    {
                        rix[j, i] = Mat[i, j];
                    }
                }

            return rix;
        }
        public static double Opr2(double[,] matrix)
        {
            double m = matrix[0, 0] * matrix[1, 1] - matrix[1, 0] * matrix[0, 1];
            return m;
        }

        public static double Oprfinding(double[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                if (matrix.GetLength(0) == 2)
                    return Opr2(matrix);
                else
                {
                    double t = 0;
                    for (int i = 0; i < matrix.GetLength(0); i++)
                        t += matrix[i, 0] * Oprfinding(MatrixMinus(matrix, i, 0)) * Math.Pow(-1, i);
                    return t;
                }
            }
            else
            {
                Console.WriteLine("Лох, держи ничего");
                return 0;
            }
        }

        public static double[,] MatrixMinus(double[,] matrix, int m, int n)
        {
            double[,] mas = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
            int y = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                int x = 0;
                if (j != n)
                {
                    for (int i = 0; i < matrix.GetLength(0); i++)
                    {
                        if (i != m)
                        {
                            mas[x, y] = matrix[i, j];
                            x++;
                        }
                    }
                    y++;
                }
            }
            return mas;
        }

        public static double[,] TabMin(double[,] matrix)
        {
            if (matrix.GetLength(0) == matrix.GetLength(1))
            {
                double[,] lol = new double[matrix.GetLength(0), matrix.GetLength(1)];
                for (int i = 0; i < matrix.GetLength(1); i++)
                {
                    for (int j = 0; j < matrix.GetLength(0); j++)
                    
                        lol[j, i] = Oprfinding(MatrixMinus(matrix, j, i));
                    
                }
                return lol;
            }
            else
            {
                Console.WriteLine("Неа");
                return null;
            }
        }
        public static double[,] TAD(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    matrix[j, i] = matrix[j, i] * Math.Pow(-1, (2 + i + j));
                }
            }
            return matrix;
        }

        public static double[,] Oboroten(double[,] matrix, double opred)
        {
            Console.WriteLine();
            double[,] dividedmatrix = new double[matrix.GetLength(0), matrix.GetLength(1)];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    Console.Write(matrix[i, j] + "/" + opred+" ");
                    dividedmatrix[i, j] = matrix[i,j] / opred;
                }
                Console.WriteLine();
            }
            return dividedmatrix;
        }

        public static double[,] Umnozh(double[,] matr1, double[,] matr2)
        {
            if (matr2.GetLength(1) != matr1.GetLength(0))
            {
                Console.WriteLine("Лох!");
                return null;
            }

            else
            {
                Console.WriteLine(" ");
                int stolb = matr2.GetLength(0);
                int stroka = matr1.GetLength(1);
                double[,] otvet = new double[stolb, stroka];
                for (int ii = 0; ii < stroka; ii++)
                {
                    for (int j = 0; j < stolb; j++)
                    {
                        for (int i = 0; i < matr1.GetLength(0); i++)
                        {
                            otvet[j, ii] += matr1[i, ii] * matr2[j, i];
                            Console.WriteLine(otvet[j, ii]);
                        }
                    }
                }
                Console.WriteLine(" ");
                Out(otvet);
                return otvet;
            }
        }

        public static double[,] MatrixMadeWay1()
        {
            Console.WriteLine("Введите сначала количество строк, а потом столбцов");
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            double[,] matrix = new double[m, n];
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Строка " + (i + 1));
                for (int j = 0; j < m; j++)
                    matrix[j, i] = int.Parse(Console.ReadLine());
            }
            return matrix;
        }

        public static double[,] MatrixMadeWay2()
        {
            Console.WriteLine("Введите название текстового файла");
            string pathtofile = Assembly.GetExecutingAssembly().Location.ToString();
            string h = pathtofile.Remove(24, pathtofile.Length-24) + @"Desktop\" + Console.ReadLine() + ".txt";
            string[] mat = File.ReadAllLines(h);
            double[,] matrix = new double[(mat[0].Split(' ')).Length, mat.Length];
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    string[] prost = mat[i].Split(' ');
                    matrix[j, i] = int.Parse(prost[j]);
                }
            }
            Out(matrix);
            Console.WriteLine();
            return matrix;
        }

        public static void Out(double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                Console.WriteLine();
                for (int j = 0; j < matrix.GetLength(0); j++)
                    Console.Write(matrix[j, i] + " ");
            }
        }
    }
}

