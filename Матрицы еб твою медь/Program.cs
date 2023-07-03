using System;
using ClassLibrary1;

namespace Матрицы_еб_твою_медь
{
    class Program
    {
        static void Main(string[] args)
        {
            bool aaa = false;
            double[,] matrix;
            do
            {
                string ok = Begin();
                if (ok == "1")
                {
                    Console.Clear();
                    double tr = Class.TR(MatrixEnter());
                    Console.WriteLine(tr);
                }
                else if (ok == "2")
                {
                    Console.Clear();
                    matrix = Class.Transporent(MatrixEnter());
                    Class.Out(matrix);
                }
                else if (ok == "3")
                {
                    Console.Clear();
                    double opr = Class.Oprfinding(MatrixEnter());
                    Console.WriteLine("Определитель матрицы: " + opr);
                }
                else if (ok == "4")
                {
                    Console.Clear();
                    matrix = Class.TabMin(MatrixEnter());
                    Class.Out(matrix);
                }
                else if (ok == "5")
                {
                    Console.Clear();
                    matrix = Class.TabMin(MatrixEnter());
                    matrix = Class.TAD(matrix);
                    Class.Out(matrix);
                }

                else if (ok == "6")
                {
                    Console.Clear();
                    matrix = Class.Umnozh(MatrixEnter(), MatrixEnter());
                    Class.Out(matrix);
                }

                else if (ok == "7")
                {
                    Console.Clear();
                    matrix = Class.TabMin(MatrixEnter());
                    matrix = Class.TAD(matrix);
                    matrix = Class.Oboroten(matrix, Class.Oprfinding(matrix));
                }

                else if (ok == "999")
                {
                    Console.Clear();
                    Console.WriteLine("Ну вот и все");
                    aaa = true;
                }
                Console.WriteLine();
            } while (aaa == false);
        }
        static double[,] MatrixEnter()
        {
            bool aaa;
            do
            {
                aaa = true;
                Console.WriteLine("Введите 1, если хотите сами ввести матрицу, 2 если хотите из файла, что проще");
                string hoh = Console.ReadLine();

                if (hoh=="1")
                    return Class.MatrixMadeWay1();

                else if(hoh=="2")
                    return Class.MatrixMadeWay2();

                else
                    aaa = false;

            } while (aaa == false);
            return null;
        }

        static string Begin()
        {
            Console.WriteLine("Введите номер действия");
            Console.WriteLine("1. Tr от матрицы");
            Console.WriteLine("2. Трансперантанециация (Транспонирование)");
            Console.WriteLine("3. Определитель");
            Console.WriteLine("4. Таблица миноров");
            Console.WriteLine("5. Таблица алгебраических дополнений");
            Console.WriteLine("6. Умножение матриц");
            Console.WriteLine("7. Обратная матрица");
            Console.WriteLine("8. Решение системы уравнений (СКОРО)");
            Console.WriteLine("999. Закончить код");
            return Console.ReadLine();
        }
    }
}
