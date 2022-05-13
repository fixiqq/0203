using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Составляется таблица из двух частей: в левой части записывается исходная матрица \n в правой части единичная, путем преобразований аналогичных преобразованиям задачи №1. \n В левой части получают единичную матрицу, а в правой автоматически получается обратная к данной \n\n Исходная матрица");
            Console.WriteLine("______________________________");
            double[,] A = new double[3, 3];
            //Ввод значений в массив
            //A[0, 0] = -3; A[0, 1] = 2; A[0, 2] = 4;
            //A[1, 0] = 2; A[1, 1] = 1; A[1, 2] = 0;
            //A[2, 0] = 1; A[2, 1] = 0; A[2, 2] = 1;
            for (int i = 0; i < A.GetLength(0); i++)
            {
                for (int j = 0; j < A.GetLength(1); j++)
                {
                    Console.Write("Введите элемент ({0};{1}) ", i + 1, j + 1);
                    A[i, j] = Convert.ToDouble(Console.ReadLine());
                }
            }

            double[,] AObrat = new double[3, 3];
            double[,] ACopy = new double[3, 3];

            //задаем обратную матрицу как единичную           
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j) { AObrat[i, j] = 1; }
                    else { AObrat[i, j] = 0; }
                    ACopy[i, j] = A[i, j];    //создаем копию матрицы A

                }
            }

            print(ACopy);
            Console.Read();


            //прямой ход
            for (int k = 0; k < 3; k++)
            {
                double div = ACopy[k, k];
                for (int j = 0; j < 3; j++)
                {
                    ACopy[k, j] /= div;
                    AObrat[k, j] /= div;
                }
                for (int i = k + 1; i < 3; i++)
                {
                    double multi = ACopy[i, k];
                    for (int j = 0; j < 3; j++)
                    {
                        ACopy[i, j] -= multi * ACopy[k, j];
                        AObrat[i, j] -= multi * AObrat[k, j];
                    }
                }

            }

            print(AObrat);
            Console.WriteLine("______________________________");
            Console.ReadLine();
            Console.WriteLine();
            //обратный ход            
            for (int kk = 3 - 1; kk > 0; kk--)
            {
                ACopy[kk, 3 - 1] /= ACopy[kk, kk];
                AObrat[kk, 3 - 1] /= ACopy[kk, kk];

                for (int i = kk - 1; i + 1 > 0; i--)
                {
                    double multi2 = ACopy[i, kk];
                    for (int j = 3 - 1; j > 0; j--)
                    {
                        ACopy[i, j] -= multi2 * ACopy[kk, j];
                        AObrat[i, j] -= multi2 * AObrat[kk, j];
                    }
                }
            }

            double[,] Ee = new double[3, 3];
            int flagA = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == j) { Ee[i, j] = 1; }
                    else { Ee[i, j] = 0; }
                    if (Ee[i, j] != ACopy[i, j]) { Console.WriteLine("i=" + i); Console.WriteLine("j=" + j); }
                    else { flagA = 1; }
                }
            }
            print(AObrat);
            Console.WriteLine("______________________________");
            if (flagA == 1) { Console.WriteLine(" Матрица стала единичной"); }
            Console.ReadLine();

            //проверка
            double[,] ProverkaA = new double[3, 3];
            for (int i = 0; i < 3; i++)//строки
            {
                for (int j = 0; j < 3; j++)//столбцы
                {
                    for (int k = 0; k < 3; k++)
                    {
                        ProverkaA[i, j] += AObrat[i, k] * A[k, j];
                    }
                }
            }
            Console.WriteLine(" Обратная матрица равна");
            print(AObrat);
            Console.ReadLine();
        }
        static void print(double[,] m)
        {
            Console.WriteLine();
            for (var i = 0; i < m.GetLength(0); ++i)
            {
                for (var j = 0; j < m.GetLength(1); ++j)
                {
                    Console.Write("{0:0.00}\t", m[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
