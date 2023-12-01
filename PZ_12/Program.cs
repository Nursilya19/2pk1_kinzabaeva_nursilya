using System;

namespace PZ_12
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n, m; //объявляем переменные
            Console.Write("Введите размер массива: \n");
            n = int.Parse(Console.ReadLine()); //вводим их значение
            m = int.Parse(Console.ReadLine());
            Console.Write("Исходный массив\n");
            int[,] array1 = ArrayGeneration(n,m); //выводим исходный массив
            Console.Write("Транспорированный массив\n");
            int[,] array2 = TransponingArray(array1); //выводим транспорированный массив
        }
        private static int[,] ArrayGeneration(int n, int m) //создаем новый метод для создания массива
        {
            int[,] array = new int[n, m]; //создаем массив
            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    array[i, j] = random.Next(1, 100); //заполняем массив рандомными числами от 1 до 100
                    Console.Write(array[i, j] + "\t"); //выводим значение на консоли
                }
                Console.WriteLine();
            }

            return array; //возвращаем значение
        }

        public static int[,] TransponingArray(int[,] array1) //создаем метод для транспорированного массива
        {
            int n = array1.GetLength(0); //возвращаем значение из первого массива
            int m = array1.GetLength(1);

            int[,] array2 = new int[m, n]; //создаем 2 массив
            for (int j = 0; j < m; j++)
            {
                for (int i = 0; i < n; i++)
                {
                    array2[j, i] = array1[i, j]; //меняем местами строки и столбцы
                    Console.Write(array2[j, i] + "\t"); //выводим массив на консоли
                }
                Console.WriteLine();
            }

            return array2; //возвращаем значение
        }

    }
}