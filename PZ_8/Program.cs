using System;
using System.Runtime.InteropServices;

namespace PZ_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //*создать ступенчатый массив в соответствии со своим вариантом. Длину второго
            //измерения генерировать рандомно в соответствии с вариантом.Заполнить массив
            //нужными значениями(способ заполнения рандом или расчет по произвольной формуле).*//

            Console.WriteLine("Создание ступенчатого массива: ");
            Random rnd = new Random();
            char[][] array = new char[10][]; //создание массива с длиной первого измерения 10

            //заполнение массива случайными символами
            for (int i = 0; i < array.Length; i++)
            {
                int length = rnd.Next(3, 51); //генерация случайной длины второго измерения
                array[i] = new char[length];
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = (char)rnd.Next(1, 1000);
                }
            }

            // Вывод элементов массива
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            //*Создать новый одномерный массив нужной и записать в него последние элементы
            //каждой строки. Вывести данный массив*//

            char[] lastElem = new char[array.Length];

            for (int i = 0; i < array.Length; i++)
            {
                lastElem[i] = array[i][array[i].Length - 1]; 
            }

            Console.WriteLine("\nМассив с последними элементами:");
            Console.WriteLine(string.Join(" ", lastElem));

            //*В каждой строке ступенчатого найти максимальный элемент, записать их в другой
            //массив(новый или повторно использовать предыдущий) и вывести его содержимое*//

            Console.WriteLine("Максимальный элемент строки:");
            char[] chars = new char[array.Length];

            for (int i = 0; i < chars.Length; i++)
            {
                chars[i] = array[i].Max();
                Console.WriteLine(chars[i] + "");
            }

            //*В каждой строке исходного массива поменять местами первый элемент и максимальный в строке.Вывести*//
            Console.WriteLine("Обнавленный массив:");
            for (int i = 0; i < array.Length; i++)
            {
                char b = array[i][0];
                char c = array[i].Max();
                int a = Array.IndexOf(array[i], c);
                array[i][0] = c;
                array[i][a] = b;
            }

            //вывод массива после обмена элементами
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array[i].Length; j++)
                {
                    Console.Write(array[i][j] + " ");
                }
                Console.WriteLine();
            }

            // Реверс каждой строки ступенчатого массива
            for (int i = 0; i < array.Length; i++)
            {
                Array.Reverse(array[i]);
            }

            Console.WriteLine("\nМассив с реверсированными строками:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(string.Join(" ", array[i]));
            }

            // Подсчитать: Наиболее встречающиеся символы в каждой строке ступенчатого массива (для символов)//
            Dictionary<char, int> charCount = new Dictionary<char, int>(); // Создаем словарь для подсчета количества встречающихся символов

            for (int i = 0; i < array.Length; i++)
            {
                char[] row = array[i];
                for (int j = 0; j < row.Length; j++)
                {
                    char v = row[j];
                    if (charCount.ContainsKey(v)) charCount[v]++;
                    else charCount.Add(v, 1);
                }
            }

            char mostFrequentChar = ' '; 
            int maxCount = 0; 
            
            foreach (KeyValuePair<char, int> pair in charCount)
            {
                if (pair.Value > maxCount)
                {
                    mostFrequentChar = pair.Key;
                    maxCount = pair.Value;
                }
            }
            Console.WriteLine("Наиболее часто встречающийся символ: " + mostFrequentChar);
            
        }


    }

}

    
