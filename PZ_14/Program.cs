using System;
using System.IO;
namespace PZ_14
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
                int mark = int.Parse(parts[2]); // Преобразование третьей части строки в целое число и запись в переменную mark
                if (mark < 3) 
                {
                    Console.WriteLine(name); 
                }
                sum += mark;
                count++; 
            }
            double average = (double)sum / count; // Вычисление среднего балла
            Console.WriteLine($"Средний балл по классу: {{0,5:F1}} ", average); 
        }
    }
}
