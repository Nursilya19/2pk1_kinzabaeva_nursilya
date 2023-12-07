using System;
using System.IO;
namespace PZ_14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("file_pz_14.txt"); // Открывает файл и записывает в массив lines
            int sum = 0;
            int count = 0;
            Console.WriteLine("Оценки меньше 3 баллов у:");
            foreach (string line in lines)
            {
                string[] parts = line.Split(' '); // Разделение строки на части по пробелу
                string name = parts[0] + " " + parts[1]; // Составление имени из частей строки
                int mark = 0;
                if (int.TryParse(parts[2], out mark)) // Проверка и преобразование третьей части строки в целое число и запись в переменную mark
                {
                    if (mark < 3)
                    {
                        Console.WriteLine(name);
                    }
                    sum += mark;
                    count++;
                }
            }
            if (count > 0)
            {
                double average = (double)sum / count; // Вычисление среднего балла
                Console.WriteLine($"Средний балл по классу: {average:F1}"); // Вывод среднего балла с точностью до 1 десятичного знака
            }
            else
            {
                Console.WriteLine("Файл не содержит оценок.");
            }
        }
    }
}